using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmRemissionGuideOrderSelector : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;
        public bool isUpdated = false;
        Int64 sequenceNumber;

        public FrmRemissionGuideOrderSelector()
        {
            InitializeComponent();
         }

         private void FrmRemissionGuideOrderSelector_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                CheckGridView();
                LoadDrivers();
                LoadTranports();
                LoadTransportReasons();
                LoadPendingSalesOrders();
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
                LblEstablishment.Text = emissionPoint.Establishment;
                LblEmissionPoint.Text = emissionPoint.Emission;
                functions.PrinterName = emissionPoint.PrinterName;
                LblCashier.Text = loginInformation.UserName;

                GetNewSequenceNumber(emissionPoint.EmissionPointId, emissionPoint.LocationId);
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }


        private void GetNewSequenceNumber(int _emissionPointId, int _locationId)
        {
            ClsGeneral clsGeneral = new ClsGeneral();
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = clsGeneral.GetSequenceByEmissionPointId(_emissionPointId, _locationId, (int)ClsEnums.SequenceType.REMISSIONGUIDE);

                if (sequenceTable != null)
                {
                    sequenceNumber = sequenceTable.Sequence;
                    string stringSequence = sequenceNumber.ToString();
                    LblRemissionGuideNumber.Text = stringSequence.PadLeft(9, '0');
                }
                else
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", ClsEnums.MessageType.WARNING);
                    Close();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al obtener secuencia."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void CheckGridView()
        {
            GrvSalesOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesOrder.DataSource = null;

            BindingList<SP_RemissionPendingSalesOrder_Consult_Result> bindingList = new BindingList<SP_RemissionPendingSalesOrder_Consult_Result>();
            GrcSalesOrder.DataSource = bindingList;
        }

        private void LoadPendingSalesOrders()
        {
            try
            {
                List<SP_RemissionPendingSalesOrder_Consult_Result> list = new ClsSalesOrder().GetPendingSalesOrders();
                BindingList<SP_RemissionPendingSalesOrder_Consult_Result> bindingList = new BindingList<SP_RemissionPendingSalesOrder_Consult_Result>(list);
                if (bindingList.Count == 0)
                {
                    functions.ShowMessage("No existen ordenes de venta lista para insertar a una guia de remision", ClsEnums.MessageType.WARNING);
                    Close();
                }
                else
                {
                    GrcSalesOrder.DataSource = bindingList;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al consultar ordenes pendientes."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }

        private void LoadDrivers()
        {
            try
            {
                List<TransportDriver> transportDrivers = new ClsSalesOrder().GetTransportDrivers();
                if (transportDrivers != null)
                {
                    if (transportDrivers.Count > 0)
                    {
                        foreach (TransportDriver transportDriver in transportDrivers)
                        {
                            CmbTransportDriver.Properties.Items.Add(new ImageComboBoxItem { Value = transportDriver.TransportDriverId, Description = transportDriver.Firtsname + " " + transportDriver.Lastname });
                        }
                        CmbTransportDriver.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                                          "Ocurrio un problema al consultar conductores."
                                                          , ClsEnums.MessageType.ERROR
                                                          , true
                                                          , ex.InnerException.Message
                                                      );
            }
        }

        private void LoadTranports()
        {
            try
            {
                List<Transport> transports = new ClsSalesOrder().GetTransports();
                if (transports != null)
                {
                    if (transports.Count > 0)
                    {
                        foreach (Transport transport in transports)
                        {
                            CmbTransport.Properties.Items.Add(new ImageComboBoxItem { Value = transport.TransportId, Description = transport.LicencePlate });
                        }
                        CmbTransport.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                                          "Ocurrio un problema al consultar conductores."
                                                          , ClsEnums.MessageType.ERROR
                                                          , true
                                                          , ex.InnerException.Message
                                                      );
            }
        }
        private void LoadTransportReasons()
        {
            try
            {
                List<TransportReason> transportReasons = new ClsSalesOrder().GetTransportReasons();
                if (transportReasons != null)
                {
                    if (transportReasons.Count > 0)
                    {
                        foreach (TransportReason transportReason in transportReasons)
                        {
                            CmbTransportReason.Properties.Items.Add(new ImageComboBoxItem { Value = transportReason.TransportReasonId, Description = transportReason.Name });
                        }
                        CmbTransportReason.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                                          "Ocurrio un problema al consultar conductores."
                                                          , ClsEnums.MessageType.ERROR
                                                          , true
                                                          , ex.InnerException.Message
                                                      );
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            BindingList<SP_RemissionPendingSalesOrder_Consult_Result> list = (BindingList<SP_RemissionPendingSalesOrder_Consult_Result>)GrcSalesOrder.DataSource;
            //int resultCount = list.Count;
            int checkedItems = 0;
            foreach (SP_RemissionPendingSalesOrder_Consult_Result item in list)
            {
                if ((bool)item.isSelected)
                {
                    checkedItems++;
                }
            }
            if (checkedItems == 0)
            {
                functions.ShowMessage("Para crear una guia, se requiere que esten marcados 1 o mas pedidos.", ClsEnums.MessageType.WARNING);
                return;
            }

            try
            {
                XElement salesRemission = new XElement("SalesRemission");
                XElement salesRemissionTable = new XElement("SalesRemissionTable");
                SalesRemissionTable remissionTable = new SalesRemissionTable()
                {
                    SalesRemissionDate = DateTime.Now,
                    TypeDoc = 6,
                    Establishment = emissionPoint.Establishment,
                    Emission = emissionPoint.Emission,
                    RemissionNumber = sequenceNumber,
                    TransportId = (int)CmbTransport.EditValue,
                    TransportDriverId = (int)CmbTransportDriver.EditValue,
                    TransportReasonId = (int)CmbTransportReason.EditValue,
                    LocationId = emissionPoint.LocationId,
                    EmissionPointId = emissionPoint.EmissionPointId,
                    Status = "A",
                    CreatedBy = (int)loginInformation.UserId,
                    CreatedDatetime = DateTime.Now,
                    ModifiedBy = (int)loginInformation.UserId,
                    ModifiedDatetime = DateTime.Now,
                    Workstation = loginInformation.Workstation,
                };

                Type type = remissionTable.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(remissionTable);

                    if (value == null)
                    {
                        value = "";
                    }

                    salesRemissionTable.Add(new XElement(name, value));
                }
                salesRemission.Add(salesRemissionTable);

                BindingList<SP_RemissionPendingSalesOrder_Consult_Result> salesOrders = (BindingList<SP_RemissionPendingSalesOrder_Consult_Result>)GrvSalesOrder.DataSource;
                foreach (SP_RemissionPendingSalesOrder_Consult_Result item in salesOrders)
                {
                    XElement salesRemissionLine = new XElement("SalesRemissionLine");
                    if ((bool)item.isSelected)
                    {
                        SalesRemissionLine line = new SalesRemissionLine();
                        line.SalesOrderId = item.SalesOrderId;
                        line.Status = "A";

                        type = line.GetType();
                        properties = type.GetProperties();

                        foreach (var prop in properties)
                        {
                            var name = prop.Name;
                            var value = prop.GetValue(line);

                            if (value == null)
                            {
                                value = "";
                            }

                            salesRemissionLine.Add(new XElement(name, value));
                        }
                        salesRemission.Add(salesRemissionLine);
                    }
                }

                SP_SalesOrderRemission_Insert_Result result = new ClsSalesOrderTrans().CreateNewRemissionGuide(salesRemission.ToString());
                if (!(bool)result.Error)
                {
                    isUpdated = true;

                    if (functions.PrintDocument((long)result.SalesRemissionId, ClsEnums.DocumentType.REMISSIONGUIDE, false))
                    {
                        functions.ShowMessage("Guia de remision creada exitosamente.", ClsEnums.MessageType.INFO);
                        //DELETE PAYMODES
                        Close();
                    }
                    else
                    {
                        functions.ShowMessage("La guia se creo correctamente pero no se pudo imprimir.", ClsEnums.MessageType.WARNING);
                        Close();
                    }
                }
                else
                {
                    functions.ShowMessage("Existio un error al guardar guia de retencion", ClsEnums.MessageType.ERROR, true, result.TextError);
                    Close();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Existio un error al guardar guia de retencion", ClsEnums.MessageType.ERROR, true, ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
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

        private void GrcSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnSearch_Click(null, null);
                    break;
                case Keys.F2:
                    BtnModify_Click(null, null);
                    break;
                case Keys.Escape:
                    BtnCancel_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}