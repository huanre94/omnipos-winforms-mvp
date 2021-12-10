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
        public static EmissionPoint emissionPoint;

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
            FrmMain frmMain = new FrmMain
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmMain.Show();

            if (Application.OpenForms.OfType<FrmMain>().Count() == 1)
                Hide();
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
                Hide();
        }

        private void BtnPartialClosing_Click(object sender, EventArgs e)
        {
            FrmPartialClosing frmPartial = new FrmPartialClosing
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmPartialClosing>().Count() == 1)
                Hide();
        }

        private void BtnSalesOrder_Click(object sender, EventArgs e)
        {
            FrmSalesOrderPicker frmPartial = new FrmSalesOrderPicker
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmSalesOrderPicker>().Count() == 1)
                Hide();
        }

        private void BtnGiftCardRedeem_Click(object sender, EventArgs e)
        {
            FrmRedeemGiftCard frmPartial = new FrmRedeemGiftCard
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmPartial.Show();

            if (Application.OpenForms.OfType<FrmRedeemGiftCard>().Count() == 1)
                Hide();
        }

        private void BtnInvoiceCancel_Click(object sender, EventArgs e)
        {
            FrmInvoiceCancel frmPartial = new FrmInvoiceCancel
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmPartial.ShowDialog();

            if (Application.OpenForms.OfType<FrmInvoiceCancel>().Count() == 1)
                Hide();
        }

        private void BtnChangePaymMode_Click(object sender, EventArgs e)
        {
            FrmChangePaymMode frmChange = new FrmChangePaymMode
            {
                loginInformation = loginInformation
            };
            frmChange.ShowDialog();
        }

        private void BtnPhysicalInventory_Click(object sender, EventArgs e)
        {
            bool allowInventory = false;

            try
            {
                allowInventory = (from par in new POSEntities().GlobalParameter.ToList()
                                  where par.Name == "AllowPhysicalInventory"
                                  select par.Value).FirstOrDefault() == "1";

            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                    "Ocurrio un problema al configurar temporizador."
                                    , ClsEnums.MessageType.ERROR
                                    , true
                                    , ex.Message
                                  );
            }

            if (allowInventory)
            {

                FrmPhysicalStockCount frmPhysicalStock = new FrmPhysicalStockCount
                {
                    loginInformation = loginInformation,
                    globalParameters = globalParameters
                };
                frmPhysicalStock.ShowDialog();

                if (Application.OpenForms.OfType<FrmPhysicalStockCount>().Count() == 1)
                    Hide();
            }
            else
            {
                functions.ShowMessage("La toma de inventario no se encuentra habilitada.", ClsEnums.MessageType.WARNING);
            }
        }
    }
}