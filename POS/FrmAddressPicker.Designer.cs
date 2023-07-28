namespace POS
{
    partial class FrmAddressPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddressPicker));
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.LblMotive = new System.Windows.Forms.Label();
            this.CmbAddressPicker = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.BtnKeyboardAddressRef = new DevExpress.XtraEditors.SimpleButton();
            this.TxtAddressRef = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeyboardAddress = new DevExpress.XtraEditors.SimpleButton();
            this.TxtAddress = new DevExpress.XtraEditors.TextEdit();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.LblCustomerId = new System.Windows.Forms.Label();
            this.LblTitleCustomerName = new System.Windows.Forms.Label();
            this.LblTitleCustomer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTelephoneAddress = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeypadTelephone = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnModify = new DevExpress.XtraEditors.SimpleButton();
            this.BtnNewAddress = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAddressPicker = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.CmbAddressPicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddressRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelephoneAddress.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnCancel.Location = new System.Drawing.Point(371, 345);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 143;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblMotive
            // 
            this.LblMotive.AutoSize = true;
            this.LblMotive.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblMotive.Location = new System.Drawing.Point(23, 14);
            this.LblMotive.Name = "LblMotive";
            this.LblMotive.Size = new System.Drawing.Size(109, 46);
            this.LblMotive.TabIndex = 144;
            this.LblMotive.Text = "Direccion \r\nEntrega";
            // 
            // CmbAddressPicker
            // 
            this.CmbAddressPicker.Location = new System.Drawing.Point(138, 12);
            this.CmbAddressPicker.Name = "CmbAddressPicker";
            this.CmbAddressPicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbAddressPicker.Size = new System.Drawing.Size(425, 30);
            this.CmbAddressPicker.TabIndex = 0;
            this.CmbAddressPicker.SelectedIndexChanged += new System.EventHandler(this.CmbAddressPicker_SelectedIndexChanged);
            this.CmbAddressPicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbAddressPicker_KeyDown);
            // 
            // BtnKeyboardAddressRef
            // 
            this.BtnKeyboardAddressRef.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyboardAddressRef.Appearance.Options.UseFont = true;
            this.BtnKeyboardAddressRef.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyboardAddressRef.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyboardAddressRef.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyboardAddressRef.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardAddressRef.ImageOptions.SvgImage")));
            this.BtnKeyboardAddressRef.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyboardAddressRef.Location = new System.Drawing.Point(572, 222);
            this.BtnKeyboardAddressRef.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardAddressRef.Name = "BtnKeyboardAddressRef";
            this.BtnKeyboardAddressRef.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardAddressRef.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardAddressRef.TabIndex = 151;
            this.BtnKeyboardAddressRef.Click += new System.EventHandler(this.BtnKeyboardAddressRef_Click);
            // 
            // TxtAddressRef
            // 
            this.TxtAddressRef.Location = new System.Drawing.Point(138, 229);
            this.TxtAddressRef.Name = "TxtAddressRef";
            this.TxtAddressRef.Size = new System.Drawing.Size(425, 30);
            this.TxtAddressRef.TabIndex = 2;
            this.TxtAddressRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddressRef_KeyDown);
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
            this.BtnKeyboardAddress.Location = new System.Drawing.Point(572, 165);
            this.BtnKeyboardAddress.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyboardAddress.Name = "BtnKeyboardAddress";
            this.BtnKeyboardAddress.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyboardAddress.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyboardAddress.TabIndex = 148;
            this.BtnKeyboardAddress.Click += new System.EventHandler(this.BtnKeyboardAddress_Click);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(138, 172);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(425, 30);
            this.TxtAddress.TabIndex = 1;
            this.TxtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress_KeyDown);
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.AutoSize = true;
            this.LblCustomerName.Location = new System.Drawing.Point(135, 129);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(183, 20);
            this.LblCustomerName.TabIndex = 198;
            this.LblCustomerName.Text = "CONSUMIDOR FINAL";
            // 
            // LblCustomerId
            // 
            this.LblCustomerId.AutoSize = true;
            this.LblCustomerId.Location = new System.Drawing.Point(135, 83);
            this.LblCustomerId.Name = "LblCustomerId";
            this.LblCustomerId.Size = new System.Drawing.Size(139, 20);
            this.LblCustomerId.TabIndex = 197;
            this.LblCustomerId.Text = "9999999999999";
            // 
            // LblTitleCustomerName
            // 
            this.LblTitleCustomerName.AutoSize = true;
            this.LblTitleCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerName.Location = new System.Drawing.Point(23, 129);
            this.LblTitleCustomerName.Name = "LblTitleCustomerName";
            this.LblTitleCustomerName.Size = new System.Drawing.Size(87, 20);
            this.LblTitleCustomerName.TabIndex = 196;
            this.LblTitleCustomerName.Text = "Nombre:";
            // 
            // LblTitleCustomer
            // 
            this.LblTitleCustomer.AutoSize = true;
            this.LblTitleCustomer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomer.Location = new System.Drawing.Point(23, 83);
            this.LblTitleCustomer.Name = "LblTitleCustomer";
            this.LblTitleCustomer.Size = new System.Drawing.Size(81, 20);
            this.LblTitleCustomer.TabIndex = 195;
            this.LblTitleCustomer.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(23, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 232;
            this.label2.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 234;
            this.label3.Text = "Referencia:";
            // 
            // TxtTelephoneAddress
            // 
            this.TxtTelephoneAddress.Location = new System.Drawing.Point(137, 286);
            this.TxtTelephoneAddress.Name = "TxtTelephoneAddress";
            this.TxtTelephoneAddress.Size = new System.Drawing.Size(425, 30);
            this.TxtTelephoneAddress.TabIndex = 3;
            this.TxtTelephoneAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTelephoneAddress_KeyDown);
            // 
            // BtnKeypadTelephone
            // 
            this.BtnKeypadTelephone.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadTelephone.Appearance.Options.UseFont = true;
            this.BtnKeypadTelephone.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadTelephone.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadTelephone.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadTelephone.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadTelephone.ImageOptions.SvgImage")));
            this.BtnKeypadTelephone.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadTelephone.Location = new System.Drawing.Point(571, 279);
            this.BtnKeypadTelephone.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadTelephone.Name = "BtnKeypadTelephone";
            this.BtnKeypadTelephone.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadTelephone.Size = new System.Drawing.Size(82, 50);
            this.BtnKeypadTelephone.TabIndex = 151;
            this.BtnKeypadTelephone.Click += new System.EventHandler(this.BtnKeypadTelephone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 234;
            this.label1.Text = "Telefono:";
            // 
            // BtnModify
            // 
            this.BtnModify.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModify.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.Appearance.Options.UseBackColor = true;
            this.BtnModify.Appearance.Options.UseFont = true;
            this.BtnModify.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.ImageOptions.Image")));
            this.BtnModify.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnModify.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnModify.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnModify.Location = new System.Drawing.Point(196, 345);
            this.BtnModify.Margin = new System.Windows.Forms.Padding(5);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(165, 50);
            this.BtnModify.TabIndex = 235;
            this.BtnModify.Text = "F2 Modificar";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnNewAddress
            // 
            this.BtnNewAddress.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnNewAddress.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnNewAddress.Appearance.Options.UseBackColor = true;
            this.BtnNewAddress.Appearance.Options.UseFont = true;
            this.BtnNewAddress.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewAddress.ImageOptions.Image")));
            this.BtnNewAddress.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnNewAddress.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnNewAddress.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnNewAddress.Location = new System.Drawing.Point(26, 345);
            this.BtnNewAddress.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNewAddress.Name = "BtnNewAddress";
            this.BtnNewAddress.Size = new System.Drawing.Size(160, 50);
            this.BtnNewAddress.TabIndex = 3;
            this.BtnNewAddress.Text = "F3 Nueva\r\nDireccion";
            this.BtnNewAddress.Click += new System.EventHandler(this.BtnNewAddress_Click);
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
            this.BtnRefresh.Location = new System.Drawing.Point(571, 3);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(82, 50);
            this.BtnRefresh.TabIndex = 4;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnAddressPicker
            // 
            this.BtnAddressPicker.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAddressPicker.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAddressPicker.Appearance.Options.UseBackColor = true;
            this.BtnAddressPicker.Appearance.Options.UseFont = true;
            this.BtnAddressPicker.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddressPicker.ImageOptions.Image")));
            this.BtnAddressPicker.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAddressPicker.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAddressPicker.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnAddressPicker.Location = new System.Drawing.Point(541, 346);
            this.BtnAddressPicker.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAddressPicker.Name = "BtnAddressPicker";
            this.BtnAddressPicker.Size = new System.Drawing.Size(168, 50);
            this.BtnAddressPicker.TabIndex = 142;
            this.BtnAddressPicker.Text = "F6 Elegir";
            this.BtnAddressPicker.Click += new System.EventHandler(this.BtnAddressPicker_Click);
            // 
            // FrmAddressPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(779, 476);
            this.ControlBox = false;
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.LblCustomerId);
            this.Controls.Add(this.LblTitleCustomerName);
            this.Controls.Add(this.LblTitleCustomer);
            this.Controls.Add(this.BtnKeypadTelephone);
            this.Controls.Add(this.BtnKeyboardAddressRef);
            this.Controls.Add(this.TxtTelephoneAddress);
            this.Controls.Add(this.TxtAddressRef);
            this.Controls.Add(this.BtnKeyboardAddress);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.LblMotive);
            this.Controls.Add(this.CmbAddressPicker);
            this.Controls.Add(this.BtnNewAddress);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnAddressPicker);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAddressPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Direccion de Entrega";
            this.Load += new System.EventHandler(this.FrmAddressPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CmbAddressPicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddressRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelephoneAddress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnAddressPicker;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label LblMotive;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbAddressPicker;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardAddressRef;
        private DevExpress.XtraEditors.TextEdit TxtAddressRef;
        private DevExpress.XtraEditors.SimpleButton BtnKeyboardAddress;
        private DevExpress.XtraEditors.TextEdit TxtAddress;
        public System.Windows.Forms.Label LblCustomerName;
        public System.Windows.Forms.Label LblCustomerId;
        private System.Windows.Forms.Label LblTitleCustomerName;
        private System.Windows.Forms.Label LblTitleCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton BtnNewAddress;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
        private DevExpress.XtraEditors.TextEdit TxtTelephoneAddress;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadTelephone;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnModify;
    }
}