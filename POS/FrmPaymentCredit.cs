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
        public bool formActionResult;
        public decimal creditLimit;
        public decimal paidAmount;
        public Customer customer;
        public EmissionPoint emissionPoint;
        public AxOposScanner_CCO.AxOPOSScanner scanner;
        public bool isPresentingCreditCard;
        public long internalCreditCardId;
        public string internalCreditCardCode = string.Empty;
        public int salesOriginId;
        readonly ClsFunctions functions = new ClsFunctions();
        ScaleBrands scaleBrand;

        public FrmPaymentCredit()
        {
            InitializeComponent();
        }

        private void FrmPaymentCredit_Load(object sender, EventArgs e)
        {
            if (new ClsInvoiceTrans(Program.customConnectionString).ConsultSalesOriginCredit(salesOriginId))
            {
                formActionResult = true;
                Close();
            }
            else
            {
                if (ValidateCustomerInformation())
                {
                    if (ValidateCredit())
                    {
                        if (isPresentingCreditCard)
                        {
                            LblAuthorization.Visible = true;
                            TxtCreditCardCode.Visible = true;

                            scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

                            if (scaleBrand == ScaleBrands.DATALOGIC)
                            {
                                functions.AxOPOSScanner = scanner;
                                functions.DisableScanner();
                                functions.AxOPOSScanner = AxOPOSScanner;
                                functions.EnableScanner(emissionPoint.ScanBarcodeName);
                            }
                        }
                        else
                        {
                            if (internalCreditCardCode != "")
                            {
                                GetInternalCreditCard(internalCreditCardCode);
                            }
                            else
                            {
                                if (customer.IsEmployee && !(bool)customer.IsCredit)
                                {
                                    functions.ShowMessage("No se ha ingresado la tarjeta de afiliado.", MessageType.WARNING);
                                    Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        functions.ShowMessage("El cliente no puede realizar compra a Crédito.", MessageType.WARNING);
                        DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        private bool ValidateCredit()
        {
            bool response = false;

            if ((bool)customer.IsCredit)
            {
                LblAuthorization.Visible = false;
                TxtCreditCardCode.Visible = false;
                customer = new ClsCustomer(Program.customConnectionString).GetCustomerById(customer.CustomerId);
                decimal _creditLimit = customer.CreditLimit;
                LblCreditLimit.Text = $"{_creditLimit:#.00}";
                LblHolderName.Text = $"{customer.Firtsname} {customer.Lastname}";
                creditLimit = _creditLimit;
                response = true;
            }
            else if (customer.IsEmployee)
            {
                response = true;
            }

            return response;
        }

        private bool ValidateCustomerInformation()
        {
            if (customer?.CustomerId == 1)
            {
                functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
                DialogResult = DialogResult.Cancel;
                return false;
            }

            return true;
        }

        private bool ValidateInternalCreditFields()
        {
            bool response = false;

            if (customer.IsEmployee)
            {
                if (LblHolderName.Text != "" && LblCreditLimit.Text != "")
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("No se obtuvieron datos de la tarjeta de consumo.", MessageType.WARNING);
                }
            }
            else
            {
                response = true;
            }

            if (!response)
            {
                DialogResult = DialogResult.None;
            }

            return response;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isPresentingCreditCard && scaleBrand == ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
                functions.AxOPOSScanner = scanner;
                functions.EnableScanner(emissionPoint.ScanBarcodeName);
            }
        }

        private void TxtCreditCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCreditCardCode.Text != "")
                {
                    GetInternalCreditCard(TxtCreditCardCode.Text);
                }
            }
        }

        private void GetInternalCreditCard(string _internalCreditCardCode)
        {
            if (_internalCreditCardCode == "")
            {
                functions.ShowMessage("Debe proporcionar el código de la tarjeta de afiliado.", MessageType.WARNING);
                return;
            }

            try
            {
                SP_InternalCreditCard_Consult_Result internalCreditCardCustomer = new ClsCustomerTrans(Program.customConnectionString).GetInternalCreditCard(_internalCreditCardCode);

                if (internalCreditCardCustomer == null)
                {
                    functions.ShowMessage("No existe titular asociado a la tarjeta ingresada.", MessageType.WARNING);
                    TxtCreditCardCode.Text = "";
                    return;
                }

                if (internalCreditCardCustomer.CustomerId != customer.CustomerId)
                {
                    functions.ShowMessage("El cliente tiene que ser el titular de la tarjeta.", MessageType.ERROR);
                    TxtCreditCardCode.Text = "";
                    return;
                }

                LblHolderName.Text = internalCreditCardCustomer.Name;
                creditLimit = internalCreditCardCustomer.Consumed;
                LblCreditLimit.Text = $"{creditLimit:0.##}";
                internalCreditCardId = internalCreditCardCustomer.InternalCreditCardId;
                internalCreditCardCode = internalCreditCardCustomer.Barcode;
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al consultar tarjeta de consumo."
                                        , MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                        );
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInternalCreditFields())
            {
                if (isPresentingCreditCard)
                {
                    formActionResult = true;

                    if (scaleBrand == ScaleBrands.DATALOGIC)
                    {
                        functions.DisableScanner();
                        functions.AxOPOSScanner = scanner;
                        functions.EnableScanner(emissionPoint.ScanBarcodeName);
                    }

                    Close();
                }
                else
                {
                    if (creditLimit > 0)
                    {
                        if (creditLimit >= paidAmount)
                        {
                            FrmPayment frmPayment = new FrmPayment()
                            {
                                emissionPoint = emissionPoint
                            };
                            TxtCreditCardCode.Text = "";
                            formActionResult = true;
                            Close();
                        }
                        else
                        {
                            functions.ShowMessage("El saldo de la tarjeta es insuficiente para realizar la compra.", MessageType.WARNING);
                        }
                    }
                    else
                    {
                        functions.ShowMessage("La tarjeta no posee cupo.", MessageType.WARNING);
                    }
                }
            }
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtCreditCardCode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }
    }
}