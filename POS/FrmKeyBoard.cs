﻿using POS.DLL.Enums;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmKeyBoard : DevExpress.XtraEditors.XtraForm
    {
        InputFromOption InputFromOption { get; set; }
        public string checkOwnerName = "";
        public string checkOwnerIdentification = "";
        public string customerIdentification = "";
        public string customerFirstName = "";
        public string customerLastName = "";
        public string customerAddress = "";
        public string customerEmail = "";
        public string observation = "";
        public string productName = "";

        public FrmKeyBoard(InputFromOption _inputFromOption)
        {
            InitializeComponent();
            InputFromOption = _inputFromOption;
        }

        #region Keyboard Buttons
        private void BtnQ_Click(object sender, EventArgs e) => TxtValue.Text += "Q";

        private void BtnW_Click(object sender, EventArgs e) => TxtValue.Text += "W";

        private void BtnE_Click(object sender, EventArgs e) => TxtValue.Text += "E";

        private void BtnR_Click(object sender, EventArgs e) => TxtValue.Text += "R";

        private void BtnT_Click(object sender, EventArgs e) => TxtValue.Text += "T";

        private void BtnY_Click(object sender, EventArgs e) => TxtValue.Text += "Y";

        private void BtnU_Click(object sender, EventArgs e) => TxtValue.Text += "U";

        private void BtnI_Click(object sender, EventArgs e) => TxtValue.Text += "I";

        private void BtnO_Click(object sender, EventArgs e) => TxtValue.Text += "O";

        private void BtnP_Click(object sender, EventArgs e) => TxtValue.Text += "P";

        private void BtnA_Click(object sender, EventArgs e) => TxtValue.Text += "A";

        private void BtnS_Click(object sender, EventArgs e) => TxtValue.Text += "S";

        private void BtnD_Click(object sender, EventArgs e) => TxtValue.Text += "D";

        private void BtnF_Click(object sender, EventArgs e) => TxtValue.Text += "F";

        private void BtnG_Click(object sender, EventArgs e) => TxtValue.Text += "G";

        private void BtnH_Click(object sender, EventArgs e) => TxtValue.Text += "H";

        private void BtnJ_Click(object sender, EventArgs e) => TxtValue.Text += "J";

        private void BtnK_Click(object sender, EventArgs e) => TxtValue.Text += "K";

        private void BtnL_Click(object sender, EventArgs e) => TxtValue.Text += "L";

        private void BtnZ_Click(object sender, EventArgs e) => TxtValue.Text += "Z";

        private void BtnX_Click(object sender, EventArgs e) => TxtValue.Text += "X";

        private void BtnC_Click(object sender, EventArgs e) => TxtValue.Text += "C";

        private void BtnV_Click(object sender, EventArgs e) => TxtValue.Text += "V";

        private void BtnB_Click(object sender, EventArgs e) => TxtValue.Text += "B";

        private void BtnN_Click(object sender, EventArgs e) => TxtValue.Text += "N";

        private void BtnM_Click(object sender, EventArgs e) => TxtValue.Text += "M";

        private void BtnComma_Click(object sender, EventArgs e) => TxtValue.Text += ",";

        private void BtnDot_Click(object sender, EventArgs e) => TxtValue.Text += ".";

        private void BtnAt_Click(object sender, EventArgs e) => TxtValue.Text += "@";

        private void BtnHyphen_Click(object sender, EventArgs e) => TxtValue.Text += "-";

        private void BtnUnderscore_Click(object sender, EventArgs e) => TxtValue.Text += "_";

        private void BtnSpace_Click(object sender, EventArgs e) => TxtValue.Text += " ";

        private void Btn0_Click(object sender, EventArgs e) => TxtValue.Text += "0";

        private void Btn1_Click(object sender, EventArgs e) => TxtValue.Text += "1";

        private void Btn2_Click(object sender, EventArgs e) => TxtValue.Text += "2";

        private void Btn3_Click(object sender, EventArgs e) => TxtValue.Text += "3";

        private void Btn4_Click(object sender, EventArgs e) => TxtValue.Text += "4";

        private void Btn5_Click(object sender, EventArgs e) => TxtValue.Text += "5";

        private void Btn6_Click(object sender, EventArgs e) => TxtValue.Text += "6";

        private void Btn7_Click(object sender, EventArgs e) => TxtValue.Text += "7";

        private void Btn8_Click(object sender, EventArgs e) => TxtValue.Text += "8";

        private void Btn9_Click(object sender, EventArgs e) => TxtValue.Text += "9";

        private void BtnDot2_Click(object sender, EventArgs e) => TxtValue.Text += ".";

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text == "")
            {
                return;
            }
            TxtValue.Text = TxtValue.Text.Remove(TxtValue.Text.Length - 1);
        }
        #endregion

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text == string.Empty)
            {
                new ClsFunctions().ShowMessage("Debe ingresar un valor.", MessageType.WARNING);
                return;
            }
            switch (InputFromOption)
            {
                case InputFromOption.CHECK_OWNERNAME:
                    checkOwnerName = TxtValue.Text;
                    break;
                case InputFromOption.CHECK_OWNERIDENTIFICATION:
                    checkOwnerIdentification = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_IDENTIFICATION:
                    customerIdentification = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_FIRSTNAME:
                    customerFirstName = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_LASTNAME:
                    customerLastName = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_ADDRESS:
                    customerAddress = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_EMAIL:
                    customerEmail = TxtValue.Text.ToLower();
                    break;
                case InputFromOption.OBSERVATION:
                    observation = TxtValue.Text;
                    break;
                case InputFromOption.PRODUCT_NAME:
                    productName = TxtValue.Text;
                    break;

                default:
                    break;
            }

            Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
        }

        //05/07/2022
        private void TxtValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    BtnEnter_Click(null, null);
                    break;
            }

        }
    }
}