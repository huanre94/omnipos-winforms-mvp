﻿using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
        public bool applyPaymmodeDiscount = false;
        public XElement invoiceXml;
        public EmissionPoint emissionPoint;
        public decimal amountPaymmodeDiscount = 0;

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
                amountPaymmodeDiscount = LblAmountDiscounted.Text == string.Empty ? 0 : decimal.Parse(LblAmountDiscounted.Text);
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

            var line = from r in invoiceXml.Descendants("InvoiceLine")
                       select r;

            foreach (var item in line)
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
                    long availableProm = new ClsPaymMode().GetPromotionsCount(customer.CustomerId, selectedCardBank, selectedCardBrand);
                    if (availableProm > 0)
                    {
                        string paymmode = string.Format("{0}|{1}|{2}", (int)paymModeEnum, selectedCardBank, selectedCardBrand);

                        var invoiceDetails = (from li in invoiceXml.Descendants("InvoiceLine") select li).ToList();

                        foreach (XElement item in invoiceDetails)
                        {
                            decimal qtyFound = 0;
                            string barcode = "";

                            foreach (var node in item.Elements())
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

                            SP_Product_Consult_Result _productResult = new ClsInvoiceTrans().ProductConsult(
                                                 emissionPoint.LocationId,
                                                 barcode,
                                                 qtyFound,
                                                 customer.CustomerId,
                                                 0,
                                                 paymmode
                                                 );


                            var updateQuery = from r in invoiceXml.Descendants("InvoiceLine")
                                              where r.Element("ProductId").Value == _productResult.ProductId.ToString()
                                              select r;

                            foreach (var query in updateQuery)
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
                    functions.ShowMessage(
                                           "Ocurrio un problema al cargar promociones de este banco."
                                           , ClsEnums.MessageType.ERROR
                                           , true
                                           , ex.InnerException.Message
                                       );
                }
            }
        }
    }
}