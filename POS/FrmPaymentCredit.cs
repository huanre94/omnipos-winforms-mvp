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
using POS.DLL;

namespace POS
{
    public partial class FrmPaymentCredit : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public decimal creditLimit;
        public decimal paidAmount;
        public Customer customer = null;

        public FrmPaymentCredit()
        {
            InitializeComponent();
        }

        private void FrmPaymentCredit_Load(object sender, EventArgs e)
        {
            ValidateCustomerInformation();
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (customer != null)
            {                
                if (customer.CustomerId > 0)
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

        private void TxtCreditCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCreditCardCode.Text != "")
                {                    
                    DLL.SP_InternalCreditCard_Consult_Result result;
                    DLL.Transaction.ClsCustomerTrans clsCustomer = new DLL.Transaction.ClsCustomerTrans();

                    try
                    {
                        result = clsCustomer.GetInternalCreditCard(TxtCreditCardCode.Text);

                        if (result != null)
                        {
                            if (result.CustomerId == customer.CustomerId)
                            {
                                LblHolderName.Text = result.Name;
                                creditLimit = result.Consumed;
                                LblCreditLimit.Text = creditLimit.ToString();
                            }
                            else
                            {
                                functions.ShowMessage("El cliente tiene que ser el titular de la tarjeta.", ClsEnums.MessageType.ERROR);
                                TxtCreditCardCode.Text = "";
                            }
                        }
                        else
                        {
                            functions.ShowMessage("No existe titular asociado a la tarjeta ingresada.", ClsEnums.MessageType.WARNING);
                            TxtCreditCardCode.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {                        
                        functions.ShowMessage(
                                                "Ocurrio un problema al consultar tarjeta de consumo."
                                                ,ClsEnums.MessageType.ERROR
                                                ,true
                                                ,ex.InnerException.Message
                                                );
                    }
                }
            }            
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInternalCreditFields())
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
                    functions.ShowMessage("La tarjeta no posee cupo.", ClsEnums.MessageType.WARNING);
                }
            }            
        }

        private bool ValidateInternalCreditFields()
        {
            bool response = false;

            if (TxtCreditCardCode.Text != "")
            {
                if (LblHolderName.Text != "" && LblCreditLimit.Text != "")
                {
                    response = true;
                }
                else
                {
                    functions.ShowMessage("No se obtuvieron datos de la tarjeta de consumo.", ClsEnums.MessageType.WARNING);
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar el codigo de la tarjeta.", ClsEnums.MessageType.WARNING);                
            }

            if (!response)
            {
                this.DialogResult = DialogResult.None;
            }

            return response;
        }        
    }
}