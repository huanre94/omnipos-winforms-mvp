using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmRedeemGiftCard : DevExpress.XtraEditors.XtraForm
    {
        List<SP_GiftCard_Consult_Result> result1;
        ClsFunctions functions = new ClsFunctions();
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        public bool formActionResult;
        public decimal giftcardAmount;
        public string giftcardNumber;
        public decimal paidAmount;
        EmissionPoint emissionPoint;
        ClsCatchWeight catchWeight;
        ClsEnums.ScaleBrands scaleBrand;
        private string portName = "";

        public FrmRedeemGiftCard()
        {
            InitializeComponent();
        }     

        #region Control Events
        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.GIFTCARD_NUMBER;
            keyPad.ShowDialog();
            TxtGiftCardNumber.Text = keyPad.giftcardNumber;
        }

        private void BtnBarcodeKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.GIFTCARD_NUMBER;
            keyPad.ShowDialog();
            TxtBarcode.Text = keyPad.giftcardNumber;
            TxtBarcode.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void BtnIdentificationKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERNAME;
            keyBoard.ShowDialog();
            TxtRedeemIdentification.Text = keyBoard.checkOwnerName;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtGiftCardNumber.Text != "")
            {
                ClsCustomerTrans customer = new ClsCustomerTrans();

                try
                {
                    result1 = customer.GetGiftCardProducts(TxtGiftCardNumber.Text);
                    SP_GiftCard_Consult_Result result = result1[0];
                    if (result1 != null)
                    {
                        if (result.Type == "CC")
                        {
                            bool status = false;
                            BtnAccept.Enabled = status;
                            TxtRedeemIdentification.Enabled = status;
                            TxtRedeemName.Enabled = status;
                            TxtBarcode.Enabled = status;
                            BtnBarcodeKeyPad.Enabled = status;
                            BtnIdentificationKeyPad.Enabled = status;
                            BtnRedeemCustomerName.Enabled = status;
                            BtnRemove.Enabled = status;

                            functions.ShowMessage("El bono ingresado es de consumo. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardStatus.Text = "bono tipo consumo".ToUpper();
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else if (DateTime.Today.CompareTo(result.Expiration) > 0)
                        {
                            bool status = false;
                            BtnAccept.Enabled = status;
                            TxtRedeemIdentification.Enabled = status;
                            TxtRedeemName.Enabled = status;
                            TxtBarcode.Enabled = status;
                            BtnBarcodeKeyPad.Enabled = status;
                            BtnIdentificationKeyPad.Enabled = status;
                            BtnRedeemCustomerName.Enabled = status;
                            BtnRemove.Enabled = status;

                            LblGiftCardStatus.Text = "expirado".ToUpper();
                            functions.ShowMessage("El bono ingresado esta caducado. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else if (result.StatusLine == "C")
                        {
                            bool status = false;
                            BtnAccept.Enabled = status;
                            TxtRedeemIdentification.Enabled = status;
                            TxtRedeemName.Enabled = status;
                            TxtBarcode.Enabled = status;
                            BtnBarcodeKeyPad.Enabled = status;
                            BtnIdentificationKeyPad.Enabled = status;
                            BtnRedeemCustomerName.Enabled = status;
                            BtnRemove.Enabled = status;

                            LblGiftCardStatus.Text = "consumido".ToUpper();
                            functions.ShowMessage("El bono ingresado ya fue consumido. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else if (result.StatusLine == "I")
                        {
                            bool status = false;
                            BtnAccept.Enabled = status;
                            TxtRedeemIdentification.Enabled = status;
                            TxtRedeemName.Enabled = status;
                            TxtBarcode.Enabled = status;
                            BtnBarcodeKeyPad.Enabled = status;
                            BtnIdentificationKeyPad.Enabled = status;
                            BtnRedeemCustomerName.Enabled = status;
                            BtnRemove.Enabled = status;

                            LblGiftCardStatus.Text = "anulado".ToUpper();
                            functions.ShowMessage("El bono ingresado esta anulado. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else
                        {
                            bool status = true;
                            BtnAccept.Enabled = status;
                            TxtRedeemIdentification.Enabled = status;
                            TxtRedeemName.Enabled = status;
                            TxtBarcode.Enabled = status;
                            BtnBarcodeKeyPad.Enabled = status;
                            BtnIdentificationKeyPad.Enabled = status;
                            BtnRedeemCustomerName.Enabled = status;
                            BtnRemove.Enabled = status;

                            BtnAccept.Enabled = true;
                            LblGiftCardStatus.Text = "activo".ToUpper();
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                            giftcardNumber = result.GiftCardNumber;
                            //LblAmount.Text = giftcardAmount.ToString
                        }
                    }
                    else
                    {
                        functions.ShowMessage("No existe bono con el numero ingresado.", ClsEnums.MessageType.WARNING);
                        TxtGiftCardNumber.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al consultar el bono."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                            );
                }

            }
        }

        private void BtnRedeemCustomerName_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERNAME;
            keyBoard.ShowDialog();
            TxtRedeemName.Text = keyBoard.checkOwnerName;
        }

        private void FrmRedeemGiftCard_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                if (emissionPoint.ScaleBrand != "")
                {
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
                    }
                }
                LblCashierUser.Text = loginInformation.UserName;
                CheckGridView();
                ClearGiftCard();
            }
        }

        private void CheckGridView()
        {
            GrvProduct.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcProduct.DataSource = null;
            GrvProduct.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_Product_Consult_Result> bindingList = new BindingList<SP_Product_Consult_Result>();
            bindingList.AllowNew = true;

            GrcProduct.DataSource = bindingList;
        }
        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtGiftCardNumber.Text == "")
            {
                functions.ShowMessage("El numero de bono no puede estar vacio.", ClsEnums.MessageType.WARNING);
                return;
            }
            else if (TxtRedeemIdentification.Text == "" || TxtRedeemName.Text == "")
            {
                functions.ShowMessage("Los datos del canje no pueden estar vacios.", ClsEnums.MessageType.WARNING);
                return;
            }
            else if (((BindingList<SP_Product_Consult_Result>)GrvProduct.DataSource).Count == 0)
            {
                functions.ShowMessage("Debe existir productos registrados.", ClsEnums.MessageType.WARNING);
                return;
            }
            else
            {
                functions.emissionPoint = emissionPoint;

                if (functions.RequestSupervisorAuth(requireMotive: false))
                {
                    XElement giftCardLine = new XElement("GiftCardLine");
                    BindingList<SP_Product_Consult_Result> dataSource = (BindingList<SP_Product_Consult_Result>)GrvProduct.DataSource;
                    foreach (SP_Product_Consult_Result item in dataSource)
                    {
                        XElement giftCardTrans = new XElement("GiftCardTrans");
                        GiftCardTrans gift = new GiftCardTrans();
                        gift.ProductId = item.ProductId;
                        gift.Quantity = (decimal)item.Quantity;
                        gift.RedeemQuantity = 1;
                        Type type = gift.GetType();
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (var prop in properties)
                        {
                            var name = prop.Name;
                            var value = prop.GetValue(gift);
                            if (value == null)
                            {
                                value = "";
                            }
                            giftCardTrans.Add(new XElement(name, value));
                        }
                        giftCardLine.Add(giftCardTrans);
                    }
                    try
                    {
                        SP_GiftCardRedeem_Insert_Result response = new ClsCustomerTrans().GiftCardRedeemInsert(TxtGiftCardNumber.Text,
                            TxtRedeemName.Text,
                            TxtRedeemIdentification.Text,
                            emissionPoint.LocationId,
                            giftCardLine.ToString());

                        if (!(bool)response.Error)
                        {
                            functions.ShowMessage("Bono canjeado exitosamente.", ClsEnums.MessageType.INFO);
                            ClearGiftCard();
                        }
                        else
                        {
                            functions.ShowMessage("Bono no pudo ser canjeado.", ClsEnums.MessageType.INFO);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage(
                                                 "Ocurrio un problema al canjear bono."
                                                 , ClsEnums.MessageType.ERROR
                                                 , true
                                                 , ex.InnerException.Message
                                                 );
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.loginInformation = loginInformation;
            frmMenu.globalParameters = globalParameters;
            frmMenu.Visible = true;
            Close();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetProductInformation(
                                        emissionPoint.LocationId
                                        , TxtBarcode.Text
                                        , 1
                                        , 1
                                        , 1
                                        , ""
                                        , false
                                    );
            }
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }
        #endregion

        #region Functions

        private void ClearGiftCard()
        {
            LblGiftCardStatus.Text = "Pendiente".ToUpper();
            TxtGiftCardNumber.Text = string.Empty;
            TxtRedeemName.Text = string.Empty;
            TxtRedeemIdentification.Text = string.Empty;
            LblExpirationDate.Text = DateTime.Today.ToString();

            bool status = false;
            BtnAccept.Enabled = status;            
            TxtRedeemIdentification.Enabled = status;
            TxtRedeemName.Enabled = status;
            TxtBarcode.Enabled = status;
            BtnBarcodeKeyPad.Enabled = status;
            BtnIdentificationKeyPad.Enabled = status;
            BtnRedeemCustomerName.Enabled = status;
            BtnRemove.Enabled = status;

            CheckGridView();
        }

        private void AddRecordToGrid(SP_Product_Consult_Result _productResult, bool _updateRecord)
        {
            Type type = _productResult.GetType();
            PropertyInfo[] properties = type.GetProperties();

            if (!_updateRecord)
            {
                GrvProduct.AddNewRow();
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["ProductId"], _productResult.ProductId);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["ProductName"], _productResult.ProductName);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["Quantity"], _productResult.Quantity);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["FinalPrice"], _productResult.FinalPrice);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["LineDiscount"], _productResult.LineDiscount);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["LineAmount"], _productResult.LineAmount);
                GrvProduct.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                int rowIndex = GrvProduct.LocateByValue("ProductId", _productResult.ProductId);

                if (rowIndex < 0)
                {
                    rowIndex = GrvProduct.FocusedRowHandle;
                }

                GrvProduct.FocusedRowHandle = rowIndex;
                GrvProduct.UpdateCurrentRow();
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["ProductId"], _productResult.ProductId);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["ProductName"], _productResult.ProductName);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["Quantity"], _productResult.Quantity);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["FinalPrice"], _productResult.FinalPrice);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["LineDiscount"], _productResult.LineDiscount);
                GrvProduct.SetRowCellValue(GrvProduct.FocusedRowHandle, GrvProduct.Columns["LineAmount"], _productResult.LineAmount);
                GrvProduct.Appearance.HideSelectionRow.BackColor = Color.FromArgb(184, 255, 61);
            }

            TxtBarcode.Text = "";
            TxtBarcode.Focus();
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

            if (emissionPoint != null)
            {
                response = true;
                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

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
            decimal qtyFound = 0;
            decimal amountFound = 0;
            decimal amountTaxFound = 0;
            bool useWeightControl = false;
            bool useCatchWeight = false;
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

                            if (true)
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

                                        AddRecordToGrid(result, false);
                                    }
                                    else
                                    {
                                        functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", ClsEnums.MessageType.WARNING);
                                    }
                                }
                            }
                        }
                        else
                        {
                            AddRecordToGrid(result, false);
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
        #endregion

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvProduct.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a eliminar.", ClsEnums.MessageType.ERROR);
            }
            else
            {
                SP_Product_Consult_Result selectedRow = (SP_Product_Consult_Result)GrvProduct.GetRow(rowIndex);

                BindingList<SP_Product_Consult_Result> dataSource = (BindingList<SP_Product_Consult_Result>)GrvProduct.DataSource;
                foreach (SP_Product_Consult_Result item in dataSource)
                {
                    if (item.ProductId == selectedRow.ProductId)
                    {
                        dataSource.Remove(item);
                        break;
                    }
                }

                GrcProduct.DataSource = dataSource;
            }

            TxtBarcode.Focus();
        }        
    }
}