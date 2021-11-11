
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
            this.GrcAdvance = new DevExpress.XtraGrid.GridControl();
            this.GrvAdvance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LblTotalCashier = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPrintHistoricAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPrintLastAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.Btn9 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn8 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn7 = new DevExpress.XtraEditors.SimpleButton();
            this.LblBarcode = new System.Windows.Forms.Label();
            this.Btn6 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn4 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.Btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefreshAdvances = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPayment = new DevExpress.XtraEditors.SimpleButton();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblTitleTotal = new System.Windows.Forms.Label();
            this.GrcPayment = new DevExpress.XtraGrid.GridControl();
            this.GrvPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnNewAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrcAdvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvAdvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(682, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 22);
            this.label1.TabIndex = 177;
            this.label1.Text = "Anticipos Realizados";
            // 
            // GrcAdvance
            // 
            this.GrcAdvance.Location = new System.Drawing.Point(686, 67);
            this.GrcAdvance.MainView = this.GrvAdvance;
            this.GrcAdvance.Name = "GrcAdvance";
            this.GrcAdvance.Size = new System.Drawing.Size(496, 573);
            this.GrcAdvance.TabIndex = 174;
            this.GrcAdvance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvAdvance});
            // 
            // GrvAdvance
            // 
            this.GrvAdvance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvAdvance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.GrvAdvance.GridControl = this.GrcAdvance;
            this.GrvAdvance.Name = "GrvAdvance";
            this.GrvAdvance.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvance.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvance.OptionsBehavior.ReadOnly = true;
            this.GrvAdvance.OptionsCustomization.AllowColumnMoving = false;
            this.GrvAdvance.OptionsCustomization.AllowColumnResizing = false;
            this.GrvAdvance.OptionsCustomization.AllowFilter = false;
            this.GrvAdvance.OptionsCustomization.AllowGroup = false;
            this.GrvAdvance.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvAdvance.OptionsCustomization.AllowSort = false;
            this.GrvAdvance.OptionsView.RowAutoHeight = true;
            this.GrvAdvance.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Fecha Hora";
            this.gridColumn3.FieldName = "ClosingCashierHour";
            this.gridColumn3.MaxWidth = 160;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 160;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Monto";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "CashierAmount";
            this.gridColumn4.MaxWidth = 100;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSize = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 100;
            // 
            // LblTotalCashier
            // 
            this.LblTotalCashier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTotalCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblTotalCashier.Location = new System.Drawing.Point(1074, 664);
            this.LblTotalCashier.Name = "LblTotalCashier";
            this.LblTotalCashier.Size = new System.Drawing.Size(108, 22);
            this.LblTotalCashier.TabIndex = 183;
            this.LblTotalCashier.Text = "0.00";
            this.LblTotalCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // BtnAccept
            // 
            this.BtnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAccept.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAccept.Appearance.Options.UseBackColor = true;
            this.BtnAccept.Appearance.Options.UseFont = true;
            this.BtnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAccept.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAccept.ImageOptions.SvgImage = global::POS.Properties.Resources.accept2;
            this.BtnAccept.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAccept.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnAccept.Location = new System.Drawing.Point(1192, 704);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 179;
            this.BtnAccept.Text = "Aceptar";
            // 
            // BtnPrintHistoricAdvance
            // 
            this.BtnPrintHistoricAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintHistoricAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintHistoricAdvance.Appearance.Options.UseBackColor = true;
            this.BtnPrintHistoricAdvance.Appearance.Options.UseFont = true;
            this.BtnPrintHistoricAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintHistoricAdvance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintHistoricAdvance.ImageOptions.SvgImage")));
            this.BtnPrintHistoricAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintHistoricAdvance.Location = new System.Drawing.Point(1192, 127);
            this.BtnPrintHistoricAdvance.Margin = new System.Windows.Forms.Padding(5);
            this.BtnPrintHistoricAdvance.Name = "BtnPrintHistoricAdvance";
            this.BtnPrintHistoricAdvance.Size = new System.Drawing.Size(160, 50);
            this.BtnPrintHistoricAdvance.TabIndex = 180;
            this.BtnPrintHistoricAdvance.Text = "Historico \r\nAnticipos";
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
            this.BtnCancel.Location = new System.Drawing.Point(1022, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 181;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnPrintLastAdvance
            // 
            this.BtnPrintLastAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintLastAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintLastAdvance.Appearance.Options.UseBackColor = true;
            this.BtnPrintLastAdvance.Appearance.Options.UseFont = true;
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
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(44, 131);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtBarcode.Properties.Appearance.Options.UseFont = true;
            this.TxtBarcode.Size = new System.Drawing.Size(245, 44);
            this.TxtBarcode.TabIndex = 187;
            // 
            // Btn9
            // 
            this.Btn9.AllowFocus = false;
            this.Btn9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn9.Appearance.Options.UseBackColor = true;
            this.Btn9.Appearance.Options.UseFont = true;
            this.Btn9.Location = new System.Drawing.Point(214, 184);
            this.Btn9.Margin = new System.Windows.Forms.Padding(8);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(75, 65);
            this.Btn9.TabIndex = 200;
            this.Btn9.Text = "9";
            this.Btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // Btn8
            // 
            this.Btn8.AllowFocus = false;
            this.Btn8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn8.Appearance.Options.UseBackColor = true;
            this.Btn8.Appearance.Options.UseFont = true;
            this.Btn8.Location = new System.Drawing.Point(128, 184);
            this.Btn8.Margin = new System.Windows.Forms.Padding(8);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(75, 65);
            this.Btn8.TabIndex = 199;
            this.Btn8.Text = "8";
            this.Btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // Btn7
            // 
            this.Btn7.AllowFocus = false;
            this.Btn7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn7.Appearance.Options.UseBackColor = true;
            this.Btn7.Appearance.Options.UseFont = true;
            this.Btn7.Location = new System.Drawing.Point(44, 184);
            this.Btn7.Margin = new System.Windows.Forms.Padding(6);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(75, 65);
            this.Btn7.TabIndex = 198;
            this.Btn7.Text = "7";
            this.Btn7.Click += new System.EventHandler(this.Btn7_Click);
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
            // Btn6
            // 
            this.Btn6.AllowFocus = false;
            this.Btn6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn6.Appearance.Options.UseBackColor = true;
            this.Btn6.Appearance.Options.UseFont = true;
            this.Btn6.Location = new System.Drawing.Point(214, 260);
            this.Btn6.Margin = new System.Windows.Forms.Padding(8);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(75, 65);
            this.Btn6.TabIndex = 197;
            this.Btn6.Text = "6";
            this.Btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // Btn5
            // 
            this.Btn5.AllowFocus = false;
            this.Btn5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn5.Appearance.Options.UseBackColor = true;
            this.Btn5.Appearance.Options.UseFont = true;
            this.Btn5.Location = new System.Drawing.Point(128, 260);
            this.Btn5.Margin = new System.Windows.Forms.Padding(6);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(75, 65);
            this.Btn5.TabIndex = 196;
            this.Btn5.Text = "5";
            this.Btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // Btn1
            // 
            this.Btn1.AllowFocus = false;
            this.Btn1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn1.Appearance.Options.UseBackColor = true;
            this.Btn1.Appearance.Options.UseFont = true;
            this.Btn1.Location = new System.Drawing.Point(44, 334);
            this.Btn1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 65);
            this.Btn1.TabIndex = 192;
            this.Btn1.Text = "1";
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn4
            // 
            this.Btn4.AllowFocus = false;
            this.Btn4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn4.Appearance.Options.UseBackColor = true;
            this.Btn4.Appearance.Options.UseFont = true;
            this.Btn4.Location = new System.Drawing.Point(44, 260);
            this.Btn4.Margin = new System.Windows.Forms.Padding(5);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(75, 65);
            this.Btn4.TabIndex = 195;
            this.Btn4.Text = "4";
            this.Btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // Btn2
            // 
            this.Btn2.AllowFocus = false;
            this.Btn2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn2.Appearance.Options.UseBackColor = true;
            this.Btn2.Appearance.Options.UseFont = true;
            this.Btn2.Location = new System.Drawing.Point(128, 334);
            this.Btn2.Margin = new System.Windows.Forms.Padding(5);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(75, 65);
            this.Btn2.TabIndex = 193;
            this.Btn2.Text = "2";
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.AllowFocus = false;
            this.BtnDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnDelete.Appearance.Options.UseBackColor = true;
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnDelete.ImageOptions.SvgImage")));
            this.BtnDelete.Location = new System.Drawing.Point(44, 484);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(159, 45);
            this.BtnDelete.TabIndex = 190;
            this.BtnDelete.Text = "Borrar";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Btn3
            // 
            this.Btn3.AllowFocus = false;
            this.Btn3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn3.Appearance.Options.UseBackColor = true;
            this.Btn3.Appearance.Options.UseFont = true;
            this.Btn3.Location = new System.Drawing.Point(214, 334);
            this.Btn3.Margin = new System.Windows.Forms.Padding(6);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(75, 65);
            this.Btn3.TabIndex = 194;
            this.Btn3.Text = "3";
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.AllowFocus = false;
            this.BtnEnter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnEnter.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnEnter.Appearance.Options.UseBackColor = true;
            this.BtnEnter.Appearance.Options.UseFont = true;
            this.BtnEnter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnEnter.ImageOptions.SvgImage")));
            this.BtnEnter.Location = new System.Drawing.Point(215, 408);
            this.BtnEnter.Margin = new System.Windows.Forms.Padding(6);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(75, 121);
            this.BtnEnter.TabIndex = 189;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // Btn0
            // 
            this.Btn0.AllowFocus = false;
            this.Btn0.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn0.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn0.Appearance.Options.UseBackColor = true;
            this.Btn0.Appearance.Options.UseFont = true;
            this.Btn0.Location = new System.Drawing.Point(44, 408);
            this.Btn0.Margin = new System.Windows.Forms.Padding(5);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(159, 65);
            this.Btn0.TabIndex = 191;
            this.Btn0.Text = "0";
            this.Btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // BtnRefreshAdvances
            // 
            this.BtnRefreshAdvances.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRefreshAdvances.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRefreshAdvances.Appearance.Options.UseBackColor = true;
            this.BtnRefreshAdvances.Appearance.Options.UseFont = true;
            this.BtnRefreshAdvances.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefreshAdvances.ImageOptions.Image")));
            this.BtnRefreshAdvances.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRefreshAdvances.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRefreshAdvances.Location = new System.Drawing.Point(1192, 67);
            this.BtnRefreshAdvances.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefreshAdvances.Name = "BtnRefreshAdvances";
            this.BtnRefreshAdvances.Size = new System.Drawing.Size(160, 50);
            this.BtnRefreshAdvances.TabIndex = 186;
            this.BtnRefreshAdvances.Text = "Actualizar";
            // 
            // BtnPayment
            // 
            this.BtnPayment.AllowFocus = false;
            this.BtnPayment.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPayment.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnPayment.Appearance.Options.UseBackColor = true;
            this.BtnPayment.Appearance.Options.UseFont = true;
            this.BtnPayment.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPayment.ImageOptions.SvgImage")));
            this.BtnPayment.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.BtnPayment.Location = new System.Drawing.Point(399, 59);
            this.BtnPayment.Name = "BtnPayment";
            this.BtnPayment.Size = new System.Drawing.Size(160, 50);
            this.BtnPayment.TabIndex = 201;
            this.BtnPayment.Text = "Pagos";
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.LblTotal.Location = new System.Drawing.Point(168, 67);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(122, 34);
            this.LblTotal.TabIndex = 203;
            this.LblTotal.Text = "00.00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleTotal
            // 
            this.LblTitleTotal.AutoSize = true;
            this.LblTitleTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.LblTitleTotal.Location = new System.Drawing.Point(38, 67);
            this.LblTitleTotal.Name = "LblTitleTotal";
            this.LblTitleTotal.Size = new System.Drawing.Size(124, 34);
            this.LblTitleTotal.TabIndex = 202;
            this.LblTitleTotal.Text = "Total: $";
            // 
            // GrcPayment
            // 
            this.GrcPayment.Location = new System.Drawing.Point(331, 125);
            this.GrcPayment.MainView = this.GrvPayment;
            this.GrcPayment.Name = "GrcPayment";
            this.GrcPayment.Size = new System.Drawing.Size(294, 429);
            this.GrcPayment.TabIndex = 204;
            this.GrcPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPayment});
            // 
            // GrvPayment
            // 
            this.GrvPayment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Description,
            this.Amount});
            this.GrvPayment.GridControl = this.GrcPayment;
            this.GrvPayment.Name = "GrvPayment";
            this.GrvPayment.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPayment.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPayment.OptionsBehavior.ReadOnly = true;
            this.GrvPayment.OptionsCustomization.AllowColumnMoving = false;
            this.GrvPayment.OptionsCustomization.AllowColumnResizing = false;
            this.GrvPayment.OptionsCustomization.AllowFilter = false;
            this.GrvPayment.OptionsCustomization.AllowGroup = false;
            this.GrvPayment.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPayment.OptionsCustomization.AllowSort = false;
            this.GrvPayment.OptionsView.RowAutoHeight = true;
            this.GrvPayment.OptionsView.ShowGroupPanel = false;
            // 
            // Description
            // 
            this.Description.AppearanceHeader.Options.UseTextOptions = true;
            this.Description.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Description.Caption = "Descripción";
            this.Description.FieldName = "Description";
            this.Description.MaxWidth = 160;
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowEdit = false;
            this.Description.OptionsColumn.AllowSize = false;
            this.Description.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Description.OptionsColumn.FixedWidth = true;
            this.Description.OptionsColumn.ReadOnly = true;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 0;
            this.Description.Width = 160;
            // 
            // Amount
            // 
            this.Amount.AppearanceHeader.Options.UseTextOptions = true;
            this.Amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Amount.Caption = "Monto";
            this.Amount.DisplayFormat.FormatString = "c2";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.MaxWidth = 100;
            this.Amount.Name = "Amount";
            this.Amount.OptionsColumn.AllowEdit = false;
            this.Amount.OptionsColumn.AllowSize = false;
            this.Amount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Amount.OptionsColumn.FixedWidth = true;
            this.Amount.OptionsColumn.ReadOnly = true;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 1;
            this.Amount.Width = 100;
            // 
            // BtnNewAdvance
            // 
            this.BtnNewAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNewAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnNewAdvance.Appearance.Options.UseBackColor = true;
            this.BtnNewAdvance.Appearance.Options.UseFont = true;
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
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.simpleButton1.Location = new System.Drawing.Point(1192, 187);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(160, 50);
            this.simpleButton1.TabIndex = 205;
            this.simpleButton1.Text = "Anulacion";
            // 
            // FrmAdvance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.GrcPayment);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.LblTitleTotal);
            this.Controls.Add(this.BtnPayment);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.LblBarcode);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.Btn0);
            this.Controls.Add(this.BtnRefreshAdvances);
            this.Controls.Add(this.BtnNewAdvance);
            this.Controls.Add(this.BtnPrintLastAdvance);
            this.Controls.Add(this.LblTotalCashier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnPrintHistoricAdvance);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GrcAdvance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdvance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcAdvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvAdvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GrcAdvance;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvAdvance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label LblTotalCashier;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnPrintHistoricAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnPrintLastAdvance;
        private DevExpress.XtraEditors.TextEdit TxtBarcode;
        private DevExpress.XtraEditors.SimpleButton Btn9;
        private DevExpress.XtraEditors.SimpleButton Btn8;
        private DevExpress.XtraEditors.SimpleButton Btn7;
        private System.Windows.Forms.Label LblBarcode;
        private DevExpress.XtraEditors.SimpleButton Btn6;
        private DevExpress.XtraEditors.SimpleButton Btn5;
        private DevExpress.XtraEditors.SimpleButton Btn1;
        private DevExpress.XtraEditors.SimpleButton Btn4;
        private DevExpress.XtraEditors.SimpleButton Btn2;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton Btn3;
        private DevExpress.XtraEditors.SimpleButton BtnEnter;
        private DevExpress.XtraEditors.SimpleButton Btn0;
        private DevExpress.XtraEditors.SimpleButton BtnRefreshAdvances;
        private DevExpress.XtraEditors.SimpleButton BtnPayment;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblTitleTotal;
        private DevExpress.XtraGrid.GridControl GrcPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPayment;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraEditors.SimpleButton BtnNewAdvance;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}