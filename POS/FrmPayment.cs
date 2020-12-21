using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmPayment : DevExpress.XtraEditors.XtraForm
    {
        #region Global Load Definitions

        ClsFunctions functions = new ClsFunctions();
        public XElement paymentXml = new XElement("Payment");
        public Customer customer = null;
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;
        public decimal invoiceAmount = 0;
        decimal paidAmount = 0;
        decimal pendingAmount = 0;
        decimal changeAmount = 0;
        public bool canCloseInvoice = false;
        public decimal baseAmount = 0;
        public decimal taxAmount = 0;
        public AxOposScanner_CCO.AxOPOSScanner scanner;
        public string internalCreditCardCode = "";

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            CheckGridView();
            GetPaymentInformation();
        }

        private void GetPaymentInformation()
        {
            LblTotal.Text = invoiceAmount.ToString();
            TxtAmount.Text = invoiceAmount.ToString();
            pendingAmount = invoiceAmount;
            LblPending.Text = pendingAmount.ToString();

            bool customerRetention = customer.UseRetention ?? false;
            if (customerRetention)
            {
                if (functions.ShowMessage("El cliente seleccionado genera retención. ¿Desea registrarla ahora?", ClsEnums.MessageType.CONFIRM))
                {
                    Withhold();
                }
            }

        }
        #endregion

        #region Control Validations
        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region Keypad Buttons
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtAmount.Text += "9";
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!TxtAmount.Text.Contains("."))
            {
                TxtAmount.Text += ".";
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtAmount.Text = "";
        }

        #endregion

        #region Payment Buttons      

        private void BtnCash_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                Cash();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnCreditCard_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                CreditCard();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                Check();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnInternalCredit_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                InternalCredit();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnGiftcard_Click(object sender, EventArgs e)
        {
            if (TxtAmount.Text != "")
            {
                GiftCard();
            }
            else
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", ClsEnums.MessageType.WARNING);
            }
        }

        private void BtnWithhold_Click(object sender, EventArgs e)
        {
            if (taxAmount == 0 && baseAmount == 0)
            {
                functions.ShowMessage("La venta no aplica retención, la base imponible es cero", ClsEnums.MessageType.WARNING);
            }
            else
            {
                Withhold();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BindingList<PaymentEntry> bindingList = (BindingList<PaymentEntry>)GrvPayment.DataSource;
            if (bindingList.Count > 0)
            {
                bool response;

                response = functions.ShowMessage("Existen pagos registrados, desea continuar?", ClsEnums.MessageType.CONFIRM);

                if (response)
                {
                    GrcPayment.DataSource = null;
                    paymentXml.RemoveAll();
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
        }
        #endregion

        #region Payment Functions

        private void Cash()
        {
            decimal cashReceivedAmount = decimal.Parse(TxtAmount.Text);
            decimal cashAmount = cashReceivedAmount;

            if (cashReceivedAmount > pendingAmount)
            {
                changeAmount = cashReceivedAmount - pendingAmount;
                cashAmount = cashReceivedAmount - changeAmount;
                LblTitleChange.Visible = true;
                LblChange.Visible = true;
                LblChange.Text = changeAmount.ToString();
                functions.ShowMessage("El cambio a entregar es de $" + changeAmount.ToString());
            }

            InvoicePayment invoicePayment = new InvoicePayment
            {
                PaymModeId = (int)ClsEnums.PaymModeEnum.EFECTIVO,
                Amount = cashAmount,
                Change = changeAmount,
                Received = cashReceivedAmount
            };

            AddRecordToGrid(invoicePayment);
            CalculatePayment();
        }

        private void CreditCard()
        {
            FrmPaymentCard paymentCard = new FrmPaymentCard();
            paymentCard.creditCardAmount = decimal.Parse(TxtAmount.Text);
            paymentCard.customer = customer;
            paymentCard.ShowDialog();

            if (paymentCard.processResponse)
            {
                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)paymentCard.paymModeEnum,
                    BankId = paymentCard.bankId,
                    CreditCardId = paymentCard.creditCardId,
                    Authorization = paymentCard.authorization,
                    Amount = decimal.Parse(TxtAmount.Text)
                };

                AddRecordToGrid(invoicePayment);
                CalculatePayment();
            }
        }

        private void Check()
        {
            ClsEnums.PaymModeEnum paymModeEnum;
            FrmPaymentCheck paymentCheck = new FrmPaymentCheck();
            paymentCheck.checkAmount = decimal.Parse(TxtAmount.Text);
            paymentCheck.customer = customer;
            paymentCheck.ShowDialog();

            if (paymentCheck.processResponse)
            {
                if (paymentCheck.checkDate > DateTime.Now)
                {
                    paymModeEnum = ClsEnums.PaymModeEnum.CHEQUE_POST;
                }
                else
                {
                    paymModeEnum = ClsEnums.PaymModeEnum.CHEQUE_DIA;
                }

                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)paymModeEnum,
                    CheckOwner = paymentCheck.checkOwnerName,
                    BankId = paymentCheck.checkBankId,
                    CkeckDate = paymentCheck.checkDate,
                    AccountNumber = paymentCheck.checkAccountNumber,
                    CkeckNumber = paymentCheck.checkNumber,
                    Authorization = paymentCheck.checkAuthorization,
                    Amount = decimal.Parse(TxtAmount.Text)
                };

                AddRecordToGrid(invoicePayment);
                CalculatePayment();
            }
        }

        private void InternalCredit()
        {
            FrmPaymentCredit paymentCredit = new FrmPaymentCredit();
            paymentCredit.paidAmount = decimal.Parse(TxtAmount.Text);
            paymentCredit.customer = customer;
            paymentCredit.emissionPoint = emissionPoint;
            //paymentCredit.scanner = scanner;
            paymentCredit.internalCreditCardCode = internalCreditCardCode;
            paymentCredit.ShowDialog();

            if (paymentCredit.formActionResult)
            {
                ClsGeneral general = new ClsGeneral();
                bool responseAuthorization = true;
                GlobalParameter parameter;

                try
                {
                    string value = customer.IsEmployee ? "InternalCreditRequestAuth" : "RequireSupervisorAuthorizationCustomer";
                    parameter = general.GetParameterByName(value);

                    if (parameter != null)
                    {
                        if (parameter.Value == "1")
                        {
                            functions.emissionPoint = emissionPoint;
                            functions.AxOPOSScanner = scanner;
                            responseAuthorization = functions.RequestSupervisorAuth();
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ha ocurrido un problema al consultar parametro."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
                }

                if (responseAuthorization)
                {
                    InvoicePayment invoicePayment = new InvoicePayment();
                    if (!customer.IsEmployee)
                    {
                        invoicePayment.PaymModeId = (int)ClsEnums.PaymModeEnum.CREDITO;
                        invoicePayment.Amount = decimal.Parse(TxtAmount.Text);
                        invoicePayment.Authorization = functions.supervisorAuthorization;
                    }
                    else
                    {
                        invoicePayment.PaymModeId = (int)ClsEnums.PaymModeEnum.TARJETA_CONSUMO;
                        invoicePayment.Amount = decimal.Parse(TxtAmount.Text);
                        invoicePayment.InternalCreditCardId = paymentCredit.internalCreditCardId;
                        invoicePayment.Authorization = functions.supervisorAuthorization;
                    }

                    AddRecordToGrid(invoicePayment);
                    CalculatePayment();
                }
            }
        }

        private void GiftCard()
        {
            FrmPaymentGiftcard giftcard = new FrmPaymentGiftcard();
            giftcard.paidAmount = decimal.Parse(TxtAmount.Text);
            giftcard.ShowDialog();

            if (giftcard.formActionResult)
            {
                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)ClsEnums.PaymModeEnum.BONO,
                    GiftCardNumber = giftcard.giftcardNumber,
                    Amount = decimal.Parse(TxtAmount.Text)
                };

                AddRecordToGrid(invoicePayment);
                CalculatePayment();
            }
        }

        private void Withhold()
        {
            bool hasRetention = false;

            try
            {
                int retentionCount = (from pa in paymentXml.Descendants("InvoicePayment") where int.Parse(pa.Element("PaymModeId").Value) == (int)ClsEnums.PaymModeEnum.RETENCION select pa).Count();
                if (retentionCount > 0)
                {
                    hasRetention = true;
                }
            }
            catch
            {
                hasRetention = false;
            }

            if (hasRetention)
            {
                functions.ShowMessage("Ya se encuentra registrada una retencion", ClsEnums.MessageType.WARNING);
            }
            else
            {
                FrmPaymentWithhold paymentWithhold = new FrmPaymentWithhold
                {
                    customer = customer,
                    loginInformation = loginInformation,
                    taxAmount = taxAmount,
                    baseAmount = baseAmount
                };
                paymentWithhold.ShowDialog();

                if (paymentWithhold.processResponse)
                {
                    decimal paymentRetencion = paymentWithhold.totalDiscounted;
                    TxtAmount.Text = paymentRetencion.ToString();
                    List<InvoicePayment> retentionList = paymentWithhold.retentionList;

                    foreach (InvoicePayment item in retentionList)
                    {
                        AddRecordToGrid(item);
                    }

                    CalculatePayment();
                }
            }
        }

        private void CheckGridView()
        {
            GrcPayment.DataSource = null;
            GrvPayment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<PaymentEntry> bindingList = new BindingList<PaymentEntry>();
            bindingList.AllowNew = true;

            GrcPayment.DataSource = bindingList;
        }

        private class PaymentEntry
        {
            public PaymentEntry() { }

            public PaymentEntry(string _description, decimal _amount)
            {
                Description = _description; Amount = _amount;
            }

            public string Description { get; set; }
            public decimal Amount { get; set; }
        }

        private void AddRecordToGrid(InvoicePayment _invoicePayment)
        {
            ClsEnums.PaymModeEnum paymModeEnum = (ClsEnums.PaymModeEnum)_invoicePayment.PaymModeId;

            GrvPayment.AddNewRow();
            GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, GrvPayment.Columns["Description"], paymModeEnum);
            GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, GrvPayment.Columns["Amount"], _invoicePayment.Amount);

            Type type = _invoicePayment.GetType();
            PropertyInfo[] properties = type.GetProperties();
            XElement paymentDetailXml = new XElement("InvoicePayment");

            foreach (var prop in properties)
            {
                if (prop.Name != "InvoiceTable" && prop.Name != "Location" && prop.Name != "PaymMode")
                {
                    var name = prop.Name;
                    var value = prop.GetValue(_invoicePayment);

                    if (value == null)
                    {
                        value = "";
                    }

                    paymentDetailXml.Add(new XElement(name, value));
                }
            }

            paymentXml.Add(paymentDetailXml);
        }

        private void CalculatePayment()
        {
            paidAmount += decimal.Parse(TxtAmount.Text);
            paidAmount *= 1.00M;
            paidAmount = Math.Round(paidAmount, 2);

            if (paidAmount > invoiceAmount)
            {
                paidAmount = invoiceAmount;
            }

            if (invoiceAmount >= paidAmount)
            {
                pendingAmount = invoiceAmount - paidAmount;

                LblPaid.Text = paidAmount.ToString();
                LblPending.Text = pendingAmount.ToString();

                if (paidAmount == invoiceAmount)
                {
                    canCloseInvoice = true;
                    Close();
                }
                else
                {
                    TxtAmount.Text = pendingAmount.ToString();
                }
            }
            else
            {
                functions.ShowMessage("El monto a pagar no puede ser mayor al de la factura.", ClsEnums.MessageType.ERROR);
            }
        }
        #endregion
    }
}