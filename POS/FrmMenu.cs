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
                
        private void BtnExit_Click(object sender, EventArgs e)
        {
            FormCollection formCollection = Application.OpenForms;            

            if (formCollection.Count > 0)
            {
                foreach (Form frm in formCollection)
                {
                    if (!frm.Focused)
                    {
                        frm.Close();
                    }
                }
            }

            Close();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Close();

            FrmMain frmMain = new FrmMain();
            frmMain.loginInformation = loginInformation;
            frmMain.globalParameters = globalParameters;
            this.Visible = false;
            frmMain.Show();
        }


    }
}