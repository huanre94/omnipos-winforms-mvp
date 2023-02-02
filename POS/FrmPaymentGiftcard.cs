using POS.Classes;
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
            if (TxtGiftCard.Text != "")
            {
                DLL.SP_GiftCard_Consult_Result result;
                DLL.Transaction.ClsCustomerTrans customer = new DLL.Transaction.ClsCustomerTrans();

                try
                {
                    result = customer.GetGiftCard(TxtGiftCard.Text);

                    if (result != null)
                    {
                        if (result.Type == "PR")
                        {
                            functions.ShowMessage("El bono ingresado es un bono de producto. Por favor consultar con Supervisor.", ClsEnums.MessageType.WARNING);
                        }
                        else
                        {
                            LblDocument.Text = result.InvoiceNumber;
                            LblReference.Text = result.CustomerNameInvoice;
                            giftcardAmount = (decimal)result.Amount;
                            giftcardNumber = result.GiftCardNumber;
                            LblAmount.Text = giftcardAmount.ToString();
                            BtnAccept.Focus();  //07/07/2022
                        }
                    }
                    else
                    {
                        functions.ShowMessage("No existe bono con el numero ingresado.", ClsEnums.MessageType.WARNING);
                        TxtGiftCard.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al consultar el bono."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                            );
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateGiftCardFields())
            {
                if (giftcardAmount > 0)
                {
                    if (giftcardAmount == paidAmount)
                    {
                        TxtGiftCard.Text = "";
                        formActionResult = true;
                    }
                    else if (paidAmount > giftcardAmount)
                    {
                        functions.ShowMessage("El saldo del bono es insuficiente para realizar la compra.", ClsEnums.MessageType.WARNING);
                    }
                    else
                    {
                        functions.ShowMessage("El bono tiene que ser debitado en su totalidad.", ClsEnums.MessageType.WARNING);
                    }
                }
                else
                {
                    functions.ShowMessage("El bono no cuenta con cupo.", ClsEnums.MessageType.WARNING);
                    this.DialogResult = DialogResult.None;
                }
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
                    functions.ShowMessage("No se obtuvieron datos del bono.", ClsEnums.MessageType.WARNING);
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar el numero del bono.", ClsEnums.MessageType.WARNING);
            }

            if (!response)
            {
                DialogResult = DialogResult.None;
            }

            return response;
        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.GIFTCARD_NUMBER;
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