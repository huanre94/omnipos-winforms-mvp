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
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmSalesOrderEcommerce : DevExpress.XtraEditors.XtraForm
    {
        public SP_Login_Consult_Result loginInformation;
        public long salesOrderId;
        public EmissionPoint emissionPoint;
        SalesOrder salesOrder;
        readonly ClsFunctions functions = new ClsFunctions();
        ClsSalesOrderTrans sales = new ClsSalesOrderTrans();
        XElement salesOrderXml = new XElement("SalesOrder");
        public List<GlobalParameter> globalParameters;
        ClsEnums.ScaleBrands scaleBrand;
        private string portName = "";
        public bool isUpdated = false;

        public FrmSalesOrderEcommerce()
        {
            InitializeComponent();
         }

        private void EnableKeypad(bool status)
        {
            BtnQty.Enabled = status;
            BtnRemove.Enabled = status;
            BtnEnter.Enabled = status;
            BtnDelete.Enabled = status;
            Btn0.Enabled = status;
            Btn1.Enabled = status;
            Btn2.Enabled = status;
            Btn3.Enabled = status;
            Btn4.Enabled = status;
            Btn5.Enabled = status;
            Btn6.Enabled = status;
            Btn7.Enabled = status;
            Btn8.Enabled = status;
            Btn9.Enabled = status;
            TxtBarcode.Enabled = status;
        }

        private void LoadSalesOrder()
        {
            LblSalesOrderNumber.Text = salesOrder.SalesOrderId.ToString();
            Customer customer = new ClsCustomer().GetCustomerById(salesOrder.CustomerId);
            LblCustomerId.Text = customer.Identification;
            LblCustomerName.Text = customer.Firtsname + ' ' + customer.Lastname;
            LblCustomerAddress.Text = customer.Address;
            LblCustomerTelephoneNumber.Text = customer.Phone;
            LblObservation.Text = salesOrder.Observation;

            List<CustomerAddress> customerAddress = new ClsCustomer().GetCustomerAddressesById(customer);
            CustomerAddress selectedAddress = (from ca in customerAddress
                                               where ca.CustomerAddressId == salesOrder.CustomerAddressId
                                               select ca).FirstOrDefault();
            LblDeliveryAddress.Text = selectedAddress.Address;
            LblDeliveryAddressRef.Text = selectedAddress.AddressReference;
            bool canAddNewItems = !(salesOrder.OrderECommerce > 0);
            CheckGridView(canAddNewItems);
            EnableKeypad(canAddNewItems);

            var list = new ClsSalesOrder().GetSalesOrderProductsById(salesOrder.SalesOrderId);
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    AddRecordToGrid(item, false, item.Barcode);
                }
                CalculateInvoice();
            }
        }

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
                , salesOrder.CustomerId
                , 1
                , ""
                , false
            );
        }
        #endregion

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
            dynamic result;
            bool updateRecord = false;
            decimal qtyFound = 0;
            decimal amountFound = 0;
            decimal amountTaxFound = 0;
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
                        int barcodeLength = searchBarcode.Length;
                        searchBarcode = searchBarcode.Substring(0, 7);
                        searchBarcode = searchBarcode.PadRight(barcodeLength, '0');
                    }


                    var searchXml = from xm in salesOrderXml.Descendants("SalesOrderLine")
                                    where xm.Element("Barcode").Value == searchBarcode
                                    || xm.Element("Barcode").Value == _barcode
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
                            case "BaseTaxAmount":
                                amountTaxFound = decimal.Parse(node.Value);
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
                        if (result.Price == 0)
                        {
                            functions.ShowMessage("No se puede procesar un producto con precio cero.", ClsEnums.MessageType.WARNING);
                            return;
                        }

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
                                                                                        , false

                                                                                    );
                                }
                            }
                        }

                        if (canInsert)
                        {
                            AddRecordToGrid(
                                            result
                                            , updateRecord
                                            , _barcode
                                            );
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddRecordToGrid(SP_SalesOrderProduct_Consult_Result _productResult
                                     , bool _updateRecord
                                     , string _barcode)
        {
            Type type = _productResult.GetType();
            PropertyInfo[] properties = type.GetProperties();
            XElement salesOrderLineXml = new XElement("SalesOrderLine");


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

                    salesOrderLineXml.Add(new XElement(name, value));
                }

                salesOrderXml.Add(salesOrderLineXml);
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

                var updateQuery = from r in salesOrderXml.Descendants("SalesOrderLine")
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
                    query.Element("BarcodeBefore").SetValue(_barcode);
                }
            }

            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }

        private void CalculateInvoice()
        {
            decimal invoiceAmount = 0.00M;
            decimal discAmount = 0.00M;

            var line = from r in salesOrderXml.Descendants("SalesOrderLine")
                       select r;

            foreach (var item in line)
            {
                discAmount += decimal.Parse(item.Element("LineDiscount").Value);
                invoiceAmount += decimal.Parse(item.Element("LineAmount").Value);
            }

            LblTotal.Text = Math.Round(invoiceAmount, 2).ToString();
            LblDiscAmount.Text = Math.Round(discAmount, 2).ToString();
        }

        private void CheckGridView(bool canAddNewItem)
        {
            GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesDetail.DataSource = null;
            if (canAddNewItem)
            {
                GrvSalesDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            }

            BindingList<SP_SalesOrderProduct_Consult_Result> bindingList = new BindingList<SP_SalesOrderProduct_Consult_Result>();
            bindingList.AllowNew = true;

            GrcSalesDetail.DataSource = bindingList;
        }

        private void BtnCancelSale_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("¿Esta seguro de cancelar la orden?", ClsEnums.MessageType.CONFIRM))
            {
                functions.emissionPoint = emissionPoint;
                bool isApproved = functions.RequestSupervisorAuth(false, 0);
                if (isApproved)
                {
                    sales.loginInformation = loginInformation;
                    if (sales.CancelSalesOrder(salesOrder.SalesOrderId))
                    {
                        isUpdated = true;
                        functions.ShowMessage("Orden Cancelada Exitosamente", ClsEnums.MessageType.INFO);
                        Close();
                    }
                    else
                    {
                        functions.ShowMessage("Orden no pudo ser cancelada, valide que no este ingresada en una guia.", ClsEnums.MessageType.WARNING);
                    }
                }
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(LblTotal.Text) == 0)
            {
                functions.ShowMessage("No existen elementos a guardar.", ClsEnums.MessageType.INFO);
                return;
            }

            if (functions.ShowMessage("Se procedera a guardar los cambios en la orden ¿Desea continuar?", ClsEnums.MessageType.CONFIRM))
            {
                try
                {
                    (from li in salesOrderXml.Descendants("SalesOrderPayment") select li).Remove();
                    //TODO validar metodo pago 
                    XElement salesOrderPayment = new XElement("SalesOrderPayment");
                    SalesOrderPayment payment = new SalesOrderPayment()
                    {
                        Amount = decimal.Parse(LblTotal.Text),
                        PaymModeId = (int)ClsEnums.PaymModeEnum.EFECTIVO,
                        Authorization = string.Empty
                    };

                    Type type = payment.GetType();
                    PropertyInfo[] properties = type.GetProperties();

                    foreach (var prop in properties)
                    {
                        var name = prop.Name;
                        var value = prop.GetValue(payment);

                        if (value == null)
                        {
                            value = "";
                        }

                        salesOrderPayment.Add(new XElement(name, value));
                    }
                    salesOrderXml.Add(salesOrderPayment);

                    sales.loginInformation = loginInformation;
                    SP_SalesOrderOmnipos_Insert_Result result = sales.CreateOrUpdateSalesOrder(salesOrderXml.ToString(), salesOrderId);
                    if ((bool)!result.Error)
                    {
                        isUpdated = true;
                        functions.ShowMessage("Detalles de la orden fueron guardados correctamente", ClsEnums.MessageType.INFO);
                    }
                    else
                    {
                        functions.ShowMessage("Existio un error al momento de guardar los detalles de la orden", ClsEnums.MessageType.WARNING, true, result.TextError);
                    }
                }
                catch (Exception ex)
                {

                    functions.ShowMessage("Ocurrio un error al cargar Orden de Venta", ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
                }


            }
        }

        private void BtnFinishOrder_Click(object sender, EventArgs e)
        {
            functions.emissionPoint = emissionPoint;
            if (functions.ShowMessage("Esta seguro de finalizar la orden? Posterior a esto la orden solo podra ser agregada a una guia de remision", ClsEnums.MessageType.CONFIRM))
            {
                sales.loginInformation = loginInformation;
                if (sales.FinishSalesOrder(salesOrder.SalesOrderId))
                {
                    isUpdated = true;
                    functions.PrintDocument(salesOrderId, ClsEnums.DocumentType.SALESORDER, false);
                    functions.ShowMessage("Orden cambiada a Packing Exitosamente", ClsEnums.MessageType.INFO);
                    Close();
                }
            }
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
                bool isApproved = functions.RequestSupervisorAuth(false, 0);
                if (isApproved)
                {
                    SP_SalesOrderProduct_Consult_Result selectedRow = (SP_SalesOrderProduct_Consult_Result)GrvSalesDetail.GetRow(rowIndex);

                    BindingList<SP_SalesOrderProduct_Consult_Result> dataSource = (BindingList<SP_SalesOrderProduct_Consult_Result>)GrvSalesDetail.DataSource;
                    foreach (var item in dataSource)
                    {
                        if (item.ProductId == selectedRow.ProductId)
                        {
                            dataSource.Remove(item);
                            break;
                        }
                    }

                    var newInvoiceXML = from xm in salesOrderXml.Descendants("SalesOrderLine")
                                        where long.Parse(xm.Element("ProductId").Value) == selectedRow.ProductId
                                        select xm;

                    XElement element = null;
                    if (newInvoiceXML.Count() == 1)
                    {
                        element = newInvoiceXML.First();
                    }

                    newInvoiceXML.Remove();

                    CalculateInvoice();
                    GrcSalesDetail.DataSource = dataSource;
                }
            }

            TxtBarcode.Focus();
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = new ClsGeneral().GetEmissionPointByIP(addressIP);
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
                return false;
            }

            try
            {
                emissionPoint = new ClsGeneral().GetEmissionPointByIP(addressIP);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                    ClsEnums.MessageType.ERROR,
                    true,
                    ex.Message);
            }


            if (emissionPoint == null)
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                return false;
            }

            functions.PrinterName = emissionPoint.PrinterName;
            LblCashier.Text = loginInformation.UserName;

            return true;
        }

        private void FrmSalesOrderEcommerce_Load(object sender, EventArgs e)
        {
            try
            {
                if (GetEmissionPointInformation())
                {
                    if (emissionPoint.ScaleBrand != "")
                    {
                        scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

                        if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                        {
                            functions.AxOPOSScanner = AxOPOSScanner;
                            //functions.EnableScanner(emissionPoint.ScanBarcodeName);
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
                        }
                    }

                    salesOrder = new ClsSalesOrder().GetSalesOrderById(salesOrderId);
                    if (salesOrder == null)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        LoadSalesOrder();
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un error al cargar Orden de Venta", ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void FrmSalesOrderEcommerce_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
            }
        }
    }
}