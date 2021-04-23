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
using POS.DLL;
using POS.DLL.Catalog;
using POS.Classes;

namespace POS
{
    public partial class FrmRemissionGuide : DevExpress.XtraEditors.XtraForm
    {
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;
        ClsFunctions functions = new ClsFunctions();

        public FrmRemissionGuide()
        {
            InitializeComponent();
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            FrmRemissionGuideOrderSelector frm = new FrmRemissionGuideOrderSelector();
            frm.emissionPoint = emissionPoint;
            frm.loginInformation = loginInformation;
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

                if (list.Count == 0)
                {
                    functions.ShowMessage("No existen guias de remisiones activas", Classes.ClsEnums.MessageType.WARNING);
                    return;
                }

                SP_RemissionGuide_Consult_Result rv = (SP_RemissionGuide_Consult_Result)GrvRemissionGuide.GetRow(GrvRemissionGuide.FocusedRowHandle);
                FrmRemissionGuideOrderToInvoice frm = new FrmRemissionGuideOrderToInvoice();
                frm.remission = rv;
                frm.emissionPoint = emissionPoint;
                frm.loginInformation = loginInformation;
                frm.ShowDialog();

                if (frm.isUpdated)
                {
                    LoadPendingRemissionGuides();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar guias de remision", Classes.ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
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
                LoadPendingRemissionGuides();
            }
        }

        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);
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
            }

            if (emissionPoint != null)
            {
                response = true;
                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void LoadPendingRemissionGuides()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<SP_RemissionGuide_Consult_Result> result;
            try
            {
                result = new ClsSalesOrder().GetActiveRemissionGuides();
                if (result.Count == 0)
                {
                    GrcSalesOrder.DataSource = null;
                }

                BindingList<SP_RemissionGuide_Consult_Result> bindingList = new BindingList<SP_RemissionGuide_Consult_Result>(result);
                GrcRemissionGuide.DataSource = bindingList;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las guias de remisiones activas", Classes.ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
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
                List<SP_RemissionGuideSalesOrder_Consult_Result> list = new ClsSalesOrder().GetSalesOrderByRemissionGuideNumber(ds[selectedIndex].SalesRemissionId);
                BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bind = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>(list);
                GrcSalesOrder.DataSource = bind;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las ordenes de venta de esta guia", Classes.ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void BtnPrintRemissionGuide_Click(object sender, EventArgs e)
        {
            BindingList<SP_RemissionGuide_Consult_Result> list = (BindingList<SP_RemissionGuide_Consult_Result>)GrcRemissionGuide.DataSource;
            if (list.Count == 0)
            {
                functions.ShowMessage("No existe guias de remision a imprimir.", ClsEnums.MessageType.WARNING);
                return;
            }

            functions.emissionPoint = emissionPoint;
            bool isApproved = true;//functions.RequestSupervisorAuth();
            if (isApproved)
            {
                try
                {
                    SP_RemissionGuide_Consult_Result result = (SP_RemissionGuide_Consult_Result)GrvRemissionGuide.GetRow(GrvRemissionGuide.FocusedRowHandle);
                    Int64 lastId = result.SalesRemissionId;
                    if (lastId == 0)
                    {
                        functions.ShowMessage("No hay documento previo existente.", ClsEnums.MessageType.WARNING);
                    }
                    else
                    {
                        functions.PrintDocument(lastId, ClsEnums.DocumentType.REMISSIONGUIDE);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al imprimir la última factura."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
        }
    }
}