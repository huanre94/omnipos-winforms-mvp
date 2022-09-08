namespace POS
{
    partial class FrmRemissionGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemissionGuide));
            this.GrcRemissionGuide = new DevExpress.XtraGrid.GridControl();
            this.GrvRemissionGuide = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrcSalesOrder = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnModify = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnNewOrder = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPrintRemissionGuide = new DevExpress.XtraEditors.SimpleButton();
            this.ChkMyGuides = new DevExpress.XtraEditors.CheckEdit();
            this.CmbTransportDriver = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrcRemissionGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvRemissionGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkMyGuides.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportDriver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GrcRemissionGuide
            // 
            this.GrcRemissionGuide.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcRemissionGuide.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcRemissionGuide.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcRemissionGuide.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcRemissionGuide.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcRemissionGuide.Location = new System.Drawing.Point(26, 72);
            this.GrcRemissionGuide.MainView = this.GrvRemissionGuide;
            this.GrcRemissionGuide.Name = "GrcRemissionGuide";
            this.GrcRemissionGuide.Size = new System.Drawing.Size(1310, 294);
            this.GrcRemissionGuide.TabIndex = 140;
            this.GrcRemissionGuide.UseEmbeddedNavigator = true;
            this.GrcRemissionGuide.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvRemissionGuide});
            // 
            // GrvRemissionGuide
            // 
            this.GrvRemissionGuide.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column1,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13});
            this.GrvRemissionGuide.GridControl = this.GrcRemissionGuide;
            this.GrvRemissionGuide.Name = "GrvRemissionGuide";
            this.GrvRemissionGuide.OptionsView.ShowGroupPanel = false;
            this.GrvRemissionGuide.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrvRemissionGuide_RowClick);
            // 
            // Column1
            // 
            this.Column1.AppearanceHeader.Options.UseTextOptions = true;
            this.Column1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column1.Caption = "ID Guia";
            this.Column1.FieldName = "SalesRemissionId";
            this.Column1.MaxWidth = 200;
            this.Column1.Name = "Column1";
            this.Column1.OptionsColumn.AllowEdit = false;
            this.Column1.OptionsColumn.AllowMove = false;
            this.Column1.OptionsColumn.AllowSize = false;
            this.Column1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Column1.OptionsColumn.FixedWidth = true;
            this.Column1.OptionsColumn.ReadOnly = true;
            this.Column1.Visible = true;
            this.Column1.VisibleIndex = 0;
            this.Column1.Width = 200;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Fecha ";
            this.gridColumn8.DisplayFormat.FormatString = "g";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "SalesRemissionDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Placa";
            this.gridColumn9.FieldName = "LicencePlate";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Conductor";
            this.gridColumn10.FieldName = "Name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Cant. Ped.";
            this.gridColumn11.FieldName = "OrderQuantity";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "Estado";
            this.gridColumn13.FieldName = "Status";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // GrcSalesOrder
            // 
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcSalesOrder.Location = new System.Drawing.Point(26, 412);
            this.GrcSalesOrder.MainView = this.GrvSalesOrder;
            this.GrcSalesOrder.Name = "GrcSalesOrder";
            this.GrcSalesOrder.Size = new System.Drawing.Size(1310, 270);
            this.GrcSalesOrder.TabIndex = 140;
            this.GrcSalesOrder.UseEmbeddedNavigator = true;
            this.GrcSalesOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesOrder});
            // 
            // GrvSalesOrder
            // 
            this.GrvSalesOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.GrvSalesOrder.GridControl = this.GrcSalesOrder;
            this.GrvSalesOrder.Name = "GrvSalesOrder";
            this.GrvSalesOrder.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "# Orden";
            this.gridColumn1.FieldName = "SalesOrderId";
            this.gridColumn1.MaxWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Canal";
            this.gridColumn2.DisplayFormat.FormatString = "g";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "ChannelName";
            this.gridColumn2.MaxWidth = 175;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 175;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "OrderDate";
            this.gridColumn3.MaxWidth = 150;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Cliente";
            this.gridColumn4.FieldName = "CustomerName";
            this.gridColumn4.MaxWidth = 250;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSize = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Monto";
            this.gridColumn5.DisplayFormat.FormatString = "c2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Amount";
            this.gridColumn5.MaxWidth = 150;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Estado";
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.MaxWidth = 250;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.AllowSize = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 250;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "# E-Com. ";
            this.gridColumn7.FieldName = "OrderECommerce";
            this.gridColumn7.MaxWidth = 200;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.AllowSize = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 200;
            // 
            // BtnModify
            // 
            this.BtnModify.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModify.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnModify.Appearance.Options.UseBackColor = true;
            this.BtnModify.Appearance.Options.UseFont = true;
            this.BtnModify.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.ImageOptions.Image")));
            this.BtnModify.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnModify.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnModify.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnModify.Location = new System.Drawing.Point(1126, 704);
            this.BtnModify.Margin = new System.Windows.Forms.Padding(5);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(210, 50);
            this.BtnModify.TabIndex = 142;
            this.BtnModify.Text = "Visualizar Guia";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancel.ImageOptions.SvgImage")));
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(956, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 143;
            this.BtnCancel.Text = "Salir";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnNewOrder
            // 
            this.BtnNewOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNewOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnNewOrder.Appearance.Options.UseBackColor = true;
            this.BtnNewOrder.Appearance.Options.UseFont = true;
            this.BtnNewOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewOrder.ImageOptions.Image")));
            this.BtnNewOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnNewOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnNewOrder.Location = new System.Drawing.Point(26, 704);
            this.BtnNewOrder.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNewOrder.Name = "BtnNewOrder";
            this.BtnNewOrder.Size = new System.Drawing.Size(160, 50);
            this.BtnNewOrder.TabIndex = 144;
            this.BtnNewOrder.Text = "Nueva \r\nGuia";
            this.BtnNewOrder.Click += new System.EventHandler(this.BtnNewOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(23, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 251;
            this.label1.Text = "Pedidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(23, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 252;
            this.label4.Text = "Guias";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRefresh.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRefresh.Appearance.Options.UseBackColor = true;
            this.BtnRefresh.Appearance.Options.UseFont = true;
            this.BtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.ImageOptions.Image")));
            this.BtnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRefresh.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRefresh.Location = new System.Drawing.Point(1176, 14);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(160, 50);
            this.BtnRefresh.TabIndex = 254;
            this.BtnRefresh.Text = "Actualizar";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnPrintRemissionGuide
            // 
            this.BtnPrintRemissionGuide.AllowFocus = false;
            this.BtnPrintRemissionGuide.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintRemissionGuide.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintRemissionGuide.Appearance.Options.UseBackColor = true;
            this.BtnPrintRemissionGuide.Appearance.Options.UseFont = true;
            this.BtnPrintRemissionGuide.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintRemissionGuide.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintRemissionGuide.ImageOptions.SvgImage")));
            this.BtnPrintRemissionGuide.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintRemissionGuide.Location = new System.Drawing.Point(536, 704);
            this.BtnPrintRemissionGuide.Name = "BtnPrintRemissionGuide";
            this.BtnPrintRemissionGuide.Size = new System.Drawing.Size(160, 50);
            this.BtnPrintRemissionGuide.TabIndex = 255;
            this.BtnPrintRemissionGuide.Text = "Imp. Guia";
            this.BtnPrintRemissionGuide.Click += new System.EventHandler(this.BtnPrintRemissionGuide_Click);
            // 
            // ChkMyGuides
            // 
            this.ChkMyGuides.Location = new System.Drawing.Point(344, 20);
            this.ChkMyGuides.Name = "ChkMyGuides";
            this.ChkMyGuides.Properties.Caption = "Mis Guias";
            this.ChkMyGuides.Size = new System.Drawing.Size(164, 28);
            this.ChkMyGuides.TabIndex = 256;
            // 
            // CmbTransportDriver
            // 
            this.CmbTransportDriver.Location = new System.Drawing.Point(689, 23);
            this.CmbTransportDriver.Name = "CmbTransportDriver";
            this.CmbTransportDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTransportDriver.Size = new System.Drawing.Size(291, 30);
            this.CmbTransportDriver.TabIndex = 258;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(587, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 257;
            this.label2.Text = "Conductor";
            // 
            // FrmRemissionGuide
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.CmbTransportDriver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkMyGuides);
            this.Controls.Add(this.BtnPrintRemissionGuide);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNewOrder);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrcSalesOrder);
            this.Controls.Add(this.GrcRemissionGuide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRemissionGuide";
            this.Text = "FrmRemissionGuide";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRemissionGuide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcRemissionGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvRemissionGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkMyGuides.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportDriver.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrcRemissionGuide;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvRemissionGuide;
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private DevExpress.XtraGrid.GridControl GrcSalesOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton BtnModify;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnNewOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SimpleButton BtnPrintRemissionGuide;
        private DevExpress.XtraEditors.CheckEdit ChkMyGuides;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbTransportDriver;
        private System.Windows.Forms.Label label2;
    }
}