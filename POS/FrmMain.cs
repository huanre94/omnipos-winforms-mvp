using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

/***
 *  Changelog:
 *  IG001 Israel Gonzalez    2020/12/12: 
 *      Adding "OR" for case when barcode is not weight 
 *  IG002 Israel Gonzalez    2020/12/20: 
 *      Update field BarcodeBefore in xml with the last generated 
 *  IG003 Israel Gonzalez    2021/01/12: 
 *      Avoid product with price zero
 *  IG004 Israel Gonzalez    2021/01/13: 
 *      Remove Payment node from xml when error is true
 *  HR001 Hugo Restrepo      2021/01/13: 
 *      Substract discount from base amount for retention
 *  IG005 Israel Gonzalez    2021/01/30: 
 *      Fix sum of weight with taxes
 *  HR002 Hugo Restrepo      2021/03/02: 
 *      Recalculate discount with payment mode
 ***/

namespace POS
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        EmissionPoint emissionPoint;
        Customer currentCustomer = new Customer();
        XElement invoiceXml = new XElement("Invoice");
        ClsCatchWeight catchWeight;
        ScaleBrands scaleBrand;
        long sequenceNumber;
        public IEnumerable<GlobalParameter> GlobalParameters { get; set; }
        public SP_Login_Consult_Result LoginInformation { get; set; }
        public long internalCreditCardId = 0;
        public string internalCreditCardCode = "";
        private string portName = "";
        private int salesOriginId;
        private int salesManId;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Global Load Definitions
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!GetEmissionPointInformation())
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            ClearInvoice();
            CheckGridView();
            InitializeScaleAndScanner();
            CheckForSuspendedSale();
        }

        private void InitializeScaleAndScanner()
        {
            if (emissionPoint.ScaleBrand == string.Empty)
            {
                functions.ShowMessage("No se proporcionó configuracion de balanza.", MessageType.WARNING);
                return;
            }

            scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

            switch (scaleBrand)
            {
                case ScaleBrands.DATALOGIC:
                case ScaleBrands.ZEBRA:
                    catchWeight = new ClsCatchWeight(scaleBrand)
                    {
                        AxOPOSScale = AxOPOSScale
                    };
                    catchWeight.EnableScale(emissionPoint.ScaleName);
                    functions.AxOPOSScanner = AxOPOSScanner;
                    functions.EnableScanner(emissionPoint.ScanBarcodeName);
                    break;
                default:
                    string[] portNames = SerialPort.GetPortNames();
                    portName = string.Empty;

                    foreach (string item in portNames)
                    {
                        portName = item;
                        break;
                    }
                    break;
            }
        }

        void CheckForSuspendedSale()
        {
            if (new InvoiceRepository(Program.customConnectionString).HasSuspendedSale(emissionPoint))
            {
                BtnSuspendSale.Text = "F4 Reanudar";
                BtnSuspendSale.ImageOptions.SvgImage = Properties.Resources.resume;
            }
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = LoginInformation.AddressIP;

            if (addressIP == string.Empty)
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return false;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }

            if (emissionPoint == null)
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                return false;
            }

            LblEstablishment.Text = emissionPoint.Establishment;
            LblEmissionPoint.Text = emissionPoint.Emission;
            functions.PrinterName = emissionPoint.PrinterName;
            LblCashier.Text = LoginInformation.UserName;

            GetNewSequenceNumber(emissionPoint.EmissionPointId, emissionPoint.LocationId);

            return true;
        }

        private void CheckGridView()
        {
            GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesDetail.DataSource = null;
            GrvSalesDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_Product_Consult_Result> bindingList = new BindingList<SP_Product_Consult_Result>
            {
                AllowNew = true
            };

            GrcSalesDetail.DataSource = bindingList;
        }
        #endregion

        #region Keypad Buttons

        private void Btn0_Click(object sender, EventArgs e) => TxtBarcode.Text += "0";


        private void Btn1_Click(object sender, EventArgs e) => TxtBarcode.Text += "1";

        private void Btn2_Click(object sender, EventArgs e) => TxtBarcode.Text += "2";

        private void Btn3_Click(object sender, EventArgs e) => TxtBarcode.Text += "3";

        private void Btn4_Click(object sender, EventArgs e) => TxtBarcode.Text += "4";

        private void Btn5_Click(object sender, EventArgs e) => TxtBarcode.Text += "5";

        private void Btn6_Click(object sender, EventArgs e) => TxtBarcode.Text += "6";

        private void Btn7_Click(object sender, EventArgs e) => TxtBarcode.Text += "7";

        private void Btn8_Click(object sender, EventArgs e) => TxtBarcode.Text += "8";

        private void Btn9_Click(object sender, EventArgs e) => TxtBarcode.Text += "9";

        private void BtnDelete_Click(object sender, EventArgs e) => ClearBarcode();

        private void ClearBarcode()
        {
            TxtBarcode.Text = string.Empty;
            TxtBarcode.Focus();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            GetProductInformation(emissionPoint.LocationId,
                                  TxtBarcode.Text,
                                  1,
                                  currentCustomer.CustomerId,
                                  internalCreditCardId,
                                  "",
                                  false);
        }
        #endregion

        #region Bottom Side Buttons

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_IDENTIFICATION
            };
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification == string.Empty)
            {
                return;
            }

            string identification = keyBoard.customerIdentification;

            try
            {
                currentCustomer = new CustomerRepository(Program.customConnectionString).GetCustomerByIdentification(identification);

                if (currentCustomer == null)
                {
                    if (functions.ShowMessage("El cliente ingresado no está registrado. ¿Desea ingresarlo?.", MessageType.CONFIRM))
                    {
                        currentCustomer = CreateCustomer(identification);

                        if (currentCustomer == null)
                        {
                            functions.ShowMessage("No se pudo cargar datos de cliente.", MessageType.WARNING);
                            currentCustomer = LoadFinalConsumptionCustomer();
                            return;
                        }
                    }
                }

                if (currentCustomer?.CustomerId > 0)
                {
                    if (currentCustomer.IsEmployee)
                    {
                        if (functions.ShowMessage("El cliente es un empleado, ¿Desea utilizar la tarjeta de afiliado?", MessageType.CONFIRM))
                        {
                            //FrmPaymentCredit paymentCredit = new FrmPaymentCredit(customer: currentCustomer,
                            //    emissionPoint: emissionPoint,
                            //    scanner: AxOPOSScanner,
                            //    isPresentingCreditCard: true,
                            //    SalesOriginId: salesOriginId);

                            FrmPaymentCredit paymentCredit = new FrmPaymentCredit()
                            {
                                Customer = currentCustomer,
                                EmissionPoint = emissionPoint,
                                scanner = AxOPOSScanner,
                                IsPresentingCreditCard = true,
                                SalesOriginId = salesOriginId
                            };


                            paymentCredit.ShowDialog();

                            if (paymentCredit.formActionResult)
                            {
                                internalCreditCardId = paymentCredit.internalCreditCardId;
                                internalCreditCardCode = paymentCredit.InternalCreditCardCode;
                            }
                        }
                    }
                }
                LoadCustomerInformation(currentCustomer);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información del cliente.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private void LoadCustomerInformation(Customer customer)
        {
            LblCustomerId.Text = customer.Identification;
            LblCustomerName.Text = $"{customer.FullName}";
            LblCustomerAddress.Text = customer.Address;
            LblCustomerEmail.Text = customer.Email;
            TxtBarcode.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (!IsProductGridEmpty())
            {
                functions.ShowMessage("No puede salir mientras existe una venta en proceso. Por favor anule la venta.", MessageType.ERROR);
                TxtBarcode.Focus();
                return;
            }

            FrmMenu frmMenu = new FrmMenu()
            {
                loginInformation = LoginInformation
            };
            frmMenu.Show();
            Close();
        }

        private void BtnQty_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvSalesDetail.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No ha seleccionado ningun producto.", MessageType.WARNING);
                return;
            }

            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.PRODUCT_QUANTITY);
            keyPad.ShowDialog();

            if (keyPad.GetValue() == "")
            {
                functions.ShowMessage("La cantidad a agregar no puede esta vacia.", MessageType.WARNING);
                return;
            }

            int newAmount = int.Parse(keyPad.GetValue());

            //decimal quantity = (decimal)GrvSalesDetail.GetRowCellValue(rowIndex, "Quantity");
            SP_Product_Consult_Result row = (SP_Product_Consult_Result)GrvSalesDetail.GetRow(rowIndex);

            if (newAmount <= row.Quantity)
            {
                functions.ShowMessage("El valor ingresado no puede ser igual o menor al actual.", MessageType.WARNING);
                return;
            }

            IEnumerable<XElement> searchXml = from xm in invoiceXml.Descendants("InvoiceLine")
                                              where long.Parse(xm.Element("ProductId").Value) == row.ProductId
                                              select xm;

            string barcode = "";
            foreach (XElement item in searchXml.Elements())
            {
                if (item.Name == "Barcode")
                    barcode = item.Value;
            }

            long newValue = (long)(newAmount - row.Quantity);

            GetProductInformation(emissionPoint.LocationId,
                                  barcode,
                                  newValue,
                                  currentCustomer.CustomerId,
                                  internalCreditCardId,
                                  "",
                                  false);

            TxtBarcode.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvSalesDetail.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a anular.", MessageType.ERROR);
                return;
            }

            functions.emissionPoint = emissionPoint;

            if (functions.RequestSupervisorAuth())
            {
                SP_Product_Consult_Result selectedRow = (SP_Product_Consult_Result)GrvSalesDetail.GetRow(rowIndex);

                BindingList<SP_Product_Consult_Result> dataSource = (BindingList<SP_Product_Consult_Result>)GrvSalesDetail.DataSource;
                foreach (SP_Product_Consult_Result item in dataSource)
                {
                    if (item.ProductId == selectedRow.ProductId)
                    {
                        dataSource.Remove(item);
                        break;
                    }
                }

                IEnumerable<XElement> itemDeletedXml =
                        invoiceXml
                        .Descendants("InvoiceLine")
                        .Where(xm => long.Parse(xm.Element("ProductId").Value) == selectedRow.ProductId);

                XElement element = null;
                if (itemDeletedXml.Count() == 1)
                {
                    element = itemDeletedXml.First();
                }

                SalesLog salesLog = new SalesLog
                {
                    CustomerId = currentCustomer.CustomerId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    LocationId = emissionPoint.LocationId,
                    InvoiceNumber = sequenceNumber,
                    XmlLog = element.ToString(),
                    LogTypeId = (int)DLL.Enums.LogType.ELIMINAR_PRODUCTO,
                    Authorization = functions.SupervisorAuthorization,
                    CreatedDatetime = DateTime.Now,
                    CreatedBy = (int)LoginInformation.UserId,
                    Status = "A",
                    Workstation = LoginInformation.Workstation
                };

                new InvoiceRepository(Program.customConnectionString).InsertCancelledSales(salesLog);

                itemDeletedXml.Remove();

                CalculateInvoice();
                GrcSalesDetail.DataSource = dataSource;
            }

            ClearBarcode();
        }

        private void BtnPrintLastInvoice_Click(object sender, EventArgs e)
        {
            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth())
            {
                try
                {
                    long lastId = new InvoiceRepository(Program.customConnectionString).GetLastInvoice(emissionPoint);

                    if (lastId == 0)
                    {
                        functions.ShowMessage("No hay documento previo existente.", MessageType.WARNING);
                        return;
                    }

                    functions.PrintDocument(lastId, DocumentType.INVOICE, false);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al imprimir la última factura.",
                                          MessageType.ERROR,
                                          true,
                                          ex.Message);
                }
            }
            ClearBarcode();
        }

        private void BtnSalesOrigin_Click(object sender, EventArgs e)
        {
            FrmSalesOrigin frmSalesOrigin = new FrmSalesOrigin();
            frmSalesOrigin.ShowDialog();

            if (frmSalesOrigin.result != null)
            {
                salesOriginId = frmSalesOrigin.result.SalesOriginId;
                salesManId = frmSalesOrigin.result.SalesmanId;

                ImgSalesOrigin.Visible = (salesOriginId == 1);
                ImgSalesOrigin.SvgImage = (DevExpress.Utils.Svg.SvgImage)Properties.Resources.ResourceManager.GetObject(frmSalesOrigin.result.Name);
            }
        }
        #endregion

        #region Right Side Buttons

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) <= 0)
            {
                functions.ShowMessage("El valor a pagar debe ser mayor a 0", MessageType.WARNING);
                ClearBarcode();
                return;
            }

            decimal baseAmount = 0; //base 0
            decimal baseTaxAmount = 0; //base 12%
            decimal taxAmount = 0; //valor 12%
            decimal irbpAmount = 0; //irbp
            decimal discountAmount = 0; //discount

            IEnumerable<XElement> line = invoiceXml.Descendants("InvoiceLine");

            foreach (XElement item in line)
            {
                baseTaxAmount += decimal.Parse(item.Element("BaseTaxAmount").Value);
                taxAmount += decimal.Parse(item.Element("TaxAmount").Value);
                baseAmount += decimal.Parse(item.Element("BaseAmount").Value);
                irbpAmount += decimal.Parse(item.Element("IrbpAmount").Value);
                discountAmount += decimal.Parse(item.Element("LineDiscount").Value);
            }

            FrmPayment payment = new FrmPayment()
            {
                invoiceAmount = decimal.Parse(LblTotal.Text),
                customer = currentCustomer,
                emissionPoint = emissionPoint,
                taxAmount = taxAmount,
                baseAmount = baseAmount,
                baseTaxAmount = baseTaxAmount,
                irbpAmount = irbpAmount,
                discountAmount = discountAmount,
                loginInformation = LoginInformation,
                scanner = AxOPOSScanner,
                internalCreditCardCode = internalCreditCardCode,
                invoiceXml = invoiceXml,
                salesOriginId = salesOriginId
            };
            payment.ShowDialog();

            if (payment.canCloseInvoice)
            {
                if (payment.isInvoicePaymentDiscount)
                {
                    invoiceXml = payment.invoiceXml;
                }

                if (payment.paymentXml.HasElements)
                {
                    invoiceXml.Add(payment.paymentXml);
                    ClosingInvoice();
                }
            }

            ClearBarcode();
        }

        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            FrmProductSearch productSearch = new FrmProductSearch(emissionPoint);
            productSearch.ShowDialog();

            if (productSearch.GetProduct().Barcode == string.Empty)
            {
                return;
            }

            decimal quantity = productSearch.GetProduct().UseCatchWeight ? functions.CatchWeightProduct(AxOPOSScale,
                                                                                           productSearch.GetProduct(),
                                                                                           scaleBrand,
                                                                                           portName) : 1;

            if (quantity <= 0)
            {
                functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", MessageType.WARNING);
                return;
            }

            GetProductInformation(emissionPoint.LocationId,
                                  productSearch.GetProduct().Barcode,
                                  quantity,
                                  currentCustomer.CustomerId,
                                  internalCreditCardId,
                                  "",
                                  true);

            ClearBarcode();
        }

        //TODO
        private bool IsProductGridEmpty()
        {
            return ((BindingList<SP_Product_Consult_Result>)GrvSalesDetail.DataSource).Count == 0;
        }

        private void BtnSuspendSale_Click(object sender, EventArgs e)
        {
            functions.emissionPoint = emissionPoint;
            bool isApproved = functions.RequestSupervisorAuth();
            if (isApproved)
            {
                if (new InvoiceRepository(Program.customConnectionString).HasSuspendedSale(emissionPoint))
                {
                    if (!IsProductGridEmpty())
                    {
                        functions.ShowMessage("No puede reanudar una venta mientras exista otra en proceso", MessageType.WARNING);
                        return;
                    }

                    BtnSuspendSale.Text = "F4 Suspender";
                    BtnSuspendSale.ImageOptions.SvgImage = Properties.Resources.SuspendSale;

                    SP_SalesLog_Consult_Result sales = new InvoiceRepository(Program.customConnectionString).ConsultSuspendedSale(emissionPoint);

                    XElement element = XElement.Parse(sales.XmlLog);

                    IEnumerable<XElement> listProducts = element.Descendants("InvoiceLine");

                    foreach (XElement item in listProducts)
                    {
                        decimal qtyFound = 0;
                        string barcode = "";

                        foreach (XElement node in item.Elements())
                        {
                            switch (node.Name.ToString())
                            {
                                case "Barcode":
                                    barcode = node.Value;
                                    break;
                                case "BarcodeBefore":
                                    if (node.Value != "")
                                    {
                                        barcode = node.Value;
                                    }
                                    break;
                                case "Quantity":
                                    qtyFound = decimal.Parse(node.Value);
                                    break;
                            }
                        }

                        GetProductInformation(emissionPoint.LocationId,
                                              barcode,
                                              qtyFound,
                                              currentCustomer.CustomerId,
                                              internalCreditCardId,
                                              "",
                                              true);
                    }

                    currentCustomer = new CustomerRepository(Program.customConnectionString).GetCustomerById(sales.CustomerId);

                    if (currentCustomer?.CustomerId > 0)
                    {
                        LoadCustomerInformation(currentCustomer);
                    }

                    CalculateInvoice();
                    return;
                }

                if (decimal.Parse(LblTotal.Text) <= 0)
                {
                    functions.ShowMessage("El valor a pagar debe ser mayor a 0", MessageType.WARNING);
                    return;
                }

                BtnSuspendSale.Text = "F4 Reanudar";
                BtnSuspendSale.ImageOptions.SvgImage = POS.Properties.Resources.resume;

                SalesLog salesLog = new SalesLog
                {
                    CustomerId = currentCustomer.CustomerId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    LocationId = emissionPoint.LocationId,
                    InvoiceNumber = sequenceNumber,
                    XmlLog = invoiceXml.ToString(),
                    ReasonId = functions.MotiveId,
                    LogTypeId = (int)DLL.Enums.LogType.SUSPENDER_DOCUMENTO,
                    Authorization = "",
                    CreatedDatetime = DateTime.Now,
                    CreatedBy = (int)LoginInformation.UserId,
                    Status = "A",
                    Workstation = LoginInformation.Workstation
                };

                if (!new InvoiceRepository(Program.customConnectionString).InsertCancelledSales(salesLog))
                {
                    functions.ShowMessage("Hubo un error al poner la venta en espera, por favor vuelva a intentar", MessageType.ERROR);
                    return;
                }

                ClearInvoice();
            }

            TxtBarcode.Focus();
        }

        private void BtnCancelSale_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) <= 0)
            {
                functions.ShowMessage("No se puede anular una transaccion sin detalles.", MessageType.WARNING);
                return;
            }

            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth(true, CancelReasonType.INVOICE_CANCEL))
            {
                SalesLog salesLog = new SalesLog
                {
                    CustomerId = currentCustomer.CustomerId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    LocationId = emissionPoint.LocationId,
                    InvoiceNumber = sequenceNumber,
                    XmlLog = invoiceXml.ToString(),
                    ReasonId = functions.MotiveId,
                    LogTypeId = (int)DLL.Enums.LogType.ANULAR_DOCUMENTO,
                    Authorization = functions.SupervisorAuthorization,
                    CreatedDatetime = DateTime.Now,
                    CreatedBy = (int)LoginInformation.UserId,
                    Status = "A",
                    Workstation = LoginInformation.Workstation
                };

                if (!new InvoiceRepository(Program.customConnectionString).InsertCancelledSales(salesLog))
                {
                    functions.ShowMessage("Hubo un error al anular la transaccion, por favor vuelva a intentar", MessageType.ERROR);
                    return;
                }

                ClearInvoice();
            }
        }

        private void BtnAdvance_Click(object sender, EventArgs e)
        {
            //FrmAdvance advance = new FrmAdvance( )
            //{
            //    _currentCustomer = currentCustomer,
            //    emissionPoint = emissionPoint,
            //    loginInformation = loginInformation
            //};
            //advance.ShowDialog();
        }

        private void BtnReturns_Click(object sender, EventArgs e)
        {
            FrmReturns returns = new FrmReturns();
            returns.ShowDialog();
        }

        private void BtnProductChecker_Click(object sender, EventArgs e)
        {
            FrmProductChecker checker = new FrmProductChecker(new ProductRepository(Program.customConnectionString));
            checker.ShowDialog();
        }
        #endregion

        #region Form Control Events
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            //05/07/2020
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnPayment_Click(null, null);
                    break;
                case Keys.F3:
                    BtnProductSearch_Click(null, null);
                    break;
                case Keys.F4:
                    BtnSuspendSale_Click(null, null);
                    break;
                case Keys.F5:
                    BtnCancelSale_Click(null, null);
                    break;
                case Keys.F6:
                    BtnCustomer_Click(null, null);
                    break;
                case Keys.F7:
                    BtnPrintLastInvoice_Click(null, null);
                    break;
                case Keys.F8:
                    BtnSalesOrigin_Click(null, null);
                    break;
                case Keys.F9:
                    BtnExit_Click(null, null);
                    break;
                case Keys.F12:
                    GrcSalesDetail.Focus();
                    break;
                case Keys.Enter:

                    break;
                default:
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBarcode.Text.Contains("X"))
                {
                    TxtBarcode.Properties.UseSystemPasswordChar = true;
                    TxtBarcode.Properties.PasswordChar = '•';
                }
                else
                {
                    if (TxtBarcode.Properties.UseSystemPasswordChar)
                    {
                        TxtBarcode.Properties.UseSystemPasswordChar = false;
                        TxtBarcode.Properties.PasswordChar = '\0';
                    }

                    GetProductInformation(emissionPoint.LocationId,
                                          TxtBarcode.Text,
                                          1,
                                          currentCustomer.CustomerId,
                                          internalCreditCardId,
                                          "",
                                          false);
                }
            }
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scaleBrand == ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
                catchWeight.DisableScale();
            }
        }
        #endregion

        #region Main Functions

        private void GetProductInformation(short _locationId,
                                           string _barcode,
                                           decimal _qty,
                                           long _customerId,
                                           long _internalCreditCardId,
                                           string _paymMode,
                                           bool _skipCatchWeight)
        {
            SP_Product_Consult_Result result = null;
            bool updateRecord = false;
            decimal qtyFound = 0;
            decimal amountFound = 0;
            decimal amountTaxFound = 0;
            bool useWeightControl = false;
            bool useCatchWeight = false;
            bool canInsert = true;
            string barcodeBefore = _barcode;
            decimal taxAmountFound = 0;     // IG005

            if (_barcode == string.Empty)
            {
                functions.ShowMessage("El código de barras no puede estar vacío.", MessageType.WARNING);
                return;
            }

            try
            {
                string searchBarcode = _barcode;

                if (searchBarcode.StartsWith("21") && searchBarcode.Length >= 7)
                {
                    int barcodeLength = searchBarcode.Length;
                    searchBarcode = searchBarcode.Substring(0, 7);
                    searchBarcode = searchBarcode.PadRight(barcodeLength, '0');
                }

                IEnumerable<XElement> searchXml = invoiceXml
                    .Descendants("InvoiceLine")
                    .Where(xm => xm.Element("Barcode").Value == searchBarcode || xm.Element("Barcode").Value == _barcode); // IG001 


                foreach (XElement node in searchXml.Elements())
                {
                    updateRecord = true;

                    switch (node.Name.ToString())
                    {
                        case "WeightControl":
                            if (bool.Parse(node.Value))
                                useWeightControl = true;
                            break;
                        case "UseCatchWeight":
                            useCatchWeight = bool.Parse(node.Value);
                            break;
                        case "Quantity":
                            qtyFound = decimal.Parse(node.Value);
                            break;
                        case "BaseAmount":
                            amountFound = decimal.Parse(node.Value);
                            break;
                        case "BaseTaxAmount":
                            amountTaxFound = decimal.Parse(node.Value);
                            break;
                        //Begin(IG005)
                        case "TaxAmount":
                            taxAmountFound = decimal.Parse(node.Value);
                            break;
                            //End(IG005)
                    }
                }

                if (updateRecord)
                {
                    if (useWeightControl && !useCatchWeight)
                    {
                        string productCode = _barcode.Substring(0, 7);
                        string entere = _barcode.Substring(7, 3);
                        string decimals = _barcode.Substring(10, 3);
                        string newNumber = entere + "." + decimals;
                        decimal newAmount = decimal.Parse(newNumber);
                        amountTaxFound += taxAmountFound;   // IG005
                        newAmount += amountFound + amountTaxFound;
                        newAmount = Math.Round(newAmount, 3);
                        string value = newAmount.ToString();
                        value = value.Replace(".", "");
                        value = value.PadLeft(6, '0');
                        _barcode = productCode + value;
                    }
                    else
                    {
                        _qty += qtyFound;
                    }
                }

                result = new ProductRepository(Program.customConnectionString).ProductConsult(_locationId,
                                                                                            _barcode,
                                                                                            _qty,
                                                                                            _customerId,
                                                                                            _internalCreditCardId,
                                                                                            _paymMode,
                                                                                            barcodeBefore);

                if (result == null)
                {
                    functions.ShowMessage($"El producto con codigo de barras {_barcode} no se encuentra registrado.", MessageType.WARNING);
                    ClearBarcode();
                    return;
                }

                // Begin(IG003)
                if (result.Price == 0)
                {
                    functions.ShowMessage("No se puede procesar un producto con precio cero.", MessageType.WARNING);
                    return;
                }
                // End(IG003)

                if ((bool)result.WeightControl)
                {
                    functions.globalParameters = GlobalParameters;

                    if (result.UseCatchWeight)
                    {
                        if (!_skipCatchWeight)
                        {
                            decimal weight = functions.CatchWeightProduct(AxOPOSScale,
                                                                          result,
                                                                          scaleBrand,
                                                                          portName);

                            if (weight <= 0)
                            {
                                functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", MessageType.WARNING);
                                canInsert = false;
                            }

                            result = new ProductRepository(Program.customConnectionString).ProductConsult(_locationId,
                                                                                                        _barcode,
                                                                                                        weight + qtyFound,
                                                                                                        _customerId,
                                                                                                        _internalCreditCardId,
                                                                                                        _paymMode,
                                                                                                        barcodeBefore);
                        }
                    }
                    else
                    {
                        if (!_skipCatchWeight)
                        {
                            bool isTestMode = new ClsGeneral(Program.customConnectionString).GetParameterByName("MODETEST").Value == "1";

                            canInsert = functions.ValidateCatchWeightProduct(AxOPOSScale,
                                                                             (decimal)result.QuantityBefore,
                                                                             result,
                                                                             scaleBrand,
                                                                             portName,
                                                                             isTestMode);
                        }
                    }
                }

                if (!canInsert)
                {
                    ClearBarcode();
                    return;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Hubo un problema al consultar producto.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);

                ClearBarcode();
                return;
            }

            AddRecordToGrid(result, updateRecord, _barcode); // IG002
            CalculateInvoice();
        }

        private void ClosingInvoice()
        {
            XElement invoiceTableXml = new XElement("InvoiceTable");

            try
            {
                InvoiceTable invoiceTable = new InvoiceTable
                {
                    LocationId = emissionPoint.LocationId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    Establishment = emissionPoint.Establishment,
                    Emission = emissionPoint.Emission,
                    InvoiceNumber = sequenceNumber,
                    CustomerId = currentCustomer.CustomerId,
                    ShippingFree = false,
                    ShippingAmount = 0,
                    SalesOrderId = 0,
                    CreatedBy = (int)LoginInformation.UserId,
                    Workstation = LoginInformation.Workstation,
                    SalesOriginId = salesOriginId,
                    SalesmanId = salesManId,
                    TransferStatusId = (int)DLL.Enums.TransferStatus.PENDING_MIGRATE,
                    TypeDoc = (short)DocumentType.INVOICE
                    //,IsBbqZone = ChbBbqZone.Checked
                };

                Type type = invoiceTable.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(invoiceTable);

                    if (value == null)
                    {
                        value = "";
                    }

                    invoiceTableXml.Add(new XElement(name, value));
                }

                invoiceXml.Add(invoiceTableXml);

                if (!invoiceXml.HasElements)
                {
                    functions.ShowMessage("No se ha podido registrar la factura. Revisar detalle.", MessageType.WARNING);
                    return;
                }

                SP_Invoice_Insert_Result invoiceResult = new InvoiceRepository(Program.customConnectionString).CreateInvoice(invoiceXml);

                if ((bool)invoiceResult?.Error)
                {
                    // Begin(IG004)
                    invoiceXml.Descendants("Payment").Remove();
                    // End(IG004)

                    invoiceXml.Descendants("InvoiceTable").Remove();

                    functions.ShowMessage("No se ha podido registrar la factura. Revisar detalle.",
                                          MessageType.WARNING,
                                          true,
                                          invoiceResult.TextError);
                    return;
                }

                ClearInvoice();

                if (functions.PrintDocument((long)invoiceResult.InvoiceId, DocumentType.INVOICE, true))
                {
                    functions.ShowMessage("Venta finalizada exitosamente.");
                    return;
                }

                functions.ShowMessage("La venta finalizó correctamente pero no se pudo imprimir factura.", MessageType.WARNING);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ha ocurrido un problema al registrar la factura.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
            finally
            {
                invoiceTableXml.RemoveAll();
            }
        }

        private void ClearInvoice()
        {
            BtnCustomer.Enabled = true;

            currentCustomer = LoadFinalConsumptionCustomer();
            LoadCustomerInformation(currentCustomer);
            internalCreditCardId = 0;
            internalCreditCardCode = string.Empty;

            salesOriginId = 1;
            salesManId = 1;

            invoiceXml.RemoveAll();
            GrcSalesDetail.DataSource = null;
            GetNewSequenceNumber(emissionPoint.EmissionPointId, emissionPoint.LocationId);
            CheckGridView();
            LblTotal.Text = "0.00";
            LblDiscAmount.Text = "0.00";
            ImgSalesOrigin.Visible = false;
            ClearBarcode();

            //ChbBbqZone.Checked = false;
        }

        private Customer LoadFinalConsumptionCustomer()
        {
            return new CustomerRepository(Program.customConnectionString).GetCustomerById(1);
        }

        #endregion

        #region Recurrent Functions
        private void GetNewSequenceNumber(int _emissionPointId, int _locationId)
        {
            try
            {
                SequenceTable sequenceTable = new ClsGeneral(Program.customConnectionString).GetSequenceByEmissionPointId(_emissionPointId, _locationId, (int)DLL.Enums.SequenceType.INVOICE);

                if (sequenceTable == null)
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", MessageType.WARNING);
                    return;
                }

                sequenceNumber = (long)(sequenceTable?.Sequence);
                string stringSequence = sequenceNumber.ToString();
                LblInvoiceNumber.Text = stringSequence.PadLeft(9, '0');
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al obtener secuencia.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void AddRecordToGrid(SP_Product_Consult_Result _productResult, bool _updateRecord, string _barcode)
        {
            BtnCustomer.Enabled = false;

            Type type = _productResult.GetType();
            PropertyInfo[] properties = type.GetProperties();
            XElement invoiceLineXml = new XElement("InvoiceLine");

            if (!_updateRecord)
            {
                GrvSalesDetail.AddNewRow();
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["ProductId"], _productResult.ProductId);
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["ProductName"], _productResult.ProductName);
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["Quantity"], _productResult.Quantity);
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["FinalPrice"], _productResult.FinalPrice);
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["LineDiscount"], _productResult.LineDiscount);
                GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["LineAmount"], _productResult.LineAmount);
                GrvSalesDetail.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 255, 255);

                foreach (PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(_productResult);

                    if (value == null)
                    {
                        value = "";
                    }

                    invoiceLineXml.Add(new XElement(name, value));
                }

                invoiceXml.Add(invoiceLineXml);
                ClearBarcode();
                return;
            }

            int rowIndex = GrvSalesDetail.LocateByValue("ProductId", _productResult.ProductId);

            if (rowIndex < 0)
            {
                rowIndex = GrvSalesDetail.FocusedRowHandle;
            }

            GrvSalesDetail.FocusedRowHandle = rowIndex;
            GrvSalesDetail.UpdateCurrentRow();
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["ProductId"], _productResult.ProductId);
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["ProductName"], _productResult.ProductName);
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["Quantity"], _productResult.Quantity);
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["FinalPrice"], _productResult.FinalPrice);
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["LineDiscount"], _productResult.LineDiscount);
            GrvSalesDetail.SetRowCellValue(GrvSalesDetail.FocusedRowHandle, GrvSalesDetail.Columns["LineAmount"], _productResult.LineAmount);
            GrvSalesDetail.Appearance.HideSelectionRow.BackColor = Color.FromArgb(184, 255, 61);

            IEnumerable<XElement> updateQuery = invoiceXml
                .Descendants("InvoiceLine")
                .Where(r => r.Element("ProductId").Value == _productResult.ProductId.ToString());

            foreach (XElement query in updateQuery)
            {
                query.Element("Cost").SetValue(_productResult.Cost);
                query.Element("Price").SetValue(_productResult.Price);
                query.Element("PromotionPrice").SetValue(_productResult.PromotionPrice);
                query.Element("FinalPrice").SetValue(_productResult.FinalPrice);
                query.Element("TaxProductAmount").SetValue(_productResult.TaxProductAmount);
                query.Element("DiscountProductAmount").SetValue(_productResult.DiscountProductAmount);
                query.Element("IrbpProductAmount").SetValue(_productResult.IrbpProductAmount);
                query.Element("Stock").SetValue(_productResult.Stock);
                query.Element("Quantity").SetValue(_productResult.Quantity);
                query.Element("BaseAmount").SetValue(_productResult.BaseAmount);
                query.Element("BaseTaxAmount").SetValue(_productResult.BaseTaxAmount);
                query.Element("LinePercent").SetValue(_productResult.LinePercent);
                query.Element("LineDiscount").SetValue(_productResult.LineDiscount);
                query.Element("TaxPercent").SetValue(_productResult.TaxPercent);
                query.Element("TaxAmount").SetValue(_productResult.TaxAmount);
                query.Element("IrbpAmount").SetValue(_productResult.IrbpAmount);
                query.Element("LineAmount").SetValue(_productResult.LineAmount);
                query.Element("RewardPercent").SetValue(_productResult.RewardPercent);
                query.Element("BarcodeBefore").SetValue(_barcode);  // IG002
            }

            ClearBarcode();
        }

        private void CalculateInvoice()
        {
            decimal invoiceAmount = 0.00M;
            decimal discountAmount = 0.00M;
            decimal baseAmount = 0.00M;
            decimal baseTaxAmount = 0.00M;
            decimal taxAmount = 0.00M;


            IEnumerable<XElement> line = invoiceXml.Descendants("InvoiceLine");

            foreach (XElement item in line)
            {
                discountAmount += decimal.Parse(item.Element("LineDiscount").Value);
                invoiceAmount += decimal.Parse(item.Element("LineAmount").Value);
                baseAmount += decimal.Parse(item.Element("BaseAmount").Value);
                baseTaxAmount += decimal.Parse(item.Element("BaseTaxAmount").Value);
                taxAmount += decimal.Parse(item.Element("TaxAmount").Value);
            }

            LblTotal.Text = Math.Round(invoiceAmount, 2).ToString();
            LblDiscAmount.Text = Math.Round(discountAmount, 2).ToString();
        }

        private Customer CreateCustomer(string _identification)
        {
            FrmCustomer frmCustomer = new FrmCustomer(emissionPoint, LoginInformation, _identification);
            frmCustomer.ShowDialog();

            if (frmCustomer.GetCurrentCustomer().CustomerId == 0)
            {
                return LoadFinalConsumptionCustomer();
            }

            return frmCustomer.GetCurrentCustomer();
        }

        #endregion

        private void TxtBarcode_EditValueChanged(object sender, EventArgs e) { }

        private void TxtBarcode_Click(object sender, EventArgs e) { }

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e) { }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                BtnCustomer_Click(null, null);
            }
        }

        private void GrcSalesDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    BtnQty_Click(null, null);
                    break;
                case Keys.F11:
                    BtnRemove_Click(null, null);
                    break;
                case Keys.Escape:
                    TxtBarcode.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}