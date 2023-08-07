using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmRemissionGuide : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;

        public FrmRemissionGuide()
        {
            InitializeComponent();
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            FrmRemissionGuideOrderSelector frm = new FrmRemissionGuideOrderSelector
            {
                emissionPoint = emissionPoint,
                loginInformation = loginInformation
            };
            frm.ShowDialog();

            if (frm.isUpdated)
            {
                LoadPendingRemissionGuides();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                BindingList<SP_RemissionGuide_Consult_Result> list = (BindingList<SP_RemissionGuide_Consult_Result>)GrcRemissionGuide.DataSource;

                if (list?.Count() == 0)
                {
                    functions.ShowMessage("No existen guias de remisiones activas", MessageType.WARNING);
                    return;
                }

                SP_RemissionGuide_Consult_Result remissionGuideConsult = (SP_RemissionGuide_Consult_Result)GrvRemissionGuide.GetRow(GrvRemissionGuide.FocusedRowHandle);

                FrmRemissionGuideOrderToInvoice frm = new FrmRemissionGuideOrderToInvoice()
                {
                    remission = remissionGuideConsult,
                    emissionPoint = emissionPoint,
                    loginInformation = loginInformation
                };
                frm.ShowDialog();


                if (frm.isUpdated)
                {
                    LoadPendingRemissionGuides();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar guias de remision", MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRemissionGuide_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                CheckGridView();
                LoadDrivers();
                LoadPendingRemissionGuides();
            }
        }

        private void LoadDrivers()
        {
            try
            {
                IEnumerable<TransportDriver> transportDrivers = new SalesOrderRepository(Program.customConnectionString).GetTransportDrivers();

                if (transportDrivers?.Count() > 0)
                {
                    foreach (TransportDriver transportDriver in transportDrivers)
                    {
                        CmbTransportDriver.Properties.Items.Add(new ImageComboBoxItem { Value = transportDriver.TransportDriverId, Description = transportDriver.Firtsname + " " + transportDriver.Lastname });
                    }
                    CmbTransportDriver.Properties.Items.Insert(0, new ImageComboBoxItem { Value = 0, Description = "Todos" });
                    CmbTransportDriver.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al consultar conductores.",
                     MessageType.ERROR,
                    true,
                    ex.InnerException.Message);
            }
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP == string.Empty)
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return false;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);

                if (emissionPoint == null)
                {
                    functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                    return false;
                }

                functions.PrinterName = emissionPoint.PrinterName;
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

        private void LoadPendingRemissionGuides()
        {
            try
            {
                long userId = 0;
                int driverId = 0;
                if (ChkMyGuides.Checked)
                {
                    userId = (long)loginInformation.UserId;
                }
                if (CmbTransportDriver.EditValue != null)
                {
                    driverId = (int)CmbTransportDriver.EditValue;
                }


                IEnumerable<SP_RemissionGuide_Consult_Result> result = new RemissionSaleRepository(Program.customConnectionString).GetActiveRemissionGuides(userId, driverId);
                if (result.Count() == 0)
                {
                    GrcSalesOrder.DataSource = null;
                }

                BindingList<SP_RemissionGuide_Consult_Result> bindingList = new BindingList<SP_RemissionGuide_Consult_Result>(result.ToList());
                GrcRemissionGuide.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las guias de remisiones activas",
                                      MessageType.WARNING,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingRemissionGuides();
        }

        private void CheckGridView()
        {
            GrvRemissionGuide.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcRemissionGuide.DataSource = null;

            BindingList<SP_RemissionGuide_Consult_Result> bindingList = new BindingList<SP_RemissionGuide_Consult_Result>();
            GrcRemissionGuide.DataSource = bindingList;

            GrvSalesOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesOrder.DataSource = null;

            BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bindingList2 = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>();
            GrcSalesOrder.DataSource = bindingList2;
        }

        private void GrvRemissionGuide_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BindingList<SP_RemissionGuide_Consult_Result> ds = (BindingList<SP_RemissionGuide_Consult_Result>)GrvRemissionGuide.DataSource;
            int selectedIndex;
            if (GrvRemissionGuide.FocusedRowHandle < 0)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex = GrvRemissionGuide.FocusedRowHandle;
            }

            try
            {
                IEnumerable<SP_RemissionGuideSalesOrder_Consult_Result> list = new SalesOrderRepository(Program.customConnectionString).GetSalesOrderByRemissionGuideNumber(ds[selectedIndex].SalesRemissionId);
                BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bind = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>(list.ToList());
                GrcSalesOrder.DataSource = bind;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las ordenes de venta de esta guia", MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void BtnPrintRemissionGuide_Click(object sender, EventArgs e)
        {
            BindingList<SP_RemissionGuide_Consult_Result> list = (BindingList<SP_RemissionGuide_Consult_Result>)GrcRemissionGuide.DataSource;
            if (list.Count == 0)
            {
                functions.ShowMessage("No existe guias de remision a imprimir.", MessageType.WARNING);
                return;
            }

            functions.emissionPoint = emissionPoint;
            bool isApproved = true;//functions.RequestSupervisorAuth();
            if (isApproved)
            {
                try
                {
                    SP_RemissionGuide_Consult_Result result = (SP_RemissionGuide_Consult_Result)GrvRemissionGuide.GetRow(GrvRemissionGuide.FocusedRowHandle);
                    long lastId = result.SalesRemissionId;
                    if (lastId == 0)
                    {
                        functions.ShowMessage("No hay documento previo existente.", MessageType.WARNING);
                    }
                    else
                    {
                        functions.PrintDocument(lastId, DocumentType.REMISSIONGUIDE, false);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al imprimir la última factura."
                                            , MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
        }

        private void GrcRemissionGuide_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                //case Keys.F1:
                //    BtnSearch_Click(null, null);
                //    break;
                case Keys.F2:
                    BtnNewOrder_Click(null, null);
                    break;
                case Keys.F3:
                    BtnPrintRemissionGuide_Click(null, null);
                    break;
                case Keys.F5:
                    BtnRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    BtnModify_Click(null, null);
                    break;
                case Keys.Enter:
                    GrvRemissionGuide_RowClick(null, null);
                    break;
                //case Keys.F7:
                //    BtnRemissionGuide_Click(null, null);
                //    break;
                default:
                    break;
            }



            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C))
            {
                CmbTransportDriver.Focus(); //BtnCash.Focus();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.M))
            {
                ChkMyGuides.Focus();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
            {
                BtnCancel_Click(null, null);
            }

        }

        private void CmbTransportDriver_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnRefresh_Click(null, null);
                    GrcRemissionGuide.Focus();
                    break;
                default:
                    break;
            }
        }

        private void ChkMyGuides_CheckedChanged(object sender, EventArgs e)
        {
            BtnRefresh_Click(null, null);
            GrcRemissionGuide.Focus();
        }
    }
}