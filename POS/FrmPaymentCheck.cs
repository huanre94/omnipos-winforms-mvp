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
    public partial class FrmPaymentCheck : DevExpress.XtraEditors.XtraForm
    {
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
    }
}