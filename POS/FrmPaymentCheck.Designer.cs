namespace POS
{
    partial class FrmPaymentCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentCheck));
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.TxtOwnerName = new DevExpress.XtraEditors.TextEdit();
            this.TxtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.TxtAuthorization = new DevExpress.XtraEditors.TextEdit();
            this.TxtCheckDate = new DevExpress.XtraEditors.DateEdit();
            this.LblOwnerName = new System.Windows.Forms.Label();
            this.LblBank = new System.Windows.Forms.Label();
            this.LblCheckDate = new System.Windows.Forms.Label();
            this.LblAccountNumber = new System.Windows.Forms.Label();
            this.TxtCheckNumber = new DevExpress.XtraEditors.TextEdit();
            this.LblCheckNumber = new System.Windows.Forms.Label();
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.BtnKeyboardOwner = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeypadAccount = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeypadCheck = new DevExpress.XtraEditors.SimpleButton();
            this.CmbCheckBank = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.BtnKeypadIdentification = new DevExpress.XtraEditors.SimpleButton();
            this.LblIndentification = new System.Windows.Forms.Label();
            this.TxtIdentification = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeypadPhone = new DevExpress.XtraEditors.SimpleButton();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtPhone = new DevExpress.XtraEditors.TextEdit();
            this.BtnAuthorization = new DevExpress.XtraEditors.SimpleButton();
            this.LblCheckAmount = new System.Windows.Forms.Label();
            this.TxtCheckAmount = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeypadAuth = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwnerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCheckBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdentification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckAmount.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnAccept.Location = new System.Drawing.Point(494, 565);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 49);
            this.BtnAccept.TabIndex = 153;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(324, 565);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 49);
            this.BtnCancel.TabIndex = 152;
            this.BtnCancel.Text = "Cancelar";
            // 
            // TxtOwnerName
            // 
            this.TxtOwnerName.Location = new System.Drawing.Point(175, 12);
            this.TxtOwnerName.Name = "TxtOwnerName";
            this.TxtOwnerName.Size = new System.Drawing.Size(376, 38);
            this.TxtOwnerName.TabIndex = 20;
            // 
            // TxtAccountNumber
            // 
            this.TxtAccountNumber.Location = new System.Drawing.Point(175, 298);
            this.TxtAccountNumber.Name = "TxtAccountNumber";
            this.TxtAccountNumber.Size = new System.Drawing.Size(219, 38);
            this.TxtAccountNumber.TabIndex = 4;
            // 
            // TxtAuthorization
            // 
            this.TxtAuthorization.Enabled = false;
            this.TxtAuthorization.Location = new System.Drawing.Point(175, 469);
            this.TxtAuthorization.Name = "TxtAuthorization";
            this.TxtAuthorization.Size = new System.Drawing.Size(219, 38);
            this.TxtAuthorization.TabIndex = 6;
            // 
            // TxtCheckDate
            // 
            this.TxtCheckDate.EditValue = null;
            this.TxtCheckDate.Location = new System.Drawing.Point(175, 241);
            this.TxtCheckDate.Name = "TxtCheckDate";
            this.TxtCheckDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtCheckDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtCheckDate.Properties.DisplayFormat.FormatString = "";
            this.TxtCheckDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TxtCheckDate.Properties.EditFormat.FormatString = "";
            this.TxtCheckDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TxtCheckDate.Properties.Mask.EditMask = "";
            this.TxtCheckDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.TxtCheckDate.Size = new System.Drawing.Size(300, 38);
            this.TxtCheckDate.TabIndex = 3;
            // 
            // LblOwnerName
            // 
            this.LblOwnerName.AutoSize = true;
            this.LblOwnerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblOwnerName.Location = new System.Drawing.Point(33, 23);
            this.LblOwnerName.Name = "LblOwnerName";
            this.LblOwnerName.Size = new System.Drawing.Size(71, 18);
            this.LblOwnerName.TabIndex = 1;
            this.LblOwnerName.Text = "Nombre";
            // 
            // LblBank
            // 
            this.LblBank.AutoSize = true;
            this.LblBank.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblBank.Location = new System.Drawing.Point(33, 200);
            this.LblBank.Name = "LblBank";
            this.LblBank.Size = new System.Drawing.Size(60, 18);
            this.LblBank.TabIndex = 161;
            this.LblBank.Text = "Banco";
            // 
            // LblCheckDate
            // 
            this.LblCheckDate.AutoSize = true;
            this.LblCheckDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCheckDate.Location = new System.Drawing.Point(33, 252);
            this.LblCheckDate.Name = "LblCheckDate";
            this.LblCheckDate.Size = new System.Drawing.Size(124, 18);
            this.LblCheckDate.TabIndex = 162;
            this.LblCheckDate.Text = "Fecha Cheque";
            // 
            // LblAccountNumber
            // 
            this.LblAccountNumber.AutoSize = true;
            this.LblAccountNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAccountNumber.Location = new System.Drawing.Point(33, 309);
            this.LblAccountNumber.Name = "LblAccountNumber";
            this.LblAccountNumber.Size = new System.Drawing.Size(133, 18);
            this.LblAccountNumber.TabIndex = 163;
            this.LblAccountNumber.Text = "Numero Cuenta";
            // 
            // TxtCheckNumber
            // 
            this.TxtCheckNumber.Location = new System.Drawing.Point(175, 355);
            this.TxtCheckNumber.Name = "TxtCheckNumber";
            this.TxtCheckNumber.Size = new System.Drawing.Size(219, 38);
            this.TxtCheckNumber.TabIndex = 5;
            // 
            // LblCheckNumber
            // 
            this.LblCheckNumber.AutoSize = true;
            this.LblCheckNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCheckNumber.Location = new System.Drawing.Point(33, 366);
            this.LblCheckNumber.Name = "LblCheckNumber";
            this.LblCheckNumber.Size = new System.Drawing.Size(137, 18);
            this.LblCheckNumber.TabIndex = 165;
            this.LblCheckNumber.Text = "Numero Cheque";
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAuthorization.Location = new System.Drawing.Point(33, 480);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(109, 18);
            this.LblAuthorization.TabIndex = 166;
            this.LblAuthorization.Text = "Autorizacion";
            // 
            // BtnKeyboardOwner
            // 
            this.BtnKeyboardOwner.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeyboardOwner.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardOwner.Appearance.Options.UseBackColor = true;
            this.BtnKeyboardOwner.Appearance.Options.UseFont = true;
            this.BtnKeyboardOwner.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardOwner.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardOwner.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardOwner.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardOwner.ImageOptions.SvgImage")));
            this.BtnKeyboardOwner.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardOwner.Location = new System.Drawing.Point(560, 8);
            this.BtnKeyboardOwner.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardOwner.Name = "BtnKeyboardOwner";
            this.BtnKeyboardOwner.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardOwner.Size = new System.Drawing.Size(80, 50);
            this.BtnKeyboardOwner.TabIndex = 167;
            this.BtnKeyboardOwner.Click += new System.EventHandler(this.BtnKeyboardOwner_Click);
            // 
            // BtnKeypadAccount
            // 
            this.BtnKeypadAccount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadAccount.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadAccount.Appearance.Options.UseBackColor = true;
            this.BtnKeypadAccount.Appearance.Options.UseFont = true;
            this.BtnKeypadAccount.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadAccount.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadAccount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadAccount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadAccount.ImageOptions.SvgImage")));
            this.BtnKeypadAccount.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadAccount.Location = new System.Drawing.Point(403, 294);
            this.BtnKeypadAccount.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadAccount.Name = "BtnKeypadAccount";
            this.BtnKeypadAccount.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadAccount.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadAccount.TabIndex = 168;
            this.BtnKeypadAccount.Click += new System.EventHandler(this.BtnKeypadAccount_Click);
            // 
            // BtnKeypadCheck
            // 
            this.BtnKeypadCheck.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadCheck.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadCheck.Appearance.Options.UseBackColor = true;
            this.BtnKeypadCheck.Appearance.Options.UseFont = true;
            this.BtnKeypadCheck.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadCheck.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadCheck.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadCheck.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadCheck.ImageOptions.SvgImage")));
            this.BtnKeypadCheck.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadCheck.Location = new System.Drawing.Point(403, 351);
            this.BtnKeypadCheck.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadCheck.Name = "BtnKeypadCheck";
            this.BtnKeypadCheck.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadCheck.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadCheck.TabIndex = 169;
            this.BtnKeypadCheck.Click += new System.EventHandler(this.BtnKeypadCheck_Click);
            // 
            // CmbCheckBank
            // 
            this.CmbCheckBank.Location = new System.Drawing.Point(175, 184);
            this.CmbCheckBank.Name = "CmbCheckBank";
            this.CmbCheckBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCheckBank.Size = new System.Drawing.Size(300, 38);
            this.CmbCheckBank.TabIndex = 2;
            // 
            // BtnKeypadIdentification
            // 
            this.BtnKeypadIdentification.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadIdentification.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadIdentification.Appearance.Options.UseBackColor = true;
            this.BtnKeypadIdentification.Appearance.Options.UseFont = true;
            this.BtnKeypadIdentification.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadIdentification.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadIdentification.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadIdentification.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadIdentification.ImageOptions.SvgImage")));
            this.BtnKeypadIdentification.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadIdentification.Location = new System.Drawing.Point(403, 66);
            this.BtnKeypadIdentification.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadIdentification.Name = "BtnKeypadIdentification";
            this.BtnKeypadIdentification.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadIdentification.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadIdentification.TabIndex = 174;
            this.BtnKeypadIdentification.Click += new System.EventHandler(this.BtnKeypadIdentification_Click);
            // 
            // LblIndentification
            // 
            this.LblIndentification.AutoSize = true;
            this.LblIndentification.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblIndentification.Location = new System.Drawing.Point(33, 83);
            this.LblIndentification.Name = "LblIndentification";
            this.LblIndentification.Size = new System.Drawing.Size(116, 18);
            this.LblIndentification.TabIndex = 173;
            this.LblIndentification.Text = "Identificacion";
            // 
            // TxtIdentification
            // 
            this.TxtIdentification.Location = new System.Drawing.Point(175, 69);
            this.TxtIdentification.Name = "TxtIdentification";
            this.TxtIdentification.Size = new System.Drawing.Size(219, 38);
            this.TxtIdentification.TabIndex = 21;
            // 
            // BtnKeypadPhone
            // 
            this.BtnKeypadPhone.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadPhone.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadPhone.Appearance.Options.UseBackColor = true;
            this.BtnKeypadPhone.Appearance.Options.UseFont = true;
            this.BtnKeypadPhone.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadPhone.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadPhone.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadPhone.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadPhone.ImageOptions.SvgImage")));
            this.BtnKeypadPhone.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadPhone.Location = new System.Drawing.Point(403, 123);
            this.BtnKeypadPhone.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadPhone.Name = "BtnKeypadPhone";
            this.BtnKeypadPhone.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadPhone.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadPhone.TabIndex = 177;
            this.BtnKeypadPhone.Click += new System.EventHandler(this.BtnKeypadPhone_Click);
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblPhone.Location = new System.Drawing.Point(33, 141);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(77, 18);
            this.LblPhone.TabIndex = 176;
            this.LblPhone.Text = "Telefono";
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(175, 127);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Size = new System.Drawing.Size(219, 38);
            this.TxtPhone.TabIndex = 1;
            // 
            // BtnAuthorization
            // 
            this.BtnAuthorization.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnAuthorization.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAuthorization.Appearance.Options.UseBackColor = true;
            this.BtnAuthorization.Appearance.Options.UseFont = true;
            this.BtnAuthorization.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnAuthorization.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAuthorization.ImageOptions.SvgImage")));
            this.BtnAuthorization.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAuthorization.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnAuthorization.Location = new System.Drawing.Point(405, 464);
            this.BtnAuthorization.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAuthorization.Name = "BtnAuthorization";
            this.BtnAuthorization.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnAuthorization.Size = new System.Drawing.Size(63, 55);
            this.BtnAuthorization.TabIndex = 179;
            this.BtnAuthorization.Click += new System.EventHandler(this.BtnAuthorization_Click);
            // 
            // LblCheckAmount
            // 
            this.LblCheckAmount.AutoSize = true;
            this.LblCheckAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCheckAmount.Location = new System.Drawing.Point(33, 423);
            this.LblCheckAmount.Name = "LblCheckAmount";
            this.LblCheckAmount.Size = new System.Drawing.Size(116, 18);
            this.LblCheckAmount.TabIndex = 181;
            this.LblCheckAmount.Text = "Valor Cheque";
            // 
            // TxtCheckAmount
            // 
            this.TxtCheckAmount.Enabled = false;
            this.TxtCheckAmount.Location = new System.Drawing.Point(175, 412);
            this.TxtCheckAmount.Name = "TxtCheckAmount";
            this.TxtCheckAmount.Size = new System.Drawing.Size(219, 38);
            this.TxtCheckAmount.TabIndex = 0;
            // 
            // BtnKeypadAuth
            // 
            this.BtnKeypadAuth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadAuth.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadAuth.Appearance.Options.UseBackColor = true;
            this.BtnKeypadAuth.Appearance.Options.UseFont = true;
            this.BtnKeypadAuth.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadAuth.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadAuth.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadAuth.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.BtnKeypadAuth.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadAuth.Location = new System.Drawing.Point(403, 465);
            this.BtnKeypadAuth.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadAuth.Name = "BtnKeypadAuth";
            this.BtnKeypadAuth.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadAuth.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadAuth.TabIndex = 182;
            this.BtnKeypadAuth.Visible = false;
            this.BtnKeypadAuth.Click += new System.EventHandler(this.BtnKeypadAuth_Click);
            // 
            // FrmPaymentCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 628);
            this.ControlBox = false;
            this.Controls.Add(this.LblCheckAmount);
            this.Controls.Add(this.TxtCheckAmount);
            this.Controls.Add(this.BtnAuthorization);
            this.Controls.Add(this.BtnKeypadPhone);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.BtnKeypadIdentification);
            this.Controls.Add(this.LblIndentification);
            this.Controls.Add(this.TxtIdentification);
            this.Controls.Add(this.CmbCheckBank);
            this.Controls.Add(this.BtnKeypadCheck);
            this.Controls.Add(this.BtnKeypadAccount);
            this.Controls.Add(this.BtnKeyboardOwner);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.LblCheckNumber);
            this.Controls.Add(this.TxtCheckNumber);
            this.Controls.Add(this.LblAccountNumber);
            this.Controls.Add(this.LblCheckDate);
            this.Controls.Add(this.LblBank);
            this.Controls.Add(this.LblOwnerName);
            this.Controls.Add(this.TxtAuthorization);
            this.Controls.Add(this.TxtAccountNumber);
            this.Controls.Add(this.TxtOwnerName);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtCheckDate);
            this.Controls.Add(this.BtnKeypadAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheques";
            this.Load += new System.EventHandler(this.FrmPaymentCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtOwnerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCheckBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdentification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCheckAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label LblOwnerName;
        private System.Windows.Forms.Label LblBank;
        private System.Windows.Forms.Label LblCheckDate;
        private System.Windows.Forms.Label LblAccountNumber;
        private System.Windows.Forms.Label LblCheckNumber;
        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardOwner;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadAccount;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadCheck;
        public DevExpress.XtraEditors.TextEdit TxtOwnerName;
        public DevExpress.XtraEditors.TextEdit TxtAccountNumber;
        public DevExpress.XtraEditors.TextEdit TxtAuthorization;
        public DevExpress.XtraEditors.DateEdit TxtCheckDate;
        public DevExpress.XtraEditors.TextEdit TxtCheckNumber;
        public DevExpress.XtraEditors.ImageComboBoxEdit CmbCheckBank;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadIdentification;
        private System.Windows.Forms.Label LblIndentification;
        public DevExpress.XtraEditors.TextEdit TxtIdentification;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadPhone;
        private System.Windows.Forms.Label LblPhone;
        public DevExpress.XtraEditors.TextEdit TxtPhone;
        private DevExpress.XtraEditors.SimpleButton BtnAuthorization;
        private System.Windows.Forms.Label LblCheckAmount;
        public DevExpress.XtraEditors.TextEdit TxtCheckAmount;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadAuth;
    }
}