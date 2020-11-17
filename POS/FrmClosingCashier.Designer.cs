namespace POS
{
    partial class FrmClosingCashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClosingCashier));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Btn9 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn8 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn7 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn6 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn4 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.Btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.GrcPayment = new DevExpress.XtraGrid.GridControl();
            this.GrvPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PaymModeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Caja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrcDenomination = new DevExpress.XtraGrid.GridControl();
            this.GrvDenomination = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DenominationTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Monto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymModeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.GrcPartialClosing = new DevExpress.XtraGrid.GridControl();
            this.GrvPartialClosing = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.LblBarcode = new System.Windows.Forms.Label();
            this.BtnLastClosing = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTotalCashier = new System.Windows.Forms.Label();
            this.LblDifference = new System.Windows.Forms.Label();
            this.BtnDot = new DevExpress.XtraEditors.SimpleButton();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcDenomination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvDenomination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPartialClosing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPartialClosing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "gridColumn7";
            this.gridColumn7.FieldName = "PaymModeId";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // Amount
            // 
            this.Amount.AppearanceHeader.Options.UseTextOptions = true;
            this.Amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Amount.Caption = "Sistema";
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
            this.Amount.OptionsFilter.AllowFilter = false;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 1;
            this.Amount.Width = 100;
            // 
            // Amount2
            // 
            this.Amount2.AppearanceHeader.Options.UseTextOptions = true;
            this.Amount2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Amount2.Caption = "#";
            this.Amount2.DisplayFormat.FormatString = "n0";
            this.Amount2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount2.FieldName = "TypedAmount";
            this.Amount2.MaxWidth = 100;
            this.Amount2.Name = "Amount2";
            this.Amount2.OptionsColumn.AllowEdit = false;
            this.Amount2.OptionsColumn.AllowSize = false;
            this.Amount2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Amount2.OptionsColumn.FixedWidth = true;
            this.Amount2.OptionsColumn.ReadOnly = true;
            this.Amount2.OptionsFilter.AllowFilter = false;
            this.Amount2.Visible = true;
            this.Amount2.VisibleIndex = 2;
            this.Amount2.Width = 93;
            // 
            // Btn9
            // 
            this.Btn9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn9.Appearance.Options.UseBackColor = true;
            this.Btn9.Appearance.Options.UseFont = true;
            this.Btn9.Location = new System.Drawing.Point(209, 386);
            this.Btn9.Margin = new System.Windows.Forms.Padding(8);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(75, 65);
            this.Btn9.TabIndex = 144;
            this.Btn9.Text = "9";
            this.Btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // Btn8
            // 
            this.Btn8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn8.Appearance.Options.UseBackColor = true;
            this.Btn8.Appearance.Options.UseFont = true;
            this.Btn8.Location = new System.Drawing.Point(123, 386);
            this.Btn8.Margin = new System.Windows.Forms.Padding(8);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(75, 65);
            this.Btn8.TabIndex = 143;
            this.Btn8.Text = "8";
            this.Btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // Btn7
            // 
            this.Btn7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn7.Appearance.Options.UseBackColor = true;
            this.Btn7.Appearance.Options.UseFont = true;
            this.Btn7.Location = new System.Drawing.Point(39, 386);
            this.Btn7.Margin = new System.Windows.Forms.Padding(6);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(75, 65);
            this.Btn7.TabIndex = 142;
            this.Btn7.Text = "7";
            this.Btn7.Click += new System.EventHandler(this.Btn7_Click);
            // 
            // Btn6
            // 
            this.Btn6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn6.Appearance.Options.UseBackColor = true;
            this.Btn6.Appearance.Options.UseFont = true;
            this.Btn6.Location = new System.Drawing.Point(209, 462);
            this.Btn6.Margin = new System.Windows.Forms.Padding(8);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(75, 65);
            this.Btn6.TabIndex = 141;
            this.Btn6.Text = "6";
            this.Btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // Btn5
            // 
            this.Btn5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn5.Appearance.Options.UseBackColor = true;
            this.Btn5.Appearance.Options.UseFont = true;
            this.Btn5.Location = new System.Drawing.Point(123, 462);
            this.Btn5.Margin = new System.Windows.Forms.Padding(6);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(75, 65);
            this.Btn5.TabIndex = 140;
            this.Btn5.Text = "5";
            this.Btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // Btn1
            // 
            this.Btn1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn1.Appearance.Options.UseBackColor = true;
            this.Btn1.Appearance.Options.UseFont = true;
            this.Btn1.Location = new System.Drawing.Point(39, 536);
            this.Btn1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 65);
            this.Btn1.TabIndex = 136;
            this.Btn1.Text = "1";
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn4
            // 
            this.Btn4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn4.Appearance.Options.UseBackColor = true;
            this.Btn4.Appearance.Options.UseFont = true;
            this.Btn4.Location = new System.Drawing.Point(39, 462);
            this.Btn4.Margin = new System.Windows.Forms.Padding(5);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(75, 65);
            this.Btn4.TabIndex = 139;
            this.Btn4.Text = "4";
            this.Btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // Btn2
            // 
            this.Btn2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn2.Appearance.Options.UseBackColor = true;
            this.Btn2.Appearance.Options.UseFont = true;
            this.Btn2.Location = new System.Drawing.Point(123, 535);
            this.Btn2.Margin = new System.Windows.Forms.Padding(5);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(75, 65);
            this.Btn2.TabIndex = 137;
            this.Btn2.Text = "2";
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnDelete.Appearance.Options.UseBackColor = true;
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnDelete.ImageOptions.SvgImage")));
            this.BtnDelete.Location = new System.Drawing.Point(209, 332);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(76, 45);
            this.BtnDelete.TabIndex = 134;
            this.BtnDelete.Text = "Borrar";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Btn3
            // 
            this.Btn3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn3.Appearance.Options.UseBackColor = true;
            this.Btn3.Appearance.Options.UseFont = true;
            this.Btn3.Location = new System.Drawing.Point(209, 536);
            this.Btn3.Margin = new System.Windows.Forms.Padding(6);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(75, 65);
            this.Btn3.TabIndex = 138;
            this.Btn3.Text = "3";
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnEnter.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnEnter.Appearance.Options.UseBackColor = true;
            this.BtnEnter.Appearance.Options.UseFont = true;
            this.BtnEnter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEnter.ImageOptions.Image")));
            this.BtnEnter.Location = new System.Drawing.Point(298, 332);
            this.BtnEnter.Margin = new System.Windows.Forms.Padding(6);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(75, 345);
            this.BtnEnter.TabIndex = 133;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // Btn0
            // 
            this.Btn0.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn0.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn0.Appearance.Options.UseBackColor = true;
            this.Btn0.Appearance.Options.UseFont = true;
            this.Btn0.Location = new System.Drawing.Point(39, 612);
            this.Btn0.Margin = new System.Windows.Forms.Padding(5);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(159, 65);
            this.Btn0.TabIndex = 135;
            this.Btn0.Text = "0";
            this.Btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // GrcPayment
            // 
            this.GrcPayment.Location = new System.Drawing.Point(911, 61);
            this.GrcPayment.MainView = this.GrvPayment;
            this.GrcPayment.Name = "GrcPayment";
            this.GrcPayment.Size = new System.Drawing.Size(426, 540);
            this.GrcPayment.TabIndex = 151;
            this.GrcPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPayment});
            // 
            // GrvPayment
            // 
            this.GrvPayment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.PaymModeName,
            this.Amount,
            this.Caja});
            gridFormatRule1.Column = this.gridColumn7;
            gridFormatRule1.ColumnApplyTo = this.Amount;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[PaymModeId] = 8";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.GrvPayment.FormatRules.Add(gridFormatRule1);
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
            this.GrvPayment.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrvPayment_RowClick);
            // 
            // PaymModeName
            // 
            this.PaymModeName.AppearanceHeader.Options.UseTextOptions = true;
            this.PaymModeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PaymModeName.Caption = "Forma";
            this.PaymModeName.FieldName = "PaymModeName";
            this.PaymModeName.MaxWidth = 160;
            this.PaymModeName.Name = "PaymModeName";
            this.PaymModeName.OptionsColumn.AllowEdit = false;
            this.PaymModeName.OptionsColumn.AllowSize = false;
            this.PaymModeName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.PaymModeName.OptionsColumn.FixedWidth = true;
            this.PaymModeName.OptionsColumn.ReadOnly = true;
            this.PaymModeName.Visible = true;
            this.PaymModeName.VisibleIndex = 0;
            this.PaymModeName.Width = 160;
            // 
            // Caja
            // 
            this.Caja.AppearanceHeader.Options.UseTextOptions = true;
            this.Caja.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Caja.Caption = "Caja";
            this.Caja.DisplayFormat.FormatString = "c2";
            this.Caja.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Caja.FieldName = "CashierAmount";
            this.Caja.Name = "Caja";
            this.Caja.OptionsColumn.AllowEdit = false;
            this.Caja.UnboundExpression = "0";
            this.Caja.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.Caja.Visible = true;
            this.Caja.VisibleIndex = 2;
            // 
            // GrcDenomination
            // 
            this.GrcDenomination.Location = new System.Drawing.Point(398, 61);
            this.GrcDenomination.MainView = this.GrvDenomination;
            this.GrcDenomination.Name = "GrcDenomination";
            this.GrcDenomination.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.GrcDenomination.Size = new System.Drawing.Size(498, 616);
            this.GrcDenomination.TabIndex = 151;
            this.GrcDenomination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvDenomination});
            // 
            // GrvDenomination
            // 
            this.GrvDenomination.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvDenomination.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DenominationTypeName,
            this.gridColumn1,
            this.Amount2,
            this.Monto,
            this.PaymModeId});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.Amount2;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[TypedAmount] <> 0";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.GrvDenomination.FormatRules.Add(gridFormatRule2);
            this.GrvDenomination.GridControl = this.GrcDenomination;
            this.GrvDenomination.Name = "GrvDenomination";
            this.GrvDenomination.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvDenomination.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvDenomination.OptionsBehavior.ReadOnly = true;
            this.GrvDenomination.OptionsCustomization.AllowColumnMoving = false;
            this.GrvDenomination.OptionsCustomization.AllowColumnResizing = false;
            this.GrvDenomination.OptionsCustomization.AllowFilter = false;
            this.GrvDenomination.OptionsCustomization.AllowGroup = false;
            this.GrvDenomination.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvDenomination.OptionsCustomization.AllowSort = false;
            this.GrvDenomination.OptionsView.RowAutoHeight = true;
            this.GrvDenomination.OptionsView.ShowGroupPanel = false;
            this.GrvDenomination.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrvDenomination_RowClick);
            // 
            // DenominationTypeName
            // 
            this.DenominationTypeName.AppearanceHeader.Options.UseTextOptions = true;
            this.DenominationTypeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DenominationTypeName.Caption = "Tipo";
            this.DenominationTypeName.FieldName = "DenominationTypeName";
            this.DenominationTypeName.Name = "DenominationTypeName";
            this.DenominationTypeName.OptionsColumn.AllowEdit = false;
            this.DenominationTypeName.OptionsFilter.AllowFilter = false;
            this.DenominationTypeName.Visible = true;
            this.DenominationTypeName.VisibleIndex = 0;
            this.DenominationTypeName.Width = 356;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Denominacion";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Value";
            this.gridColumn1.MaxWidth = 160;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 118;
            // 
            // Monto
            // 
            this.Monto.AppearanceHeader.Options.UseTextOptions = true;
            this.Monto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Monto.Caption = "Monto";
            this.Monto.DisplayFormat.FormatString = "c2";
            this.Monto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Monto.FieldName = "TotalAmount";
            this.Monto.Name = "Monto";
            this.Monto.OptionsColumn.AllowEdit = false;
            this.Monto.OptionsFilter.AllowFilter = false;
            this.Monto.Visible = true;
            this.Monto.VisibleIndex = 3;
            this.Monto.Width = 558;
            // 
            // PaymModeId
            // 
            this.PaymModeId.Caption = "gridColumn8";
            this.PaymModeId.FieldName = "PaymModeId";
            this.PaymModeId.Name = "PaymModeId";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
            this.BtnAccept.Location = new System.Drawing.Point(1177, 704);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 155;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(1007, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 156;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrcPartialClosing
            // 
            this.GrcPartialClosing.Location = new System.Drawing.Point(26, 61);
            this.GrcPartialClosing.MainView = this.GrvPartialClosing;
            this.GrcPartialClosing.Name = "GrcPartialClosing";
            this.GrcPartialClosing.Size = new System.Drawing.Size(357, 202);
            this.GrcPartialClosing.TabIndex = 157;
            this.GrcPartialClosing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPartialClosing});
            // 
            // GrvPartialClosing
            // 
            this.GrvPartialClosing.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvPartialClosing.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.GrvPartialClosing.GridControl = this.GrcPartialClosing;
            this.GrvPartialClosing.Name = "GrvPartialClosing";
            this.GrvPartialClosing.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPartialClosing.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPartialClosing.OptionsBehavior.ReadOnly = true;
            this.GrvPartialClosing.OptionsCustomization.AllowColumnMoving = false;
            this.GrvPartialClosing.OptionsCustomization.AllowColumnResizing = false;
            this.GrvPartialClosing.OptionsCustomization.AllowFilter = false;
            this.GrvPartialClosing.OptionsCustomization.AllowGroup = false;
            this.GrvPartialClosing.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvPartialClosing.OptionsCustomization.AllowSort = false;
            this.GrvPartialClosing.OptionsView.RowAutoHeight = true;
            this.GrvPartialClosing.OptionsView.ShowGroupPanel = false;
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
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(39, 333);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtBarcode.Properties.Appearance.Options.UseFont = true;
            this.TxtBarcode.Size = new System.Drawing.Size(159, 44);
            this.TxtBarcode.TabIndex = 158;
            // 
            // LblBarcode
            // 
            this.LblBarcode.AutoSize = true;
            this.LblBarcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblBarcode.Location = new System.Drawing.Point(39, 308);
            this.LblBarcode.Name = "LblBarcode";
            this.LblBarcode.Size = new System.Drawing.Size(58, 22);
            this.LblBarcode.TabIndex = 159;
            this.LblBarcode.Text = "Valor";
            // 
            // BtnLastClosing
            // 
            this.BtnLastClosing.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnLastClosing.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnLastClosing.Appearance.Options.UseBackColor = true;
            this.BtnLastClosing.Appearance.Options.UseFont = true;
            this.BtnLastClosing.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnLastClosing.ImageOptions.SvgImage = global::POS.Properties.Resources.printer;
            this.BtnLastClosing.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnLastClosing.Location = new System.Drawing.Point(772, 704);
            this.BtnLastClosing.Margin = new System.Windows.Forms.Padding(5);
            this.BtnLastClosing.Name = "BtnLastClosing";
            this.BtnLastClosing.Size = new System.Drawing.Size(225, 50);
            this.BtnLastClosing.TabIndex = 156;
            this.BtnLastClosing.Text = "Ult Cierre";
            this.BtnLastClosing.Click += new System.EventHandler(this.BtnLastClosing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 160;
            this.label1.Text = "Cierres Parciales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label2.Location = new System.Drawing.Point(407, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 160;
            this.label2.Text = "Denominaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label3.Location = new System.Drawing.Point(907, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 22);
            this.label3.TabIndex = 160;
            this.label3.Text = "Formas de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label4.Location = new System.Drawing.Point(1106, 655);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 22);
            this.label4.TabIndex = 159;
            this.label4.Text = "Total            $  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.label5.Location = new System.Drawing.Point(1106, 623);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 159;
            this.label5.Text = "Diferencia   $";
            // 
            // LblTotalCashier
            // 
            this.LblTotalCashier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTotalCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblTotalCashier.Location = new System.Drawing.Point(1229, 655);
            this.LblTotalCashier.Name = "LblTotalCashier";
            this.LblTotalCashier.Size = new System.Drawing.Size(108, 22);
            this.LblTotalCashier.TabIndex = 159;
            this.LblTotalCashier.Text = "0.00";
            this.LblTotalCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblDifference
            // 
            this.LblDifference.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblDifference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblDifference.Location = new System.Drawing.Point(1231, 623);
            this.LblDifference.Name = "LblDifference";
            this.LblDifference.Size = new System.Drawing.Size(106, 22);
            this.LblDifference.TabIndex = 159;
            this.LblDifference.Text = "0.00";
            this.LblDifference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnDot
            // 
            this.BtnDot.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDot.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.BtnDot.Appearance.Options.UseBackColor = true;
            this.BtnDot.Appearance.Options.UseFont = true;
            this.BtnDot.Location = new System.Drawing.Point(208, 612);
            this.BtnDot.Margin = new System.Windows.Forms.Padding(5);
            this.BtnDot.Name = "BtnDot";
            this.BtnDot.Size = new System.Drawing.Size(76, 65);
            this.BtnDot.TabIndex = 161;
            this.BtnDot.Text = ".";
            this.BtnDot.Click += new System.EventHandler(this.BtnDot_Click);
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(614, 204);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(192, 192);
            this.AxOPOSScanner.TabIndex = 162;
            // 
            // FrmClosingCashier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.BtnDot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.LblDifference);
            this.Controls.Add(this.LblTotalCashier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblBarcode);
            this.Controls.Add(this.GrcPartialClosing);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnLastClosing);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrcDenomination);
            this.Controls.Add(this.GrcPayment);
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.Btn0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmClosingCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmClosingCashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcDenomination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvDenomination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPartialClosing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPartialClosing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Btn9;
        private DevExpress.XtraEditors.SimpleButton Btn8;
        private DevExpress.XtraEditors.SimpleButton Btn7;
        private DevExpress.XtraEditors.SimpleButton Btn6;
        private DevExpress.XtraEditors.SimpleButton Btn5;
        private DevExpress.XtraEditors.SimpleButton Btn1;
        private DevExpress.XtraEditors.SimpleButton Btn4;
        private DevExpress.XtraEditors.SimpleButton Btn2;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton Btn3;
        private DevExpress.XtraEditors.SimpleButton BtnEnter;
        private DevExpress.XtraEditors.SimpleButton Btn0;
        private DevExpress.XtraGrid.GridControl GrcPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPayment;
        private DevExpress.XtraGrid.Columns.GridColumn PaymModeName;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraGrid.GridControl GrcDenomination;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvDenomination;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Amount2;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraGrid.GridControl GrcPartialClosing;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPartialClosing;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit TxtBarcode;
        private System.Windows.Forms.Label LblBarcode;
        private DevExpress.XtraEditors.SimpleButton BtnLastClosing;
        private DevExpress.XtraGrid.Columns.GridColumn Monto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn Caja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblTotalCashier;
        private System.Windows.Forms.Label LblDifference;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn PaymModeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.SimpleButton BtnDot;
        private DevExpress.XtraGrid.Columns.GridColumn DenominationTypeName;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
    }
}