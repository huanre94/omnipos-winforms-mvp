using POS.Classes;
using POS.DLL;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentCredit : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal creditLimit;
        public decimal paidAmount;
        public Customer customer;
        public EmissionPoint emissionPoint;
        public AxOposScanner_CCO.AxOPOSScanner scanner;
        public bool isPresentingCreditCard;
        public Int64 internalCreditCardId;
        public string internalCreditCardCode = string.Empty;
        ClsEnums.ScaleBrands scaleBrand;

        public FrmPaymentCredit()
        {
            InitializeComponent();
        }

        private void FrmPaymentCredit_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                if (ValidateCredit())
                {
                    if (isPresentingCreditCard)
                    {
                        LblAuthorization.Visible = true;
                        TxtCreditCardCode.Visible = true;

                        scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

                        if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
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
                                functions.ShowMessage("No se ha ingresado la tarjeta de afiliado.", ClsEnums.MessageType.WARNING);
                                Close();
                            }
                        }
                    }
                }
                else
                {
                    functions.ShowMessage("El cliente no puede realizar compra a Crédito.", ClsEnums.MessageType.WARNING);
                    DialogResult = DialogResult.Cancel;
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
                decimal _creditLimit = customer.CreditLimit;
                LblCreditLimit.Text = _creditLimit.ToString("#.00");
                LblHolderName.Text = customer.Firtsname + " " + customer.Lastname;
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
            bool response = false;

            if (customer != null)
            {
                if (customer.CustomerId != 1)
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", ClsEnums.MessageType.ERROR);
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            return response;
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
                    functions.ShowMessage("No se obtuvieron datos de la tarjeta de consumo.", ClsEnums.MessageType.WARNING);
                }               
            }
            else
            {
                response = true;
            }

            if (!response)
            {
                this.DialogResult = DialogResult.None;
            }

            return response;
        }
        
      
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isPresentingCreditCard && scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
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
            DLL.SP_InternalCreditCard_Consult_Result result;
            DLL.Transaction.ClsCustomerTrans clsCustomer = new DLL.Transaction.ClsCustomerTrans();

            if (_internalCreditCardCode == "")
            {
                functions.ShowMessage("Debe proporcionar el código de la tarjeta de afiliado.", ClsEnums.MessageType.WARNING);
                return;
            }

            try
            {
                result = clsCustomer.GetInternalCreditCard(_internalCreditCardCode);

                if (result != null)
                {
                    if (result.CustomerId == customer.CustomerId)
                    {
                        LblHolderName.Text = result.Name;
                        creditLimit = result.Consumed;
                        LblCreditLimit.Text = creditLimit.ToString();
                        internalCreditCardId = result.InternalCreditCardId;
                        internalCreditCardCode = result.Barcode;
                    }
                    else
                    {
                        functions.ShowMessage("El cliente tiene que ser el titular de la tarjeta.", ClsEnums.MessageType.ERROR);
                        TxtCreditCardCode.Text = "";
                    }
                }
                else
                {
                    functions.ShowMessage("No existe titular asociado a la tarjeta ingresada.", ClsEnums.MessageType.WARNING);
                    TxtCreditCardCode.Text = "";
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al consultar tarjeta de consumo."
                                        , ClsEnums.MessageType.ERROR
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

                    if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
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
                            FrmPayment frmPayment = new FrmPayment();
                            frmPayment.emissionPoint = emissionPoint;
                            TxtCreditCardCode.Text = "";
                            formActionResult = true;
                            Close();
                        }
                        else
                        {
                            functions.ShowMessage("El saldo de la tarjeta es insuficiente para realizar la compra.", ClsEnums.MessageType.WARNING);
                        }
                    }
                    else
                    {
                        functions.ShowMessage("La tarjeta no posee cupo.", ClsEnums.MessageType.WARNING);
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