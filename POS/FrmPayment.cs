using DevExpress.XtraGrid.Views.Grid;
using POS.Class;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

// HR002 Hugo Restrepo 2021-03-02: Recalculate discount with payment mode
namespace POS
{
    public partial class FrmPayment : DevExpress.XtraEditors.XtraForm
    {
        #region Global Load Definitions
        readonly ClsFunctions functions = new ClsFunctions();
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
        public decimal baseTaxAmount = 0;
        public decimal taxAmount = 0;
        public decimal irbpAmount = 0;
        public decimal discountAmount = 0;

        public AxOposScanner_CCO.AxOPOSScanner scanner;
        public string internalCreditCardCode = "";
        public XElement invoiceXml; //HR002
        public bool isInvoicePaymentDiscount = false;   //HR002
        public int salesOriginId = 1;
        public bool paymentMethod { get; set; } = true;

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            CheckGridView();
            GetPaymentInformation();

            BtnCash.Enabled = true;
            BtnCreditCard.Enabled = true;
            BtnCheck.Enabled = true;

            BtnInternalCredit.Enabled = paymentMethod;
            BtnGiftcard.Enabled = paymentMethod;
            BtnWithhold.Enabled = paymentMethod;
            BtnAdvance.Enabled = paymentMethod;
            BtnReturn.Enabled = paymentMethod;

            BtnCash.Click += BtnCash_Click;

            TxtAmount.Focus();
        }


        private void GetPaymentInformation()
        {
            pendingAmount = invoiceAmount;

            TxtAmount.Text = invoiceAmount.ToString();
            LblPending.Text = pendingAmount.ToString();

            //TODO 
            string taxPercent = new ClsGeneral(Program.customConnectionString).GetActiveTax();

            IList<PaymentDetail> paymentDetails = new List<PaymentDetail>
            {
                new PaymentDetail($"Base IVA 0%", baseAmount),
                new PaymentDetail($"(+) Base IVA {taxPercent}%", baseTaxAmount),
                new PaymentDetail($"(+) IVA {taxPercent}%", taxAmount),
                new PaymentDetail($"(+) IRBP", irbpAmount),
                new PaymentDetail($"(-) Descuento", discountAmount),
                new PaymentDetail($"(=) Total", invoiceAmount)
            };

            foreach (PaymentDetail detail in paymentDetails)
            {
                AddRecordToPaymentGrid(detail);
            }

            if ((customer.UseRetention ?? false) && functions.ShowMessage("El cliente seleccionado genera retención. ¿Desea registrarla ahora?", MessageType.CONFIRM))
            {
                Withhold();
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
        private void Btn0_Click(object sender, EventArgs e) => TxtAmount.Text += "0";

        private void Btn1_Click(object sender, EventArgs e) => TxtAmount.Text += "1";

        private void Btn2_Click(object sender, EventArgs e) => TxtAmount.Text += "2";

        private void Btn3_Click(object sender, EventArgs e) => TxtAmount.Text += "3";

        private void Btn4_Click(object sender, EventArgs e) => TxtAmount.Text += "4";

        private void Btn5_Click(object sender, EventArgs e) => TxtAmount.Text += "5";

        private void Btn6_Click(object sender, EventArgs e) => TxtAmount.Text += "6";

        private void Btn7_Click(object sender, EventArgs e) => TxtAmount.Text += "7";

        private void Btn8_Click(object sender, EventArgs e) => TxtAmount.Text += "8";

        private void Btn9_Click(object sender, EventArgs e) => TxtAmount.Text += "9";

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!TxtAmount.Text.Contains("."))
            {
                TxtAmount.Text += ".";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e) => TxtAmount.Text = string.Empty;
        #endregion

        #region Payment Buttons      

        private void BtnCash_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.EFECTIVO);
        }

        private void BtnCreditCard_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.TARJETA_CREDITO);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.CHEQUE_DIA);
        }

        private void CallPaymentMethod(PaymModeEnum paymMode)
        {
            if (TxtAmount.Text == string.Empty)
            {
                functions.ShowMessage("Debe ingresar un valor obligatoriamente", MessageType.WARNING);
                return;
            }

            if (decimal.Parse(TxtAmount.Text) > pendingAmount && paymMode != PaymModeEnum.EFECTIVO)
            {
                functions.ShowMessage("Solo el metodo de pago Efectivo permite montos mayor al pendiente.", MessageType.WARNING);
                return;
            }

            switch (paymMode)
            {
                case PaymModeEnum.NOTA_CREDITO:
                case PaymModeEnum.ANTICIPOS:
                    AccountReceivable(paymMode);
                    break;
                case PaymModeEnum.EFECTIVO:
                    Cash();
                    break;
                case PaymModeEnum.CHEQUE_DIA:
                    Check();
                    break;
                case PaymModeEnum.CREDITO:
                    InternalCredit();
                    break;
                case PaymModeEnum.TARJETA_CREDITO:
                    CreditCard();
                    break;
                case PaymModeEnum.BONO:
                    GiftCard();
                    break;


                case PaymModeEnum.RETENCION:
                    if (customer.CustomerId == 1)
                    {
                        functions.ShowMessage("No aplica retencion, cliente ", MessageType.WARNING);
                        return;
                    }

                    if (taxAmount == 0 && baseAmount == 0)
                    {
                        functions.ShowMessage("La venta no aplica retención, la base imponible es cero", MessageType.WARNING);
                        return;
                    }

                    if (!(bool)customer.UseRetention)
                    {
                        functions.ShowMessage("No aplica retencion, cliente ", MessageType.WARNING);
                        return;
                    }

                    Withhold();
                    break;

                default:
                    functions.ShowMessage("Metodo no implementado. Por favor contactar con Sistemas.", MessageType.WARNING);
                    break;
            }
        }

        private void BtnInternalCredit_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.CREDITO);
        }

        private void BtnGiftcard_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.BONO);
        }

        private void BtnWithhold_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.RETENCION);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BindingList<PaymentEntry> bindingList = (BindingList<PaymentEntry>)GrvPayment.DataSource;
            if (bindingList.Count > 0)
            {
                if (functions.ShowMessage("Existen pagos registrados, desea continuar?", MessageType.CONFIRM))
                {
                    GrcPayment.DataSource = null;
                    paymentXml.RemoveAll();
                    Close();
                    return;
                }

                DialogResult = DialogResult.None;
            }
        }

        private void BtnAdvance_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.ANTICIPOS);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.NOTA_CREDITO);
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            CallPaymentMethod(PaymModeEnum.DEPOSITO_BANCARIO);
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
                functions.ShowMessage("El cambio a entregar es de $ " + changeAmount.ToString());
            }

            InvoicePayment invoicePayment = new InvoicePayment
            {
                PaymModeId = (int)PaymModeEnum.EFECTIVO,
                Amount = cashAmount,
                Change = changeAmount,
                Received = cashReceivedAmount
            };

            AddRecordToGrid(invoicePayment);
            CalculatePayment();
        }

        private void CreditCard()
        {
            string AuxXml = invoiceXml.ToString(); //HR002
            FrmPaymentCard paymentCard = new FrmPaymentCard()
            {
                creditCardAmount = decimal.Parse(TxtAmount.Text),
                customer = customer,
                applyPaymmodeDiscount = TxtAmount.Text.Equals(invoiceAmount),   //HR002
                invoiceXml = invoiceXml,    //HR002
                emissionPoint = emissionPoint //HR002
            };
            paymentCard.ShowDialog();

            if (paymentCard.processResponse)
            {
                //Begin(HR002)
                if (paymentCard.applyPaymmodeDiscount)
                {
                    isInvoicePaymentDiscount = paymentCard.applyPaymmodeDiscount;

                    if (paymentCard.amountPaymmodeDiscount > 0)
                    {
                        invoiceAmount = paymentCard.amountPaymmodeDiscount;
                        TxtAmount.Text = invoiceAmount.ToString();
                        invoiceXml = paymentCard.invoiceXml;
                    }
                    else
                    {
                        invoiceXml = XElement.Parse(AuxXml);
                    }
                }
                //End(HR002)

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
            else
            {
                invoiceXml = XElement.Parse(AuxXml);
            }
        }

        private void Check()
        {
            PaymModeEnum paymModeEnum;
            FrmPaymentCheck paymentCheck = new FrmPaymentCheck()
            {
                checkAmount = decimal.Parse(TxtAmount.Text),
                customer = customer
            };
            paymentCheck.ShowDialog();

            if (paymentCheck.processResponse)
            {
                if (paymentCheck.checkDate > DateTime.Now)
                {
                    paymModeEnum = PaymModeEnum.CHEQUE_POST;
                }
                else
                {
                    paymModeEnum = PaymModeEnum.CHEQUE_DIA;
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
            FrmPaymentCredit paymentCredit = new FrmPaymentCredit
            (
               paidAmount: decimal.Parse(TxtAmount.Text),
                customer,
                emissionPoint,
                internalCreditCardCode,
                salesOriginId
            );
            paymentCredit.ShowDialog();

            if (paymentCredit.formActionResult)
            {
                bool requireAutorization = true;
                try
                {
                    string parameterName = customer.IsEmployee ? "InternalCreditRequestAuth" : "RequireSupervisorAuthorizationCustomer";

                    if (new ClsGeneral(Program.customConnectionString).GetParameterByName(parameterName).Value == "1")
                    {
                        functions.emissionPoint = emissionPoint;
                        functions.AxOPOSScanner = scanner;
                        requireAutorization = functions.RequestSupervisorAuth();
                    }

                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ha ocurrido un problema al consultar parametro.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }

                if (requireAutorization)
                {
                    InvoicePayment invoicePayment = new InvoicePayment();
                    if (!customer.IsEmployee)
                    {
                        invoicePayment.PaymModeId = (int)PaymModeEnum.CREDITO;
                        invoicePayment.Amount = decimal.Parse(TxtAmount.Text);
                        invoicePayment.Authorization = functions.supervisorAuthorization;
                    }
                    else
                    {
                        invoicePayment.PaymModeId = (int)PaymModeEnum.TARJETA_CONSUMO;
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
            FrmPaymentGiftcard giftcard = new FrmPaymentGiftcard
            {
                PaidAmount = decimal.Parse(TxtAmount.Text)
            };
            giftcard.ShowDialog();

            if (giftcard.FormActionResult)
            {
                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)PaymModeEnum.BONO,
                    GiftCardNumber = giftcard.giftcardNumber,
                    Amount = decimal.Parse(TxtAmount.Text)
                };

                AddRecordToGrid(invoicePayment);
                CalculatePayment();
            }
        }

        private void Withhold()
        {
            if (paymentXml
                .Descendants("InvoicePayment")
                .Where(pa => int.Parse(pa.Element("PaymModeId").Value) == (int)PaymModeEnum.RETENCION)
                .Count() > 0)
            {
                functions.ShowMessage("Ya se encuentra registrada una retencion", MessageType.WARNING);
                return;
            }

            FrmPaymentWithhold paymentWithhold = new FrmPaymentWithhold()
            {
                customer = customer,
                loginInformation = loginInformation,
                taxAmount = taxAmount,
                baseAmount = baseAmount + baseTaxAmount - discountAmount
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

        private void CheckGridView()
        {
            GrcPayment.DataSource = null;
            GrvPayment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<PaymentEntry> bindingList = new BindingList<PaymentEntry> { AllowNew = true };

            GrcPayment.DataSource = bindingList;


            GrcInvoicePaymentDetail.DataSource = null;
            GrvInvoicePaymentDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<PaymentDetail> invoicePaymentDetail = new BindingList<PaymentDetail> { AllowNew = true };

            GrcInvoicePaymentDetail.DataSource = invoicePaymentDetail;
        }

        private void AddRecordToPaymentGrid(PaymentDetail detail)
        {

            GrvInvoicePaymentDetail.AddNewRow();
            GrvInvoicePaymentDetail.SetRowCellValue(GrvInvoicePaymentDetail.FocusedRowHandle, GrvInvoicePaymentDetail.Columns["Description"], detail.Description);
            GrvInvoicePaymentDetail.SetRowCellValue(GrvInvoicePaymentDetail.FocusedRowHandle, GrvInvoicePaymentDetail.Columns["Amount"], detail.Amount);

        }

        private void AddRecordToGrid(InvoicePayment _invoicePayment)
        {
            PaymModeEnum paymModeEnum = (PaymModeEnum)_invoicePayment.PaymModeId;

            //PaymentEntry entry = new PaymentEntry(paymModeEnum.ToString(), _invoicePayment.Amount);

            GrvPayment.AddNewRow();
            GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, GrvPayment.Columns["Description"], paymModeEnum);
            GrvPayment.SetRowCellValue(GrvPayment.FocusedRowHandle, GrvPayment.Columns["Amount"], _invoicePayment.Amount);

            Type type = _invoicePayment.GetType();
            PropertyInfo[] properties = type.GetProperties();
            XElement paymentDetailXml = new XElement("InvoicePayment");

            foreach (PropertyInfo prop in properties)
            {
                if (prop.Name != "InvoiceTable" && prop.Name != "Location" && prop.Name != "PaymMode")
                {
                    string name = prop.Name;
                    object value = prop.GetValue(_invoicePayment);

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

            if (invoiceAmount < paidAmount)
            {
                functions.ShowMessage("El monto a pagar no puede ser mayor al de la factura.", MessageType.ERROR);
                return;
            }

            pendingAmount = invoiceAmount - paidAmount;

            LblPaid.Text = paidAmount.ToString();
            LblPending.Text = pendingAmount.ToString();

            if (paidAmount != invoiceAmount)
            {
                TxtAmount.Text = pendingAmount.ToString();
                TxtAmount.Focus();
                return;
            }

            canCloseInvoice = true;
            Close();
        }

        private void AccountReceivable(PaymModeEnum _paymMode)
        {
            FrmPaymentAdvance paymentAdvance = new FrmPaymentAdvance()
            {
                paymentAmount = decimal.Parse(TxtAmount.Text),
                _currentCustomer = customer,
                _paymMode = _paymMode
            };
            paymentAdvance.ShowDialog();

            if (paymentAdvance.GetResponse())
            {
                functions.emissionPoint = emissionPoint;
                functions.AxOPOSScanner = scanner;
                bool responseAuthorization = functions.RequestSupervisorAuth();
                if (responseAuthorization)
                {
                    decimal pendingAdvanceAmount = paymentAdvance.pendingAmount;
                    TxtAmount.Text = pendingAdvanceAmount.ToString("#.00");
                    foreach (SP_Advance_Consult_Result item in paymentAdvance.advances)
                    {
                        if ((bool)item.IsSelected)
                        {
                            InvoicePayment invoicePayment = new InvoicePayment()
                            {
                                PaymModeId = (int)_paymMode,
                                Amount = (decimal)item.AdvanceAmount,
                                GiftCardNumber = item.AdvanceId.ToString(),
                                Authorization = functions.supervisorAuthorization
                            };
                            AddRecordToGrid(invoicePayment);
                        }
                    }
                    CalculatePayment();
                }
            }
        }

        #endregion

        private void TxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    CallPaymentMethod(PaymModeEnum.EFECTIVO);
                    break;
                case Keys.F2:
                    CallPaymentMethod(PaymModeEnum.TARJETA_CREDITO);
                    break;
                case Keys.F3:
                    CallPaymentMethod(PaymModeEnum.CHEQUE_DIA);
                    break;
                case Keys.F4:
                    CallPaymentMethod(PaymModeEnum.CREDITO);
                    break;
                case Keys.F5:
                    CallPaymentMethod(PaymModeEnum.RETENCION);
                    break;
                case Keys.F6:
                    CallPaymentMethod(PaymModeEnum.BONO);
                    break;
                case Keys.F7:
                    CallPaymentMethod(PaymModeEnum.ANTICIPOS);
                    break;
                case Keys.F8:
                    CallPaymentMethod(PaymModeEnum.NOTA_CREDITO);
                    break;
            }
        }
    }
}