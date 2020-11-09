using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.ComponentModel;
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
        public decimal invoiceAmount = 0;
        decimal paidAmount = 0;
        decimal pendingAmount = 0;
        decimal changeAmount = 0;
        public bool canCloseInvoice = false;
        public decimal baseAmount = 0;
        public decimal taxAmount = 0;

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            GetPaymentInformation();
            CheckGridView();
        }

        private void GetPaymentInformation()
        {
            //invoiceAmount = 42.69M; //Here the invoice total amount
            LblTotal.Text = invoiceAmount.ToString();
            TxtAmount.Text = invoiceAmount.ToString();
            pendingAmount = invoiceAmount;

            bool customerRetention = customer.UseRetention ?? false;
            if (customerRetention)
            {
                if (functions.ShowMessage("Este cliente genera retencion. ¿Desea registrar una?", ClsEnums.MessageType.CONFIRM))
                {
                    Withhold();
                }
                /*
                 if (taxAmount == 0)
        {
            functions.ShowMessage("No aplica retencion: La base imponible es cero", ClsEnums.MessageType.ERROR);
        }
                 */
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
        private void BtnWithhold_Click(object sender, EventArgs e)
        {
            if (taxAmount == 0)
            {
                functions.ShowMessage("No aplica retencion, la base imponible es cero", ClsEnums.MessageType.ERROR);
            }
            else
            {
                Withhold();
            }
        }

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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (GrvPayment.RowCount > 0)
            {
                bool response;

                response = functions.ShowMessage("Existen pagos registrados, desea continuar?", ClsEnums.MessageType.CONFIRM);

                if (response)
                {
                    GrcPayment.DataSource = null;
                    GrvPayment.Columns.Clear();
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
            InvoicePayment invoicePayment = new InvoicePayment
            {
                PaymModeId = (int)ClsEnums.PaymModeEnum.EFECTIVO,
                Amount = decimal.Parse(TxtAmount.Text)
            };

            AddRecordToSource(invoicePayment);
            CalculatePayment(ClsEnums.PaymModeEnum.EFECTIVO);
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

                AddRecordToSource(invoicePayment);
                CalculatePayment(paymentCard.paymModeEnum);
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

                AddRecordToSource(invoicePayment);
                CalculatePayment(paymModeEnum);
            }
        }

        private void InternalCredit()
        {
            FrmPaymentCredit paymentCredit = new FrmPaymentCredit();
            paymentCredit.paidAmount = decimal.Parse(TxtAmount.Text);
            paymentCredit.customer = customer;
            paymentCredit.ShowDialog();

            if (paymentCredit.formActionResult)
            {
                ClsGeneral general = new ClsGeneral();
                bool responseAuthorization = true;
                GlobalParameter parameter;

                try
                {
                    parameter = general.GetParameterByName("InternalCreditRequestAuth");

                    if (parameter != null)
                    {
                        if (parameter.Value == "1")
                        {
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
                    InvoicePayment invoicePayment = new InvoicePayment
                    {
                        PaymModeId = (int)ClsEnums.PaymModeEnum.TARJETA_CONSUMO,
                        Amount = decimal.Parse(TxtAmount.Text)
                    };

                    AddRecordToSource(invoicePayment);
                    CalculatePayment(ClsEnums.PaymModeEnum.TARJETA_CONSUMO);
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

                AddRecordToSource(invoicePayment);
                CalculatePayment(ClsEnums.PaymModeEnum.BONO);
            }
        }

        private void Withhold()
        {
            FrmPaymentWithhold paymentWithhold = new FrmPaymentWithhold();
            paymentWithhold.customer = customer;
            paymentWithhold.loginInformation = loginInformation;
            paymentWithhold.retentionAmount = taxAmount;
            paymentWithhold.ShowDialog();

            if (paymentWithhold.processResponse)
            {

                TxtAmount.Text = paymentWithhold.retentionAmount.ToString();

                ClsEnums.PaymModeEnum paymModeEnum = ClsEnums.PaymModeEnum.RETENCION;
                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)paymModeEnum,
                    RetentionCode = paymentWithhold.retentionCode,
                    RetentionNumber = paymentWithhold.retentionNumber,
                    Authorization = paymentWithhold.authorization,
                    Amount = paymentWithhold.retentionAmount
                };

                AddRecordToSource(invoicePayment);
                CalculatePayment(paymModeEnum);
            }
        }

        private void CheckGridView()
        {
            //if (dataTable.Columns.Count == 0)
            //{
            //    GrcPayment.DataSource = null;
            //    GrvPayment.Columns.Clear();
            //    GrvPayment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            //    dataTable.Columns.Add("Descripción", typeof(string));
            //    dataTable.Columns.Add("Monto", typeof(decimal));
            //    GrcPayment.DataSource = dataTable;
            //}

            //GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
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

        private void AddRecordToSource(InvoicePayment _invoicePayment)
        {
            ClsEnums.PaymModeEnum paymModeEnum = (ClsEnums.PaymModeEnum)_invoicePayment.PaymModeId;

            //DataRow NewRow = dataTable.NewRow();
            //NewRow[0] = paymModeEnum;
            //NewRow[1] = Math.Round(_invoicePayment.Amount * 1.00M, 2);
            //dataTable.Rows.Add(NewRow);
            //GrcPayment.DataSource = dataTable;

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

        private void CalculatePayment(ClsEnums.PaymModeEnum _paymModeId)
        {
            paidAmount += decimal.Parse(TxtAmount.Text);
            paidAmount *= 1.00M;
            paidAmount = Math.Round(paidAmount, 2);

            if (_paymModeId == ClsEnums.PaymModeEnum.EFECTIVO)
            {
                if (paidAmount > invoiceAmount)
                {
                    changeAmount = paidAmount - invoiceAmount;
                    functions.ShowMessage("El cambio a entregar es de $" + changeAmount.ToString());
                    paidAmount = invoiceAmount;
                }
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