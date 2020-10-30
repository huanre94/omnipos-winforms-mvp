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
    public partial class FrmPaymentCredit : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal creditLimit;
        public decimal paidAmount;

        public FrmPaymentCredit()
        {
            InitializeComponent();
        }        

        private void TxtCreditCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCreditCardCode.Text != "")
                {                    
                    List<DLL.SP_InternalCreditCard_Consult_Result> result;
                    DLL.Transaction.ClsCustomer customer = new DLL.Transaction.ClsCustomer();

                    try
                    {
                        result = customer.GetInternalCreditCard(TxtCreditCardCode.Text);

                        if (result != null)
                        {
                            if (result.Count > 0)
                            {
                                LblHolderName.Text = result.FirstOrDefault().Name;
                                creditLimit = result.FirstOrDefault().Consumed;
                                LblCreditLimit.Text = creditLimit.ToString();
                            }
                            else
                            {
                                functions.ShowMessage("No existe titular asociado a la tarjeta ingresada.", ClsEnums.MessageType.WARNING);
                                TxtCreditCardCode.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {                        
                        functions.ShowMessage(
                                                "Ocurrio un problema al consultar tarjeta de consumo."
                                                ,ClsEnums.MessageType.ERROR
                                                ,true
                                                ,ex.Message
                                                );
                    }
                }
            }            
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtCreditCardCode.Text != "")
            {
                if (creditLimit > 0)
                {
                    if (creditLimit >= paidAmount)
                    {
                        TxtCreditCardCode.Text = "";
                        formActionResult = true;
                    }
                    else
                    {
                        functions.ShowMessage("El saldo de la tarjeta es insuficiente para realizar la compra.", ClsEnums.MessageType.WARNING);
                    }
                }
                else
                {
                    functions.ShowMessage("No se obtuvieron datos de la tarjeta de consumo.", ClsEnums.MessageType.WARNING);
                }
            }
            else
            {                
                functions.ShowMessage("Debe proporcionar el codigo de la tarjeta.", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }

        }
    }
}