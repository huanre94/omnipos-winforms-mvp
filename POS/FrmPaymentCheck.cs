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

namespace POS
{
    public partial class FrmPaymentCheck : DevExpress.XtraEditors.XtraForm
    {
        public bool processResponse;

        public FrmPaymentCheck()
        {
            InitializeComponent();
        }

        private void BtnKeypadAccount_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.fromOption = "CheckAccountNumber";
            keyPad.ShowDialog();
            TxtAccountNumber.Text = keyPad.checkAccountNumber;
        }

        private void BtnKeypadCheck_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.fromOption = "CheckNumber";
            keyPad.ShowDialog();
            TxtCheckNumber.Text = keyPad.checkNumber;
        }

        private void BtnKeypadAuth_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.fromOption = "CheckAuthorization";
            keyPad.ShowDialog();
            TxtAuthorization.Text = keyPad.checkAuthorization;
        }

        private void BtnKeyboardOwner_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.fromOption = "CheckOwnerName";
            keyBoard.ShowDialog();
            TxtOwnerName.Text = keyBoard.checkOwnerName;
        }

        private void FrmPaymentCheck_Load(object sender, EventArgs e)
        {
            LoadBanks();
        }

        private void LoadBanks()
        {
            var db = new DLL.POSEntities();
            var banks = from ba in db.Bank
                        where ba.Status == "A"
                        select ba;

            foreach (var item in banks.ToList())
            {
                CmbCheckBank.Properties.Items.Add(new ImageComboBoxItem { Value = item.BankId, Description = item.Name });
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtOwnerName.Text != "" && CmbCheckBank.EditValue != null
                && TxtCheckDate.EditValue != null && TxtAuthorization.Text != ""
                && TxtAccountNumber.Text != "" && TxtCheckNumber.Text != "")
            {
                processResponse = true;
            }
            else
            {
                ClsFunctions functions = new ClsFunctions();
                functions.ShowMessage("Debe llenar todos los campos", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}