namespace POS
{
    partial class FrmSalesOrderPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesOrderPicker));
            this.GrcSalesOrder = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SalesOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Identification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Channel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderECommerce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemGuide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnModify = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnNewOrder = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRemissionGuide = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.LblMotive = new System.Windows.Forms.Label();
            this.CmbOrderStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSalesOrderOrigin = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.ETOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.ChkDate = new DevExpress.XtraEditors.CheckButton();
            this.BtnPrintSaleOrder = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOrderStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSalesOrderOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETOrderDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GrcSalesOrder
            // 
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcSalesOrder.Location = new System.Drawing.Point(26, 88);
            this.GrcSalesOrder.MainView = this.GrvSalesOrder;
            this.GrcSalesOrder.Name = "GrcSalesOrder";
            this.GrcSalesOrder.Size = new System.Drawing.Size(1312, 600);
            this.GrcSalesOrder.TabIndex = 139;
            this.GrcSalesOrder.UseEmbeddedNavigator = true;
            this.GrcSalesOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesOrder});
            this.GrcSalesOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrcSalesOrder_KeyDown);
            this.GrcSalesOrder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrcSalesOrder_KeyUp);
            // 
            // GrvSalesOrder
            // 
            this.GrvSalesOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SalesOrderId,
            this.OrderDate,
            this.Identification,
            this.CustomerName,
            this.Status,
            this.Channel,
            this.OrderECommerce,
            this.RemGuide});
            this.GrvSalesOrder.GridControl = this.GrcSalesOrder;
            this.GrvSalesOrder.Name = "GrvSalesOrder";
            this.GrvSalesOrder.OptionsView.ShowGroupPanel = false;
            // 
            // SalesOrderId
            // 
            this.SalesOrderId.AppearanceHeader.Options.UseTextOptions = true;
            this.SalesOrderId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SalesOrderId.Caption = "Orden";
            this.SalesOrderId.FieldName = "SalesOrderId";
            this.SalesOrderId.MaxWidth = 100;
            this.SalesOrderId.Name = "SalesOrderId";
            this.SalesOrderId.OptionsColumn.AllowEdit = false;
            this.SalesOrderId.Visible = true;
            this.SalesOrderId.VisibleIndex = 0;
            this.SalesOrderId.Width = 100;
            // 
            // OrderDate
            // 
            this.OrderDate.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderDate.Caption = "Fecha Orden";
            this.OrderDate.DisplayFormat.FormatString = "g";
            this.OrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.OrderDate.FieldName = "OrderDate";
            this.OrderDate.MaxWidth = 150;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.OptionsColumn.AllowEdit = false;
            this.OrderDate.Visible = true;
            this.OrderDate.VisibleIndex = 1;
            this.OrderDate.Width = 150;
            // 
            // Identification
            // 
            this.Identification.AppearanceHeader.Options.UseTextOptions = true;
            this.Identification.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Identification.Caption = "Identificacion";
            this.Identification.FieldName = "Identification";
            this.Identification.MaxWidth = 150;
            this.Identification.Name = "Identification";
            this.Identification.OptionsColumn.AllowEdit = false;
            this.Identification.OptionsColumn.AllowMove = false;
            this.Identification.OptionsColumn.AllowSize = false;
            this.Identification.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Identification.OptionsColumn.FixedWidth = true;
            this.Identification.OptionsColumn.ReadOnly = true;
            this.Identification.Visible = true;
            this.Identification.VisibleIndex = 2;
            this.Identification.Width = 150;
            // 
            // CustomerName
            // 
            this.CustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.CustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerName.Caption = "Nombre";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.MaxWidth = 250;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OptionsColumn.AllowEdit = false;
            this.CustomerName.OptionsColumn.AllowMove = false;
            this.CustomerName.OptionsColumn.AllowSize = false;
            this.CustomerName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.CustomerName.OptionsColumn.FixedWidth = true;
            this.CustomerName.OptionsColumn.ReadOnly = true;
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 3;
            this.CustomerName.Width = 250;
            // 
            // Status
            // 
            this.Status.AppearanceHeader.Options.UseTextOptions = true;
            this.Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Status.Caption = "Estado";
            this.Status.FieldName = "Status";
            this.Status.MaxWidth = 250;
            this.Status.Name = "Status";
            this.Status.OptionsColumn.AllowEdit = false;
            this.Status.OptionsColumn.AllowMove = false;
            this.Status.OptionsColumn.AllowSize = false;
            this.Status.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Status.OptionsColumn.FixedWidth = true;
            this.Status.OptionsColumn.ReadOnly = true;
            this.Status.Visible = true;
            this.Status.VisibleIndex = 4;
            this.Status.Width = 250;
            // 
            // Channel
            // 
            this.Channel.AppearanceHeader.Options.UseTextOptions = true;
            this.Channel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Channel.Caption = "Canal";
            this.Channel.FieldName = "Channel";
            this.Channel.MaxWidth = 200;
            this.Channel.Name = "Channel";
            this.Channel.OptionsColumn.AllowEdit = false;
            this.Channel.OptionsColumn.AllowMove = false;
            this.Channel.OptionsColumn.AllowSize = false;
            this.Channel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Channel.OptionsColumn.FixedWidth = true;
            this.Channel.OptionsColumn.ReadOnly = true;
            this.Channel.Visible = true;
            this.Channel.VisibleIndex = 5;
            this.Channel.Width = 200;
            // 
            // OrderECommerce
            // 
            this.OrderECommerce.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderECommerce.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderECommerce.Caption = "# E-Com. ";
            this.OrderECommerce.FieldName = "OrderECommerce";
            this.OrderECommerce.MaxWidth = 80;
            this.OrderECommerce.Name = "OrderECommerce";
            this.OrderECommerce.OptionsColumn.AllowEdit = false;
            this.OrderECommerce.OptionsColumn.AllowMove = false;
            this.OrderECommerce.OptionsColumn.AllowSize = false;
            this.OrderECommerce.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.OrderECommerce.OptionsColumn.FixedWidth = true;
            this.OrderECommerce.OptionsColumn.ReadOnly = true;
            this.OrderECommerce.Visible = true;
            this.OrderECommerce.VisibleIndex = 6;
            this.OrderECommerce.Width = 80;
            // 
            // RemGuide
            // 
            this.RemGuide.AppearanceHeader.Options.UseTextOptions = true;
            this.RemGuide.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RemGuide.Caption = "Guia Rem.";
            this.RemGuide.FieldName = "RemGuide";
            this.RemGuide.MaxWidth = 80;
            this.RemGuide.Name = "RemGuide";
            this.RemGuide.OptionsColumn.AllowEdit = false;
            this.RemGuide.Visible = true;
            this.RemGuide.VisibleIndex = 7;
            this.RemGuide.Width = 80;
            // 
            // BtnModify
            // 
            this.BtnModify.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModify.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnModify.Appearance.Options.UseBackColor = true;
            this.BtnModify.Appearance.Options.UseFont = true;
            this.BtnModify.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnModify.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.ImageOptions.Image")));
            this.BtnModify.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnModify.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnModify.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnModify.Location = new System.Drawing.Point(1165, 704);
            this.BtnModify.Margin = new System.Windows.Forms.Padding(5);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(173, 50);
            this.BtnModify.TabIndex = 140;
            this.BtnModify.Text = "F6 Modificar";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancel.ImageOptions.SvgImage")));
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(995, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 141;
            this.BtnCancel.Text = "Salir";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnNewOrder
            // 
            this.BtnNewOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNewOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnNewOrder.Appearance.Options.UseBackColor = true;
            this.BtnNewOrder.Appearance.Options.UseFont = true;
            this.BtnNewOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnNewOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewOrder.ImageOptions.Image")));
            this.BtnNewOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnNewOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnNewOrder.Location = new System.Drawing.Point(478, 704);
            this.BtnNewOrder.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNewOrder.Name = "BtnNewOrder";
            this.BtnNewOrder.Size = new System.Drawing.Size(160, 50);
            this.BtnNewOrder.TabIndex = 141;
            this.BtnNewOrder.Text = "F2 Nuevo \r\nPedido";
            this.BtnNewOrder.Click += new System.EventHandler(this.BtnNewOrder_Click);
            // 
            // BtnRemissionGuide
            // 
            this.BtnRemissionGuide.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRemissionGuide.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRemissionGuide.Appearance.Options.UseBackColor = true;
            this.BtnRemissionGuide.Appearance.Options.UseFont = true;
            this.BtnRemissionGuide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRemissionGuide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRemissionGuide.ImageOptions.Image")));
            this.BtnRemissionGuide.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRemissionGuide.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRemissionGuide.Location = new System.Drawing.Point(26, 704);
            this.BtnRemissionGuide.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRemissionGuide.Name = "BtnRemissionGuide";
            this.BtnRemissionGuide.Size = new System.Drawing.Size(176, 50);
            this.BtnRemissionGuide.TabIndex = 141;
            this.BtnRemissionGuide.Text = "F7 Ver guias";
            this.BtnRemissionGuide.Click += new System.EventHandler(this.BtnRemissionGuide_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRefresh.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.Appearance.Options.UseBackColor = true;
            this.BtnRefresh.Appearance.Options.UseFont = true;
            this.BtnRefresh.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.ImageOptions.Image")));
            this.BtnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRefresh.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRefresh.Location = new System.Drawing.Point(1165, 20);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(173, 50);
            this.BtnRefresh.TabIndex = 140;
            this.BtnRefresh.Text = "F5 Actualizar";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // LblMotive
            // 
            this.LblMotive.AutoSize = true;
            this.LblMotive.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblMotive.Location = new System.Drawing.Point(345, 38);
            this.LblMotive.Name = "LblMotive";
            this.LblMotive.Size = new System.Drawing.Size(78, 23);
            this.LblMotive.TabIndex = 142;
            this.LblMotive.Text = "&Estado";
            // 
            // CmbOrderStatus
            // 
            this.CmbOrderStatus.Location = new System.Drawing.Point(425, 29);
            this.CmbOrderStatus.Name = "CmbOrderStatus";
            this.CmbOrderStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbOrderStatus.Size = new System.Drawing.Size(238, 30);
            this.CmbOrderStatus.TabIndex = 143;
            this.CmbOrderStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbOrderStatus_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 142;
            this.label1.Text = "Fecha";
            // 
            // CmbSalesOrderOrigin
            // 
            this.CmbSalesOrderOrigin.Location = new System.Drawing.Point(758, 29);
            this.CmbSalesOrderOrigin.Name = "CmbSalesOrderOrigin";
            this.CmbSalesOrderOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbSalesOrderOrigin.Size = new System.Drawing.Size(245, 30);
            this.CmbSalesOrderOrigin.TabIndex = 143;
            this.CmbSalesOrderOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSalesOrderOrigin_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(685, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 142;
            this.label2.Text = "&Canal";
            // 
            // ETOrderDate
            // 
            this.ETOrderDate.EditValue = null;
            this.ETOrderDate.Location = new System.Drawing.Point(135, 28);
            this.ETOrderDate.Name = "ETOrderDate";
            this.ETOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ETOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ETOrderDate.Properties.EditFormat.FormatString = "";
            this.ETOrderDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ETOrderDate.Properties.Mask.EditMask = "";
            this.ETOrderDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.ETOrderDate.Size = new System.Drawing.Size(186, 30);
            this.ETOrderDate.TabIndex = 143;
            this.ETOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ETOrderDate_KeyDown);
            // 
            // ChkDate
            // 
            this.ChkDate.AppearancePressed.BackColor = System.Drawing.Color.Lime;
            this.ChkDate.AppearancePressed.Options.UseBackColor = true;
            this.ChkDate.Location = new System.Drawing.Point(26, 30);
            this.ChkDate.Name = "ChkDate";
            this.ChkDate.Size = new System.Drawing.Size(103, 36);
            this.ChkDate.TabIndex = 144;
            this.ChkDate.Text = "&Fecha";
            this.ChkDate.CheckedChanged += new System.EventHandler(this.ChkDate_CheckedChanged);
            // 
            // BtnPrintSaleOrder
            // 
            this.BtnPrintSaleOrder.AllowFocus = false;
            this.BtnPrintSaleOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintSaleOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintSaleOrder.Appearance.Options.UseBackColor = true;
            this.BtnPrintSaleOrder.Appearance.Options.UseFont = true;
            this.BtnPrintSaleOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintSaleOrder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintSaleOrder.ImageOptions.SvgImage")));
            this.BtnPrintSaleOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintSaleOrder.Location = new System.Drawing.Point(646, 704);
            this.BtnPrintSaleOrder.Name = "BtnPrintSaleOrder";
            this.BtnPrintSaleOrder.Size = new System.Drawing.Size(183, 52);
            this.BtnPrintSaleOrder.TabIndex = 152;
            this.BtnPrintSaleOrder.Text = "F3 Ult. Orden";
            this.BtnPrintSaleOrder.Click += new System.EventHandler(this.BtnPrintSaleOrder_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnSearch.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSearch.Appearance.Options.UseBackColor = true;
            this.BtnSearch.Appearance.Options.UseFont = true;
            this.BtnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSearch.ImageOptions.SvgImage")));
            this.BtnSearch.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnSearch.Location = new System.Drawing.Point(1034, 20);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 158;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmSalesOrderPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnPrintSaleOrder);
            this.Controls.Add(this.ChkDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblMotive);
            this.Controls.Add(this.CmbSalesOrderOrigin);
            this.Controls.Add(this.CmbOrderStatus);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnNewOrder);
            this.Controls.Add(this.BtnRemissionGuide);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrcSalesOrder);
            this.Controls.Add(this.ETOrderDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalesOrderPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSalesOrderPicker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSalesOrderPicker_FormClosing);
            this.Load += new System.EventHandler(this.FrmSalesOrderPicker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalesOrderPicker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOrderStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSalesOrderOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETOrderDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrcSalesOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesOrder;
        private DevExpress.XtraGrid.Columns.GridColumn OrderECommerce;
        private DevExpress.XtraGrid.Columns.GridColumn Identification;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn Channel;
        private DevExpress.XtraGrid.Columns.GridColumn SalesOrderId;
        private DevExpress.XtraEditors.SimpleButton BtnModify;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnNewOrder;
        private DevExpress.XtraEditors.SimpleButton BtnRemissionGuide;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
        private System.Windows.Forms.Label LblMotive;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbOrderStatus;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbSalesOrderOrigin;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit ETOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn RemGuide;
        private DevExpress.XtraEditors.CheckButton ChkDate;
        private DevExpress.XtraEditors.SimpleButton BtnPrintSaleOrder;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
    }
}