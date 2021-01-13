using POS.Classes;
using POS.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmMenu : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;
        public EmissionPoint emissionPoint;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            LblUsername.Text = loginInformation.UserName;
            LblVersion.Text = functions.GetPublishVersion() ?? "";
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
            frmMain.Show();

            if (Application.OpenForms.OfType<FrmMain>().Count() == 1)
                this.Hide();
        }

        private void BtnCloseCashier_Click(object sender, EventArgs e)
        {
            FrmClosingCashier frmClosing = new FrmClosingCashier
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters                
            };            
            frmClosing.Show();

            if (Application.OpenForms.OfType<FrmClosingCashier>().Count() == 1)
                this.Hide();
        }

        private void BtnPartialClosing_Click(object sender, EventArgs e)
        {
            FrmPartialClosing frmPartial = new FrmPartialClosing();
            frmPartial.loginInformation = loginInformation;
            frmPartial.globalParameters = globalParameters;            
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmPartialClosing>().Count() == 1)
                this.Hide();
        }

        private void BtnSalesOrder_Click(object sender, EventArgs e)
        {
            FrmSalesOrderPicker frmPartial = new FrmSalesOrderPicker();
            frmPartial.loginInformation = loginInformation;
            frmPartial.globalParameters = globalParameters;
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmSalesOrderPicker>().Count() == 1)
                this.Hide(); 
        }

        private void BtnGiftCardRedeem_Click(object sender, EventArgs e)
        {
            FrmRedeemGiftCard frmPartial = new FrmRedeemGiftCard();
            frmPartial.loginInformation = loginInformation;
            frmPartial.globalParameters = globalParameters;
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmRedeemGiftCard>().Count() == 1)
                this.Hide();
        }

        private void BtnInvoiceCancel_Click(object sender, EventArgs e)
        {
            FrmInvoiceCancel frmPartial = new FrmInvoiceCancel();
            frmPartial.loginInformation = loginInformation;
            frmPartial.globalParameters = globalParameters;
            frmPartial.ShowDialog();

            if (Application.OpenForms.OfType<FrmInvoiceCancel>().Count() == 1)
                this.Hide();
        }

        private void BtnChangePaymMode_Click(object sender, EventArgs e)
        {
            FrmChangePaymMode frmChange = new FrmChangePaymMode();
            frmChange.loginInformation = loginInformation;
            frmChange.ShowDialog();
        }

        private void BtnPhysicalInventory_Click(object sender, EventArgs e)
        {
            string allowInventory = String.Empty;

            allowInventory = (from par in globalParameters.ToList()
                              where par.Name == "AllowPhysicalInventory"
                              select par.Value).FirstOrDefault();

            if (allowInventory == "1")
            {

                FrmPhysicalStockCount frmPhysicalStock = new FrmPhysicalStockCount();
                frmPhysicalStock.loginInformation = loginInformation;
                frmPhysicalStock.globalParameters = globalParameters;
                frmPhysicalStock.ShowDialog();

                if (Application.OpenForms.OfType<FrmPhysicalStockCount>().Count() == 1)
                    this.Hide();
            }
            else
            {
                functions.ShowMessage("La toma de inventario no se encuentra habilitada.", ClsEnums.MessageType.WARNING);
            }
        }
    }
}