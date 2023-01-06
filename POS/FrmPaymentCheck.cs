using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaymentCheck : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool processResponse;
        public string checkOwnerName = "";
        public int checkBankId = 0;
        public DateTime checkDate;
        public string checkAccountNumber = "";
        public int checkNumber = 0;
        public decimal checkAmount = 0.00M;
        public string checkAuthorization = "";
        public Customer customer = null;

        public FrmPaymentCheck(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable

        private void FrmPaymentCheck_Load(object sender, EventArgs e)
        {
            if (ValidateCustomerInformation())
            {
                GetPaymentInformation();
                LoadBanks();
            }
        }

        private void GetPaymentInformation()
        {
            TxtCheckAmount.Text = checkAmount.ToString();
            TxtCheckDate.DateTime = DateTime.Now;
        }

        private bool ValidateCustomerInformation()
        {
            bool response = false;

            if (customer != null)
            {
                if (customer.CustomerId != 1)
                {
                    TxtIdentification.Text = customer.Identification;
                    TxtOwnerName.Text = customer.Firtsname + " " + customer.Lastname;
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

        #region Keypad Call Buttons
        private void BtnKeyboardOwner_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC);
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERNAME;
            keyBoard.ShowDialog();
            TxtOwnerName.Text = keyBoard.checkOwnerName;
            TxtOwnerName.Focus();
        }
        private void BtnKeypadIdentification_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC);
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERIDENTIFICATION;
            keyBoard.ShowDialog();
            TxtIdentification.Text = keyBoard.checkOwnerIdentification;
            TxtIdentification.Focus();
        }

        private void BtnKeypadPhone_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_PHONE;
            keyPad.ShowDialog();
            TxtPhone.Text = keyPad.checkPhone;
            TxtPhone.Focus();   //06/07/2022
        }

        private void BtnKeypadAccount_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_ACCOUNTNUMBER;
            keyPad.ShowDialog();
            TxtAccountNumber.Text = keyPad.checkAccountNumber;
            TxtAccountNumber.Focus();   //06/07/2022
        }

        private void BtnKeypadCheck_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_NUMBER;
            keyPad.ShowDialog();
            TxtCheckNumber.Text = keyPad.checkNumber;
            TxtCheckNumber.Focus();   //06/07/2022
        }

        private void BtnKeypadAuth_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_AUTHORIZATION;
            keyPad.ShowDialog();
            TxtAuthorization.Text = keyPad.checkAuthorization;
        }
        #endregion

        private void LoadBanks()
        {
            ClsPaymMode paymMode = new ClsPaymMode();
            List<DLL.Bank> banks;

            try
            {
                banks = paymMode.GetBanks(CadenaC);

                if (banks != null)
                {
                    if (banks.Count > 0)
                    {
                        foreach (var bank in banks)
                        {
                            CmbCheckBank.Properties.Items.Add(new ImageComboBoxItem { Value = bank.BankId, Description = bank.Name });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Bancos."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                        );
            }
        }

        private void BtnAuthorization_Click(object sender, EventArgs e)
        {
            if (ValidateCheckFields())
            {
                int dateDiff = DateTime.Today.CompareTo(DateTime.Parse(TxtCheckDate.Text).Date);
                if (dateDiff == 0)
                {
                    DLL.Transaction.ClsAuthorizationTrans authorization = new DLL.Transaction.ClsAuthorizationTrans();
                    SP_GaranCheck_Authorize_Result authorizeResult;

                    try
                    {
                        authorizeResult = authorization.GetGaranCheckAuth(
                                                                            int.Parse(CmbCheckBank.EditValue.ToString())
                                                                            , TxtAccountNumber.Text
                                                                            , int.Parse(TxtCheckNumber.Text)
                                                                            , checkAmount
                                                                            , TxtIdentification.Text
                                                                            , TxtOwnerName.Text
                                                                            , TxtPhone.Text
                                                                            , ""
                                                                            , CadenaC
                                                                            );

                        if (authorizeResult != null)
                        {

                            string result = authorizeResult.Result;

                            if (authorizeResult.Response == 0)
                            {
                                TxtAuthorization.Text = result;
                                functions.ShowMessage("Se ha obtenido autorizacion exitosamente. Autorizacion: " + result);
                                BtnAccept.Focus();  //06/07/2022

                            }
                            else
                            {
                                bool response = functions.ShowMessage(
                                                                        "No se ha podido obtener autorizacion. Desea ingresarla manualmente?"
                                                                        , ClsEnums.MessageType.CONFIRM
                                                                        , true
                                                                        , result
                                                                        );
                                if (response)
                                {
                                    BtnAuthorization.Visible = false;
                                    BtnKeypadAuth.Visible = true;
                                    TxtAuthorization.Enabled = true;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage(
                                                "Ocurrio un problema al obtener autorizacion."
                                                , ClsEnums.MessageType.ERROR
                                                , true
                                                , ex.InnerException.Message
                                                );
                    }
                }
                else
                {

                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateCheckFields())
            {
                int dateDiff = DateTime.Today.CompareTo(DateTime.Parse(TxtCheckDate.Text).Date);
                if (dateDiff == 0)
                {
                    if (TxtAuthorization.Text != "")
                    {
                        processResponse = true;
                        checkOwnerName = TxtOwnerName.Text;
                        checkBankId = int.Parse(CmbCheckBank.EditValue.ToString());
                        checkDate = TxtCheckDate.DateTime;
                        checkAccountNumber = TxtAccountNumber.Text;
                        checkNumber = int.Parse(TxtCheckNumber.Text);
                        checkAuthorization = TxtAuthorization.Text;
                    }
                    else
                    {
                        functions.ShowMessage("No ha solicitado autorizacion para el cheque.", ClsEnums.MessageType.WARNING);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    processResponse = true;
                    checkOwnerName = TxtOwnerName.Text;
                    checkBankId = int.Parse(CmbCheckBank.EditValue.ToString());
                    checkDate = TxtCheckDate.DateTime;
                    checkAccountNumber = TxtAccountNumber.Text;
                    checkNumber = int.Parse(TxtCheckNumber.Text);
                    checkAuthorization = TxtAuthorization.Text;

                }

            }
        }

        private bool ValidateCheckFields()
        {
            bool response = false;

            if (TxtOwnerName.Text != "" && TxtIdentification.Text != ""
                && TxtPhone.Text != "" && CmbCheckBank.EditValue != null
                && TxtCheckDate.EditValue != null && TxtAccountNumber.Text != ""
                && TxtCheckNumber.Text != "" && TxtCheckAmount.Text != "")
            {
                response = true;
            }
            else
            {
                functions.ShowMessage("Debe llenar todos los campos", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }

            return response;
        }

        private void TxtCheckDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int dateDiff = DateTime.Today.CompareTo(DateTime.Parse(TxtCheckDate.Text).Date);
                if (dateDiff == 0)
                {
                    TxtAuthorization.Enabled = true;
                    BtnAuthorization.Enabled = true;
                }
                else
                {
                    TxtAuthorization.Enabled = false;
                    BtnAuthorization.Enabled = false;

                }
            }
            catch
            {
                TxtCheckDate.DateTime = DateTime.Now;
            }

        }

        private void TxtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CmbCheckBank.Focus();//SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    BtnKeypadPhone_Click(null, null);
                    break;                
                default:
                    break;
            }

            //06/07/2022
            //if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
        }

        private void CmbCheckBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) TxtCheckDate.Focus();
        }

        private void TxtCheckDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
        }

        private void TxtAccountNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    BtnKeypadAccount_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtCheckNumber_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    BtnKeypadCheck_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtAuthorization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) SendKeys.Send("{TAB}");
        }

        private void TxtOwnerName_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    BtnKeyboardOwner_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F1:
                    BtnKeypadIdentification_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}