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
    public partial class FrmMenu : DevExpress.XtraEditors.XtraForm
    {
        public DLL.SP_Login_Consult_Result loginInformation;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //Application.OpenForms["FrmLogin"].Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Close();

            FrmMain frmMain = new FrmMain();
            frmMain.loginInformation = loginInformation;
            this.Visible = false;
            frmMain.Show();
        }

        
    }
}