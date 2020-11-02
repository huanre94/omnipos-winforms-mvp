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
using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL.Catalog;
using POS.DLL;
using DevExpress.XtraDashboardLayout;
using System.Runtime.InteropServices.WindowsRuntime;

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

        public FrmPaymentCheck()
        {
            InitializeComponent();
        }

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
                TxtIdentification.Text = customer.Identification;
                TxtOwnerName.Text = customer.Firtsname + " " + customer.Lastname;
                response = true;
            }
            else
            {
                functions.ShowMessage("La factura no puede ser CONSUMIDOR FINAL.", ClsEnums.MessageType.ERROR);
                this.DialogResult = DialogResult.Cancel;
            }

            return response;
        }

        #region Keypad Call Buttons
        private void BtnKeyboardOwner_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERNAME;
            keyBoard.ShowDialog();
            TxtOwnerName.Text = keyBoard.checkOwnerName;
        }
        private void BtnKeypadIdentification_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = ClsEnums.InputFromOption.CHECK_OWNERIDENTIFICATION;
            keyBoard.ShowDialog();
            TxtIdentification.Text = keyBoard.checkOwnerIdentification;
        }

        private void BtnKeypadPhone_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_PHONE;
            keyPad.ShowDialog();
            TxtPhone.Text = keyPad.checkPhone;
        }

        private void BtnKeypadAccount_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_ACCOUNTNUMBER;
            keyPad.ShowDialog();
            TxtAccountNumber.Text = keyPad.checkAccountNumber;
        }

        private void BtnKeypadCheck_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CHECK_NUMBER;
            keyPad.ShowDialog();
            TxtCheckNumber.Text = keyPad.checkNumber;
        }

        private void BtnKeypadAuth_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
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
                banks = paymMode.GetBanks();

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
            catch(Exception ex)
            {                
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Bancos."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                        );
            }
        }

        private void BtnAuthorization_Click(object sender, EventArgs e)
        {
            if (ValidateCheckFields())
            {
                DLL.Transaction.ClsAuthorizationTrans authorization = new DLL.Transaction.ClsAuthorizationTrans();
                DLL.SP_GaranCheck_Authorize_Result authorizeResult;

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
                                                                        );

                    if (authorizeResult != null)
                    {
                       
                        string result = authorizeResult.Result;

                        if (authorizeResult.Response == 0)
                        {
                            TxtAuthorization.Text = result;
                            functions.ShowMessage("Se ha obtenido autorizacion exitosamente. Autorizacion: " + result);
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
                                            , ex.Message
                                            );
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateCheckFields())
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

        
    }
}