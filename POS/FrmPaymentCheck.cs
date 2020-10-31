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

namespace POS
{
    public partial class FrmPaymentCheck : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();        
        public bool processResponse;
        public string checkOwnerName;       
        public int checkBankId;
        public DateTime checkDate;
        public string checkAccountNumber;
        public int checkNumber;
        public decimal checkAmount;
        public string checkAuthorization;
        

        public FrmPaymentCheck()
        {
            InitializeComponent();
        }

        private void FrmPaymentCheck_Load(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            TxtOwnerName.Text = main.LblCustomerName.Text;
            TxtIdentification.Text = main.LblCustomerId.Text;
            TxtCheckAmount.Text = checkAmount.ToString();
            TxtCheckDate.DateTime = DateTime.Now;

            LoadBanks();
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
                List<DLL.SP_GaranCheck_Authorize_Result> authorizeResult;

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
                        if (authorizeResult.Count > 0)
                        {
                            string result = authorizeResult.FirstOrDefault().Result;

                            if (authorizeResult.FirstOrDefault().Response == 0)
                            {
                                TxtAuthorization.Text = result;
                                functions.ShowMessage("Se ha obtenido autorizacion exitosamente. Autorizacion: " + result);
                            }
                            else
                            {
                                functions.ShowMessage(
                                                        "No se ha podido obtener autorizacion."
                                                        , ClsEnums.MessageType.WARNING
                                                        , true
                                                        , result
                                                        );
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