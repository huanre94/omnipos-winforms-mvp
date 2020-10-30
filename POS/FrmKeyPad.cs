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
    public partial class FrmKeyPad : DevExpress.XtraEditors.XtraForm
    {
        public ClsEnums.InputFromOption inputFromOption;
        public string creditCardAuthorization;
        public string checkAccountNumber;
        public string checkNumber;
        public string checkOwnerIdentification;
        public string checkPhone;
        public string giftcardNumber;

        public FrmKeyPad()
        {
            InitializeComponent();
        }

        #region KeyPad Buttons
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtValue.Text = "";
        }
        #endregion

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text != "")
            {
                switch (inputFromOption)
                {
                    case ClsEnums.InputFromOption.CHECK_ACCOUNTNUMBER:
                        checkAccountNumber = TxtValue.Text;
                        break;                    
                    case ClsEnums.InputFromOption.CHECK_NUMBER:
                        checkNumber = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CHECK_OWNERIDENTIFICATION:
                        checkOwnerIdentification = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CHECK_PHONE:
                        checkPhone = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CREDITCARD_AUTHORIZATION:
                        creditCardAuthorization = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.GIFTCARD_NUMBER:
                        giftcardNumber = TxtValue.Text;
                        break;
                    default:
                        break;
                }                

                Close();
            }
            else
            {
                ClsFunctions functions = new ClsFunctions();
                functions.ShowMessage("Debe ingresar un numero", ClsEnums.MessageType.WARNING);
            }
        }
    }
}