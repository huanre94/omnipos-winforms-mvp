using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

// HR002 Hugo Restrepo 2021-03-02: Recalculate discount with payment mode
namespace POS
{
    public partial class FrmPaymentCard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public PaymModeEnum paymModeEnum;
        public int bankId;
        public int creditCardId;
        public decimal creditCardAmount = 0.00M;
        public string authorization = "";
        public bool processResponse;
        public Customer customer = null;
        //Begin(HR002)
        public bool applyPaymmodeDiscount = false;
        public XElement invoiceXml;
        public EmissionPoint emissionPoint;
        public decimal amountPaymmodeDiscount = 0;
        //End(HR002)

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
                if (customer.CustomerId != 1)
                {
                    LblCustomerName.Text = $"{customer.Firtsname} {customer.Lastname}";
                    response = true;
                }
                else
                {
                    functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", MessageType.ERROR);
                    DialogResult = DialogResult.Cancel;
                }
            }

            return response;
        }

        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.CREDITCARD_AUTHORIZATION);
            keyPad.ShowDialog();

            TxtAuthorization.Text = keyPad.GetValue();
            TxtAuthorization.Focus();
        }

        private void LoadBanks()
        {
            try
            {
                IEnumerable<Bank> banks = new ClsPaymMode(Program.customConnectionString).GetBanks();

                if (banks?.Count() > 0)
                {
                    foreach (Bank bank in banks)
                    {
                        CmbCardBank.Properties.Items.Add(new ImageComboBoxItem { Value = bank.BankId, Description = bank.Name });
                    }
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de Bancos.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

        }

        private void CmbCardBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCardBank = int.Parse(CmbCardBank.EditValue.ToString());
            CmbCardBrand.Properties.Items.Clear();
            LoadCreditCards(selectedCardBank);
            CmbCardBrand.SelectedIndex = -1;
            label1.Visible = false;
            LblAmountDiscounted.Visible = false;
            LblAmountDiscounted.Text = string.Empty;
        }

        private void LoadCreditCards(int _bankId)
        {
            IEnumerable<CreditCard> creditCards;

            if (CmbCardType.SelectedItem != null)
            {
                try
                {
                    paymModeEnum = CmbCardType.SelectedItem.ToString() == "DEBITO" ? PaymModeEnum.DEBITO_BANCARIO : PaymModeEnum.TARJETA_CREDITO;

                    creditCards = new ClsPaymMode(Program.customConnectionString).GetCreditCardsByBank(_bankId, true);   //13/07/2022 No enviaba parametro booleano, por defoult envia true

                    foreach (CreditCard creditCard in creditCards)
                    {
                        CmbCardBrand.Properties.Items.Add(new ImageComboBoxItem { Value = creditCard.CreditCardId, Description = creditCard.Name });
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar lista de Marcas de Tarjeta.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (CmbCardType.SelectedItem == null || CmbCardBank.EditValue == null || CmbCardBrand.EditValue == null || TxtAuthorization.Text == "")
            {
                functions.ShowMessage("Debe llenar todos los campos", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            bankId = int.Parse(CmbCardBank.EditValue.ToString());
            creditCardId = int.Parse(CmbCardBrand.EditValue.ToString());
            authorization = TxtAuthorization.Text;
            amountPaymmodeDiscount = LblAmountDiscounted.Text == string.Empty ? 0 : decimal.Parse(LblAmountDiscounted.Text);
            processResponse = true;
        }

        private void CmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCardBank.Properties.Items.Clear();
            CmbCardBrand.Properties.Items.Clear();
            label1.Visible = false;
            LblAmountDiscounted.Visible = false;
            LblAmountDiscounted.Text = string.Empty;
            LoadBanks();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private decimal CalculateInvoice()
        {
            decimal invoiceAmount = 0.00M;
            decimal discAmount = 0.00M;

            IEnumerable<XElement> line = invoiceXml.Descendants("InvoiceLine");

            foreach (XElement item in line)
            {
                discAmount += decimal.Parse(item.Element("LineDiscount").Value);
                invoiceAmount += decimal.Parse(item.Element("LineAmount").Value);
            }

            return Math.Round(invoiceAmount, 2);
        }

        private void CmbCardBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCardBank = int.Parse(CmbCardBank.EditValue.ToString());
            if (CmbCardBrand.EditValue == null)
            {
                label1.Visible = false;
                LblAmountDiscounted.Visible = false;
                LblAmountDiscounted.Text = string.Empty;
                return;
            }
            int selectedCardBrand = int.Parse(CmbCardBrand.EditValue.ToString());
            if (applyPaymmodeDiscount)
            {
                try
                {
                    long availableProm = new ClsPaymMode(Program.customConnectionString).GetPromotionsCount(customer.CustomerId, selectedCardBank, selectedCardBrand);
                    if (availableProm > 0)
                    {
                        string paymmode = string.Format("{0}|{1}|{2}", (int)paymModeEnum, selectedCardBank, selectedCardBrand);

                        List<XElement> invoiceDetails = (from li in invoiceXml.Descendants("InvoiceLine") select li).ToList();

                        foreach (XElement item in invoiceDetails)
                        {
                            decimal qtyFound = 0;
                            string barcode = "";

                            foreach (XElement node in item.Elements())
                            {
                                switch (node.Name.ToString())
                                {
                                    case "Barcode":
                                        barcode = node.Value;
                                        break;
                                    case "BarcodeBefore":
                                        if (node.Value != "")
                                        {
                                            barcode = node.Value;
                                        }
                                        break;
                                    case "Quantity":
                                        qtyFound = decimal.Parse(node.Value);
                                        break;
                                }
                            }

                            ProductConsultDto product = new ProductConsultDto(emissionPoint.LocationId,
                                barcode,
                                qtyFound,
                                customer.CustomerId,
                                0,
                                paymmode);

                            SP_Product_Consult_Result _productResult = new ClsInvoiceTrans(Program.customConnectionString).ProductConsult(product);


                            IEnumerable<XElement> updateQuery =
                                invoiceXml
                                .Descendants("InvoiceLine")
                                .Where(r => r.Element("ProductId").Value == _productResult.ProductId.ToString());

                            foreach (XElement query in updateQuery)
                            {
                                query.Element("Cost").SetValue(_productResult.Cost);
                                query.Element("Price").SetValue(_productResult.Price);
                                query.Element("PromotionPrice").SetValue(_productResult.PromotionPrice);
                                query.Element("FinalPrice").SetValue(_productResult.FinalPrice);
                                query.Element("TaxProductAmount").SetValue(_productResult.TaxProductAmount);
                                query.Element("DiscountProductAmount").SetValue(_productResult.DiscountProductAmount);
                                query.Element("IrbpProductAmount").SetValue(_productResult.IrbpProductAmount);
                                query.Element("Stock").SetValue(_productResult.Stock);
                                query.Element("Quantity").SetValue(_productResult.Quantity);
                                query.Element("BaseAmount").SetValue(_productResult.BaseAmount);
                                query.Element("BaseTaxAmount").SetValue(_productResult.BaseTaxAmount);
                                query.Element("LinePercent").SetValue(_productResult.LinePercent);
                                query.Element("LineDiscount").SetValue(_productResult.LineDiscount);
                                query.Element("TaxPercent").SetValue(_productResult.TaxPercent);
                                query.Element("TaxAmount").SetValue(_productResult.TaxAmount);
                                query.Element("IrbpAmount").SetValue(_productResult.IrbpAmount);
                                query.Element("LineAmount").SetValue(_productResult.LineAmount);
                                query.Element("RewardPercent").SetValue(_productResult.RewardPercent);
                                //query.Element("BarcodeBefore").SetValue(_barcode);  // IG002
                            }
                        }
                        decimal newAmount = CalculateInvoice();
                        if (creditCardAmount != newAmount)
                        {
                            label1.Visible = true;
                            LblAmountDiscounted.Text = newAmount.ToString();
                            LblAmountDiscounted.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar promociones de este banco.",
                        MessageType.ERROR,
                        true,
                        ex.InnerException.Message);
                }
            }
        }


        private void CmbCardType_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CmbCardBank.Focus();
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void CmbCardBank_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CmbCardBrand.Focus();
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void CmbCardBrand_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtAuthorization.Focus();
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void TxtAuthorization_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnAccept.Focus();
                    break;
                case Keys.F1:
                    BtnKeyPad_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}