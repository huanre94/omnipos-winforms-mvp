using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentWithhold : DevExpress.XtraEditors.XtraForm
    {
        public bool processResponse;
        ClsFunctions functions = new ClsFunctions();
        public Customer customer = null;
        public SP_Login_Consult_Result loginInformation;
        public decimal retentionAmount = 0.00M;
        public bool isTaxPayerCompany = false;
        public bool isTaxPayerCustomer = false;
        public string authorization = "";
        public int retentionCode;
        public string retentionNumber = "";
        public FrmPaymentWithhold()
        {
            InitializeComponent();
        }

        private void FrmPaymentWithhold2_Load(object sender, EventArgs e)
        {
            ValidateCustomerInformation();
            LoadTaxPercent();
        }

        private void LoadTaxPercent()
        {
            ClsPaymMode paymMode = new ClsPaymMode();
            List<RetentionTable> retentionTables;

            bool customerTaxPayer = (bool)customer.IsSpecialTaxpayer;
            bool companyTaxPayer = (bool)loginInformation.IsTaxpayerSpecial;

            int _retentionCode = 0;

            if (!customerTaxPayer)
            {
                _retentionCode = 1;
            }
            else if (companyTaxPayer && customerTaxPayer)
            {
                _retentionCode = 2;
            }
            else
            {
                _retentionCode = 3;
            }

            retentionCode = _retentionCode;
            try
            {
                retentionTables = paymMode.GetRetentionTables(_retentionCode);

                if (retentionTables != null)
                {
                    if (retentionTables.Count > 0)
                    {
                        foreach (var bank in retentionTables)
                        {
                            decimal totalAmount = retentionAmount * bank.Percent / 100;

                            LblTaxBase.Text = retentionAmount.ToString("");
                            LblTaxPercent.Text = string.Format("{0}%", bank.Percent);
                            LblAmount.Text = string.Format("{0:f2}", totalAmount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar tabla de retenciones."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }



        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (customer != null)
            {
                if (customer.CustomerId > 0)
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

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            bool validate = true;
            //bool validate2 = true;
            if (TxtNAutorization.Text.Length == 0)
            {
                validate = false;
                functions.ShowMessage("La autorizacion no puede estar vacia.", ClsEnums.MessageType.ERROR);
            }
            else if (TxtNAutorization.Text.Length != 10)
            {
                validate = false;
                functions.ShowMessage("La autorizacion no puede estar vacia.", ClsEnums.MessageType.ERROR);
            }
            if (TxtNRetention.Text.Length == 0)
            {
                validate = false;
                functions.ShowMessage("La retencion no puede estar vacia.", ClsEnums.MessageType.ERROR);
            }
            else if (TxtNRetention.Text.Length != 15)
            {
                functions.ShowMessage("La retencion no puede estar vacia.", ClsEnums.MessageType.ERROR);
                validate = false;
            }

            if (validate)
            {
                processResponse = true;
                authorization = TxtNAutorization.Text;
                retentionNumber = TxtNRetention.Text;
                retentionAmount = decimal.Parse(LblAmount.Text);
            }
            else
            {
                functions.ShowMessage("Debe llenar todos los campos", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CREDITCARD_AUTHORIZATION;
            keyPad.ShowDialog();
            TxtNAutorization.Text = keyPad.creditCardAuthorization;
        }

        private void BtnKeypadRet_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CREDITCARD_AUTHORIZATION;
            keyPad.ShowDialog();
            TxtNRetention.Text = keyPad.creditCardAuthorization;
        }
    }
}