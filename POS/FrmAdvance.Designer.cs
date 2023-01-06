
namespace POS
{
    partial class FrmAdvance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdvance));
            this.label1 = new System.Windows.Forms.Label();
            this.GrcAdvanceHistory = new DevExpress.XtraGrid.GridControl();
            this.GrvAdvanceHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.LblTotalAdvance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnPrintHistoricAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPrintLastAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.LblBarcode = new System.Windows.Forms.Label();
            this.BtnRefreshAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAdvancePayment = new DevExpress.XtraEditors.SimpleButton();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblTitleTotal = new System.Windows.Forms.Label();
            this.BtnNewAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancelAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.LblTitleCustomerName = new System.Windows.Forms.Label();
            this.BtnKeypadAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrcAdvanceHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvAdvanceHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(614, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 22);
            this.label1.TabIndex = 177;
            this.label1.Text = "Anticipos Realizados";
            // 
            // GrcAdvanceHistory
            // 
            this.GrcAdvanceHistory.Location = new System.Drawing.Point(618, 67);
            this.GrcAdvanceHistory.MainView = this.GrvAdvanceHistory;
            this.GrcAdvanceHistory.Name = "GrcAdvanceHistory";
            this.GrcAdvanceHistory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1});
            this.GrcAdvanceHistory.Size = new System.Drawing.Size(564, 573);
            this.GrcAdvanceHistory.TabIndex = 174;
            this.GrcAdvanceHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvAdvanceHistory});
            // 
            // GrvAdvanceHistory
            // 
            this.GrvAdvanceHistory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvAdvanceHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2});
            this.GrvAdvanceHistory.GridControl = this.GrcAdvanceHistory;
            this.GrvAdvanceHistory.Name = "GrvAdvanceHistory";
            this.GrvAdvanceHistory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvanceHistory.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvanceHistory.OptionsBehavior.ReadOnly = true;
            this.GrvAdvanceHistory.OptionsCustomization.AllowColumnMoving = false;
            this.GrvAdvanceHistory.OptionsCustomization.AllowColumnResizing = false;
            this.GrvAdvanceHistory.OptionsCustomization.AllowFilter = false;
            this.GrvAdvanceHistory.OptionsCustomization.AllowGroup = false;
            this.GrvAdvanceHistory.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvanceHistory.OptionsCustomization.AllowSort = false;
            this.GrvAdvanceHistory.OptionsView.RowAutoHeight = true;
            this.GrvAdvanceHistory.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "IsSelected";
            this.gridColumn1.MaxWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "AdvanceDate";
            this.gridColumn3.MaxWidth = 160;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 160;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Monto";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "AdvanceAmount";
            this.gridColumn4.MaxWidth = 100;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSize = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Establecimiento";
            this.gridColumn2.FieldName = "EstablishmentName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // LblTotalAdvance
            // 
            this.LblTotalAdvance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTotalAdvance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblTotalAdvance.Location = new System.Drawing.Point(1074, 664);
            this.LblTotalAdvance.Name = "LblTotalAdvance";
            this.LblTotalAdvance.Size = new System.Drawing.Size(108, 22);
            this.LblTotalAdvance.TabIndex = 183;
            this.LblTotalAdvance.Text = "0.00";
            this.LblTotalAdvance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(981, 664);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 185;
            this.label4.Text = "Total  $  ";
            // 
            // BtnPrintHistoricAdvance
            // 
            this.BtnPrintHistoricAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintHistoricAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintHistoricAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnPrintHistoricAdvance.Appearance.Options.UseBackColor = true;
            this.BtnPrintHistoricAdvance.Appearance.Options.UseFont = true;
            this.BtnPrintHistoricAdvance.Appearance.Options.UseForeColor = true;
            this.BtnPrintHistoricAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintHistoricAdvance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintHistoricAdvance.ImageOptions.SvgImage")));
            this.BtnPrintHistoricAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintHistoricAdvance.Location = new System.Drawing.Point(1192, 127);
            this.BtnPrintHistoricAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnPrintHistoricAdvance.Name = "BtnPrintHistoricAdvance";
            this.BtnPrintHistoricAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnPrintHistoricAdvance.TabIndex = 180;
            this.BtnPrintHistoricAdvance.Text = "Historico \r\nAnticipos";
            this.BtnPrintHistoricAdvance.Click += new System.EventHandler(this.BtnPrintHistoricAdvance_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.Appearance.Options.UseForeColor = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancel.ImageOptions.SvgImage")));
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(1192, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 181;
            this.BtnCancel.Text = "Salir";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnPrintLastAdvance
            // 
            this.BtnPrintLastAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintLastAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintLastAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnPrintLastAdvance.Appearance.Options.UseBackColor = true;
            this.BtnPrintLastAdvance.Appearance.Options.UseFont = true;
            this.BtnPrintLastAdvance.Appearance.Options.UseForeColor = true;
            this.BtnPrintLastAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintLastAdvance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintLastAdvance.ImageOptions.SvgImage")));
            this.BtnPrintLastAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintLastAdvance.Location = new System.Drawing.Point(184, 704);
            this.BtnPrintLastAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnPrintLastAdvance.Name = "BtnPrintLastAdvance";
            this.BtnPrintLastAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnPrintLastAdvance.TabIndex = 186;
            this.BtnPrintLastAdvance.Text = "Ultimo \r\nAnticipo";
            this.BtnPrintLastAdvance.Click += new System.EventHandler(this.BtnPrintLastAdvance_Click);
            // 
            // LblBarcode
            // 
            this.LblBarcode.AutoSize = true;
            this.LblBarcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblBarcode.Location = new System.Drawing.Point(40, 29);
            this.LblBarcode.Name = "LblBarcode";
            this.LblBarcode.Size = new System.Drawing.Size(147, 22);
            this.LblBarcode.TabIndex = 188;
            this.LblBarcode.Text = "Monto Anticipo";
            // 
            // BtnRefreshAdvance
            // 
            this.BtnRefreshAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRefreshAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRefreshAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnRefreshAdvance.Appearance.Options.UseBackColor = true;
            this.BtnRefreshAdvance.Appearance.Options.UseFont = true;
            this.BtnRefreshAdvance.Appearance.Options.UseForeColor = true;
            this.BtnRefreshAdvance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefreshAdvance.ImageOptions.Image")));
            this.BtnRefreshAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRefreshAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRefreshAdvance.Location = new System.Drawing.Point(1192, 67);
            this.BtnRefreshAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefreshAdvance.Name = "BtnRefreshAdvance";
            this.BtnRefreshAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnRefreshAdvance.TabIndex = 186;
            this.BtnRefreshAdvance.Text = "Actualizar";
            this.BtnRefreshAdvance.Click += new System.EventHandler(this.BtnRefreshAdvance_Click);
            // 
            // BtnAdvancePayment
            // 
            this.BtnAdvancePayment.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAdvancePayment.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnAdvancePayment.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnAdvancePayment.Appearance.Options.UseBackColor = true;
            this.BtnAdvancePayment.Appearance.Options.UseFont = true;
            this.BtnAdvancePayment.Appearance.Options.UseForeColor = true;
            this.BtnAdvancePayment.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAdvancePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAdvancePayment.ImageOptions.SvgImage")));
            this.BtnAdvancePayment.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.BtnAdvancePayment.Location = new System.Drawing.Point(44, 279);
            this.BtnAdvancePayment.Name = "BtnAdvancePayment";
            this.BtnAdvancePayment.Size = new System.Drawing.Size(160, 50);
            this.BtnAdvancePayment.TabIndex = 201;
            this.BtnAdvancePayment.Text = "Pagos";
            this.BtnAdvancePayment.Click += new System.EventHandler(this.BtnAdvancePayment_Click);
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.LblTotal.Location = new System.Drawing.Point(204, 212);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(143, 34);
            this.LblTotal.TabIndex = 203;
            this.LblTotal.Text = "00.00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleTotal
            // 
            this.LblTitleTotal.AutoSize = true;
            this.LblTitleTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.LblTitleTotal.Location = new System.Drawing.Point(38, 212);
            this.LblTitleTotal.Name = "LblTitleTotal";
            this.LblTitleTotal.Size = new System.Drawing.Size(124, 34);
            this.LblTitleTotal.TabIndex = 202;
            this.LblTitleTotal.Text = "Total: $";
            // 
            // BtnNewAdvance
            // 
            this.BtnNewAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNewAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnNewAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnNewAdvance.Appearance.Options.UseBackColor = true;
            this.BtnNewAdvance.Appearance.Options.UseFont = true;
            this.BtnNewAdvance.Appearance.Options.UseForeColor = true;
            this.BtnNewAdvance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewAdvance.ImageOptions.Image")));
            this.BtnNewAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnNewAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnNewAdvance.Location = new System.Drawing.Point(14, 704);
            this.BtnNewAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNewAdvance.Name = "BtnNewAdvance";
            this.BtnNewAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnNewAdvance.TabIndex = 186;
            this.BtnNewAdvance.Text = "Nuevo\r\nAnticipo";
            this.BtnNewAdvance.Click += new System.EventHandler(this.BtnNewAdvance_Click);
            // 
            // BtnCancelAdvance
            // 
            this.BtnCancelAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancelAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancelAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCancelAdvance.Appearance.Options.UseBackColor = true;
            this.BtnCancelAdvance.Appearance.Options.UseFont = true;
            this.BtnCancelAdvance.Appearance.Options.UseForeColor = true;
            this.BtnCancelAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancelAdvance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancelAdvance.ImageOptions.SvgImage")));
            this.BtnCancelAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancelAdvance.Location = new System.Drawing.Point(1192, 187);
            this.BtnCancelAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancelAdvance.Name = "BtnCancelAdvance";
            this.BtnCancelAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnCancelAdvance.TabIndex = 205;
            this.BtnCancelAdvance.Text = "Anulacion";
            this.BtnCancelAdvance.Click += new System.EventHandler(this.BtnCancelAdvance_Click);
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblCustomerName.Location = new System.Drawing.Point(181, 67);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(431, 18);
            this.LblCustomerName.TabIndex = 207;
            // 
            // LblTitleCustomerName
            // 
            this.LblTitleCustomerName.AutoSize = true;
            this.LblTitleCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleCustomerName.Location = new System.Drawing.Point(41, 67);
            this.LblTitleCustomerName.Name = "LblTitleCustomerName";
            this.LblTitleCustomerName.Size = new System.Drawing.Size(69, 18);
            this.LblTitleCustomerName.TabIndex = 206;
            this.LblTitleCustomerName.Text = "Cliente:";
            // 
            // BtnKeypadAdvance
            // 
            this.BtnKeypadAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadAdvance.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnKeypadAdvance.Appearance.Options.UseBackColor = true;
            this.BtnKeypadAdvance.Appearance.Options.UseFont = true;
            this.BtnKeypadAdvance.Appearance.Options.UseForeColor = true;
            this.BtnKeypadAdvance.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadAdvance.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadAdvance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadAdvance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadAdvance.ImageOptions.SvgImage")));
            this.BtnKeypadAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadAdvance.Location = new System.Drawing.Point(356, 208);
            this.BtnKeypadAdvance.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadAdvance.Name = "BtnKeypadAdvance";
            this.BtnKeypadAdvance.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadAdvance.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadAdvance.TabIndex = 208;
            this.BtnKeypadAdvance.Click += new System.EventHandler(this.BtnKeypadAdvance_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(44, 130);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Anticipo"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Bono")});
            this.radioGroup1.Size = new System.Drawing.Size(392, 57);
            this.radioGroup1.TabIndex = 209;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(41, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 206;
            this.label2.Text = "Tipo";
            // 
            // FrmAdvance
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.BtnKeypadAdvance);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitleCustomerName);
            this.Controls.Add(this.BtnCancelAdvance);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.LblTitleTotal);
            this.Controls.Add(this.BtnAdvancePayment);
            this.Controls.Add(this.LblBarcode);
            this.Controls.Add(this.BtnRefreshAdvance);
            this.Controls.Add(this.BtnNewAdvance);
            this.Controls.Add(this.BtnPrintLastAdvance);
            this.Controls.Add(this.LblTotalAdvance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnPrintHistoricAdvance);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GrcAdvanceHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdvance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcAdvanceHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvAdvanceHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GrcAdvanceHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvAdvanceHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label LblTotalAdvance;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton BtnPrintHistoricAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnPrintLastAdvance;
        private System.Windows.Forms.Label LblBarcode;
        private DevExpress.XtraEditors.SimpleButton BtnRefreshAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnAdvancePayment;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblTitleTotal;
        private DevExpress.XtraEditors.SimpleButton BtnNewAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnCancelAdvance;
        private System.Windows.Forms.Label LblCustomerName;
        private System.Windows.Forms.Label LblTitleCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadAdvance;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.Label label2;
    }
}