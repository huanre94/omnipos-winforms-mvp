using POS.DLL.Enums;
using System;

namespace POS
{
    public partial class FrmKeyPad : DevExpress.XtraEditors.XtraForm
    {
        public InputFromOption inputFromOption;
        public string creditCardAuthorization = "";
        public string checkAuthorization = "";
        public string checkAccountNumber = "";
        public string checkNumber = "";
        public string checkOwnerIdentification = "";
        public string checkPhone = "";
        public string giftcardNumber = "";
        public string customerPhone = "";
        public string loginUsername = "";
        public string loginPassword = "";
        public string productQuantity = "";
        public string emissionPoint = "";
        public string invoiceNumber = "";
        public string productInventory = "";
        public string supervisorPassword = "";
        public string salesOrderId = "";
        public string advanceAmount = "";

        public FrmKeyPad()
        {
            InitializeComponent();
        }

        private void FrmKeyPad_Load(object sender, EventArgs e)
        {
            if (inputFromOption == InputFromOption.LOGIN_PASSWORD)
            {
                TxtValue.Properties.UseSystemPasswordChar = true;
                TxtValue.Properties.PasswordChar = '•';
            }
            else
            {
                TxtValue.Properties.UseSystemPasswordChar = false;
                TxtValue.Properties.PasswordChar = '\0';

                BtnDot.Enabled = inputFromOption == InputFromOption.PRODUCT_INVENTORY || inputFromOption == InputFromOption.ADVANCE_AMOUNT;
            }
        }

        #region KeyPad Buttons
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

        private void BtnDelete_Click(object sender, EventArgs e) => TxtValue.Text = "";

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!TxtValue.Text.Contains("."))
            {
                TxtValue.Text += ".";
            }
        }
        #endregion

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtValue.Text == string.Empty)
            {
                new ClsFunctions().ShowMessage("Debe ingresar un numero", MessageType.WARNING);
                return;
            }

            switch (inputFromOption)
            {
                case InputFromOption.CHECK_ACCOUNTNUMBER:
                    checkAccountNumber = TxtValue.Text;
                    break;
                case InputFromOption.CHECK_AUTHORIZATION:
                    checkAuthorization = TxtValue.Text;
                    break;
                case InputFromOption.CHECK_NUMBER:
                    checkNumber = TxtValue.Text;
                    break;
                case InputFromOption.CHECK_OWNERIDENTIFICATION:
                    checkOwnerIdentification = TxtValue.Text;
                    break;
                case InputFromOption.CHECK_PHONE:
                    checkPhone = TxtValue.Text;
                    break;
                case InputFromOption.CREDITCARD_AUTHORIZATION:
                    creditCardAuthorization = TxtValue.Text;
                    break;
                case InputFromOption.GIFTCARD_NUMBER:
                    giftcardNumber = TxtValue.Text;
                    break;
                case InputFromOption.CUSTOMER_PHONE:
                    customerPhone = TxtValue.Text;
                    break;
                case InputFromOption.LOGIN_USERNAME:
                    loginUsername = TxtValue.Text;
                    break;
                case InputFromOption.LOGIN_PASSWORD:
                    loginPassword = TxtValue.Text;
                    break;
                case InputFromOption.PRODUCT_QUANTITY:
                    productQuantity = TxtValue.Text;
                    break;
                case InputFromOption.EMISSIONPOINT_NUMBER:
                    emissionPoint = TxtValue.Text;
                    break;
                case InputFromOption.INVOICE_NUMBER:
                    invoiceNumber = TxtValue.Text;
                    break;
                case InputFromOption.PRODUCT_INVENTORY:
                    productInventory = TxtValue.Text;
                    break;
                case InputFromOption.SUPERVISOR_PASSWORD:
                    supervisorPassword = TxtValue.Text;
                    break;
                case InputFromOption.SALESORDER_ID:
                    salesOrderId = TxtValue.Text;
                    break;
                case InputFromOption.ADVANCE_AMOUNT:
                    advanceAmount = TxtValue.Text;
                    break;
                default:
                    break;
            }
            Close();
        }

        private void TxtValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (((int)e.KeyCode) == 13)
            {
                BtnEnter_Click(null, null);
            }

            if (((int)e.KeyCode) == 27)
            {
                Close();
            }
        }

        private void TxtValue_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}