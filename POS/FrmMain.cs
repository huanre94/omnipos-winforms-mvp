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
using POS.DLL.Catalog;
using POS.DLL;
using POS.Classes;

namespace POS
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Keypad Buttons

        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "2";
        }
               
        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = "";
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            ClsFunctions functions = new ClsFunctions();
            functions.ShowMessage(TxtBarcode.Text);
            TxtBarcode.Text = "";
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //Initial loading functions
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = Classes.ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION;
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification != "")
            {
                ClsCustomer customer = new ClsCustomer();
                Customer cust;

                try 
                {
                    cust = customer.GetCustomerByIdentification(keyBoard.customerIdentification);

                    if (cust != null)
                    {
                        if (cust.CustomerId > 0)
                        {
                            LblCustomerId.Text = cust.Identification;
                            LblCustomerName.Text = cust.Firtsname + " " + cust.Lastname;
                            LblCustomerAddress.Text = cust.Address;                            
                        }                        
                    }
                    else
                    {
                        bool response = functions.ShowMessage("El cliente ingresado no existe, desea ingresarlo?.", ClsEnums.MessageType.CONFIRM);

                        if (response)
                        {
                            FrmCustomer frmCustomer = new FrmCustomer();
                            frmCustomer.customerIdentification = keyBoard.customerIdentification;
                            frmCustomer.ShowDialog();
                        }
                    }
                }
                catch(Exception ex)
                {
                    functions.ShowMessage(
                                        "Ocurrio un problema al cargar información del cliente."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
                }

                
            }
        }

            

            

        private void BtnPayment_Click(object sender, EventArgs e)
        {          
            FrmPayment payment = new FrmPayment();
            payment.ShowDialog();
        }
        
    }
}