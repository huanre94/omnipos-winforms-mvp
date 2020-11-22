using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Reflection;
using System.Drawing.Printing;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace POS
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public List<GlobalParameter> globalParameters;
        EmissionPoint emissionPoint;
        Customer currentCustomer = new Customer();
        XElement invoiceXml = new XElement("Invoice");
        Int64 sequenceNumber;
        public SP_Login_Consult_Result loginInformation;
        public Int64 internalCreditCardId = 0;
        public string internalCreditCardCode = "";
        ClsCatchWeight catchWeight;
        ClsEnums.ScaleBrands scaleBrand;
        private string portName = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Global Load Definitions

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                ClearInvoice();
                CheckGridView();
                LblCashier.Text = loginInformation.UserName;
                scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

                if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                {
                    catchWeight = new ClsCatchWeight(scaleBrand);
                    catchWeight.AxOPOSScale = AxOPOSScale;
                    catchWeight.EnableScale(emissionPoint.ScaleName);
                    functions.AxOPOSScanner = AxOPOSScanner;
                    functions.EnableScanner(emissionPoint.ScanBarcodeName);                    
                }
                else
                {
                    string[] portNames = SerialPort.GetPortNames();                    
                    portName = string.Empty;

                    foreach (var item in portNames)
                    {
                        portName = item;
                        break;
                    }

                    //MessageBox.Show(portName);
                }

                if (new ClsInvoiceTrans().HasSuspendedSale(emissionPoint))
                {
                    BtnSuspendSale.Text = "Reanudar";
                    BtnSuspendSale.ImageOptions.SvgImage = POS.Properties.Resources.resume;
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);

                    if (emissionPoint != null)
                    {
                        response = true;
                        LblEstablishment.Text = emissionPoint.Establishment;
                        LblEmissionPoint.Text = emissionPoint.Emission;
                        functions.PrinterName = emissionPoint.PrinterName;

                        GetNewSequenceNumber(emissionPoint.EmissionPointId);
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void CheckGridView()
        {
            GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesDetail.DataSource = null;
            GrvSalesDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_Product_Consult_Result> bindingList = new BindingList<SP_Product_Consult_Result>();
            bindingList.AllowNew = true;

            GrcSalesDetail.DataSource = bindingList;
        }
        #endregion

        #region Keypad Buttons

        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            GetProductInformation(
                                    emissionPoint.LocationId
                                    , TxtBarcode.Text
                                    , 1
                                    , currentCustomer.CustomerId
                                    , internalCreditCardId
                                    , ""
                                    , false
                                );
        }
        #endregion

        #region Bottom Side Buttons

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = Classes.ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION;
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification != "")
            {
                ClsCustomer clsCustomer = new ClsCustomer();
                string identification = keyBoard.customerIdentification;

                try
                {
                    currentCustomer = clsCustomer.GetCustomerByIdentification(identification);

                    if (currentCustomer != null)
                    {
                        if (currentCustomer.CustomerId > 0)
                        {
                            if (currentCustomer.IsEmployee)
                            {
                                bool response = functions.ShowMessage("El cliente es un empleado, desea utilizar la tarjeta de afiliado?.", ClsEnums.MessageType.CONFIRM);

                                if (response)
                                {
                                    FrmPaymentCredit paymentCredit = new FrmPaymentCredit();
                                    paymentCredit.customer = currentCustomer;
                                    paymentCredit.emissionPoint = emissionPoint;
                                    paymentCredit.scanner = AxOPOSScanner;
                                    paymentCredit.isPresentingCreditCard = true;
                                    paymentCredit.ShowDialog();

                                    if (paymentCredit.formActionResult)
                                    {
                                        internalCreditCardId = paymentCredit.internalCreditCardId;
                                        internalCreditCardCode = paymentCredit.internalCreditCardCode;
                                    }
                                }
                            }

                            LblCustomerId.Text = currentCustomer.Identification;
                            LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
                            LblCustomerAddress.Text = currentCustomer.Address;
                            TxtBarcode.Focus();
                        }
                    }
                    else
                    {
                        bool response = functions.ShowMessage("El cliente ingresado no esta registrado, desea ingresarlo?.", ClsEnums.MessageType.CONFIRM);

                        if (response)
                        {   
                            currentCustomer = CreateCustomer(identification);

                            if (currentCustomer != null)
                            {
                                LblCustomerId.Text = currentCustomer.Identification;
                                LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
                                LblCustomerAddress.Text = currentCustomer.Address;
                                TxtBarcode.Focus();
                            }
                            else
                            {
                                functions.ShowMessage("No se pudo cargar datos de cliente.", ClsEnums.MessageType.WARNING);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información del cliente."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            BindingList<SP_Product_Consult_Result> list = (BindingList<SP_Product_Consult_Result>)GrvSalesDetail.DataSource;

            if (list.Count > 0)
            {
                functions.ShowMessage("No puede salir con una venta en proceso.", ClsEnums.MessageType.ERROR);
                TxtBarcode.Focus();
            }
            else
            {
                FrmMenu frmMenu = new FrmMenu
                {
                    loginInformation = loginInformation
                };
                frmMenu.Show();
                Close();
            }
        }

        private void BtnQty_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvSalesDetail.FocusedRowHandle;
            if (rowIndex < 0)
            {
                functions.ShowMessage("No ha seleccionado ningun producto.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                FrmKeyPad keyPad = new FrmKeyPad();
                keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_QUANTITY;
                keyPad.ShowDialog();

                if (keyPad.productQuantity != "")
                {
                    int newAmount = int.Parse(keyPad.productQuantity);
                    //decimal quantity = (decimal)GrvSalesDetail.GetRowCellValue(rowIndex, "Quantity");
                    SP_Product_Consult_Result row = (SP_Product_Consult_Result)GrvSalesDetail.GetRow(rowIndex);

                    if (newAmount > row.Quantity)
                    {
                        var searchXml = from xm in invoiceXml.Descendants("InvoiceLine")
                                        where long.Parse(xm.Element("ProductId").Value) == row.ProductId
                                        select xm;

                        string barcode = "";
                        foreach (var item in searchXml.Elements())
                        {
                            if (item.Name == "Barcode")
                                barcode = item.Value;
                        }

                        long newValue = (long)(newAmount - row.Quantity);

                        GetProductInformation(
                                               emissionPoint.LocationId
                                               , barcode
                                               , newValue
                                               , currentCustomer.CustomerId
                                               , internalCreditCardId
                                               , ""
                                               , false
                                               );
                    }
                    else
                    {
                        functions.ShowMessage("El valor ingresado no puede ser igual o menor al actual.", ClsEnums.MessageType.WARNING);
                    }
                }
            }

            TxtBarcode.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvSalesDetail.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a anular.", ClsEnums.MessageType.ERROR);
            }
            else
            {
                functions.emissionPoint = emissionPoint;
                bool isApproved = functions.RequestSupervisorAuth();
                if (isApproved)
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

                    var newInvoiceXML = from xm in invoiceXml.Descendants("InvoiceLine")
                                        where long.Parse(xm.Element("ProductId").Value) == selectedRow.ProductId
                                        select xm;

                    XElement element = null;
                    if (newInvoiceXML.Count() == 1)
                    {
                        element = newInvoiceXML.First();
                    }
                    ClsInvoiceTrans invoiceTrans = new ClsInvoiceTrans();
                    SalesLog salesLog = new SalesLog
                    {
                        CustomerId = currentCustomer.CustomerId,
                        EmissionPointId = emissionPoint.EmissionPointId,
                        LocationId = emissionPoint.LocationId,
                        InvoiceNumber = sequenceNumber,
                        XmlLog = element.ToString(),
                        LogTypeId = (int)ClsEnums.LogType.ELIMINAR_PRODUCTO,
                        Authorization = functions.supervisorAuthorization,
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };
                    invoiceTrans.InsertCancelledSales(salesLog);

                    newInvoiceXML.Remove();

                    CalculateInvoice();
                    GrcSalesDetail.DataSource = dataSource;                    
                }
            }

            TxtBarcode.Focus();
        }

        private void BtnPrintLastInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 lastId = new ClsInvoiceTrans().ConsultLastInvoice(emissionPoint);

                if (lastId == 0)
                {
                    functions.ShowMessage("No hay documento previo existente.", ClsEnums.MessageType.WARNING);
                }
                else
                {
                    PrintInvoice(lastId);
                }
            }
            catch(Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al imprimir la última factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }

            TxtBarcode.Focus();
        }
        #endregion

        #region Right Side Buttons

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) <= 0)
            {
                functions.ShowMessage("El valor a pagar debe ser mayor a 0", ClsEnums.MessageType.WARNING);
                TxtBarcode.Focus();
            }
            else
            {
                decimal baseAmount = 0;
                decimal taxAmount = 0;

                var line = from r in invoiceXml.Descendants("InvoiceLine")
                           select r;

                foreach (var item in line)
                {
                    baseAmount += decimal.Parse(item.Element("BaseAmount").Value) + decimal.Parse(item.Element("BaseTaxAmount").Value);
                    taxAmount += decimal.Parse(item.Element("TaxAmount").Value);
                }

                FrmPayment payment = new FrmPayment
                {
                    invoiceAmount = decimal.Parse(LblTotal.Text),
                    customer = currentCustomer,
                    emissionPoint = emissionPoint,
                    taxAmount = taxAmount,
                    baseAmount = baseAmount,
                    loginInformation = loginInformation,
                    scanner = AxOPOSScanner,
                    internalCreditCardCode = internalCreditCardCode
                };
                payment.ShowDialog();

                if (payment.canCloseInvoice)
                {
                    if (payment.paymentXml.HasElements)
                    {
                        invoiceXml.Add(payment.paymentXml);
                        ClosingInvoice();
                    }
                }

                TxtBarcode.Focus();
            }
        }

        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            FrmProductSearch productSearch = new FrmProductSearch();
            productSearch.emissionPoint = emissionPoint;
            productSearch.ShowDialog();

            if (productSearch.barcode != "")
            {
                decimal quantity = 0;

                if (productSearch.useCatchWeight)
                {

                    quantity = functions.CatchWeightProduct(
                                                            AxOPOSScale
                                                            , productSearch.productName
                                                            , scaleBrand
                                                            , portName
                                                            );
                }
                else
                {
                    quantity = 1;
                }

                if (quantity > 0)
                {
                    GetProductInformation(
                                            emissionPoint.LocationId
                                            , productSearch.barcode
                                            , quantity
                                            , currentCustomer.CustomerId
                                            , internalCreditCardId
                                            , ""
                                            , true
                                            );
                }
                else
                {
                    functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", ClsEnums.MessageType.WARNING);
                }
            }

            TxtBarcode.Focus();
        }

        private void BtnSuspendSale_Click(object sender, EventArgs e)
        {
            if (new ClsInvoiceTrans().HasSuspendedSale(emissionPoint))
            {
                if (((BindingList<SP_Product_Consult_Result>)GrvSalesDetail.DataSource).Count == 0)
                {
                    BtnSuspendSale.Text = "Suspender";
                    BtnSuspendSale.ImageOptions.SvgImage = POS.Properties.Resources.SuspendSale;

                    SP_SalesLog_Consult_Result sales = new ClsInvoiceTrans().ConsultSuspendedSale(emissionPoint);
                    XElement element = XElement.Parse(sales.XmlLog);

                    var listProducts = (from li in element.Descendants("InvoiceLine")
                                        select li).ToList();

                    foreach (XElement item in listProducts)
                    {
                        decimal qtyFound = 0;
                        string barcode = "";

                        foreach (var node in item.Elements())
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

                        GetProductInformation(
                                             emissionPoint.LocationId
                                             , barcode
                                             , qtyFound
                                             , currentCustomer.CustomerId
                                             , internalCreditCardId
                                             , ""
                                             , true
                                             );
                    }

                    currentCustomer = new ClsCustomer().GetCustomerById(sales.CustomerId);

                    if (currentCustomer != null)
                    {
                        if (currentCustomer.CustomerId > 0)
                        {
                            LblCustomerId.Text = currentCustomer.Identification;
                            LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
                            LblCustomerAddress.Text = currentCustomer.Address;
                            TxtBarcode.Focus();
                        }
                    }

                    CalculateInvoice();
                }
                else
                {
                    functions.ShowMessage("No puede reanudar una venta mientras exista otra en proceso", ClsEnums.MessageType.WARNING);
                }
            }
            else
            {
                if (decimal.Parse(LblTotal.Text) <= 0)
                {
                    functions.ShowMessage("El valor a pagar debe ser mayor a 0", ClsEnums.MessageType.WARNING);
                }
                else
                {
                    BtnSuspendSale.Text = "Reanudar";
                    BtnSuspendSale.ImageOptions.SvgImage = POS.Properties.Resources.resume;

                    ClsInvoiceTrans invoiceTrans = new ClsInvoiceTrans();
                    SalesLog salesLog = new SalesLog
                    {
                        CustomerId = currentCustomer.CustomerId,
                        EmissionPointId = emissionPoint.EmissionPointId,
                        LocationId = emissionPoint.LocationId,
                        InvoiceNumber = sequenceNumber,
                        XmlLog = invoiceXml.ToString(),
                        ReasonId = functions.motiveId,
                        LogTypeId = (int)ClsEnums.LogType.SUSPENDER_DOCUMENTO,
                        Authorization = "",
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };

                    if (invoiceTrans.InsertCancelledSales(salesLog))
                    {
                        ClearInvoice();
                    }
                    else
                    {
                        functions.ShowMessage("Hubo un error al poner la venta en espera, por favor vuelva a intentar", ClsEnums.MessageType.ERROR);
                    }
                }
            }

            TxtBarcode.Focus();
        }

        private void BtnCancelSale_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) <= 0)
            {
                functions.ShowMessage("El valor a pagar debe ser mayor a cero", ClsEnums.MessageType.WARNING);
            }
            else
            {
                functions.emissionPoint = emissionPoint;
                if (functions.RequestSupervisorAuth(requireMotive: true))
                {
                    ClsInvoiceTrans invoiceTrans = new ClsInvoiceTrans();
                    SalesLog salesLog = new SalesLog
                    {
                        CustomerId = currentCustomer.CustomerId,
                        EmissionPointId = emissionPoint.EmissionPointId,
                        LocationId = emissionPoint.LocationId,
                        InvoiceNumber = sequenceNumber,
                        XmlLog = invoiceXml.ToString(),
                        ReasonId = functions.motiveId,
                        LogTypeId = (int)ClsEnums.LogType.ANULAR_DOCUMENTO,
                        Authorization = functions.supervisorAuthorization,
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };

                    if (invoiceTrans.InsertCancelledSales(salesLog))
                    {
                        ClearInvoice();
                    }
                    else
                    {
                        functions.ShowMessage("Hubo un error al anular la transaccion, por favor vuelva a intentar", ClsEnums.MessageType.ERROR);
                    }
                }
            }

            TxtBarcode.Focus();
        }
        #endregion

        #region Form Control Events
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
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

                    GetProductInformation(
                                            emissionPoint.LocationId
                                            , TxtBarcode.Text
                                            , 1
                                            , currentCustomer.CustomerId
                                            , internalCreditCardId
                                            , ""
                                            , false
                                        );
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
            functions.DisableScanner();
            functions.DisableScale();
        }
        #endregion

        #region Main Functions

        private void GetProductInformation(
                                            short _locationId
                                            , string _barcode
                                            , decimal _qty
                                            , Int64 _customerId
                                            , Int64 _internalCreditCardId
                                            , string _paymMode
                                            , bool _skipCatchWeight
                                            )
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans();
            SP_Product_Consult_Result result;
            bool updateRecord = false;
            decimal qtyFound = 0;
            decimal amountFound = 0;
            bool useWeightControl = false;
            bool useCatchWeight = false;
            bool canInsert = true;
            string barcodeBefore = _barcode;

            if (_barcode != "")
            {
                try
                {
                    string searchBarcode = _barcode;

                    if (searchBarcode.StartsWith("21") && searchBarcode.Length >= 7)
                    {
                        int barcodeLenght = searchBarcode.Length;
                        searchBarcode = searchBarcode.Substring(0, 7);
                        searchBarcode = searchBarcode.PadRight(barcodeLenght, '0');
                    }

                    var searchXml = from xm in invoiceXml.Descendants("InvoiceLine")
                                    where xm.Element("Barcode").Value == searchBarcode
                                    select xm;

                    foreach (var node in searchXml.Elements())
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
                            newAmount += amountFound;
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

                    result = clsInvoiceTrans.ProductConsult(
                                                            _locationId
                                                            , _barcode
                                                            , _qty
                                                            , _customerId
                                                            , _internalCreditCardId
                                                            , _paymMode
                                                            , barcodeBefore
                                                            );

                    if (result != null)
                    {
                        if ((bool)result.WeightControl)
                        {
                            functions.globalParameters = globalParameters;

                            if (result.UseCatchWeight)
                            {
                                if (!_skipCatchWeight)
                                {
                                    decimal weight = functions.CatchWeightProduct(
                                                                                    AxOPOSScale
                                                                                    , result.ProductName
                                                                                    , scaleBrand
                                                                                    , portName
                                                                                    );

                                    if (weight > 0)
                                    {
                                        result = clsInvoiceTrans.ProductConsult(
                                                                                _locationId
                                                                                , _barcode
                                                                                , weight + qtyFound
                                                                                , _customerId
                                                                                , _internalCreditCardId
                                                                                , _paymMode
                                                                                , barcodeBefore
                                                                                );
                                    }
                                    else
                                    {
                                        functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", ClsEnums.MessageType.WARNING);
                                        canInsert = false;
                                    }
                                }
                            }
                            else
                            {

                                if (!_skipCatchWeight)
                                {
                                    canInsert = functions.ValidateCatchWeightProduct(
                                                                                        AxOPOSScale
                                                                                        , (decimal)result.QuantityBefore
                                                                                        , result.ProductName
                                                                                        , scaleBrand
                                                                                        , portName
                                                                                    );
                                }
                            }
                        }

                        if (canInsert)
                        {
                            AddRecordToGrid(result, updateRecord);
                            CalculateInvoice();
                        }
                        else
                        {
                            TxtBarcode.Text = "";
                            TxtBarcode.Focus();
                        }
                    }
                    else
                    {
                        functions.ShowMessage("El producto con codigo de barras " + _barcode + " no se encuentra registrado.", ClsEnums.MessageType.WARNING);
                        TxtBarcode.Text = "";
                        TxtBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Hubo un problema al consultar producto."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                            );
                }
            }
            else
            {
                functions.ShowMessage("El código de barras no puede estar vacío.", ClsEnums.MessageType.WARNING);
            }
        }

        private void ClosingInvoice()
        {
            ClsInvoiceTrans invoice = new ClsInvoiceTrans();
            SP_Invoice_Insert_Result invoiceResult = null;
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
                    CreatedBy = (int)loginInformation.UserId,
                    Workstation = loginInformation.Workstation
                };

                Type type = invoiceTable.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(invoiceTable);

                    if (value == null)
                    {
                        value = "";
                    }

                    invoiceTableXml.Add(new XElement(name, value));
                }

                invoiceXml.Add(invoiceTableXml);

                invoiceResult = invoice.CreateInvoice(invoiceXml);

                if (invoiceResult != null)
                {
                    if (!(bool)invoiceResult.Error)
                    {
                        ClearInvoice();

                        if (PrintInvoice((Int64)invoiceResult.InvoiceId))
                        {
                            functions.ShowMessage("Venta finalizada exitosamente.");
                        }
                        else
                        {
                            functions.ShowMessage("La venta finalizó correctamente pero no se pudo imprimir factura.", ClsEnums.MessageType.WARNING);
                        }
                    }
                    else
                    {
                        functions.ShowMessage(
                                               "No se ha podido registrar la factura."
                                               , ClsEnums.MessageType.WARNING
                                               , true
                                               , invoiceResult.TextError
                                            );

                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ha ocurrido un problema al registrar la factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
            finally
            {
                invoiceTableXml.RemoveAll();
            }
        }

        private bool PrintInvoice(Int64 _invoiceId)
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans();
            List<SP_InvoiceTicket_Consult_Result> invoiceTicket;
            bool response = false;
            string bodyText = "";

            try
            {
                invoiceTicket = clsInvoiceTrans.GetInvoiceTicket(_invoiceId);

                if (invoiceTicket != null)
                {
                    if (invoiceTicket.Count > 0)
                    {

                        foreach (var line in invoiceTicket)
                        {
                            bodyText += line.BodyText + Environment.NewLine;
                        }

                        bool PrinterDocumentOk = functions.PrinterDocument(bodyText);

                        if (PrinterDocumentOk == true)
                        {
                            response = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ha ocurrido un problema al imprimir la factura."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }

            return response;
        }

        private void ClearInvoice()
        {
            BtnCustomer.Enabled = true;

            currentCustomer = new ClsCustomer().GetCustomerById(1);
            LblCustomerId.Text = currentCustomer.Identification;
            LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
            LblCustomerAddress.Text = currentCustomer.Address;
            internalCreditCardId = 0;
            internalCreditCardCode = "";

            invoiceXml.RemoveAll();
            GrcSalesDetail.DataSource = null;
            GetNewSequenceNumber(emissionPoint.EmissionPointId);
            CheckGridView();
            LblTotal.Text = "0.00";
            LblDiscAmount.Text = "0.00";
            TxtBarcode.Focus();
        }

        #endregion

        #region Recurrent Functions
        private void GetNewSequenceNumber(int _emissionPointId)
        {
            ClsGeneral clsGeneral = new ClsGeneral();
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = clsGeneral.GetSequenceByEmissionPointId(_emissionPointId);

                if (sequenceTable != null)
                {
                    sequenceNumber = sequenceTable.Sequence;
                    string stringSequence = sequenceNumber.ToString();
                    LblInvoiceNumber.Text = stringSequence.PadLeft(9, '0');
                }
                else
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", ClsEnums.MessageType.WARNING);
                    Close();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al obtener secuencia."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void AddRecordToGrid(SP_Product_Consult_Result _productResult, bool _updateRecord)
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
                
                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(_productResult);

                    if (value == null)
                    {
                        value = "";
                    }

                    invoiceLineXml.Add(new XElement(name, value));
                }
                
                invoiceXml.Add(invoiceLineXml);
            }
            else
            {
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

                var updateQuery = from r in invoiceXml.Descendants("InvoiceLine")
                                  where r.Element("ProductId").Value == _productResult.ProductId.ToString()
                                  select r;

                foreach (var query in updateQuery)
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
                }
            }

            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }

        private void CalculateInvoice()
        {
            decimal invoiceAmount = 0.00M;
            decimal discAmount = 0.00M;

            var line = from r in invoiceXml.Descendants("InvoiceLine")
                       select r;

            foreach (var item in line)
            {
                discAmount += decimal.Parse(item.Element("LineDiscount").Value);
                invoiceAmount += decimal.Parse(item.Element("LineAmount").Value);
            }

            LblTotal.Text = Math.Round(invoiceAmount, 2).ToString();
            LblDiscAmount.Text = Math.Round(discAmount, 2).ToString();
        }

        private Customer CreateCustomer(string _identification)
        {
            FrmCustomer frmCustomer = new FrmCustomer();
            frmCustomer.emissionPoint = emissionPoint;
            frmCustomer.isNewCustomer = true;
            frmCustomer.customerIdentification = _identification;
            frmCustomer.ShowDialog();

            return frmCustomer.currentCustomer;
        }
        #endregion

        
    }
}