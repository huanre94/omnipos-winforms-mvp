using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
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
        ClsFunctions functions = new ClsFunctions();
        public List<GlobalParameter> globalParameters;
        public SP_Login_Consult_Result loginInformation;
        public bool formActionResult;
        EmissionPoint emissionPoint;
        ClsEnums.ScaleBrands scaleBrand;
        private int sequence = 0;

        public FrmPhysicalStockCount(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        private void FrmPhysicalStockCount_Load(object sender, EventArgs e)
        {
            ClearPhysicalStockCount();
            if (GetEmissionPointInformation())
            {
                if (emissionPoint.ScaleBrand != "")
                {
                    scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

                    if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                    {
                        functions.AxOPOSScanner = AxOPOSScanner;
                        functions.EnableScanner(emissionPoint.ScanBarcodeName);
                    }
                }

                try
                {
                    if (new ClsInventoryTrans().HasPendingCounting(emissionPoint, (int)loginInformation.UserId, CadenaC))
                    {
                        sequence = new ClsInventoryTrans().GetPendingCounting(emissionPoint, (int)loginInformation.UserId, CadenaC);
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
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar inventario."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                            );
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

            List<SP_PhysicalStockLine_Consult_Result> list;
            List<SP_PhysicalStockProduct_Consult_Result> newList = new List<SP_PhysicalStockProduct_Consult_Result>();
            try
            {
                list = new ClsInventoryTrans().GetPendingCountingLine(sequence, CadenaC);

                foreach (SP_PhysicalStockLine_Consult_Result item in list)
                {
                    SP_PhysicalStockProduct_Consult_Result result = new SP_PhysicalStockProduct_Consult_Result();
                    result.ProductId = item.ProductId;
                    result.ProductOldCode = item.ProductOldCode;
                    result.Barcode = item.Barcode;
                    result.ProductName = item.ProductName;
                    result.InventUnitId = item.InventUnitId;
                    result.UM = item.UM;
                    result.Quantity = item.Quantity;
                    newList.Add(result);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar detalle de inventario."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                        );
            }


            BindingList<SP_PhysicalStockProduct_Consult_Result> bindingList = new BindingList<SP_PhysicalStockProduct_Consult_Result>(newList);
            bindingList.AllowNew = true;

            GrcPhysicalStock.DataSource = bindingList;
        }

        private void LoadWarehouseList(int _locationId)
        {
            List<InventLocation> inventLocations;

            try
            {
                inventLocations = new ClsGeneral().GetMainWarehouseByLocationId(_locationId, CadenaC);

                if (inventLocations.Any())
                {
                    foreach (var locations in inventLocations)
                    {
                        CmbWarehouse.Properties.Items.Add(new ImageComboBoxItem { Value = locations.InventLocationId, Description = locations.Name });
                    }

                    CmbWarehouse.SelectedIndex = 0;
                    CmbWarehouse.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar bodegas."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message);
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
            }

            if (emissionPoint != null)
            {
                response = true;
                functions.PrinterName = emissionPoint.PrinterName;
                LblCashierUser.Text = loginInformation.UserName;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
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
                functions.ShowMessage("No se ha seleccionado producto a eliminar.", ClsEnums.MessageType.ERROR);
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
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_INVENTORY;
            keyPad.ShowDialog();
            TxtInternalCode.Text = keyPad.productInventory;
            TxtInternalCode.Focus();
            SendKeys.Send("{ENTER}");  
        }

        private void BtnBarcodeKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
            keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_INVENTORY;
            keyPad.ShowDialog();
            TxtBarcode.Text = keyPad.productInventory;
            TxtBarcode.Focus();
            SendKeys.Send("{ENTER}");   
        }

        private void TxtInternalCode_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtInternalCode.Text != string.Empty)
                {
                    try
                    {
                        SP_PhysicalStockProduct_Consult_Result result = new ClsProduct().GetProductPhysicalStock(emissionPoint, "", TxtInternalCode.Text, CadenaC);
                        if ((bool)result.Error)
                        {
                            functions.ShowMessage(result.Message, ClsEnums.MessageType.WARNING, false);
                            return;
                        }

                        AddResultToGrid(result);
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("No se encontró item con el codigo interno digitado."
                                                                   , ClsEnums.MessageType.ERROR
                                                                   , true
                                                                   , ex.Message
                                                               );


                    }
                    finally
                    {
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
                        SP_PhysicalStockProduct_Consult_Result result = new ClsProduct().GetProductPhysicalStock(emissionPoint, TxtBarcode.Text, "", CadenaC);
                        if ((bool)result.Error)
                        {
                            functions.ShowMessage(result.Message, ClsEnums.MessageType.WARNING, false);

                            TxtBarcode.Text = "";
                            TxtInternalCode.Text = "";
                            TxtBarcode.Focus();
                        }
                        else
                        {
                            AddResultToGrid(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("No se encontró item con el codigo de barra digitado."
                                                                   , ClsEnums.MessageType.ERROR
                                                                   , true
                                                                   , ex.Message
                                                               );

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

            var existe = (from li in list
                          where li.ProductId == result.ProductId
                          select li).Count();

            if (existe == 0)
            {
                GrvPhysicalStock.AddNewRow();
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductId"], result.ProductId);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductOldCode"], result.ProductOldCode);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Barcode"], result.Barcode);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["ProductName"], result.ProductName);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["InventUnitId"], result.InventUnitId);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["UM"], result.UM);
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], 0);

                FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
                keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_INVENTORY;

                if (result.InventUnitId == 1)
                {
                    keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_QUANTITY;
                }

                keyPad.ShowDialog();
                TxtBarcode.Focus();

                int rowIndex = GrvPhysicalStock.LocateByValue("ProductId", result.ProductId);

                if (rowIndex < 0)
                {
                    rowIndex = GrvPhysicalStock.FocusedRowHandle;
                }

                GrvPhysicalStock.FocusedRowHandle = rowIndex;
                GrvPhysicalStock.UpdateCurrentRow();
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], keyPad.inputFromOption == ClsEnums.InputFromOption.PRODUCT_INVENTORY ? keyPad.productInventory : keyPad.productQuantity);
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

            TxtBarcode.Text = "";
            TxtInternalCode.Text = "";
            TxtBarcode.Focus();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (sequence == 0)
            {
                functions.ShowMessage("Debe generar una nueva secuencia.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                BindingList<SP_PhysicalStockProduct_Consult_Result> list = (BindingList<SP_PhysicalStockProduct_Consult_Result>)GrvPhysicalStock.DataSource;

                if (list.Count == 0)
                {
                    functions.ShowMessage("No existen items por agregar.", ClsEnums.MessageType.WARNING);
                }
                else
                {
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
                            foreach (var prop in properties)
                            {
                                var name = prop.Name;
                                var value = prop.GetValue(line);
                                if (value == null)
                                {
                                    value = "";
                                }
                                physicalCountingLine.Add(new XElement(name, value));
                            }
                            physicalCountingList.Add(physicalCountingLine);
                            count++;
                        }

                        SP_PhysicalStockLine_Insert_Result response = new ClsInventoryTrans().InsertPhysicalStockCounting(sequence, physicalCountingList.ToString(), CadenaC);

                        if (!(bool)response.Error)
                        {
                            functions.ShowMessage("Registros guardados exitosamente.", ClsEnums.MessageType.INFO);
                            //ClearPhysicalStockCount();
                        }
                        else
                        {
                            functions.ShowMessage("No se pudo generar conteo fisico.", ClsEnums.MessageType.WARNING, true, response.TextError);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage(
                                                 "Ocurrio un problema al generar conteo fisico."
                                                 , ClsEnums.MessageType.ERROR
                                                 , true
                                                 , ex.Message
                                                 );
                    }
                }
            }

            TxtBarcode.Text = "";

        }

        private void ClearPhysicalStockCount()
        {
            sequence = 0;
            GrcPhysicalStock.DataSource = null;
            CheckGridView();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("¿Desea salir de la pantalla?", ClsEnums.MessageType.CONFIRM))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvPhysicalStock.FocusedRowHandle;

            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado producto a modificar.", ClsEnums.MessageType.ERROR);
            }
            else
            {
                SP_PhysicalStockProduct_Consult_Result item = (SP_PhysicalStockProduct_Consult_Result)GrvPhysicalStock.GetRow(rowIndex);



                FrmKeyPad keyPad = new FrmKeyPad(CadenaC);
                keyPad.inputFromOption = ClsEnums.InputFromOption.PRODUCT_INVENTORY;

                if (item.InventUnitId == 1)
                {
                    inputFromOption = item?.InventUnitId == 1 ? ClsEnums.InputFromOption.PRODUCT_QUANTITY : ClsEnums.InputFromOption.PRODUCT_INVENTORY;
                };
                keyPad.ShowDialog();
                GrvPhysicalStock.UpdateCurrentRow();
                GrvPhysicalStock.SetRowCellValue(GrvPhysicalStock.FocusedRowHandle, GrvPhysicalStock.Columns["Quantity"], keyPad.inputFromOption == ClsEnums.InputFromOption.PRODUCT_INVENTORY ? keyPad.productInventory : keyPad.productQuantity);
            }

            TxtBarcode.Focus();
        }

        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            FrmProductSearch productSearch = new FrmProductSearch(CadenaC);
            productSearch.emissionPoint = emissionPoint;
            productSearch.ShowDialog();

            if (productSearch.barcode != "")
            {
                try
                {
                    SP_PhysicalStockProduct_Consult_Result result = new ClsProduct().GetProductPhysicalStock(emissionPoint, productSearch.barcode, "", CadenaC);
                    if ((bool)result.Error)
                    {
                        functions.ShowMessage(result.Message, ClsEnums.MessageType.WARNING, false);

                        TxtBarcode.Text = "";
                        TxtInternalCode.Text = "";
                        TxtBarcode.Focus();
                    }
                    else
                    {
                        AddResultToGrid(result);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("No se encontró item con el codigo de barra digitado."
                                                               , ClsEnums.MessageType.ERROR
                                                               , true
                                                               , ex.Message);

                    TxtBarcode.Text = "";
                    TxtInternalCode.Text = "";
                    TxtBarcode.Focus();
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (sequence != 0)
            {
                if (functions.ShowMessage("¿Esta seguro de finalizar el recuento de inventario?", ClsEnums.MessageType.CONFIRM))
                {
                    try
                    {
                        bool response = new ClsInventoryTrans().UpdateStockTableStatus(sequence, CadenaC);
                        if (response)
                        {
                            functions.ShowMessage("Inventario finalizado con exito.", ClsEnums.MessageType.INFO, false);
                            BtnNew.Text = "F5 Nuevo";
                            //BtnNew.ImageOptions.SvgImage = Properties.Resources.resume;
                            ClearPhysicalStockCount();
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un error al momento de finalizar el inventario.",
                            ClsEnums.MessageType.ERROR,
                            true,
                            ex.Message);
                    }
                }
            }
            else
            {
                XElement physicalCountingList = new XElement("PhysicalStockCounting");

                XElement physicalCountingTable = new XElement("PhysicalStockCountingTable");
                PhysicalStockCountingTable header = new PhysicalStockCountingTable();
                header.LocationId = emissionPoint.LocationId;
                header.EmissionPointId = emissionPoint.EmissionPointId;
                header.InventLocationId = int.Parse(CmbWarehouse.EditValue.ToString());
                header.Type = "C";
                header.StockCountingId = 0;
                header.Observation = "";
                header.Status = "O";
                header.CreatedBy = (int)loginInformation.UserId;
                header.Workstation = loginInformation.Workstation;

                Type type = header.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(header);
                    if (value == null)
                    {
                        value = "";
                    }
                    physicalCountingTable.Add(new XElement(name, value));
                }

                physicalCountingList.Add(physicalCountingTable);

                try
                {
                    SP_PhysicalStockTable_Insert_Result response = new ClsInventoryTrans().InsertNewSequence(physicalCountingList.ToString(), CadenaC);

                    if (!(bool)response.Error)
                    {
                        sequence = (int)response.Sequence;
                        functions.ShowMessage("Secuencia generada exitosamente.", ClsEnums.MessageType.INFO);
                        BtnNew.Text = "F5 Finalizar";
                        BtnNew.ImageOptions.SvgImage = Properties.Resources.resume;
                    }
                    else
                    {
                        functions.ShowMessage("No se pudo generar secuencia de conteo fisico.", ClsEnums.MessageType.WARNING);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                             "Ocurrio un problema al generar secuencia del conteo."
                                             , ClsEnums.MessageType.ERROR
                                             , true
                                             , ex.Message
                                             );
                }
            }

            TxtBarcode.Focus();
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
                default:
                    break;
            }
        }
    }
}