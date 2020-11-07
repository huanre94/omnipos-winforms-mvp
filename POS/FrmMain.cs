using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using POS.DLL.Catalog;
using POS.DLL;
using POS.Classes;
using System.Net;
using System.Net.Sockets;
using POS.DLL.Transaction;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml.Linq;
using System.Reflection;
using System.Drawing.Printing;
using OposScanner_CCO;
using OposScale_CCO;

namespace POS
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        List<GlobalParameter> globalParameters;
        EmissionPoint emissionPoint = new EmissionPoint();
        Customer currentCustomer = new Customer();
        XElement invoiceXml = new XElement("Invoice");
        Int64 sequenceNumber;
        System.Drawing.Point initialLocation;
        public SP_Login_Consult_Result loginInformation;
        decimal baseAmount = 0;
        decimal taxAmount = 0;
        OposScanner_CCO.OPOSScanner scanner = new OPOSScanner();

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Global Load Definitions

        private void FrmMain_Load(object sender, EventArgs e)
        {            
            initialLocation = this.Location;

            if (GetEmissionPointInformation())
            {
                CheckGridView();
                IsEnableScanner();
            }
            else
            {
                Close();
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
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {            
            GetProductInformation(
                                    emissionPoint.LocationId
                                    , TxtBarcode.Text
                                    , 1
                                    , currentCustomer.CustomerId
                                    , 0
                                    , ""
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

                try
                {
                    currentCustomer = clsCustomer.GetCustomerByIdentification(keyBoard.customerIdentification);

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
                    else
                    {
                        bool response = functions.ShowMessage("El cliente ingresado no esta registrado, desea ingresarlo?.", ClsEnums.MessageType.CONFIRM);

                        if (response)
                        {
                            FrmCustomer frmCustomer = new FrmCustomer();
                            frmCustomer.emissionPoint = emissionPoint;
                            frmCustomer.isNewCustomer = true;
                            frmCustomer.customerIdentification = keyBoard.customerIdentification;
                            frmCustomer.ShowDialog();

                            currentCustomer = frmCustomer.currentCustomer;

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
                                            , ex.InnerException.Message
                                        );
                }
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.loginInformation = loginInformation;
            frmMenu.Visible = true;
            scanner.DeviceEnabled = false;
            Close();
        }
        #endregion

        #region Right Side Buttons

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) <= 0)
            {
                functions.ShowMessage("El valor a pagar debe ser mayor a 0", ClsEnums.MessageType.WARNING);
            }
            else
            {
                FrmPayment payment = new FrmPayment();
                payment.invoiceAmount = decimal.Parse(LblTotal.Text);
                payment.customer = currentCustomer;
                payment.taxAmount = taxAmount;
                payment.baseAmount = baseAmount;
                payment.ShowDialog();

                if (payment.canCloseInvoice)
                {
                    if (payment.paymentXml.HasElements)
                    {
                        invoiceXml.Add(payment.paymentXml);
                        ClosingInvoice();
                    }
                }
            }
        }

        private void BtnProductSearch_Click(object sender, EventArgs e)
        {

        }

        private void BtnSuspendSale_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelSale_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Form Control Events
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetProductInformation(
                                        emissionPoint.LocationId
                                        , TxtBarcode.Text
                                        , 1
                                        , currentCustomer.CustomerId
                                        , 0
                                        , ""
                                        );
            }
        }

        private void IsEnableScanner()
        {
            bool isEnable = false;
            
            int isOpen = scanner.Open("USBScanner");

            if (isOpen == 0)
            {
                scanner.ClaimDevice(1000);

                if (scanner.Claimed)
                {
                    scanner.DeviceEnabled = true;
                    //isEnable = scanner.DeviceEnabled;
                }
            }

            //return isEnable;
        }
                
        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            this.Location = initialLocation;
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

        #region Main Functions

        private void GetProductInformation(
                                            short _locationId
                                            , string _barcode
                                            , decimal _qty
                                            , Int64 _customerId
                                            , int _internalCreditCardId
                                            , string _paymMode
                                            )
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans();
            SP_Product_Consult_Result result;
            bool updateRecord = false;
            decimal qtyFound;
            decimal amountFound;

            if (_barcode != "")
            {
                try
                {
                    string searchBarcode = _barcode;

                    if (searchBarcode.StartsWith("21"))
                    {
                        searchBarcode = searchBarcode.Replace(searchBarcode.Substring(7, 6),"000000");
                    }

                    var searchXml = from xm in invoiceXml.Descendants("InvoiceLine")
                                    where xm.Element("Barcode").Value == searchBarcode
                                    select xm;

                    foreach (var node in searchXml.Elements())
                    {
                        if (node.Name == "Quantity")
                        {
                            qtyFound = decimal.Parse(node.Value); 
                            _qty += qtyFound;
                            updateRecord = true;                            
                        }
                        else if (node.Name == "BaseAmount")
                        {
                            amountFound = decimal.Parse(node.Value);

                            string productCode = _barcode.Substring(0,7);
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
                            updateRecord = true;
                        }
                    }

                    result = clsInvoiceTrans.ProductConsult(
                                                            _locationId
                                                            , _barcode
                                                            , _qty
                                                            , _customerId
                                                            , _internalCreditCardId
                                                            , _paymMode
                                                            );

                    if (result != null)
                    {
                        AddRecordToSource(result, updateRecord);
                        CalculateInvoice();
                    }
                    else
                    {
                        functions.ShowMessage("El producto con codigo de barras " + _barcode + " no se encuentra registrado.", ClsEnums.MessageType.WARNING);
                        TxtBarcode.Text = "";
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
            try
            {
                ClsInvoiceTrans invoice = new ClsInvoiceTrans();                
                SP_Invoice_Insert_Result invoiceResult = null;
                XElement invoiceTableXml = new XElement("InvoiceTable");

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
                        PrintDocument print = new PrintDocument();

                        foreach (var line in invoiceTicket)
                        {                            
                            bodyText += line.BodyText + System.Environment.NewLine;                             
                        }


                        print.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                        {
                            e1.Graphics.DrawString(
                                                    bodyText
                                                    , new Font("Courier New", 7)
                                                    , new SolidBrush(Color.Black)
                                                    , new RectangleF(0, 0, print.DefaultPageSettings.PrintableArea.Width, print.DefaultPageSettings.PrintableArea.Height)
                                                    );
                        };

                        print.Print();
                        response = true;
                    }
                }
            }
            catch(Exception ex)
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

        private void AddRecordToSource(SP_Product_Consult_Result _productResult, bool _updateRecord)
        {
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
                    query.Element("Quantity").SetValue(_productResult.Quantity);
                    query.Element("FinalPrice").SetValue(_productResult.FinalPrice);
                    query.Element("LineDiscount").SetValue(_productResult.LineDiscount);
                    query.Element("LineAmount").SetValue(_productResult.LineAmount);
                }
            }

            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }

        private void CalculateInvoice()
        {
            decimal invoiceAmount = 0;
            decimal discAmount = 0;

            var line = from r in invoiceXml.Descendants("InvoiceLine")
                       select r;

            foreach (var item in line)
            {
                discAmount += decimal.Parse(item.Element("LineDiscount").Value);
                invoiceAmount += decimal.Parse(item.Element("LineAmount").Value);
                baseAmount += decimal.Parse(item.Element("BaseAmount").Value);
                taxAmount += decimal.Parse(item.Element("TaxAmount").Value);
            }

            LblTotal.Text = Math.Round(invoiceAmount, 2).ToString();
            LblDiscAmount.Text = Math.Round(discAmount, 2).ToString();
        }

        #endregion

        private void OPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            //UpdateEventHistory(Data Event);
            //ASCIIEncoding encoder = new ASCIIEncoding();

            try
            {
                // Display the ASCII encoded label text
                TxtBarcode.Text = OPOSScanner.ScanDataLabel;
                // Display the encoding type
                //TxtBarcode.Text = OPOSScanner.ScanDataType.ToString();
                // re-enable the data event for subsequent scans
                OPOSScanner.DataEventEnabled = true;

                GetProductInformation(
                                        emissionPoint.LocationId
                                        , TxtBarcode.Text
                                        , 1
                                        , currentCustomer.CustomerId
                                        , 0
                                        , ""
                                        );
            }
            catch (Exception ex)
            {
                // Log any errors
                //UpdateEventHistory(DataEvent Operation Failed);
            }
        }
    }
}