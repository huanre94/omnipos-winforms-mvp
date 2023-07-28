using AxOposScanner_CCO;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentCredit : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public long internalCreditCardId;
        public decimal creditLimit;

        //readonly decimal paidAmount;
        public decimal paidAmount;
        public Customer Customer { get; set; }
        public EmissionPoint EmissionPoint { get; set; }

        public string InternalCreditCardCode { get; set; } = string.Empty;
        public bool IsPresentingCreditCard { get; set; } = false;

        public AxOPOSScanner scanner;
        //readonly AxOPOSScanner scanner;
        public int SalesOriginId { get; set; }
        ScaleBrands scaleBrand;

        public FrmPaymentCredit()
        {
            InitializeComponent();
        }

        public FrmPaymentCredit(Customer customer, EmissionPoint emissionPoint, AxOPOSScanner scanner, int SalesOriginId, bool isPresentingCreditCard = false)
        {
            Customer = customer;
            EmissionPoint = emissionPoint;
            this.scanner = scanner;
            IsPresentingCreditCard = isPresentingCreditCard;
            this.SalesOriginId = SalesOriginId;
        }

        public FrmPaymentCredit(decimal paidAmount, Customer customer, EmissionPoint emissionPoint, string internalCreditCardCode, int salesOriginId)
        {
            this.paidAmount = paidAmount;
            Customer = customer;
            EmissionPoint = emissionPoint;
            InternalCreditCardCode = internalCreditCardCode;
            SalesOriginId = salesOriginId;
        }

        private void FrmPaymentCredit_Load(object sender, EventArgs e)
        {
            if (new InvoiceRepository(Program.customConnectionString).ConsultSalesOriginCredit(SalesOriginId))
            {
                formActionResult = true;
                Close();
                return;
            }

            if (ValidateCustomerInformation())
            {
                if (!ValidateCredit())
                {
                    functions.ShowMessage("El cliente no puede realizar compra a Crédito.", MessageType.WARNING);
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                if (IsPresentingCreditCard)
                {
                    LblAuthorization.Visible = true;
                    TxtCreditCardCode.Visible = true;

                    scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), EmissionPoint.ScaleBrand, true);

                    if (scaleBrand == ScaleBrands.DATALOGIC)
                    {
                        functions.AxOPOSScanner = scanner;
                        functions.DisableScanner();
                        functions.AxOPOSScanner = AxOPOSScanner;
                        functions.EnableScanner(EmissionPoint.ScanBarcodeName);
                    }

                    return;
                }

                if (InternalCreditCardCode != "")
                {
                    GetInternalCreditCard(InternalCreditCardCode);
                }
                else
                {
                    if (Customer.IsEmployee && !(bool)Customer.IsCredit)
                    {
                        functions.ShowMessage("No se ha ingresado la tarjeta de afiliado.", MessageType.WARNING);
                        Close();
                    }
                }

            }
        }

        private bool ValidateCredit()
        {
            if ((bool)Customer.IsCredit)
            {
                LblAuthorization.Visible = false;
                TxtCreditCardCode.Visible = false;
                Customer = new CustomerRepository(Program.customConnectionString).GetCustomerById(Customer.CustomerId);
                decimal _creditLimit = Customer.CreditLimit;
                LblCreditLimit.Text = $"{_creditLimit:#.00}";
                LblHolderName.Text = $"{Customer.Firtsname} {Customer.Lastname}";
                creditLimit = _creditLimit;
                return true;
            }

            if (Customer.IsEmployee)
            {
                return true;
            }

            return false;
        }

        private bool ValidateCustomerInformation()
        {
            if (Customer?.CustomerId == 1)
            {
                functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
                DialogResult = DialogResult.Cancel;
                return false;
            }

            return true;
        }

        private bool ValidateInternalCreditFields()
        {
            if (Customer.IsEmployee)
            {
                if (LblHolderName.Text.Equals(string.Empty) || LblCreditLimit.Text.Equals(string.Empty))
                {
                    functions.ShowMessage("No se obtuvieron datos de la tarjeta de consumo.", MessageType.WARNING);
                    return false;
                }

                return true;
            }

            return true;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (IsPresentingCreditCard && scaleBrand == ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
                functions.AxOPOSScanner = scanner;
                functions.EnableScanner(EmissionPoint.ScanBarcodeName);
            }
        }

        private void TxtCreditCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCreditCardCode.Text == string.Empty)
                {
                    return;
                }

                GetInternalCreditCard(TxtCreditCardCode.Text);
            }
        }

        private void GetInternalCreditCard(string _internalCreditCardCode)
        {
            if (_internalCreditCardCode == string.Empty)
            {
                functions.ShowMessage("Debe proporcionar el código de la tarjeta de afiliado.", MessageType.WARNING);
                return;
            }

            try
            {
                SP_InternalCreditCard_Consult_Result internalCreditCardCustomer = new GiftcardRepository(Program.customConnectionString).GetInternalCreditCard(_internalCreditCardCode);

                if (internalCreditCardCustomer == null)
                {
                    functions.ShowMessage("No existe titular asociado a la tarjeta ingresada.", MessageType.WARNING);
                    TxtCreditCardCode.Text = "";
                    return;
                }

                if (internalCreditCardCustomer.CustomerId != Customer.CustomerId)
                {
                    functions.ShowMessage("El cliente tiene que ser el titular de la tarjeta.", MessageType.ERROR);
                    TxtCreditCardCode.Text = "";
                    return;
                }

                LblHolderName.Text = internalCreditCardCustomer.Name;
                creditLimit = internalCreditCardCustomer.Consumed;
                LblCreditLimit.Text = $"{creditLimit:0.N2}";
                internalCreditCardId = internalCreditCardCustomer.InternalCreditCardId;
                InternalCreditCardCode = internalCreditCardCustomer.Barcode;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al consultar tarjeta de consumo.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateInternalCreditFields())
            {
                DialogResult = DialogResult.None;
                return;
            }

            if (IsPresentingCreditCard)
            {
                formActionResult = true;

                if (scaleBrand == ScaleBrands.DATALOGIC)
                {
                    functions.DisableScanner();
                    functions.AxOPOSScanner = scanner;
                    functions.EnableScanner(EmissionPoint.ScanBarcodeName);
                }

                Close();
                return;
            }

            if (creditLimit <= 0)
            {
                functions.ShowMessage("La tarjeta no posee cupo.", MessageType.WARNING);
                return;
            }

            if (creditLimit < paidAmount)
            {
                functions.ShowMessage("El saldo de la tarjeta es insuficiente para realizar la compra.", MessageType.WARNING);
                return;
            }

            TxtCreditCardCode.Text = "";
            formActionResult = true;
            Close();
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtCreditCardCode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }
    }
}