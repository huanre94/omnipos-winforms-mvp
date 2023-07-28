using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmRedeemGiftCard : DevExpress.XtraEditors.XtraForm
    {
        List<SP_GiftCard_Consult_Result> result;
        readonly ClsFunctions functions = new ClsFunctions();
        public IEnumerable<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        public bool formActionResult;
        public decimal giftcardAmount;
        public string giftcardNumber;
        public decimal paidAmount;
        EmissionPoint emissionPoint;
        ClsCatchWeight catchWeight;
        ScaleBrands scaleBrand;
        private string portName = "";

        public FrmRedeemGiftCard()
        {
            InitializeComponent();
        }

        #region Control Events
        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.GIFTCARD_NUMBER);
            keyPad.ShowDialog();
            TxtGiftCardNumber.Text = keyPad.GetValue();
            TxtGiftCardNumber.Focus();//08/07/2022
        }

        private void BtnBarcodeKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.GIFTCARD_NUMBER);
            keyPad.ShowDialog();

            TxtBarcode.Text = keyPad.GetValue();
            TxtBarcode.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void BtnIdentificationKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = InputFromOption.CHECK_OWNERNAME
            };
            keyBoard.ShowDialog();
            TxtRedeemIdentification.Text = keyBoard.checkOwnerName;
            TxtRedeemIdentification.Focus();//08/07/2022
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtGiftCardNumber.Text == string.Empty)
            {
                functions.ShowMessage("Campo # Bono no puede estar vacio.", MessageType.WARNING);
                ClearGiftCard();
                return;
            }

            try
            {
                result = new GiftcardRepository(Program.customConnectionString).GetGiftCardProducts(TxtGiftCardNumber.Text);
                if (result.Count() == 0)
                {
                    functions.ShowMessage("No existe bono con el numero ingresado.", MessageType.WARNING);
                    TxtGiftCardNumber.Text = "";
                    return;
                }

                SP_GiftCard_Consult_Result giftcard = result[0];
                if (result == null)
                {
                    functions.ShowMessage("No existe bono con el numero ingresado.", MessageType.WARNING);
                    TxtGiftCardNumber.Text = "";
                    return;
                }

                if (giftcard.Type == "CC")
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

                    functions.ShowMessage("El bono ingresado es de consumo. Consulte con Supervisor.", MessageType.WARNING);
                    LblGiftCardStatus.Text = "bono tipo consumo".ToUpper();
                    LblGiftCardInvoice.Text = giftcard.InvoiceNumber;
                    LblCustomerNameRegistered.Text = giftcard.CustomerNameInvoice;
                    LblExpirationDate.Text = giftcard.Expiration.ToString();
                    return;
                }

                if (DateTime.Today.CompareTo(giftcard.Expiration) > 0)
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
                    functions.ShowMessage("El bono ingresado esta caducado. Consulte con Supervisor.", MessageType.WARNING);
                    LblGiftCardInvoice.Text = giftcard.InvoiceNumber;
                    LblCustomerNameRegistered.Text = giftcard.CustomerNameInvoice;
                    LblExpirationDate.Text = giftcard.Expiration.ToString();
                    return;
                }


                switch (giftcard.StatusLine)
                {
                    case "C":
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
                            functions.ShowMessage("El bono ingresado ya fue consumido. Consulte con Supervisor.", MessageType.WARNING);
                            LblGiftCardInvoice.Text = giftcard.InvoiceNumber;
                            LblCustomerNameRegistered.Text = giftcard.CustomerNameInvoice;
                            LblExpirationDate.Text = giftcard.Expiration.ToString();
                            break;
                        }

                    case "I":
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
                            functions.ShowMessage("El bono ingresado esta anulado. Consulte con Supervisor.", MessageType.WARNING);
                            LblGiftCardInvoice.Text = giftcard.InvoiceNumber;
                            LblCustomerNameRegistered.Text = giftcard.CustomerNameInvoice;
                            LblExpirationDate.Text = giftcard.Expiration.ToString();
                            break;
                        }

                    default:
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
                            LblGiftCardInvoice.Text = giftcard.InvoiceNumber;
                            LblCustomerNameRegistered.Text = giftcard.CustomerNameInvoice;
                            LblExpirationDate.Text = giftcard.Expiration.ToString();
                            giftcardNumber = giftcard.GiftCardNumber;
                            break;
                            //LblAmount.Text = giftcardAmount.ToString
                        }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al consultar el bono.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

        }

        private void BtnRedeemCustomerName_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CHECK_OWNERNAME
            };
            keyBoard.ShowDialog();
            TxtRedeemName.Text = keyBoard.checkOwnerName;
        }

        private void FrmRedeemGiftCard_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation(loginInformation.AddressIP))
            {
                if (emissionPoint.ScaleBrand != "")
                {
                    scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

                    switch (scaleBrand)
                    {
                        case ScaleBrands.DATALOGIC:
                            catchWeight = new ClsCatchWeight(scaleBrand)
                            {
                                AxOPOSScale = AxOPOSScale
                            };
                            catchWeight.EnableScale(emissionPoint.ScaleName);
                            functions.AxOPOSScanner = AxOPOSScanner;
                            functions.EnableScanner(emissionPoint.ScanBarcodeName);
                            break;
                        default:
                            {
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
                }
                LblCashierUser.Text = loginInformation.UserName;
                CheckGridView();
                ClearGiftCard();
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtGiftCardNumber.Text.Equals(""))
            {
                functions.ShowMessage("El numero de bono no puede estar vacio.", MessageType.WARNING);
                return;
            }

            if (TxtRedeemIdentification.Text.Equals("") && TxtRedeemName.Text.Equals(""))
            {
                functions.ShowMessage("Los datos del canje no pueden estar vacios.", MessageType.WARNING);
                return;
            }

            if (((BindingList<SP_Product_Consult_Result>)GrvProduct.DataSource).Count == 0)
            {
                functions.ShowMessage("Debe existir productos registrados.", MessageType.WARNING);
                return;
            }

            functions.emissionPoint = emissionPoint;
            if (functions.RequestSupervisorAuth())
            {
                XElement giftCardLine = new XElement("GiftCardLine");
                BindingList<SP_Product_Consult_Result> dataSource = (BindingList<SP_Product_Consult_Result>)GrvProduct.DataSource;
                foreach (SP_Product_Consult_Result item in dataSource)
                {
                    XElement giftCardTrans = new XElement("GiftCardTrans");

                    GiftCardTrans gift = new GiftCardTrans
                    {
                        ProductId = item.ProductId,
                        Quantity = (decimal)item.Quantity,
                        RedeemQuantity = 1
                    };

                    Type type = gift.GetType();
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo prop in properties)
                    {
                        string name = prop.Name;
                        object value = prop.GetValue(gift);
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
                    SP_GiftCardRedeem_Insert_Result response = new GiftcardRepository(Program.customConnectionString).GiftCardRedeemInsert(TxtGiftCardNumber.Text,
                        TxtRedeemName.Text,
                        TxtRedeemIdentification.Text,
                        emissionPoint.LocationId,
                       $"{giftCardLine}");

                    if ((bool)response.Error)
                    {
                        functions.ShowMessage("Bono no pudo ser canjeado.", MessageType.INFO, true, response.TextError);
                        return;
                    }

                    functions.ShowMessage("Bono canjeado exitosamente.", MessageType.INFO);
                    ClearGiftCard();
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al canjear bono.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu()
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters,
                Visible = true
            };
            Close();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GrcProduct.Focus();
                    break;
                case Keys.F1:
                    BtnBarcodeKeyPad_Click(null, null);
                    break;
                default:
                    break;
            }

            if (e.KeyCode == Keys.Enter)
            {
                ProductConsultDto dto = new ProductConsultDto();

                GetProductInformation(emissionPoint.LocationId,
                                      TxtBarcode.Text,
                                      1,
                                      1,
                                      1,
                                      "",
                                      false);
            }
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvProduct.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a eliminar.", MessageType.ERROR);
                return;
            }

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
            ClearBarcode();
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

            EnableControls(false);

            CheckGridView();
        }

        private void EnableControls(bool status)
        {
            BtnAccept.Enabled = status;
            TxtRedeemIdentification.Enabled = status;
            TxtRedeemName.Enabled = status;
            TxtBarcode.Enabled = status;
            BtnBarcodeKeyPad.Enabled = status;
            BtnIdentificationKeyPad.Enabled = status;
            BtnRedeemCustomerName.Enabled = status;
            BtnRemove.Enabled = status;
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

            ClearBarcode();
        }

        private bool GetEmissionPointInformation(string addressIP)
        {
            if (addressIP == "")
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

            functions.PrinterName = emissionPoint.PrinterName;
            return true;
        }

        private void CheckGridView()
        {
            GrvProduct.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcProduct.DataSource = null;
            GrvProduct.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_Product_Consult_Result> bindingList = new BindingList<SP_Product_Consult_Result>
            {
                AllowNew = true
            };

            GrcProduct.DataSource = bindingList;
        }

        private void GetProductInformation(short _locationId,
                                           string _barcode,
                                           decimal _qty,
                                           long _customerId,
                                           long _internalCreditCardId,
                                           string _paymMode,
                                           bool _skipCatchWeight)
        {
            decimal qtyFound = 0;
            decimal amountFound = 0;
            decimal amountTaxFound = 0;
            bool useWeightControl = false;
            bool useCatchWeight = false;
            string barcodeBefore = _barcode;

            if (_barcode == "")
            {
                functions.ShowMessage("El código de barras no puede estar vacío.", MessageType.WARNING);
                return;
            }

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

                SP_Product_Consult_Result result = new ProductRepository(Program.customConnectionString).ProductConsult(
                                            _locationId
                                            , _barcode
                                            , _qty
                                            , _customerId
                                            , _internalCreditCardId
                                            , _paymMode
                                            , barcodeBefore);

                if (result == null)
                {
                    functions.ShowMessage($"El producto con codigo de barras {_barcode} no se encuentra registrado.", MessageType.WARNING);
                    ClearBarcode();
                    return;
                }

                if ((bool)result.WeightControl)
                {
                    functions.globalParameters = globalParameters;

                    if (!_skipCatchWeight)
                    {
                        decimal weight = functions.CatchWeightProduct(AxOPOSScale,
                                                                      result,
                                                                      scaleBrand,
                                                                      portName);

                        if (weight <= 0)
                        {
                            functions.ShowMessage("La cantidad tiene que ser mayor a cero. Vuelva a seleccionar el Producto.", MessageType.WARNING);
                            return;
                        }

                        result = new ProductRepository(Program.customConnectionString).ProductConsult(_locationId,
                                                                                                    _barcode,
                                                                                                    weight + qtyFound,
                                                                                                    _customerId,
                                                                                                    _internalCreditCardId,
                                                                                                    _paymMode,
                                                                                                    barcodeBefore);

                        AddRecordToGrid(result, false);

                    }
                }
                else
                {
                    AddRecordToGrid(result, false);
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Hubo un problema al consultar producto.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private void ClearBarcode()
        {
            TxtBarcode.Text = "";
            TxtBarcode.Focus();
        }
        #endregion

        private void TxtGiftCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F1:
                    BtnKeyPad_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtRedeemIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtRedeemName.Focus();
                    break;
                case Keys.F1:
                    BtnIdentificationKeyPad_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtRedeemName_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtBarcode.Focus();
                    break;
                case Keys.F1:
                    BtnRedeemCustomerName_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void GrcProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.F11:
                    BtnRemove_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}