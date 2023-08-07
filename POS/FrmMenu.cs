using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmMenu : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public SP_Login_Consult_Result loginInformation;
        public IEnumerable<GlobalParameter> globalParameters;
        public static EmissionPoint emissionPoint;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                LblUsername.Text = loginInformation.UserName;
                LblVersion.Text = functions.GetPublishVersion() ?? "";
            }

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
                    return;
                }

                f.Close();
            }
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            FrmMain frmMain = new FrmMain()
            {
                LoginInformation = loginInformation,
                GlobalParameters = globalParameters
            };
            frmMain.Show();

            System.Windows.Forms.Cursor.Current = Cursors.Default;

            if (Application.OpenForms.OfType<FrmMain>().Count() == 1)
                Hide();
        }

        private void BtnCloseCashier_Click(object sender, EventArgs e)
        {
            FrmClosingCashier frmClosing = new FrmClosingCashier("F")
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmClosing.Show();
        }

        private void BtnPartialClosing_Click(object sender, EventArgs e)
        {
            FrmPartialClosing frmPartial = new FrmPartialClosing()
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
            FrmSalesOrderPicker frmPartial = new FrmSalesOrderPicker()
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
            FrmRedeemGiftCard frmPartial = new FrmRedeemGiftCard()
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
            FrmInvoiceCancel frmPartial = new FrmInvoiceCancel(globalParameters, loginInformation);
            frmPartial.ShowDialog();

            if (Application.OpenForms.OfType<FrmInvoiceCancel>().Count() == 1)
                Hide();
        }

        private void BtnChangePaymMode_Click(object sender, EventArgs e)
        {
            FrmChangePaymMode frmChange = new FrmChangePaymMode(loginInformation);
            frmChange.ShowDialog();
        }

        private void BtnPhysicalInventory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool allowInventory = false;

            try
            {
                allowInventory = new ClsGeneral(Program.customConnectionString).GetParameterByName("AllowPhysicalInventory").Value == "1";
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al configurar validar inventario.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }

            if (allowInventory)
            {

                FrmPhysicalStockCount frmPhysicalStock = new FrmPhysicalStockCount()
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
                functions.ShowMessage("La toma de inventario no se encuentra habilitada.", MessageType.WARNING);
            }

            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP == "")
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return false;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                    MessageType.ERROR,
                    true,
                    ex.Message);
            }

            try
            {
                bool pendingClosing = new ClosingCashierRepository(Program.customConnectionString).PendingClosings(emissionPoint.EmissionPointId, (int)loginInformation.UserId);
                if (pendingClosing)
                {
                    functions.ShowMessage("Existen cierres pendientes por otro usuario.", MessageType.WARNING);
                }

                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                     MessageType.ERROR,
                    true,
                    ex.Message);

                return false;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmClosingCashier frmClosing = new FrmClosingCashier("A")
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmClosing.Show();

            if (Application.OpenForms.OfType<FrmClosingCashier>().Count() == 1)
                Hide();
        }
    }
}