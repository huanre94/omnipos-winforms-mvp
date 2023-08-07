using POS.DLL.Repository;
using POS.DLL;
using POS.DLL.Enums;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentGiftcard : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public decimal giftcardAmount;
        public string giftcardNumber;
        public decimal PaidAmount { get; set; }
        public bool FormActionResult { get; set; }

        public FrmPaymentGiftcard(decimal paidAmount)
        {
            InitializeComponent();
            PaidAmount = paidAmount;
        }


        public FrmPaymentGiftcard()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtGiftCard.Text == string.Empty)
            {
                functions.ShowMessage("El numero de bono no puede estar vacio.", MessageType.WARNING);
                ClearGiftCard();
                return;
            }

            try
            {
                SP_GiftCard_Consult_Result result = new GiftcardRepository(Program.customConnectionString).GetGiftCard(TxtGiftCard.Text);

                if (result == null)
                {
                    functions.ShowMessage("No existe bono con el numero ingresado.", MessageType.WARNING);
                    ClearGiftCard();
                    return;
                }

                if (result.Type == "PR")
                {
                    functions.ShowMessage("El bono ingresado es un bono de producto. Por favor consultar con Supervisor.", MessageType.WARNING);
                    ClearGiftCard();
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
                functions.ShowMessage("Ocurrio un problema al consultar el bono.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void ClearGiftCard()
        {
            TxtGiftCard.Text = string.Empty;
            TxtGiftCard.Focus();
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

                if (giftcardAmount != PaidAmount)
                {
                    if (PaidAmount > giftcardAmount)
                    {
                        functions.ShowMessage("El saldo del bono es insuficiente para realizar la compra.", MessageType.WARNING);
                    }
                    else
                    {
                        functions.ShowMessage("El bono tiene que ser debitado en su totalidad.", MessageType.WARNING);
                    }
                    return;
                }

                ClearGiftCard();
                FormActionResult = true;
            }
        }

        private bool ValidateGiftCardFields()
        {
            if (TxtGiftCard.Text == string.Empty)
            {
                functions.ShowMessage("Debe proporcionar el numero del bono.", MessageType.WARNING);
                return false;
            }

            if (LblDocument.Text == string.Empty || LblReference.Text == string.Empty)
            {
                functions.ShowMessage("No se obtuvieron datos del bono.", MessageType.WARNING);
                return false;
            }

            DialogResult = DialogResult.None;
            return true;
        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.GIFTCARD_NUMBER);
            keyPad.ShowDialog();
            TxtGiftCard.Text = keyPad.GetValue();
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