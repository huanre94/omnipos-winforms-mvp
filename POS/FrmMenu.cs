﻿using System;
using System.Windows.Forms;

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
            FormCollection formCollection = Application.OpenForms;

            if (formCollection.Count > 0)
            {
                foreach (Form frm in formCollection)
                {
                    frm.Close();
                }
            }
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