using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentCard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public ClsEnums.PaymModeEnum paymModeEnum;
        public int bankId;
        public int creditCardId;
        public decimal creditCardAmount = 0.00M;
        public string authorization = "";
        public bool processResponse;
        public Customer customer = null;

        public FrmPaymentCard()
        {
            InitializeComponent();
        }

        private void FrmPaymentCard_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                GetPaymentInformation();
                LoadBanks();
            }
        }

        private void GetPaymentInformation()
        {
            LblAmount.Text = creditCardAmount.ToString();
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (customer != null)
            {
                if (customer.CustomerId > 0)
                {
                    LblCustomerName.Text = customer.Firtsname + " " + customer.Lastname;
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

        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CREDITCARD_AUTHORIZATION;
            keyPad.ShowDialog();
            TxtAuthorization.Text = keyPad.creditCardAuthorization;
        }

        private void LoadBanks()
        {
            ClsPaymMode paymMode = new ClsPaymMode();
            List<DLL.Bank> banks;

            try
            {
                banks = paymMode.GetBanks();

                if (banks != null)
                {
                    if (banks.Count > 0)
                    {
                        foreach (var bank in banks)
                        {
                            CmbCardBank.Properties.Items.Add(new ImageComboBoxItem { Value = bank.BankId, Description = bank.Name });
                        }
                    }
                }
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

        }

        private void CmbCardBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCardBrand.Properties.Items.Clear();
            LoadCreditCards(int.Parse(CmbCardBank.EditValue.ToString()));
        }

        private void LoadCreditCards(int _bankId)
        {
            DLL.Catalog.ClsPaymMode paymMode = new ClsPaymMode();
            List<CreditCard> creditCards;

            if (CmbCardType.SelectedItem != null)
            {
                try
                {
                    if (CmbCardType.SelectedItem.ToString() == "DEBITO")
                    {
                        paymModeEnum = ClsEnums.PaymModeEnum.DEBITO_BANCARIO;

                        creditCards = paymMode.GetCreditCardsByBank(_bankId, false);

                        foreach (var creditCard in creditCards)
                        {
                            CmbCardBrand.Properties.Items.Add(new ImageComboBoxItem { Value = creditCard.CreditCardId, Description = creditCard.Name });
                        }
                    }
                    else
                    {
                        paymModeEnum = ClsEnums.PaymModeEnum.TARJETA_CREDITO;

                        creditCards = paymMode.GetCreditCardsByBank(_bankId);

                        foreach (var creditCard in creditCards)
                        {
                            CmbCardBrand.Properties.Items.Add(new ImageComboBoxItem { Value = creditCard.CreditCardId, Description = creditCard.Name });
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar lista de Marcas de Tarjeta."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (CmbCardType.SelectedItem != null && CmbCardBank.EditValue != null
                && CmbCardBrand.EditValue != null && TxtAuthorization.Text != "")
            {
                bankId = int.Parse(CmbCardBank.EditValue.ToString());
                creditCardId = int.Parse(CmbCardBrand.EditValue.ToString());
                authorization = TxtAuthorization.Text;

                processResponse = true;
            }
            else
            {

                functions.ShowMessage("Debe llenar todos los campos", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void CmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCardBank.Properties.Items.Clear();
            CmbCardBrand.Properties.Items.Clear();
            LoadBanks();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}