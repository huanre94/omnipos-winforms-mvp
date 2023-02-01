﻿using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
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
        public List<GlobalParameter> globalParameters;

        public FrmMenu(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable

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
            FrmMain frmMain = new FrmMain(CadenaC)
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmMain.Show();

            System.Windows.Forms.Cursor.Current = Cursors.Default;

            if (Application.OpenForms.OfType<FrmMain>().Count() == 1)
                Hide();
        }

        private void BtnCloseCashier_Click(object sender, EventArgs e)
        {
            FrmClosingCashier frmClosing = new FrmClosingCashier(CadenaC, "F")
            {
                loginInformation = loginInformation,
                globalParameters = globalParameters
            };
            frmClosing.Show();
        }

        private void BtnPartialClosing_Click(object sender, EventArgs e)
        {
            FrmPartialClosing frmPartial = new FrmPartialClosing(CadenaC)
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
            FrmSalesOrderPicker frmPartial = new FrmSalesOrderPicker(CadenaC)
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
            FrmRedeemGiftCard frmPartial = new FrmRedeemGiftCard(CadenaC)
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
            FrmInvoiceCancel frmPartial = new FrmInvoiceCancel(CadenaC)
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
            FrmChangePaymMode frmChange = new FrmChangePaymMode(CadenaC)
            {
                loginInformation = loginInformation
            };
            frmChange.ShowDialog();
        }

        private void BtnPhysicalInventory_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            bool allowInventory = false;

            try
            {
                allowInventory = new POSEntities(CadenaC)
                    .GlobalParameter
                    .Where(par => par.Name == "AllowPhysicalInventory")
                    .Select(par => par.Value)
                    .FirstOrDefault() == "1";
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                    "Ocurrio un problema al configurar validar inventario."
                                    , ClsEnums.MessageType.ERROR
                                    , true
                                    , ex.Message
                                  );
            }

            if (allowInventory)
            {

                FrmPhysicalStockCount frmPhysicalStock = new FrmPhysicalStockCount(CadenaC)
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

            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP, CadenaC);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", ClsEnums.MessageType.WARNING);
                return false;
            }

            try
            {
                var pendingClosing = new ClsClosingTrans().PendingClosings(emissionPoint.EmissionPointId, (int)loginInformation.UserId, CadenaC);
                if (pendingClosing)
                {
                    functions.ShowMessage("Existen cierres pendientes por otro usuario.", ClsEnums.MessageType.WARNING);
                }

                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                    ClsEnums.MessageType.ERROR,
                    true,
                    ex.Message);

                return false;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmClosingCashier frmClosing = new FrmClosingCashier(CadenaC, "A")
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