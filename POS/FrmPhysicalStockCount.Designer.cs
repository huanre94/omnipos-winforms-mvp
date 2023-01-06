namespace POS
{
    partial class FrmPhysicalStockCount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhysicalStockCount));
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.GrcPhysicalStock = new DevExpress.XtraGrid.GridControl();
            this.GrvPhysicalStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnBarcodeKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.TxtInternalCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnInternalCodeKeypad = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LblCashierUser = new System.Windows.Forms.Label();
            this.BtnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            this.CmbWarehouse = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnProductSearch = new DevExpress.XtraEditors.SimpleButton();
            this.BtnNew = new DevExpress.XtraEditors.SimpleButton();
            this.BtnModifyAmount = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPhysicalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPhysicalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInternalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbWarehouse.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAccept
            // 
            this.BtnAccept.AllowFocus = false;
            this.BtnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAccept.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAccept.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnAccept.Appearance.Options.UseBackColor = true;
            this.BtnAccept.Appearance.Options.UseFont = true;
            this.BtnAccept.Appearance.Options.UseForeColor = true;
            this.BtnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAccept.ImageOptions.Image")));
            this.BtnAccept.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAccept.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAccept.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnAccept.Location = new System.Drawing.Point(1192, 704);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 0;
            this.BtnAccept.TabStop = false;
            this.BtnAccept.Text = "F2 Guardar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.AllowFocus = false;
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.Appearance.Options.UseForeColor = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnCancel.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(1022, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 160;
            this.BtnCancel.TabStop = false;
            this.BtnCancel.Text = "F9 Salir";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrcPhysicalStock
            // 
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.GrcPhysicalStock.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcPhysicalStock.Location = new System.Drawing.Point(31, 211);
            this.GrcPhysicalStock.MainView = this.GrvPhysicalStock;
            this.GrcPhysicalStock.Name = "GrcPhysicalStock";
            this.GrcPhysicalStock.Size = new System.Drawing.Size(1221, 476);
            this.GrcPhysicalStock.TabIndex = 188;
            this.GrcPhysicalStock.UseEmbeddedNavigator = true;
            this.GrcPhysicalStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPhysicalStock});
            this.GrcPhysicalStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrcPhysicalStock_KeyDown);
            // 
            // GrvPhysicalStock
            // 
            this.GrvPhysicalStock.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvPhysicalStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn2});
            this.GrvPhysicalStock.GridControl = this.GrcPhysicalStock;
            this.GrvPhysicalStock.Name = "GrvPhysicalStock";
            this.GrvPhysicalStock.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPhysicalStock.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPhysicalStock.OptionsBehavior.ReadOnly = true;
            this.GrvPhysicalStock.OptionsCustomization.AllowColumnMoving = false;
            this.GrvPhysicalStock.OptionsCustomization.AllowColumnResizing = false;
            this.GrvPhysicalStock.OptionsCustomization.AllowFilter = false;
            this.GrvPhysicalStock.OptionsCustomization.AllowGroup = false;
            this.GrvPhysicalStock.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPhysicalStock.OptionsCustomization.AllowSort = false;
            this.GrvPhysicalStock.OptionsView.RowAutoHeight = true;
            this.GrvPhysicalStock.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "ProductId";
            this.gridColumn1.MaxWidth = 10;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 10;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Cod. Interno";
            this.gridColumn4.FieldName = "ProductOldCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 138;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Cod. Barra";
            this.gridColumn5.FieldName = "Barcode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 195;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Nombre Producto";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.MaxWidth = 500;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 470;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "InventUnitId";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "UM";
            this.gridColumn6.FieldName = "UM";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 152;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Cantidad";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "Quantity";
            this.gridColumn2.MaxWidth = 150;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 150;
            // 
            // BtnBarcodeKeyPad
            // 
            this.BtnBarcodeKeyPad.AllowFocus = false;
            this.BtnBarcodeKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnBarcodeKeyPad.Appearance.Options.UseFont = true;
            this.BtnBarcodeKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnBarcodeKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnBarcodeKeyPad.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBarcodeKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnBarcodeKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnBarcodeKeyPad.ImageOptions.SvgImage")));
            this.BtnBarcodeKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnBarcodeKeyPad.Location = new System.Drawing.Point(855, 81);
            this.BtnBarcodeKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnBarcodeKeyPad.Name = "BtnBarcodeKeyPad";
            this.BtnBarcodeKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnBarcodeKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnBarcodeKeyPad.TabIndex = 191;
            this.BtnBarcodeKeyPad.Click += new System.EventHandler(this.BtnBarcodeKeyPad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 190;
            this.label5.Text = "Código Interno";
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(630, 83);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtBarcode.Properties.Appearance.Options.UseFont = true;
            this.TxtBarcode.Size = new System.Drawing.Size(216, 44);
            this.TxtBarcode.TabIndex = 189;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // TxtInternalCode
            // 
            this.TxtInternalCode.Location = new System.Drawing.Point(174, 83);
            this.TxtInternalCode.Name = "TxtInternalCode";
            this.TxtInternalCode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtInternalCode.Properties.Appearance.Options.UseFont = true;
            this.TxtInternalCode.Size = new System.Drawing.Size(177, 44);
            this.TxtInternalCode.TabIndex = 0;
            this.TxtInternalCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInternalCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 190;
            this.label1.Text = "Código Barra";
            // 
            // BtnInternalCodeKeypad
            // 
            this.BtnInternalCodeKeypad.AllowFocus = false;
            this.BtnInternalCodeKeypad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnInternalCodeKeypad.Appearance.Options.UseFont = true;
            this.BtnInternalCodeKeypad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnInternalCodeKeypad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnInternalCodeKeypad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnInternalCodeKeypad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnInternalCodeKeypad.ImageOptions.SvgImage")));
            this.BtnInternalCodeKeypad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnInternalCodeKeypad.Location = new System.Drawing.Point(360, 81);
            this.BtnInternalCodeKeypad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnInternalCodeKeypad.Name = "BtnInternalCodeKeypad";
            this.BtnInternalCodeKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnInternalCodeKeypad.Size = new System.Drawing.Size(82, 50);
            this.BtnInternalCodeKeypad.TabIndex = 191;
            this.BtnInternalCodeKeypad.Click += new System.EventHandler(this.BtnInternalCodeKeypad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 190;
            this.label2.Text = "Cajero";
            // 
            // LblCashierUser
            // 
            this.LblCashierUser.AutoSize = true;
            this.LblCashierUser.Location = new System.Drawing.Point(171, 38);
            this.LblCashierUser.Name = "LblCashierUser";
            this.LblCashierUser.Size = new System.Drawing.Size(0, 16);
            this.LblCashierUser.TabIndex = 190;
            // 
            // BtnRemove
            // 
            this.BtnRemove.AllowFocus = false;
            this.BtnRemove.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRemove.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRemove.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnRemove.Appearance.Options.UseBackColor = true;
            this.BtnRemove.Appearance.Options.UseFont = true;
            this.BtnRemove.Appearance.Options.UseForeColor = true;
            this.BtnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRemove.ImageOptions.Image")));
            this.BtnRemove.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnRemove.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnRemove.Location = new System.Drawing.Point(1272, 315);
            this.BtnRemove.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(80, 92);
            this.BtnRemove.TabIndex = 0;
            this.BtnRemove.Text = "F11 \r\nElim";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(735, 366);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(240, 240);
            this.AxOPOSScanner.TabIndex = 193;
            this.AxOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.AxOPOSScanner_DataEvent);
            // 
            // CmbWarehouse
            // 
            this.CmbWarehouse.Location = new System.Drawing.Point(174, 153);
            this.CmbWarehouse.Name = "CmbWarehouse";
            this.CmbWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbWarehouse.Size = new System.Drawing.Size(445, 38);
            this.CmbWarehouse.TabIndex = 194;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 190;
            this.label3.Text = "Bodega";
            // 
            // BtnProductSearch
            // 
            this.BtnProductSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnProductSearch.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductSearch.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnProductSearch.Appearance.Options.UseBackColor = true;
            this.BtnProductSearch.Appearance.Options.UseFont = true;
            this.BtnProductSearch.Appearance.Options.UseForeColor = true;
            this.BtnProductSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnProductSearch.ImageOptions.SvgImage = global::POS.Properties.Resources.productSearch2;
            this.BtnProductSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnProductSearch.Location = new System.Drawing.Point(962, 62);
            this.BtnProductSearch.Name = "BtnProductSearch";
            this.BtnProductSearch.Size = new System.Drawing.Size(220, 80);
            this.BtnProductSearch.TabIndex = 195;
            this.BtnProductSearch.Text = "F3 Productos";
            this.BtnProductSearch.Click += new System.EventHandler(this.BtnProductSearch_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.AllowFocus = false;
            this.BtnNew.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNew.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnNew.Appearance.Options.UseBackColor = true;
            this.BtnNew.Appearance.Options.UseFont = true;
            this.BtnNew.Appearance.Options.UseForeColor = true;
            this.BtnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.ImageOptions.Image")));
            this.BtnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnNew.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnNew.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnNew.Location = new System.Drawing.Point(31, 704);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(160, 50);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.TabStop = false;
            this.BtnNew.Text = "F5 Nuevo";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnModifyAmount
            // 
            this.BtnModifyAmount.AllowFocus = false;
            this.BtnModifyAmount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModifyAmount.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnModifyAmount.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnModifyAmount.Appearance.Options.UseBackColor = true;
            this.BtnModifyAmount.Appearance.Options.UseFont = true;
            this.BtnModifyAmount.Appearance.Options.UseForeColor = true;
            this.BtnModifyAmount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModifyAmount.ImageOptions.Image")));
            this.BtnModifyAmount.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnModifyAmount.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnModifyAmount.Location = new System.Drawing.Point(1271, 211);
            this.BtnModifyAmount.Margin = new System.Windows.Forms.Padding(6);
            this.BtnModifyAmount.Name = "BtnModifyAmount";
            this.BtnModifyAmount.Size = new System.Drawing.Size(80, 92);
            this.BtnModifyAmount.TabIndex = 0;
            this.BtnModifyAmount.Text = "F10 \r\nEdit";
            this.BtnModifyAmount.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // FrmPhysicalStockCount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.BtnProductSearch);
            this.Controls.Add(this.CmbWarehouse);
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.BtnModifyAmount);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnInternalCodeKeypad);
            this.Controls.Add(this.BtnBarcodeKeyPad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblCashierUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtInternalCode);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.GrcPhysicalStock);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPhysicalStockCount";
            this.Text = "FrmPhysicalStockCount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPhysicalStockCount_FormClosing);
            this.Load += new System.EventHandler(this.FrmPhysicalStockCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcPhysicalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPhysicalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInternalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbWarehouse.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraGrid.GridControl GrcPhysicalStock;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPhysicalStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton BtnBarcodeKeyPad;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit TxtBarcode;
        private DevExpress.XtraEditors.TextEdit TxtInternalCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnInternalCodeKeypad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblCashierUser;
        private DevExpress.XtraEditors.SimpleButton BtnRemove;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbWarehouse;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton BtnProductSearch;
        private DevExpress.XtraEditors.SimpleButton BtnNew;
        private DevExpress.XtraEditors.SimpleButton BtnModifyAmount;
    }
}