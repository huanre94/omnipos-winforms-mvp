using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentWithhold : DevExpress.XtraEditors.XtraForm
    {
        public bool processResponse;
        ClsFunctions functions = new ClsFunctions();
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
            ValidateCustomerInformation();
            LoadTaxPercent();
        }

        private void LoadTaxPercent()
        {
            ClsPaymMode paymMode = new ClsPaymMode();
            List<RetentionTable> retentionTables;

            bool customerTaxPayer = customer.IsSpecialTaxpayer ?? false;
            bool companyTaxPayer = loginInformation.IsTaxpayerSpecial ?? false;
            customer.UseRetention = true;
            if (customer.UseRetention ?? false)
            {
                List<RetentionTable> retentions = LoadRetentions((int)ClsEnums.Taxtype.RENTA);
                RetentionTable retentionPercent = (from re in retentions select re).FirstOrDefault();
                decimal totalBaseCalculated = baseAmount * retentionPercent.Percent / 100;
                LblBaseAmount.Text = baseAmount.ToString("#.00");
                LblBasePercent.Text = retentionPercent.Percent.ToString();
                LblAmount.Text = totalBaseCalculated.ToString("#.00");
                LblTaxBaseAmount.Text = taxAmount.ToString("#.00");

                InvoicePayment invoicePayment = new InvoicePayment
                {
                    PaymModeId = (int)ClsEnums.PaymModeEnum.RETENCION,
                    RetentionCode = retentionPercent.RetentionCode,
                    Amount = totalBaseCalculated
                };

                retentionList = new List<InvoicePayment>();
                retentionList.Add(invoicePayment);

                if (taxAmount > 0)
                {
                    retentions = LoadRetentions((int)ClsEnums.Taxtype.IVA);
                    if (retentions != null)
                    {
                        if (retentions.Count > 0)
                        {
                            foreach (var retention in retentions)
                            {
                                CmbTaxPercent.Properties.Items.Add(new ImageComboBoxItem { Value = retention.RetentionCode, Description = retention.Percent.ToString() });
                            }
                        }
                    }
                }
                else
                {
                    LblTaxBaseAmount.Enabled = false;
                    CmbTaxPercent.Enabled = false;
                    LblTaxAmount.Enabled = false;
                }

            }
            else
            {
                functions.ShowMessage("Cliente no aplica retencion", ClsEnums.MessageType.ERROR);
                this.Close();
            }
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (customer != null)
            {
                if (customer.CustomerId > 1)
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

            if (taxAmount != 0 && CmbTaxPercent.SelectedItem == null)
            {
                validate = false;
                functions.ShowMessage("Debe seleccionar un impuesto al IVA.", ClsEnums.MessageType.ERROR);
            }

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
                if (taxAmount > 0)
                {
                    InvoicePayment invoicePayment = new InvoicePayment
                    {
                        PaymModeId = (int)ClsEnums.PaymModeEnum.RETENCION,
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

        private List<RetentionTable> LoadRetentions(int typeRetention)
        {
            List<RetentionTable> retentions = null;
            try
            {
                retentions = new ClsPaymMode().GetRetentionTables(typeRetention);
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Bancos."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
            return retentions;
        }

        private void CmbTaxPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal totalTaxAmount = taxAmount * decimal.Parse(CmbTaxPercent.SelectedItem.ToString()) / 100;
            LblTaxAmount.Text = totalTaxAmount.ToString("#.00");
        }
    }
}