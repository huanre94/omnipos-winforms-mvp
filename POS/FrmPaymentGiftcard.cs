using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using POS.Classes;

namespace POS
{
    public partial class FrmPaymentGiftcard : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal giftcardAmount;
        public decimal paidAmount;

        public FrmPaymentGiftcard()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtGiftCard.Text != "")
            {
                List<DLL.SP_GiftCard_Consult_Result> result;
                DLL.Transaction.ClsCustomer customer = new DLL.Transaction.ClsCustomer();

                try
                {
                    result = customer.GetGiftCard(long.Parse(TxtGiftCard.Text));

                    if (result != null)
                    {
                        if (result.Count > 0)
                        {
                            LblDocument.Text = result.FirstOrDefault().DocNumber;
                            LblReference.Text = result.FirstOrDefault().CustomerNameInvoice;
                            giftcardAmount = (decimal)result.FirstOrDefault().Amount;
                            LblAmount.Text = giftcardAmount.ToString();                            
                        }
                        else
                        {
                            functions.ShowMessage("No existe bono con el numero ingresado.", ClsEnums.MessageType.WARNING);
                            TxtGiftCard.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(ex.Message, ClsEnums.MessageType.ERROR);
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtGiftCard.Text != "")
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
                    functions.ShowMessage("Debe primero obtener informacion del bono.", ClsEnums.MessageType.WARNING);
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar el numero del bono.", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void BtnKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.GIFTCARD_NUMBER;
            keyPad.ShowDialog();
            TxtGiftCard.Text = keyPad.giftcardNumber;
        }
    }
}