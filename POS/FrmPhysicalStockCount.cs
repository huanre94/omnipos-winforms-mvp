using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmPhysicalStockCount : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public IEnumerable<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        public bool formActionResult;
        EmissionPoint emissionPoint;
        ScaleBrands scaleBrand;
        private int sequence = 0;

        public FrmPhysicalStockCount()
        {
            InitializeComponent();
        }

        private void FrmPhysicalStockCount_Load(object sender, EventArgs e)
        {
            ClearPhysicalStockCount();
            if (GetEmissionPointInformation())
            {
                if (emissionPoint.ScaleBrand != "")
                {
                    scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

                    if (scaleBrand == ScaleBrands.DATALOGIC)
                    {
                        functions.AxOPOSScanner = AxOPOSScanner;
                        functions.EnableScanner(emissionPoint.ScanBarcodeName);
                    }
                }

                try
                {
                    if (new ClsInventoryTrans(Program.customConnectionString).HasPendingCounting(emissionPoint, (int)loginInformation.UserId))
                    {
                        sequence = new ClsInventoryTrans(Program.customConnectionString).GetPendingCounting(emissionPoint, (int)loginInformation.UserId);
                        LoadStockGrid();
                        LoadWarehouseList(emissionPoint.LocationId);

                        BtnNew.Text = "F5 Finalizar";
                        BtnNew.ImageOptions.SvgImage = Properties.Resources.resume;
                        //BtnNew.Enabled = false;
                    }
                    else
                    {
                        BtnNew.Text = "F5 Nuevo";
                        //BtnNew.ImageOptions.SvgImage = POS.Properties.Resources.resume;
                        CheckGridView();
                        LoadWarehouseList(emissionPoint.LocationId);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar inventario.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }

                LblCashierUser.Text = loginInformation.UserName;
                TxtBarcode.Focus();
            }
        }

        private void LoadStockGrid()
        {
            GrvPhysicalStock.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPhysicalStock.DataSource = null;
            GrvPhysicalStock.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            IEnumerable<SP_PhysicalStockLine_Consult_Result> list;
            List<SP_PhysicalStockProduct_Consult_Result> newList = new List<SP_PhysicalStockProduct_Consult_Result>();
            try
            {
                list = new ClsInventoryTrans(Program.customConnectionString).GetPendingCountingLine(sequence);

                foreach (SP_PhysicalStockLine_Consult_Result item in list)
                {
                    SP_PhysicalStockProduct_Consult_Result result = new SP_PhysicalStockProduct_Consult_Result
                    {
                        ProductId = item.ProductId,
                        ProductOldCode = item.ProductOldCode,
                        Barcode = item.Barcode,
                        ProductName = item.ProductName,
                        InventUnitId = item.InventUnitId,
                        UM = item.UM,
                        Quantity = item.Quantity
                    };
                    newList.Add(result);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar detalle de inventario.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }


            BindingList<SP_PhysicalStockProduct_Consult_Result> bindingList = new BindingList<SP_PhysicalStockProduct_Consult_Result>(newList);
            bindingList.AllowNew = true;

            GrcPhysicalStock.DataSource = bindingList;
        }

        private void LoadWarehouseList(int _locationId)
        {
            try
            {
                IEnumerable<InventLocation> inventLocations = new ClsGeneral(Program.customConnectionString).GetMainWarehouseByLocationId(_locationId);

                if (inventLocations.Any())
                {
                    foreach (InventLocation locations in inventLocations)
                    {
                        CmbWarehouse.Properties.Items.Add(new ImageComboBoxItem { Value = locations.InventLocationId, Description = locations.Name });
                    }

                    CmbWarehouse.SelectedIndex = 0;
                    CmbWarehouse.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar bodegas.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

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


            if (emissionPoint == null)
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                return false;
            }

            functions.PrinterName = emissionPoint.PrinterName;
            LblCashierUser.Text = loginInformation.UserName;
            return true;
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }

        private void CheckGridView()
        {
            GrvPhysicalStock.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcPhysicalStock.DataSource = null;
            GrvPhysicalStock.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindingList<SP_PhysicalStockProduct_Consult_Result> bindingList = new BindingList<SP_PhysicalStockProduct_Consult_Result>();
            bindingList.AllowNew = true;

            GrcPhysicalStock.DataSource = bindingList;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvPhysicalStock.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a eliminar.", MessageType.ERROR);
            }
            else
            {
                SP_PhysicalStockProduct_Consult_Result selectedRow = (SP_PhysicalStockProduct_Consult_Result)GrvPhysicalStock.GetRow(rowIndex);

                BindingList<SP_PhysicalStockProduct_Consult_Result> dataSource = (BindingList<SP_PhysicalStockProduct_Consult_Result>)GrvPhysicalStock.DataSource;
                foreach (SP_PhysicalStockProduct_Consult_Result item in dataSource)
                {
                    if (item.ProductId == selectedRow.ProductId)
                    {
                        dataSource.Remove(item);
                        break;
                    }
                }

                GrcPhysicalStock.DataSource = dataSource;
            }

            TxtBarcode.Focus();
        }

        private void BtnInternalCodeKeypad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.PRODUCT_INVENTORY);
            keyPad.ShowDialog();

            TxtInternalCode.Text = keyPad.GetValue();
            TxtInternalCode.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void BtnBarcodeKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.PRODUCT_INVENTORY);
            keyPad.ShowDialog();
            TxtBarcode.Text = keyPad.GetValue();
            TxtBarcode.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void TxtInternalCode_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtInternalCode.Text == string.Empty)
                {
                }

                try
                {
                    SP_PhysicalStockProduct_Consult_Result result = new ClsProduct(Program.customConnectionString).GetProductPhysicalStock(emissionPoint, "", TxtInternalCode.Text);
                    if ((bool)result.Error)
                    {
                        functions.ShowMessage(result.Message, MessageType.WARNING, false);
                        return;
                    }

                    AddResultToGrid(result);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("No se encontró item con el codigo interno digitado.",
                                          MessageType.ERROR,
                                          true,
                                          ex.Message);


                }
                finally
                {
                    TxtBarcode.Text = "";
                    TxtInternalCode.Text = "";
                    TxtBarcode.Focus();
                }

            }

            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnInternalCodeKeypad_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F3:
                    BtnProductSearch_Click(null, null);
                    break;
                case Keys.F5:
                    BtnNew_Click(null, null);
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    break;
                case Keys.F12:
                    GrcPhysicalStock.Focus();
                    break;
                default:
                    break;
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBarcode.Text != string.Empty)
                {
                    try
                    {
                        SP_PhysicalStockProduct_Consult_Result result = new ClsProduct(Program.customConnectionString).GetProductPhysicalStock(emissionPoint, TxtBarcode.Text, "");
                        if ((bool)result.Error)
                        {
                            functions.ShowMessage(result.Message, MessageType.WARNING, false);

                            TxtBarcode.Text = "";
                            TxtInternalCode.Text = "";
                            TxtBarcode.Focus();
                            return;
                        }

                        AddResultToGrid(result);
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("No se encontró item con el codigo de barra digitado.",
                            MessageType.ERROR,
                            true,
                            ex.Message);

                        TxtBarcode.Text = "";
                        TxtInternalCode.Text = "";
                        TxtBarcode.Focus();
                    }
                }
            }

            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnBarcodeKeyPad_Click(null, null);
                    break;
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F3:
                    BtnProductSearch_Click(null, null);
                    break;
                case Keys.F5:
                    BtnNew_Click(null, null);
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    break;
                case Keys.F12:
                    GrcPhysicalStock.Focus();
                    break;
                default:
                    break;
            }
        }

        private void AddResultToGrid(SP_PhysicalStockProduct_Consult_Result result)
        {
            BindingList<SP_PhysicalStockProduct_Consult_Result> list = (BindingList<SP_PhysicalStockProduct_Consult_Result>)GrvPhysicalStock.DataSource;

            int hasBeenScanned = list.Where(p => p.ProductId == result.ProductId).Count();

            if (hasBeenScanned == 0)
            {
                GrvPhysicalStock.AddNewRow();
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductId"], result.ProductId);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductOldCode"], result.ProductOldCode);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Barcode"], result.Barcode);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductName"], result.ProductName);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["InventUnitId"], result.InventUnitId);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["UM"], result.UM);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], 0);

                FrmKeyPad keyPad = new FrmKeyPad(result.InventUnitId == 1 ? InputFromOption.PRODUCT_QUANTITY : InputFromOption.PRODUCT_INVENTORY);
                keyPad.ShowDialog();

                TxtBarcode.Focus();

                int rowIndex = GrvPhysicalStock.LocateByValue("ProductId", result.ProductId);

                if (rowIndex < 0)
                {
                    rowIndex = GrvPhysicalStock.FocusedRowHandle;
                }

                GrvPhysicalStock.FocusedRowHandle = rowIndex;
                GrvPhysicalStock.UpdateCurrentRow();
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], keyPad.GetValue());
            }
            else
            {
                int rowIndex = GrvPhysicalStock.LocateByValue("ProductId", result.ProductId);

                if (rowIndex < 0)
                {
                    rowIndex = GrvPhysicalStock.FocusedRowHandle;
                }

                GrvPhysicalStock.FocusedRowHandle = rowIndex;
                GrvPhysicalStock.UpdateCurrentRow();
                GrvPhysicalStock.Appearance.HideSelectionRow.BackColor = Color.FromArgb(184, 255, 61);
            }

            ClearBarcode();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (sequence == 0)
            {
                functions.ShowMessage("Debe generar una nueva secuencia.", MessageType.WARNING);
                return;
            }

            BindingList<SP_PhysicalStockProduct_Consult_Result> list = (BindingList<SP_PhysicalStockProduct_Consult_Result>)GrvPhysicalStock.DataSource;

            if (list.Count == 0)
            {
                functions.ShowMessage("No existen items por agregar.", MessageType.WARNING);
                return;
            }

            XElement physicalCountingList = new XElement("PhysicalStockCounting");

            try
            {
                int count = 1;
                foreach (SP_PhysicalStockProduct_Consult_Result item in list)
                {
                    XElement physicalCountingLine = new XElement("PhysicalStockCountingLine");
                    PhysicalStockCountingLine line = new PhysicalStockCountingLine
                    {
                        Sequence = count,
                        ProductId = item.ProductId,
                        InventUnitId = item.InventUnitId,
                        StockQuantity = 0,
                        CountedQuantity = (decimal)item.Quantity,
                        Cost = 0
                    };

                    Type type = line.GetType();
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo prop in properties)
                    {
                        string name = prop.Name;
                        object value = prop.GetValue(line);
                        if (value == null)
                        {
                            value = "";
                        }
                        physicalCountingLine.Add(new XElement(name, value));
                    }
                    physicalCountingList.Add(physicalCountingLine);
                    count++;
                }

                SP_PhysicalStockLine_Insert_Result response = new ClsInventoryTrans(Program.customConnectionString).InsertPhysicalStockCounting(sequence, physicalCountingList.ToString());

                if ((bool)response.Error)
                {
                    functions.ShowMessage("No se pudo generar conteo fisico.", MessageType.WARNING, true, response.TextError);
                    return;
                }

                functions.ShowMessage("Registros guardados exitosamente.", MessageType.INFO);
                //ClearPhysicalStockCount();
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al generar conteo fisico.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }

            ClearBarcode();

        }

        private void ClearPhysicalStockCount()
        {
            sequence = 0;
            GrcPhysicalStock.DataSource = null;
            CheckGridView();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("¿Desea salir de la pantalla?", MessageType.CONFIRM))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvPhysicalStock.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a modificar.", MessageType.ERROR);
                return;
            }

            SP_PhysicalStockProduct_Consult_Result item = (SP_PhysicalStockProduct_Consult_Result)GrvPhysicalStock.GetRow(rowIndex);

            FrmKeyPad keyPad = new FrmKeyPad(item?.InventUnitId == 1 ? InputFromOption.PRODUCT_QUANTITY : InputFromOption.PRODUCT_INVENTORY);
            keyPad.ShowDialog();

            GrvPhysicalStock.UpdateCurrentRow();
            GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], keyPad.GetValue());

            ClearBarcode();
        }

        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            FrmProductSearch productSearch = new FrmProductSearch(emissionPoint);
            productSearch.ShowDialog();

            if (productSearch.GetProduct().Barcode == "")
            {
                return;
            }

            try
            {
                SP_PhysicalStockProduct_Consult_Result result = new ClsProduct(Program.customConnectionString).GetProductPhysicalStock(emissionPoint, productSearch.GetProduct().Barcode, "");
                if ((bool)result.Error)
                {
                    functions.ShowMessage(result.Message, MessageType.WARNING, false);
                    return;
                }

                AddResultToGrid(result);
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se encontró item con el codigo de barra digitado.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }

            ClearBarcode();
        }

        private void ClearBarcode()
        {
            TxtBarcode.Text = "";
            TxtInternalCode.Text = "";
            TxtBarcode.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (sequence == 0)
            {
                OpenNewWarehouseSequence();
                ClearBarcode();
                return;
            }

            if (functions.ShowMessage("¿Esta seguro de finalizar el recuento de inventario?", MessageType.CONFIRM))
            {
                try
                {
                    bool response = new ClsInventoryTrans(Program.customConnectionString).UpdateStockTableStatus(sequence);
                    if (response)
                    {
                        functions.ShowMessage("Inventario finalizado con exito.", MessageType.INFO, false);
                        BtnNew.Text = "F5 Nuevo";
                        //BtnNew.ImageOptions.SvgImage = Properties.Resources.resume;
                        ClearPhysicalStockCount();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un error al momento de finalizar el inventario.",
                                          MessageType.ERROR,
                                          true,
                                          ex.Message);
                }
            }

        }

        private bool OpenNewWarehouseSequence()
        {
            XElement physicalCountingList = new XElement("PhysicalStockCounting");

            XElement physicalCountingTable = new XElement("PhysicalStockCountingTable");
            PhysicalStockCountingTable header = new PhysicalStockCountingTable
            {
                LocationId = emissionPoint.LocationId,
                EmissionPointId = emissionPoint.EmissionPointId,
                InventLocationId = int.Parse(CmbWarehouse.EditValue.ToString()),
                Type = "C",
                StockCountingId = 0,
                Observation = "",
                Status = "O",
                CreatedBy = (int)loginInformation.UserId,
                Workstation = loginInformation.Workstation
            };

            Type type = header.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                string name = prop.Name;
                object value = prop.GetValue(header);
                if (value == null)
                {
                    value = "";
                }
                physicalCountingTable.Add(new XElement(name, value));
            }

            physicalCountingList.Add(physicalCountingTable);

            try
            {
                SP_PhysicalStockTable_Insert_Result response = new ClsInventoryTrans(Program.customConnectionString).InsertNewSequence(physicalCountingList.ToString());

                if ((bool)response.Error)
                {
                    functions.ShowMessage("No se pudo generar secuencia de conteo fisico.", MessageType.WARNING);
                    return false;
                }

                sequence = (int)response.Sequence;
                functions.ShowMessage("Secuencia generada exitosamente.", MessageType.INFO);
                BtnNew.Text = "F5 Finalizar";
                BtnNew.ImageOptions.SvgImage = Properties.Resources.resume;
                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al generar secuencia del conteo.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);

                return false;
            }
        }

        private void FrmPhysicalStockCount_FormClosing(object sender, FormClosingEventArgs e)
        {
            functions.DisableScanner();
        }

        private void GrcPhysicalStock_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnAccept_Click(null, null);
                    break;
                case Keys.F3:
                    BtnProductSearch_Click(null, null);
                    break;
                case Keys.F5:
                    BtnNew_Click(null, null);
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    break;
                case Keys.F10:
                    BtnModify_Click(null, null);
                    break;
                case Keys.F11:
                    BtnRemove_Click(null, null);
                    break;
                case Keys.Escape:
                    TxtBarcode.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}