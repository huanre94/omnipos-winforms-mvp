using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmRedeemGiftCard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal giftcardAmount;
        public string giftcardNumber;
        public decimal paidAmount;
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
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
                SP_GiftCard_Consult_Result result;
                ClsCustomerTrans customer = new ClsCustomerTrans();

                try
                {
                    result = customer.GetGiftCard(TxtGiftCardNumber.Text);

                    if (result != null)
                    {
                        if (result.Type == "CC")
                        {
                            functions.ShowMessage("El bono ingresado es de consumo. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else if (DateTime.Today.CompareTo(((DateTime)result.Expiration).Date) > 0)
                        {
                            functions.ShowMessage("El bono ingresado esta caducado. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else if (result.StatusLine != "A")
                        {
                            functions.ShowMessage("El bono ingresado esta anulado. Consulte con Supervisor.", ClsEnums.MessageType.WARNING);
                            LblGiftCardInvoice.Text = result.InvoiceNumber;
                            LblCustomerNameRegistered.Text = result.CustomerNameInvoice;
                            LblExpirationDate.Text = result.Expiration.ToString();
                        }
                        else
                        {
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
                ClearGiftCard();
            }
        }
       
        private void BtnAccept_Click(object sender, EventArgs e)
        {
            bool valida = true;
            if (TxtGiftCardNumber.Text == "")
            {
                functions.ShowMessage("El numero de bono no puede estar vacio.", ClsEnums.MessageType.WARNING);
                return;
            }

            if (TxtRedeemIdentification.Text == "" || TxtRedeemName.Text == "") {
                functions.ShowMessage("Los datos del canje no pueden estar vacios.", ClsEnums.MessageType.WARNING);
                return;
            }

            if (valida)
            {
                
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
            LblExpirationDate.Text = DateTime.Today.ToString();
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

                                        TxtProductDescription.Text = result.ProductName;
                                        LblWeightValue.Text = weight.ToString("");
                                    }
                                    else
                                    {
                                        functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", ClsEnums.MessageType.WARNING);
                                    }
                                }
                            }
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
    }
}