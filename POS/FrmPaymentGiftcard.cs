﻿using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentGiftcard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal giftcardAmount;
        public string giftcardNumber;
        public decimal paidAmount;

        public FrmPaymentGiftcard()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtGiftCard.Text == "")
            {
                functions.ShowMessage("El numero de bono no puede estar vacio.", MessageType.WARNING);
                return;
            }

            try
            {
                SP_GiftCard_Consult_Result result = new ClsCustomerTrans(Program.customConnectionString).GetGiftCard(TxtGiftCard.Text);

                if (result == null)
                {
                    functions.ShowMessage("No existe bono con el numero ingresado.", MessageType.WARNING);
                    TxtGiftCard.Text = "";
                    return;
                }

                if (result.Type == "PR")
                {
                    functions.ShowMessage("El bono ingresado es un bono de producto. Por favor consultar con Supervisor.", MessageType.WARNING);
                    return;
                }

                LblDocument.Text = result.InvoiceNumber;
                LblReference.Text = result.CustomerNameInvoice;
                giftcardAmount = (decimal)result.Amount;
                giftcardNumber = result.GiftCardNumber;
                LblAmount.Text = giftcardAmount.ToString();
                BtnAccept.Focus();  //07/07/2022


            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al consultar el bono."
                                        , MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                        );
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateGiftCardFields())
            {
                if (giftcardAmount <= 0)
                {
                    functions.ShowMessage("El bono no cuenta con cupo.", MessageType.WARNING);
                    DialogResult = DialogResult.None;
                    return;
                }

                if (giftcardAmount != paidAmount)
                {
                    if (paidAmount > giftcardAmount)
                    {
                        functions.ShowMessage("El saldo del bono es insuficiente para realizar la compra.", MessageType.WARNING);
                    }
                    else
                    {
                        functions.ShowMessage("El bono tiene que ser debitado en su totalidad.", MessageType.WARNING);
                    }
                    return;
                }

                TxtGiftCard.Text = "";
                formActionResult = true;
            }
        }

        private bool ValidateGiftCardFields()
        {
            bool response = false;

            if (TxtGiftCard.Text != "")
            {
                if (LblDocument.Text != "" && LblReference.Text != "")
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("No se obtuvieron datos del bono.", MessageType.WARNING);
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar el numero del bono.", MessageType.WARNING);
                return false;
            }

            if (!response)
            {
                DialogResult = DialogResult.None;
            }

            return response;
        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = InputFromOption.GIFTCARD_NUMBER
            };
            keyPad.ShowDialog();
            TxtGiftCard.Text = keyPad.giftcardNumber;
            TxtGiftCard.Focus();
        }

        private void TxtGiftCard_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnSearch_Click(null, null);
                    break;
                case Keys.F1:
                    BtnKeypad_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}