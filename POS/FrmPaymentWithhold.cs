using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentWithhold : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public bool processResponse;
        public Customer customer = null;
        public SP_Login_Consult_Result loginInformation;
        public decimal baseAmount = 0.00M;
        public decimal taxAmount = 0.00M;
        public bool isTaxPayerCompany = false;
        public bool isTaxPayerCustomer = false;
        public string authorization = "";
        public int retentionCode;
        public string retentionNumber = "";
        public decimal totalDiscounted = 0;
        public List<InvoicePayment> retentionList;

        public FrmPaymentWithhold()
        {
            InitializeComponent();
        }

        private void FrmPaymentWithhold2_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                LoadTaxPercent();
            }
        }

        private void LoadTaxPercent()
        {
            bool customerTaxPayer = customer.IsSpecialTaxpayer ?? false;
            bool companyTaxPayer = loginInformation.IsTaxpayerSpecial ?? false;
            customer.UseRetention = true;
            if (!(customer.UseRetention ?? false))
            {
                functions.ShowMessage("Cliente no aplica retencion", MessageType.ERROR);
                Close();
                return;
            }

            IEnumerable<RetentionTable> retentions = LoadRetentions((int)Taxtype.RENTA);
            RetentionTable retentionPercent = (from re in retentions select re).FirstOrDefault();
            decimal totalBaseCalculated = baseAmount * retentionPercent.Percent / 100;
            LblBaseAmount.Text = Math.Round(baseAmount, 2).ToString();
            LblBasePercent.Text = retentionPercent.Percent.ToString();
            LblAmount.Text = Math.Round(totalBaseCalculated, 2).ToString();
            LblTaxBaseAmount.Text = Math.Round(taxAmount, 2).ToString();

            InvoicePayment invoicePayment = new InvoicePayment
            {
                PaymModeId = (int)PaymModeEnum.RETENCION,
                RetentionCode = retentionPercent.RetentionCode,
                Amount = totalBaseCalculated
            };

            retentionList = new List<InvoicePayment>
                {
                    invoicePayment
                };

            if (taxAmount <= 0)
            {
                LblTaxBaseAmount.Enabled = false;
                CmbTaxPercent.Enabled = false;
                LblTaxAmount.Enabled = false;
                return;
            }

            retentions = LoadRetentions((int)Taxtype.IVA);

            if (retentions?.Count() > 0)
            {
                foreach (RetentionTable retention in retentions)
                {
                    CmbTaxPercent.Properties.Items.Add(new ImageComboBoxItem { Value = retention.RetentionCode, Description = retention.Percent.ToString() });
                }
            }
        }

        private bool ValidateCustomerInformation()
        {
            if (customer?.CustomerId > 1)
            {
                return true;
            }

            functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
            DialogResult = DialogResult.Cancel;
            return false;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            bool validate = true;

            if (taxAmount != 0 && CmbTaxPercent.SelectedItem == null)
            {
                functions.ShowMessage("Debe seleccionar un impuesto para la retención al IVA.", MessageType.ERROR);
                validate = false;
            }

            if (TxtNAutorization.Text.Length == 0)
            {
                validate = false;
                functions.ShowMessage("El número de autorización no puede estar vacío.", MessageType.ERROR);
            }
            else if (TxtNAutorization.Text.Length != 10)
            {
                validate = false;
                functions.ShowMessage("El número de autorización debe tener 10 dígitos.", MessageType.ERROR);
            }

            if (TxtNRetention.Text.Length == 0)
            {
                validate = false;
                functions.ShowMessage("El número de la retención no puede estar vacío.", MessageType.ERROR);
            }
            else if (TxtNRetention.Text.Length != 15)
            {
                functions.ShowMessage("El número de la retención debe tener 15 dígitos.", MessageType.ERROR);
                validate = false;
            }

            if (!validate)
            {
                functions.ShowMessage("Debe llenar todos los campos", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            if (taxAmount > 0)
            {
                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)PaymModeEnum.RETENCION,
                    RetentionCode = int.Parse(CmbTaxPercent.EditValue.ToString()),
                    Amount = decimal.Parse(LblTaxAmount.Text)
                };
                retentionList.Add(invoicePayment);
            }

            decimal totalValue = 0;
            foreach (InvoicePayment item in retentionList)
            {
                item.Authorization = TxtNAutorization.Text;
                item.RetentionNumber = TxtNRetention.Text;
                totalValue += item.Amount;
            }

            processResponse = true;
            totalDiscounted = totalValue;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = InputFromOption.CREDITCARD_AUTHORIZATION
            };
            keyPad.ShowDialog();
            TxtNAutorization.Text = keyPad.creditCardAuthorization;
        }

        private void BtnKeypadRet_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = InputFromOption.CREDITCARD_AUTHORIZATION
            };
            keyPad.ShowDialog();
            TxtNRetention.Text = keyPad.creditCardAuthorization;
        }

        private IEnumerable<RetentionTable> LoadRetentions(int typeRetention)
        {
            IEnumerable<RetentionTable> retentions = null;
            try
            {
                retentions = new ClsPaymMode(Program.customConnectionString).GetRetentionTables(typeRetention);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de Bancos.",
                     MessageType.ERROR,
                    true,
                    ex.InnerException.Message);
            }
            return null;
        }

        private void CmbTaxPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal totalTaxAmount = taxAmount * decimal.Parse(CmbTaxPercent.SelectedItem.ToString()) / 100;
            LblTaxAmount.Text = totalTaxAmount.ToString("#.00");
        }
    }
}