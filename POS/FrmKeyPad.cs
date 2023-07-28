using POS.DLL.Enums;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmKeyPad : DevExpress.XtraEditors.XtraForm
    {
        InputFromOption InputFromOption { get; set; }


        string creditCardAuthorization { get; set; } = "";
        string checkAuthorization { get; set; } = "";
        string checkAccountNumber { get; set; } = "";
        string checkNumber { get; set; } = "";
        string checkOwnerIdentification { get; set; } = "";
        string checkPhone { get; set; } = "";
        string giftcardNumber { get; set; } = "";
        string customerPhone { get; set; } = "";
        string loginUsername { get; set; } = "";
        string loginPassword { get; set; } = "";
        string productQuantity { get; set; } = "";
        string emissionPoint { get; set; } = "";
        string invoiceNumber { get; set; } = "";
        string productInventory { get; set; } = "";
        string supervisorPassword { get; set; } = "";
        string salesOrderId { get; set; } = "";
        string advanceAmount { get; set; } = "";
        string closingCashierId { get; set; } = "";
        string WithHoldNumber { get; set; } = "";
        string WithHoldAuthorization { get; set; } = "";
        string ProductBarcode { get; set; } = "";

        //public FrmKeyPad()
        //{
        //    InitializeComponent();
        //}

        public FrmKeyPad(InputFromOption _inputFromOption)
        {
            InitializeComponent();
            InputFromOption = _inputFromOption;
        }

        public string GetValue()
        {
            string value = "";

            switch (InputFromOption)
            {
                case InputFromOption.CHECK_ACCOUNTNUMBER:
                    value = checkAccountNumber;
                    break;
                case InputFromOption.CHECK_AUTHORIZATION:
                    value = checkAuthorization;
                    break;
                case InputFromOption.CHECK_NUMBER:
                    value = checkNumber;
                    break;
                case InputFromOption.CHECK_OWNERIDENTIFICATION:
                    value = checkOwnerIdentification;
                    break;
                case InputFromOption.CHECK_PHONE:
                    value = checkPhone;
                    break;
                case InputFromOption.CREDITCARD_AUTHORIZATION:
                    value = creditCardAuthorization;
                    break;
                case InputFromOption.GIFTCARD_NUMBER:
                    value = giftcardNumber;
                    break;
                case InputFromOption.CUSTOMER_PHONE:
                    value = customerPhone;
                    break;
                case InputFromOption.LOGIN_USERNAME:
                    value = loginUsername;
                    break;
                case InputFromOption.LOGIN_PASSWORD:
                    value = loginPassword;
                    break;
                case InputFromOption.PRODUCT_QUANTITY:
                    value = productQuantity;
                    break;
                case InputFromOption.EMISSIONPOINT_NUMBER:
                    value = emissionPoint;
                    break;
                case InputFromOption.INVOICE_NUMBER:
                    value = invoiceNumber;
                    break;
                case InputFromOption.PRODUCT_INVENTORY:
                    value = productInventory;
                    break;
                case InputFromOption.SUPERVISOR_PASSWORD:
                    value = supervisorPassword;
                    break;
                case InputFromOption.SALESORDER_ID:
                    value = salesOrderId;
                    break;
                case InputFromOption.ADVANCE_AMOUNT:
                    value = advanceAmount;
                    break;
                case InputFromOption.CLOSING_CASHIER_ID:
                    value = closingCashierId;
                    break;
                case InputFromOption.WITHOHOLD_AUTHORIZATION: value = WithHoldAuthorization; break;
                case InputFromOption.WITHOHOLD_NUMBER: value = WithHoldNumber; break;
                case InputFromOption.PRODUCT_BARCODE: value = ProductBarcode; break;
                default:
                    break;
            }
            return value;
        }

        public InputFromOption GetInputFromOption() => InputFromOption;

        private void FrmKeyPad_Load(object sender, EventArgs e)
        {
            switch (InputFromOption)
            {
                case InputFromOption.LOGIN_PASSWORD:
                    TxtValue.Properties.UseSystemPasswordChar = true;
                    TxtValue.Properties.PasswordChar = '•';
                    break;
                default:
                    TxtValue.Properties.UseSystemPasswordChar = false;
                    TxtValue.Properties.PasswordChar = '\0';

                    BtnDot.Enabled = InputFromOption == InputFromOption.PRODUCT_INVENTORY || InputFromOption == InputFromOption.ADVANCE_AMOUNT;
                    break;
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

            switch (InputFromOption)
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
                case InputFromOption.CLOSING_CASHIER_ID:
                    closingCashierId = TxtValue.Text;
                    break;
                case InputFromOption.WITHOHOLD_AUTHORIZATION: WithHoldAuthorization = TxtValue.Text; break;
                case InputFromOption.WITHOHOLD_NUMBER: WithHoldNumber = TxtValue.Text; break;
                case InputFromOption.PRODUCT_BARCODE: ProductBarcode = TxtValue.Text; break;
                default:
                    break;
            }

            Close();
        }

        private void TxtValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnEnter_Click(null, null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void TxtValue_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}