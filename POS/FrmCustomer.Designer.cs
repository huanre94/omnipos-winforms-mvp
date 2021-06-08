namespace POS
{
    partial class FrmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomer));
            this.TxtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.LblName = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeyboardName = new DevExpress.XtraEditors.SimpleButton();
            this.LblIdentType = new System.Windows.Forms.Label();
            this.BtnKeyboardIdentification = new DevExpress.XtraEditors.SimpleButton();
            this.TxtIdentification = new DevExpress.XtraEditors.TextEdit();
            this.LblIdentification = new System.Windows.Forms.Label();
            this.BtnKeyboardLastname = new DevExpress.XtraEditors.SimpleButton();
            this.TxtLastName = new DevExpress.XtraEditors.TextEdit();
            this.LblLastname = new System.Windows.Forms.Label();
            this.BtnKeyboardAddress = new DevExpress.XtraEditors.SimpleButton();
            this.TxtAddress = new DevExpress.XtraEditors.TextEdit();
            this.LblAddress = new System.Windows.Forms.Label();
            this.BtnKeyboardEmail = new DevExpress.XtraEditors.SimpleButton();
            this.TxtEmail = new DevExpress.XtraEditors.TextEdit();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblGender = new System.Windows.Forms.Label();
            this.CmbIdenType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CmbGender = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtPhone = new DevExpress.XtraEditors.TextEdit();
            this.LblPersonType = new System.Windows.Forms.Label();
            this.BtnKeypadPhone = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdentification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIdenType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(113, 69);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(546, 38);
            this.TxtFirstName.TabIndex = 3;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblName.Location = new System.Drawing.Point(22, 78);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(80, 18);
            this.LblName.TabIndex = 8;
            this.LblName.Text = "Nombres";
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
            this.BtnAccept.Location = new System.Drawing.Point(599, 432);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 9;
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
            this.BtnCancel.Location = new System.Drawing.Point(429, 432);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancelar";
            // 
            // BtnKeyboardName
            // 
            this.BtnKeyboardName.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardName.Appearance.Options.UseFont = true;
            this.BtnKeyboardName.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardName.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardName.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardName.ImageOptions.SvgImage")));
            this.BtnKeyboardName.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardName.Location = new System.Drawing.Point(666, 64);
            this.BtnKeyboardName.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardName.Name = "BtnKeyboardName";
            this.BtnKeyboardName.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardName.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardName.TabIndex = 11;
            this.BtnKeyboardName.Click += new System.EventHandler(this.BtnKeyboardName_Click);
            // 
            // LblIdentType
            // 
            this.LblIdentType.AutoSize = true;
            this.LblIdentType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblIdentType.Location = new System.Drawing.Point(22, 21);
            this.LblIdentType.Name = "LblIdentType";
            this.LblIdentType.Size = new System.Drawing.Size(42, 18);
            this.LblIdentType.TabIndex = 13;
            this.LblIdentType.Text = "Tipo";
            // 
            // BtnKeyboardIdentification
            // 
            this.BtnKeyboardIdentification.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardIdentification.Appearance.Options.UseFont = true;
            this.BtnKeyboardIdentification.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardIdentification.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardIdentification.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardIdentification.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardIdentification.ImageOptions.SvgImage")));
            this.BtnKeyboardIdentification.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardIdentification.Location = new System.Drawing.Point(666, 9);
            this.BtnKeyboardIdentification.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardIdentification.Name = "BtnKeyboardIdentification";
            this.BtnKeyboardIdentification.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardIdentification.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardIdentification.TabIndex = 15;
            this.BtnKeyboardIdentification.Click += new System.EventHandler(this.BtnKeyboardIdentification_Click);
            // 
            // TxtIdentification
            // 
            this.TxtIdentification.Location = new System.Drawing.Point(459, 12);
            this.TxtIdentification.Name = "TxtIdentification";
            this.TxtIdentification.Size = new System.Drawing.Size(200, 38);
            this.TxtIdentification.TabIndex = 2;
            // 
            // LblIdentification
            // 
            this.LblIdentification.AutoSize = true;
            this.LblIdentification.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblIdentification.Location = new System.Drawing.Point(337, 21);
            this.LblIdentification.Name = "LblIdentification";
            this.LblIdentification.Size = new System.Drawing.Size(116, 18);
            this.LblIdentification.TabIndex = 16;
            this.LblIdentification.Text = "Identificación";
            // 
            // BtnKeyboardLastname
            // 
            this.BtnKeyboardLastname.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardLastname.Appearance.Options.UseFont = true;
            this.BtnKeyboardLastname.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardLastname.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardLastname.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardLastname.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardLastname.ImageOptions.SvgImage")));
            this.BtnKeyboardLastname.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardLastname.Location = new System.Drawing.Point(666, 121);
            this.BtnKeyboardLastname.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardLastname.Name = "BtnKeyboardLastname";
            this.BtnKeyboardLastname.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardLastname.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardLastname.TabIndex = 19;
            this.BtnKeyboardLastname.Click += new System.EventHandler(this.BtnKeyboardLastname_Click);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(113, 126);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(546, 38);
            this.TxtLastName.TabIndex = 17;
            // 
            // LblLastname
            // 
            this.LblLastname.AutoSize = true;
            this.LblLastname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblLastname.Location = new System.Drawing.Point(22, 135);
            this.LblLastname.Name = "LblLastname";
            this.LblLastname.Size = new System.Drawing.Size(81, 18);
            this.LblLastname.TabIndex = 18;
            this.LblLastname.Text = "Apellidos";
            // 
            // BtnKeyboardAddress
            // 
            this.BtnKeyboardAddress.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardAddress.Appearance.Options.UseFont = true;
            this.BtnKeyboardAddress.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardAddress.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardAddress.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardAddress.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardAddress.ImageOptions.SvgImage")));
            this.BtnKeyboardAddress.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardAddress.Location = new System.Drawing.Point(666, 178);
            this.BtnKeyboardAddress.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardAddress.Name = "BtnKeyboardAddress";
            this.BtnKeyboardAddress.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardAddress.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardAddress.TabIndex = 22;
            this.BtnKeyboardAddress.Click += new System.EventHandler(this.BtnKeyboardAddress_Click);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(113, 183);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(546, 38);
            this.TxtAddress.TabIndex = 20;
            // 
            // LblAddress
            // 
            this.LblAddress.AutoSize = true;
            this.LblAddress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAddress.Location = new System.Drawing.Point(22, 192);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(85, 18);
            this.LblAddress.TabIndex = 21;
            this.LblAddress.Text = "Dirección";
            // 
            // BtnKeyboardEmail
            // 
            this.BtnKeyboardEmail.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardEmail.Appearance.Options.UseFont = true;
            this.BtnKeyboardEmail.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardEmail.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardEmail.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardEmail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardEmail.ImageOptions.SvgImage")));
            this.BtnKeyboardEmail.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardEmail.Location = new System.Drawing.Point(666, 235);
            this.BtnKeyboardEmail.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardEmail.Name = "BtnKeyboardEmail";
            this.BtnKeyboardEmail.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardEmail.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardEmail.TabIndex = 25;
            this.BtnKeyboardEmail.Click += new System.EventHandler(this.BtnKeyboardEmail_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(113, 240);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(546, 38);
            this.TxtEmail.TabIndex = 23;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblEmail.Location = new System.Drawing.Point(22, 249);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(51, 18);
            this.LblEmail.TabIndex = 24;
            this.LblEmail.Text = "Email";
            // 
            // LblGender
            // 
            this.LblGender.AutoSize = true;
            this.LblGender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGender.Location = new System.Drawing.Point(22, 363);
            this.LblGender.Name = "LblGender";
            this.LblGender.Size = new System.Drawing.Size(68, 18);
            this.LblGender.TabIndex = 27;
            this.LblGender.Text = "Género";
            // 
            // CmbIdenType
            // 
            this.CmbIdenType.Location = new System.Drawing.Point(113, 12);
            this.CmbIdenType.Name = "CmbIdenType";
            this.CmbIdenType.Properties.AutoComplete = false;
            this.CmbIdenType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbIdenType.Properties.DropDownRows = 10;
            this.CmbIdenType.Size = new System.Drawing.Size(200, 38);
            this.CmbIdenType.TabIndex = 28;
            // 
            // CmbGender
            // 
            this.CmbGender.Location = new System.Drawing.Point(113, 354);
            this.CmbGender.Name = "CmbGender";
            this.CmbGender.Properties.AutoComplete = false;
            this.CmbGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbGender.Properties.DropDownRows = 10;
            this.CmbGender.Size = new System.Drawing.Size(200, 38);
            this.CmbGender.TabIndex = 29;
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblPhone.Location = new System.Drawing.Point(22, 306);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(77, 18);
            this.LblPhone.TabIndex = 31;
            this.LblPhone.Text = "Teléfono";
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(113, 297);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Size = new System.Drawing.Size(200, 38);
            this.TxtPhone.TabIndex = 30;
            // 
            // LblPersonType
            // 
            this.LblPersonType.AutoSize = true;
            this.LblPersonType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblPersonType.Location = new System.Drawing.Point(551, 306);
            this.LblPersonType.Name = "LblPersonType";
            this.LblPersonType.Size = new System.Drawing.Size(108, 18);
            this.LblPersonType.TabIndex = 32;
            this.LblPersonType.Text = "Person Type";
            this.LblPersonType.Visible = false;
            // 
            // BtnKeypadPhone
            // 
            this.BtnKeypadPhone.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadPhone.Appearance.Options.UseFont = true;
            this.BtnKeypadPhone.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadPhone.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadPhone.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadPhone.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadPhone.ImageOptions.SvgImage")));
            this.BtnKeypadPhone.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadPhone.Location = new System.Drawing.Point(319, 292);
            this.BtnKeypadPhone.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadPhone.Name = "BtnKeypadPhone";
            this.BtnKeypadPhone.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadPhone.Size = new System.Drawing.Size(82, 50);
            this.BtnKeypadPhone.TabIndex = 33;
            this.BtnKeypadPhone.Click += new System.EventHandler(this.BtnKeypadPhone_Click);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 496);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeypadPhone);
            this.Controls.Add(this.LblPersonType);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.CmbGender);
            this.Controls.Add(this.CmbIdenType);
            this.Controls.Add(this.LblGender);
            this.Controls.Add(this.BtnKeyboardEmail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.BtnKeyboardAddress);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.LblAddress);
            this.Controls.Add(this.BtnKeyboardLastname);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.LblLastname);
            this.Controls.Add(this.LblIdentification);
            this.Controls.Add(this.BtnKeyboardIdentification);
            this.Controls.Add(this.TxtIdentification);
            this.Controls.Add(this.LblIdentType);
            this.Controls.Add(this.BtnKeyboardName);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.LblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdentification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIdenType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtFirstName;
        private System.Windows.Forms.Label LblName;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardName;
        private System.Windows.Forms.Label LblIdentType;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardIdentification;
        private DevExpress.XtraEditors.TextEdit TxtIdentification;
        private System.Windows.Forms.Label LblIdentification;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardLastname;
        private DevExpress.XtraEditors.TextEdit TxtLastName;
        private System.Windows.Forms.Label LblLastname;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardAddress;
        private DevExpress.XtraEditors.TextEdit TxtAddress;
        private System.Windows.Forms.Label LblAddress;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardEmail;
        private DevExpress.XtraEditors.TextEdit TxtEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblGender;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbIdenType;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbGender;
        private System.Windows.Forms.Label LblPhone;
        private DevExpress.XtraEditors.TextEdit TxtPhone;
        private System.Windows.Forms.Label LblPersonType;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadPhone;
    }
}