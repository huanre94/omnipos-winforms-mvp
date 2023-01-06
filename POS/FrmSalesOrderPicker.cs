﻿using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSalesOrderPicker : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;
        System.Timers.Timer timer;

        public FrmSalesOrderPicker(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //14/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //14/07/2022  Se agregó para que Cadena de conexion sea parametrizable

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu(CadenaC);
            frmMenu.loginInformation = loginInformation;
            frmMenu.globalParameters = globalParameters;
            frmMenu.Visible = true;
            Close();
        }

        private void LoadOrderStatus()
        {
            ClsSalesOrder customer = new ClsSalesOrder();
            List<SalesOrderStatus> custIdentTypes;

            try
            {
                custIdentTypes = customer.GetSalesOrderStatus(CadenaC);

                if (custIdentTypes != null)
                {
                    if (custIdentTypes.Count > 0)
                    {
                        foreach (var identType in custIdentTypes)
                        {
                            CmbOrderStatus.Properties.Items.Add(new ImageComboBoxItem { Value = identType.ShortCode, Description = identType.Name });
                        }
                        CmbOrderStatus.Properties.Items.Insert(0, new ImageComboBoxItem { Value = string.Empty, Description = "TODOS" });
                        CmbOrderStatus.Properties.Items.Insert(1, new ImageComboBoxItem { Value = 'X', Description = "ORDEN ACTIVA" });
                        CmbOrderStatus.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar estados de ordenes."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void LoadSalesOrigin()
        {
            ClsSalesOrder customer = new ClsSalesOrder();
            List<SalesOrigin> custIdentTypes;

            try
            {
                custIdentTypes = customer.GetSalesOrderOrigin(true, CadenaC);

                if (custIdentTypes != null)
                {
                    if (custIdentTypes.Count > 0)
                    {
                        foreach (var identType in custIdentTypes)
                        {
                            CmbSalesOrderOrigin.Properties.Items.Add(new ImageComboBoxItem { Value = identType.SalesOriginId, Description = identType.Name });
                        }
                        CmbSalesOrderOrigin.Properties.Items.Insert(0, new ImageComboBoxItem { Value = 0, Description = "TODOS" });
                        CmbSalesOrderOrigin.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar origenes de orden."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }



        private void FrmSalesOrderPicker_Load(object sender, EventArgs e)
        {
            bool orderTimerEnabled = false;
            long orderTimerInvertal = 0;
            try
            {
                orderTimerEnabled = (from par in new POSEntities(CadenaC).GlobalParameter.ToList()
                                     where par.Name == "OrderTimerEnabled"
                                     select par.Value).FirstOrDefault() == "1";
                orderTimerInvertal = long.Parse((from par in new POSEntities(CadenaC).GlobalParameter.ToList()
                                                 where par.Name == "OrderUpdateTimer"
                                                 select par.Value).FirstOrDefault());
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

            if (GetEmissionPointInformation())
            {
                timer = new System.Timers.Timer();
                timer.Enabled = orderTimerEnabled;
                timer.Interval = orderTimerInvertal;
                timer.Elapsed += Timer_Elapsed;

                if (timer.Enabled)
                {
                    timer.Start();
                }

                chkDate.Checked = true;
                ETOrderDate.Text = DateTime.Today.ToShortDateString();
                CheckGridView();
                LoadOrderStatus();
                LoadSalesOrigin();
                LoadSaleOrdesByFilters();
            }
            else
            {
                FrmMenu frmMenu = new FrmMenu(CadenaC);
                frmMenu.loginInformation = loginInformation;
                frmMenu.globalParameters = globalParameters;
                frmMenu.Visible = true;
                Close();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                LoadSaleOrdesByFilters();
            }));

        }

        private void LoadSaleOrdesByFilters()
        {
            List<SP_SalesOrderStatus_Consult_Result> sales;
            try
            {
                sales = new ClsSalesOrder().GetSalesOrderByStatus(DateTime.Parse(ETOrderDate.Text.ToString()).ToString("yyyyMMdd"), CmbOrderStatus.EditValue.ToString(), int.Parse(CmbSalesOrderOrigin.EditValue.ToString()), chkDate.Checked, CadenaC);

                if (sales.Count == 0)
                {
                    functions.ShowMessage("No existen ordenes generadas.", ClsEnums.MessageType.WARNING);
                    GrcSalesOrder.DataSource = null;
                    GrcSalesOrder.Focus();
                    return;
                }

                BindingList<SP_SalesOrderStatus_Consult_Result> list = new BindingList<SP_SalesOrderStatus_Consult_Result>(sales);
                GrcSalesOrder.DataSource = list;
                GrvSalesOrder.ActiveFilter.Clear();
                GrvSalesOrder.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 255, 255);

            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                      "Ocurrio un problema al cargar ordenes."
                                      , ClsEnums.MessageType.ERROR
                                      , true
                                      , ex.Message
                                    );
            }
        }

        #region Functions
        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP, CadenaC);

                    if (emissionPoint != null)
                    {
                        response = true;
                        functions.PrinterName = emissionPoint.PrinterName;
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                    }
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

            return response;
        }

        private void CheckGridView()
        {
            GrvSalesOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesOrder.DataSource = null;
            //GrvSalesOrder.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_SalesOrderStatus_Consult_Result> bindingList = new BindingList<SP_SalesOrderStatus_Consult_Result>();
            //bindingList.AllowNew = true;

            GrcSalesOrder.DataSource = bindingList;
        }
        #endregion

        private void BtnModify_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor; //07/07/2022

            int rowIndex = GrvSalesOrder.FocusedRowHandle;
            if (rowIndex < 0)
            {
                functions.ShowMessage("No ha seleccionado ninguna orden.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                SP_SalesOrderStatus_Consult_Result item = (SP_SalesOrderStatus_Consult_Result)GrvSalesOrder.GetRow(rowIndex);
                if (item.StatusShortCode.Equals("I"))
                {
                    functions.ShowMessage("No puede modificar una orden cancelada.", ClsEnums.MessageType.WARNING);
                    return;
                }
                if (item.StatusShortCode.Equals("F"))
                {
                    functions.ShowMessage("No puede modificar una orden facturada.", ClsEnums.MessageType.WARNING);
                    return;
                }

                if (item.OrderECommerce > 0)
                {
                    FrmSalesOrderEcommerce frmSalesOrder = new FrmSalesOrderEcommerce(CadenaC);
                    frmSalesOrder.loginInformation = loginInformation;
                    frmSalesOrder.emissionPoint = emissionPoint;
                    frmSalesOrder.salesOrderId = (long)item.SalesOrderId;
                    frmSalesOrder.globalParameters = globalParameters;
                    frmSalesOrder.ShowDialog();

                    if (frmSalesOrder.isUpdated)
                    {
                        LoadSaleOrdesByFilters();
                    }
                }
                else
                {
                    FrmSalesOrder frmSalesOrder = new FrmSalesOrder(CadenaC);
                    frmSalesOrder.loginInformation = loginInformation;
                    frmSalesOrder.emissionPoint = emissionPoint;
                    frmSalesOrder.salesOrderId = (long)item.SalesOrderId;
                    frmSalesOrder.globalParameters = globalParameters;
                    frmSalesOrder.ShowDialog();

                    if (frmSalesOrder.isUpdated)
                    {
                        LoadSaleOrdesByFilters();
                    }
                }
            }
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void BtnRemissionGuide_Click(object sender, EventArgs e)
        {
            FrmRemissionGuide frmRemission = new FrmRemissionGuide(CadenaC)
            {
                emissionPoint = emissionPoint,
                loginInformation = loginInformation
            };
            frmRemission.ShowDialog();
        }



        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            FrmSalesOrderHeader frmSalesOrderHeader = new FrmSalesOrderHeader(CadenaC)
            {
                emissionPoint = emissionPoint,
                loginInformation = loginInformation
            };
            frmSalesOrderHeader.ShowDialog();

            if (frmSalesOrderHeader.formActionResult)
            {
                LoadSaleOrdesByFilters();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadSaleOrdesByFilters();
            GrcSalesOrder.Focus();//07/07/2022
        }

        private void BtnPrintSaleOrder_Click(object sender, EventArgs e)
        {
            functions.emissionPoint = emissionPoint;
            bool isApproved = true;//functions.RequestSupervisorAuth();
            if (isApproved)
            {
                try
                {
                    BindingList<SP_SalesOrderStatus_Consult_Result> list = (BindingList<SP_SalesOrderStatus_Consult_Result>)GrcSalesOrder.DataSource;
                    if (list.Count == 0)
                    {
                        functions.ShowMessage("No existen documentos por imprimir.", ClsEnums.MessageType.WARNING);
                        return;
                    }

                    if (GrvSalesOrder.FocusedRowHandle < 0)
                    {
                        GrvSalesOrder.FocusedRowHandle = 0;
                    }

                    SP_SalesOrderStatus_Consult_Result result = (SP_SalesOrderStatus_Consult_Result)GrvSalesOrder.GetRow(GrvSalesOrder.FocusedRowHandle);
                    long lastId = (long)result.SalesOrderId;

                    if (lastId == 0)
                    {
                        functions.ShowMessage("No hay documento previo existente.", ClsEnums.MessageType.WARNING);
                    }
                    else
                    {
                        functions.PrintDocument(lastId, ClsEnums.DocumentType.SALESORDER, false, CadenaC);
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

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                ETOrderDate.Enabled = false;
            }
            else
            {
                ETOrderDate.Enabled = true;
            }
        }

        private void FrmSalesOrderPicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.SALESORDER_ID;
            keyPad.ShowDialog();

            int rowIndex = GrvSalesOrder.LocateByDisplayText(0, GrvSalesOrder.Columns["SalesOrderId"], keyPad.salesOrderId);

            if (rowIndex < 0)
            {
                GrvSalesOrder.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 255, 255);
                return;
            }

            GrvSalesOrder.FocusedRowHandle = rowIndex;
            GrvSalesOrder.UpdateCurrentRow();
            GrvSalesOrder.Appearance.HideSelectionRow.BackColor = Color.FromArgb(184, 255, 61);
        }

        private void FrmSalesOrderPicker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    BtnRefresh.Focus();
                    break;
                default:
                    break;
            }
        }

        private void CmbOrderStatus_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnRefresh_Click(null, null);
                    break;
                case Keys.F5:
                    BtnRefresh_Click(null,null);
                    break;
                default:
                    break;
            }
        }

        private void CmbSalesOrderOrigin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnRefresh_Click(null, null);
                    break;
                case Keys.F5:
                    BtnRefresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void ETOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    BtnRefresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void GrcSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnSearch_Click(null, null);
                    break;
                case Keys.F2:
                    BtnNewOrder_Click(null, null);
                    break;
                case Keys.F3:
                    BtnPrintSaleOrder_Click(null, null);
                    break;
                case Keys.F5:
                    BtnRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    BtnModify_Click(null, null);
                    break;
                case Keys.F7:
                    BtnRemissionGuide_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void GrcSalesOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.E))  //Combinacion de teclas Ctrl + E
            {
                CmbOrderStatus.Focus();
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.C))  //Combinacion de teclas Ctrl + C
            {
                CmbSalesOrderOrigin.Focus();
            }                        

        }
    }
}