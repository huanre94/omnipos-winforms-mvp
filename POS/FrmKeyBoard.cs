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
    public partial class FrmKeyBoard : DevExpress.XtraEditors.XtraForm
    {
        public ClsEnums.InputFromOption inputFromOption;
        public string checkOwnerName = "";
        public string checkOwnerIdentification = "";
        public string customerIdentification = "";
        public string customerFirstName = "";
        public string customerLastName = "";
        public string customerAddress = "";
        public string customerEmail = "";

        public FrmKeyBoard()
        {
            InitializeComponent();
        }

        #region Keyboard Buttons
        private void BtnQ_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "Q";
        }

        private void BtnW_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "W";
        }

        private void BtnE_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "E";
        }

        private void BtnR_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "R";
        }

        private void BtnT_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "T";
        }

        private void BtnY_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "Y";
        }

        private void BtnU_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "U";
        }

        private void BtnI_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "I";
        }

        private void BtnO_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "O";
        }

        private void BtnP_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "P";
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "A";
        }

        private void BtnS_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "S";
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "D";
        }

        private void BtnF_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "F";
        }

        private void BtnG_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "G";
        }

        private void BtnH_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "H";
        }

        private void BtnJ_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "J";
        }

        private void BtnK_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "K";
        }

        private void BtnL_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "L";
        }

        private void BtnZ_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "Z";
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "X";
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "C";
        }

        private void BtnV_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "V";
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "B";
        }

        private void BtnN_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "N";
        }

        private void BtnM_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "M";
        }

        private void BtnComma_Click(object sender, EventArgs e)
        {
            TxtValue.Text += ",";
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            TxtValue.Text += ".";
        }

        private void BtnAt_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "@";
        }

        private void BtnHyphen_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "-";
        }

        private void BtnUnderscore_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "_";
        }

        private void BtnSpace_Click(object sender, EventArgs e)
        {
            TxtValue.Text += " ";
        }

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

        private void BtnDot2_Click(object sender, EventArgs e)
        {
            TxtValue.Text += ".";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text != "")
            {
                TxtValue.Text = TxtValue.Text.Remove(TxtValue.Text.Length - 1);
            }
        }
        #endregion

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text != "")
            {
                switch (inputFromOption)
                {
                    case ClsEnums.InputFromOption.CHECK_OWNERNAME:
                        checkOwnerName = TxtValue.Text;
                        break;                    
                    case ClsEnums.InputFromOption.CHECK_OWNERIDENTIFICATION:
                        checkOwnerIdentification = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION:
                        customerIdentification = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CUSTOMER_FIRSTNAME:
                        customerFirstName = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CUSTOMER_LASTNAME:
                        customerLastName = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CUSTOMER_ADDRESS:
                        customerAddress = TxtValue.Text;
                        break;
                    case ClsEnums.InputFromOption.CUSTOMER_EMAIL:
                        customerEmail = TxtValue.Text.ToLower();
                        break;
                    default:
                        break;
                }               

                this.Close();
            }
        }

        
    }
}