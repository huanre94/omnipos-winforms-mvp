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

namespace POS
{
    public partial class FrmKeyBoard : DevExpress.XtraEditors.XtraForm
    {
        public string fromOption;
        public string checkOwnerName;
        public string customerName;

        public FrmKeyBoard()
        {
            InitializeComponent();
        }       

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

        private void BtnSlash_Click(object sender, EventArgs e)
        {
            TxtValue.Text += "/";
        }

        private void BtnSpace_Click(object sender, EventArgs e)
        {
            TxtValue.Text += " ";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text != "")
            {
                TxtValue.Text = TxtValue.Text.Remove(TxtValue.Text.Length - 1);
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text != "")
            {
                if (fromOption == "CheckOwnerName")
                {
                    checkOwnerName = TxtValue.Text.ToUpper();
                }
                else if (fromOption == "CustomerName")
                {
                    customerName = TxtValue.Text.ToUpper();
                }

                this.Close();
            }
        }

    }
}