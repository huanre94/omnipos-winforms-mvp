namespace POS
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.GrcPayment = new DevExpress.XtraGrid.GridControl();
            this.GrvPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnCash = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCreditCard = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.BtnInternalCredit = new DevExpress.XtraEditors.SimpleButton();
            this.LblPaid = new System.Windows.Forms.Label();
            this.LblTitlePaid = new System.Windows.Forms.Label();
            this.LblPending = new System.Windows.Forms.Label();
            this.LblTitlePending = new System.Windows.Forms.Label();
            this.BtnGiftcard = new DevExpress.XtraEditors.SimpleButton();
            this.BtnWithhold = new DevExpress.XtraEditors.SimpleButton();
            this.LblChange = new System.Windows.Forms.Label();
            this.LblTitleChange = new System.Windows.Forms.Label();
            this.BtnAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.GrcInvoicePaymentDetail = new DevExpress.XtraGrid.GridControl();
            this.GrvInvoicePaymentDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.GrbKeyboard = new System.Windows.Forms.GroupBox();
            this.TxtAmount = new DevExpress.XtraEditors.TextEdit();
            this.BtnDot = new DevExpress.XtraEditors.SimpleButton();
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
            this.Btn0 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcInvoicePaymentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvInvoicePaymentDetail)).BeginInit();
            this.GrbKeyboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancel.ImageOptions.SvgImage")));
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(1057, 853);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(196, 62);
            this.BtnCancel.TabIndex = 149;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrcPayment
            // 
            this.GrcPayment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.GrcPayment.Location = new System.Drawing.Point(877, 61);
            this.GrcPayment.MainView = this.GrvPayment;
            this.GrcPayment.Margin = new System.Windows.Forms.Padding(4);
            this.GrcPayment.Name = "GrcPayment";
            this.GrcPayment.Size = new System.Drawing.Size(376, 608);
            this.GrcPayment.TabIndex = 150;
            this.GrcPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPayment});
            // 
            // GrvPayment
            // 
            this.GrvPayment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Description,
            this.Amount});
            this.GrvPayment.DetailHeight = 437;
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
            this.Description.MaxWidth = 196;
            this.Description.MinWidth = 24;
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowEdit = false;
            this.Description.OptionsColumn.AllowSize = false;
            this.Description.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Description.OptionsColumn.FixedWidth = true;
            this.Description.OptionsColumn.ReadOnly = true;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 0;
            this.Description.Width = 196;
            // 
            // Amount
            // 
            this.Amount.AppearanceHeader.Options.UseTextOptions = true;
            this.Amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Amount.Caption = "Monto";
            this.Amount.DisplayFormat.FormatString = "c2";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.MaxWidth = 122;
            this.Amount.MinWidth = 24;
            this.Amount.Name = "Amount";
            this.Amount.OptionsColumn.AllowEdit = false;
            this.Amount.OptionsColumn.AllowSize = false;
            this.Amount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Amount.OptionsColumn.FixedWidth = true;
            this.Amount.OptionsColumn.ReadOnly = true;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 1;
            this.Amount.Width = 122;
            // 
            // BtnCash
            // 
            this.BtnCash.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCash.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCash.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCash.Appearance.Options.UseBackColor = true;
            this.BtnCash.Appearance.Options.UseFont = true;
            this.BtnCash.Appearance.Options.UseForeColor = true;
            this.BtnCash.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnCash.ImageOptions.SvgImage = global::POS.Properties.Resources.cash;
            this.BtnCash.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnCash.Location = new System.Drawing.Point(455, 15);
            this.BtnCash.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCash.Name = "BtnCash";
            this.BtnCash.Size = new System.Drawing.Size(125, 125);
            this.BtnCash.TabIndex = 151;
            this.BtnCash.Text = "&Efectivo";
            this.BtnCash.Click += new System.EventHandler(this.BtnCash_Click);
            // 
            // BtnCreditCard
            // 
            this.BtnCreditCard.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCreditCard.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCreditCard.Appearance.Options.UseBackColor = true;
            this.BtnCreditCard.Appearance.Options.UseFont = true;
            this.BtnCreditCard.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnCreditCard.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnCreditCard.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCreditCard.ImageOptions.SvgImage")));
            this.BtnCreditCard.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.BtnCreditCard.ImageOptions.SvgImageSize = new System.Drawing.Size(75, 75);
            this.BtnCreditCard.Location = new System.Drawing.Point(592, 15);
            this.BtnCreditCard.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCreditCard.Name = "BtnCreditCard";
            this.BtnCreditCard.Size = new System.Drawing.Size(125, 125);
            this.BtnCreditCard.TabIndex = 152;
            this.BtnCreditCard.Text = "&Tarjeta";
            this.BtnCreditCard.Click += new System.EventHandler(this.BtnCreditCard_Click);
            // 
            // BtnCheck
            // 
            this.BtnCheck.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCheck.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCheck.Appearance.Options.UseBackColor = true;
            this.BtnCheck.Appearance.Options.UseFont = true;
            this.BtnCheck.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnCheck.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnCheck.ImageOptions.SvgImage = global::POS.Properties.Resources.bankCheck;
            this.BtnCheck.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.BtnCheck.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnCheck.Location = new System.Drawing.Point(729, 15);
            this.BtnCheck.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(125, 125);
            this.BtnCheck.TabIndex = 153;
            this.BtnCheck.Text = "&Cheque";
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // BtnInternalCredit
            // 
            this.BtnInternalCredit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnInternalCredit.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnInternalCredit.Appearance.Options.UseBackColor = true;
            this.BtnInternalCredit.Appearance.Options.UseFont = true;
            this.BtnInternalCredit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnInternalCredit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnInternalCredit.ImageOptions.SvgImage = global::POS.Properties.Resources.internCredit;
            this.BtnInternalCredit.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.BtnInternalCredit.Location = new System.Drawing.Point(455, 152);
            this.BtnInternalCredit.Margin = new System.Windows.Forms.Padding(6);
            this.BtnInternalCredit.Name = "BtnInternalCredit";
            this.BtnInternalCredit.Size = new System.Drawing.Size(125, 125);
            this.BtnInternalCredit.TabIndex = 154;
            this.BtnInternalCredit.Text = "Cré&dito";
            this.BtnInternalCredit.Click += new System.EventHandler(this.BtnInternalCredit_Click);
            // 
            // LblPaid
            // 
            this.LblPaid.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblPaid.Location = new System.Drawing.Point(1150, 722);
            this.LblPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPaid.Name = "LblPaid";
            this.LblPaid.Size = new System.Drawing.Size(103, 28);
            this.LblPaid.TabIndex = 156;
            this.LblPaid.Text = "0.00";
            this.LblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitlePaid
            // 
            this.LblTitlePaid.AutoSize = true;
            this.LblTitlePaid.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTitlePaid.Location = new System.Drawing.Point(1018, 722);
            this.LblTitlePaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitlePaid.Name = "LblTitlePaid";
            this.LblTitlePaid.Size = new System.Drawing.Size(128, 28);
            this.LblTitlePaid.TabIndex = 155;
            this.LblTitlePaid.Text = "Pagado: $";
            // 
            // LblPending
            // 
            this.LblPending.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblPending.Location = new System.Drawing.Point(1150, 760);
            this.LblPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPending.Name = "LblPending";
            this.LblPending.Size = new System.Drawing.Size(103, 28);
            this.LblPending.TabIndex = 158;
            this.LblPending.Text = "0.00";
            this.LblPending.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitlePending
            // 
            this.LblTitlePending.AutoSize = true;
            this.LblTitlePending.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTitlePending.Location = new System.Drawing.Point(991, 760);
            this.LblTitlePending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitlePending.Name = "LblTitlePending";
            this.LblTitlePending.Size = new System.Drawing.Size(156, 28);
            this.LblTitlePending.TabIndex = 157;
            this.LblTitlePending.Text = "Pendiente: $";
            // 
            // BtnGiftcard
            // 
            this.BtnGiftcard.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnGiftcard.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnGiftcard.Appearance.Options.UseBackColor = true;
            this.BtnGiftcard.Appearance.Options.UseFont = true;
            this.BtnGiftcard.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnGiftcard.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnGiftcard.ImageOptions.SvgImage = global::POS.Properties.Resources.giftcard;
            this.BtnGiftcard.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.BtnGiftcard.ImageOptions.SvgImageSize = new System.Drawing.Size(55, 35);
            this.BtnGiftcard.Location = new System.Drawing.Point(729, 152);
            this.BtnGiftcard.Margin = new System.Windows.Forms.Padding(6);
            this.BtnGiftcard.Name = "BtnGiftcard";
            this.BtnGiftcard.Size = new System.Drawing.Size(125, 125);
            this.BtnGiftcard.TabIndex = 163;
            this.BtnGiftcard.Text = "&Bono ";
            this.BtnGiftcard.Click += new System.EventHandler(this.BtnGiftcard_Click);
            // 
            // BtnWithhold
            // 
            this.BtnWithhold.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnWithhold.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnWithhold.Appearance.Options.UseBackColor = true;
            this.BtnWithhold.Appearance.Options.UseFont = true;
            this.BtnWithhold.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnWithhold.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnWithhold.ImageOptions.SvgImage = global::POS.Properties.Resources.retention;
            this.BtnWithhold.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.BtnWithhold.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.BtnWithhold.Location = new System.Drawing.Point(592, 152);
            this.BtnWithhold.Margin = new System.Windows.Forms.Padding(6);
            this.BtnWithhold.Name = "BtnWithhold";
            this.BtnWithhold.Size = new System.Drawing.Size(125, 125);
            this.BtnWithhold.TabIndex = 164;
            this.BtnWithhold.Text = "&Retención";
            this.BtnWithhold.Click += new System.EventHandler(this.BtnWithhold_Click);
            // 
            // LblChange
            // 
            this.LblChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblChange.Location = new System.Drawing.Point(1150, 800);
            this.LblChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblChange.Name = "LblChange";
            this.LblChange.Size = new System.Drawing.Size(103, 28);
            this.LblChange.TabIndex = 166;
            this.LblChange.Text = "0.00";
            this.LblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblChange.Visible = false;
            // 
            // LblTitleChange
            // 
            this.LblTitleChange.AutoSize = true;
            this.LblTitleChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblTitleChange.Location = new System.Drawing.Point(1018, 797);
            this.LblTitleChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitleChange.Name = "LblTitleChange";
            this.LblTitleChange.Size = new System.Drawing.Size(129, 28);
            this.LblTitleChange.TabIndex = 165;
            this.LblTitleChange.Text = "Cambio: $";
            this.LblTitleChange.Visible = false;
            // 
            // BtnAdvance
            // 
            this.BtnAdvance.AllowFocus = false;
            this.BtnAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAdvance.Appearance.Options.UseBackColor = true;
            this.BtnAdvance.Appearance.Options.UseFont = true;
            this.BtnAdvance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdvance.ImageOptions.Image")));
            this.BtnAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnAdvance.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnAdvance.Location = new System.Drawing.Point(455, 287);
            this.BtnAdvance.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAdvance.Name = "BtnAdvance";
            this.BtnAdvance.Size = new System.Drawing.Size(125, 125);
            this.BtnAdvance.TabIndex = 168;
            this.BtnAdvance.Text = "&Anticipos";
            this.BtnAdvance.Click += new System.EventHandler(this.BtnAdvance_Click);
            // 
            // BtnReturn
            // 
            this.BtnReturn.AllowFocus = false;
            this.BtnReturn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnReturn.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnReturn.Appearance.Options.UseBackColor = true;
            this.BtnReturn.Appearance.Options.UseFont = true;
            this.BtnReturn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnReturn.ImageOptions.Image")));
            this.BtnReturn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnReturn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnReturn.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnReturn.Location = new System.Drawing.Point(592, 287);
            this.BtnReturn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(125, 125);
            this.BtnReturn.TabIndex = 168;
            this.BtnReturn.Text = "&Nota \r\nCredito";
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 28);
            this.label1.TabIndex = 155;
            this.label1.Text = "Desglose Valores:";
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.AllowFocus = false;
            this.BtnTransfer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnTransfer.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnTransfer.Appearance.Options.UseBackColor = true;
            this.BtnTransfer.Appearance.Options.UseFont = true;
            this.BtnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnTransfer.ImageOptions.Image")));
            this.BtnTransfer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnTransfer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnTransfer.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnTransfer.Location = new System.Drawing.Point(729, 287);
            this.BtnTransfer.Margin = new System.Windows.Forms.Padding(4);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(125, 125);
            this.BtnTransfer.TabIndex = 168;
            this.BtnTransfer.Text = "Trans&f.\r\nBancaria";
            this.BtnTransfer.Visible = false;
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // GrcInvoicePaymentDetail
            // 
            this.GrcInvoicePaymentDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.GrcInvoicePaymentDetail.Location = new System.Drawing.Point(19, 61);
            this.GrcInvoicePaymentDetail.MainView = this.GrvInvoicePaymentDetail;
            this.GrcInvoicePaymentDetail.Margin = new System.Windows.Forms.Padding(4);
            this.GrcInvoicePaymentDetail.Name = "GrcInvoicePaymentDetail";
            this.GrcInvoicePaymentDetail.Size = new System.Drawing.Size(406, 608);
            this.GrcInvoicePaymentDetail.TabIndex = 169;
            this.GrcInvoicePaymentDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvInvoicePaymentDetail});
            // 
            // GrvInvoicePaymentDetail
            // 
            this.GrvInvoicePaymentDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvInvoicePaymentDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.GrvInvoicePaymentDetail.DetailHeight = 437;
            this.GrvInvoicePaymentDetail.GridControl = this.GrcInvoicePaymentDetail;
            this.GrvInvoicePaymentDetail.Name = "GrvInvoicePaymentDetail";
            this.GrvInvoicePaymentDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvInvoicePaymentDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvInvoicePaymentDetail.OptionsBehavior.ReadOnly = true;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowColumnMoving = false;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowColumnResizing = false;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowFilter = false;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowGroup = false;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvInvoicePaymentDetail.OptionsCustomization.AllowSort = false;
            this.GrvInvoicePaymentDetail.OptionsView.RowAutoHeight = true;
            this.GrvInvoicePaymentDetail.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Descripción";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.MaxWidth = 250;
            this.gridColumn1.MinWidth = 24;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 196;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Monto";
            this.gridColumn2.DisplayFormat.FormatString = "c2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "Amount";
            this.gridColumn2.MaxWidth = 122;
            this.gridColumn2.MinWidth = 24;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.label2.Location = new System.Drawing.Point(872, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 28);
            this.label2.TabIndex = 155;
            this.label2.Text = "Desglose Pagos:";
            // 
            // GrbKeyboard
            // 
            this.GrbKeyboard.Controls.Add(this.TxtAmount);
            this.GrbKeyboard.Controls.Add(this.BtnDot);
            this.GrbKeyboard.Controls.Add(this.Btn9);
            this.GrbKeyboard.Controls.Add(this.Btn8);
            this.GrbKeyboard.Controls.Add(this.Btn7);
            this.GrbKeyboard.Controls.Add(this.Btn6);
            this.GrbKeyboard.Controls.Add(this.Btn5);
            this.GrbKeyboard.Controls.Add(this.Btn1);
            this.GrbKeyboard.Controls.Add(this.Btn4);
            this.GrbKeyboard.Controls.Add(this.Btn2);
            this.GrbKeyboard.Controls.Add(this.BtnDelete);
            this.GrbKeyboard.Controls.Add(this.Btn3);
            this.GrbKeyboard.Controls.Add(this.Btn0);
            this.GrbKeyboard.Location = new System.Drawing.Point(455, 419);
            this.GrbKeyboard.Name = "GrbKeyboard";
            this.GrbKeyboard.Size = new System.Drawing.Size(399, 489);
            this.GrbKeyboard.TabIndex = 184;
            this.GrbKeyboard.TabStop = false;
            // 
            // TxtAmount
            // 
            this.TxtAmount.EditValue = "";
            this.TxtAmount.Location = new System.Drawing.Point(50, 42);
            this.TxtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtAmount.Properties.Appearance.Options.UseFont = true;
            this.TxtAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.TxtAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TxtAmount.Properties.DisplayFormat.FormatString = "c2";
            this.TxtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtAmount.Properties.EditFormat.FormatString = "c2";
            this.TxtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtAmount.Size = new System.Drawing.Size(194, 34);
            this.TxtAmount.TabIndex = 184;
            // 
            // BtnDot
            // 
            this.BtnDot.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDot.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.BtnDot.Appearance.Options.UseBackColor = true;
            this.BtnDot.Appearance.Options.UseFont = true;
            this.BtnDot.Location = new System.Drawing.Point(257, 381);
            this.BtnDot.Margin = new System.Windows.Forms.Padding(6);
            this.BtnDot.Name = "BtnDot";
            this.BtnDot.Size = new System.Drawing.Size(93, 81);
            this.BtnDot.TabIndex = 196;
            this.BtnDot.Text = ".";
            this.BtnDot.Click += new System.EventHandler(this.BtnDot_Click);
            // 
            // Btn9
            // 
            this.Btn9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn9.Appearance.Options.UseBackColor = true;
            this.Btn9.Appearance.Options.UseFont = true;
            this.Btn9.Location = new System.Drawing.Point(258, 101);
            this.Btn9.Margin = new System.Windows.Forms.Padding(10);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(92, 81);
            this.Btn9.TabIndex = 195;
            this.Btn9.Text = "9";
            this.Btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // Btn8
            // 
            this.Btn8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn8.Appearance.Options.UseBackColor = true;
            this.Btn8.Appearance.Options.UseFont = true;
            this.Btn8.Location = new System.Drawing.Point(153, 101);
            this.Btn8.Margin = new System.Windows.Forms.Padding(10);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(92, 81);
            this.Btn8.TabIndex = 194;
            this.Btn8.Text = "8";
            this.Btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // Btn7
            // 
            this.Btn7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn7.Appearance.Options.UseBackColor = true;
            this.Btn7.Appearance.Options.UseFont = true;
            this.Btn7.Location = new System.Drawing.Point(50, 101);
            this.Btn7.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(92, 81);
            this.Btn7.TabIndex = 193;
            this.Btn7.Text = "7";
            this.Btn7.Click += new System.EventHandler(this.Btn7_Click);
            // 
            // Btn6
            // 
            this.Btn6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn6.Appearance.Options.UseBackColor = true;
            this.Btn6.Appearance.Options.UseFont = true;
            this.Btn6.Location = new System.Drawing.Point(258, 196);
            this.Btn6.Margin = new System.Windows.Forms.Padding(10);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(92, 81);
            this.Btn6.TabIndex = 192;
            this.Btn6.Text = "6";
            this.Btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // Btn5
            // 
            this.Btn5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn5.Appearance.Options.UseBackColor = true;
            this.Btn5.Appearance.Options.UseFont = true;
            this.Btn5.Location = new System.Drawing.Point(153, 196);
            this.Btn5.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(92, 81);
            this.Btn5.TabIndex = 191;
            this.Btn5.Text = "5";
            this.Btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // Btn1
            // 
            this.Btn1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn1.Appearance.Options.UseBackColor = true;
            this.Btn1.Appearance.Options.UseFont = true;
            this.Btn1.Location = new System.Drawing.Point(50, 288);
            this.Btn1.Margin = new System.Windows.Forms.Padding(5);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(92, 81);
            this.Btn1.TabIndex = 187;
            this.Btn1.Text = "1";
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn4
            // 
            this.Btn4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn4.Appearance.Options.UseBackColor = true;
            this.Btn4.Appearance.Options.UseFont = true;
            this.Btn4.Location = new System.Drawing.Point(50, 196);
            this.Btn4.Margin = new System.Windows.Forms.Padding(6);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(92, 81);
            this.Btn4.TabIndex = 190;
            this.Btn4.Text = "4";
            this.Btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // Btn2
            // 
            this.Btn2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn2.Appearance.Options.UseBackColor = true;
            this.Btn2.Appearance.Options.UseFont = true;
            this.Btn2.Location = new System.Drawing.Point(153, 288);
            this.Btn2.Margin = new System.Windows.Forms.Padding(6);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(92, 81);
            this.Btn2.TabIndex = 188;
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
            this.BtnDelete.Location = new System.Drawing.Point(258, 31);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(92, 56);
            this.BtnDelete.TabIndex = 185;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Btn3
            // 
            this.Btn3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn3.Appearance.Options.UseBackColor = true;
            this.Btn3.Appearance.Options.UseFont = true;
            this.Btn3.Location = new System.Drawing.Point(258, 288);
            this.Btn3.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(92, 81);
            this.Btn3.TabIndex = 189;
            this.Btn3.Text = "3";
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // Btn0
            // 
            this.Btn0.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn0.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn0.Appearance.Options.UseBackColor = true;
            this.Btn0.Appearance.Options.UseFont = true;
            this.Btn0.Location = new System.Drawing.Point(50, 381);
            this.Btn0.Margin = new System.Windows.Forms.Padding(6);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(194, 81);
            this.Btn0.TabIndex = 186;
            this.Btn0.Text = "0";
            this.Btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(1278, 930);
            this.ControlBox = false;
            this.Controls.Add(this.GrcInvoicePaymentDetail);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.BtnTransfer);
            this.Controls.Add(this.BtnAdvance);
            this.Controls.Add(this.LblChange);
            this.Controls.Add(this.LblTitleChange);
            this.Controls.Add(this.BtnWithhold);
            this.Controls.Add(this.BtnGiftcard);
            this.Controls.Add(this.LblPending);
            this.Controls.Add(this.LblTitlePending);
            this.Controls.Add(this.LblPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTitlePaid);
            this.Controls.Add(this.BtnInternalCredit);
            this.Controls.Add(this.BtnCheck);
            this.Controls.Add(this.BtnCreditCard);
            this.Controls.Add(this.BtnCash);
            this.Controls.Add(this.GrcPayment);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrbKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcInvoicePaymentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvInvoicePaymentDetail)).EndInit();
            this.GrbKeyboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraGrid.GridControl GrcPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPayment;
        private DevExpress.XtraEditors.SimpleButton BtnCash;
        private DevExpress.XtraEditors.SimpleButton BtnCreditCard;
        private DevExpress.XtraEditors.SimpleButton BtnCheck;
        private DevExpress.XtraEditors.SimpleButton BtnInternalCredit;
        private System.Windows.Forms.Label LblPaid;
        private System.Windows.Forms.Label LblTitlePaid;
        private System.Windows.Forms.Label LblPending;
        private System.Windows.Forms.Label LblTitlePending;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraEditors.SimpleButton BtnGiftcard;
        private DevExpress.XtraEditors.SimpleButton BtnWithhold;
        private System.Windows.Forms.Label LblChange;
        private System.Windows.Forms.Label LblTitleChange;
        private DevExpress.XtraEditors.SimpleButton BtnAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnReturn;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnTransfer;
        private DevExpress.XtraGrid.GridControl GrcInvoicePaymentDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvInvoicePaymentDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrbKeyboard;
        public DevExpress.XtraEditors.TextEdit TxtAmount;
        private DevExpress.XtraEditors.SimpleButton BtnDot;
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
        private DevExpress.XtraEditors.SimpleButton Btn0;
    }
}