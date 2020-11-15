using POS.DLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmMenu : DevExpress.XtraEditors.XtraForm
    {
        public DLL.SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            loginInformation = null;

            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "FrmLogin")
                {
                    f.Show();
                }
                else
                {
                    f.Close();
                }
            }            
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {            
            FrmMain frmMain = new FrmMain();
            frmMain.loginInformation = loginInformation;
            frmMain.globalParameters = globalParameters;
            this.Hide();
            frmMain.Show();
        }

        
    }
}