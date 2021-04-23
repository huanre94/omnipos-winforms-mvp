namespace POS
{
    partial class FrmSalesOrderHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesOrderHeader));
            this.BtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BtnCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.LblDeliveryAddressRef = new System.Windows.Forms.Label();
            this.LblCustomerAddress = new System.Windows.Forms.Label();
            this.LblDeliveryAddress = new System.Windows.Forms.Label();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.LblCustomerId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTitleCustomerAddress = new System.Windows.Forms.Label();
            this.LblTitleCustomerName = new System.Windows.Forms.Label();
            this.LblTitleCustomer = new System.Windows.Forms.Label();
            this.BtnSaveOrder = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDeliveryAddress = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbSalesOrderOrigin = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.EdtDeliveryDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSalesOrderOrigin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtDeliveryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtDeliveryDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.AllowFocus = false;
            this.BtnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnExit.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnExit.Appearance.Options.UseBackColor = true;
            this.BtnExit.Appearance.Options.UseFont = true;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnExit.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnExit.Location = new System.Drawing.Point(173, 556);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(250, 45);
            this.BtnExit.TabIndex = 247;
            this.BtnExit.Text = "Cancelar";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(61, 244);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(288, 294);
            this.richTextBox1.TabIndex = 246;
            this.richTextBox1.Text = "";
            // 
            // BtnCustomer
            // 
            this.BtnCustomer.AllowFocus = false;
            this.BtnCustomer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCustomer.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCustomer.Appearance.Options.UseBackColor = true;
            this.BtnCustomer.Appearance.Options.UseFont = true;
            this.BtnCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCustomer.ImageOptions.SvgImage = global::POS.Properties.Resources.user4;
            this.BtnCustomer.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCustomer.Location = new System.Drawing.Point(61, 12);
            this.BtnCustomer.Name = "BtnCustomer";
            this.BtnCustomer.Size = new System.Drawing.Size(250, 45);
            this.BtnCustomer.TabIndex = 244;
            this.BtnCustomer.Text = "Cliente";
            this.BtnCustomer.Click += new System.EventHandler(this.BtnCustomer_Click);
            // 
            // LblDeliveryAddressRef
            // 
            this.LblDeliveryAddressRef.Location = new System.Drawing.Point(488, 126);
            this.LblDeliveryAddressRef.Name = "LblDeliveryAddressRef";
            this.LblDeliveryAddressRef.Size = new System.Drawing.Size(199, 43);
            this.LblDeliveryAddressRef.TabIndex = 239;
            // 
            // LblCustomerAddress
            // 
            this.LblCustomerAddress.Location = new System.Drawing.Point(139, 166);
            this.LblCustomerAddress.Name = "LblCustomerAddress";
            this.LblCustomerAddress.Size = new System.Drawing.Size(210, 59);
            this.LblCustomerAddress.TabIndex = 240;
            this.LblCustomerAddress.Text = "GUAYAQUIL";
            // 
            // LblDeliveryAddress
            // 
            this.LblDeliveryAddress.Location = new System.Drawing.Point(488, 84);
            this.LblDeliveryAddress.Name = "LblDeliveryAddress";
            this.LblDeliveryAddress.Size = new System.Drawing.Size(199, 40);
            this.LblDeliveryAddress.TabIndex = 237;
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.Location = new System.Drawing.Point(139, 126);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(210, 40);
            this.LblCustomerName.TabIndex = 238;
            this.LblCustomerName.Text = "CONSUMIDOR FINAL";
            // 
            // LblCustomerId
            // 
            this.LblCustomerId.AutoSize = true;
            this.LblCustomerId.Location = new System.Drawing.Point(139, 83);
            this.LblCustomerId.Name = "LblCustomerId";
            this.LblCustomerId.Size = new System.Drawing.Size(112, 16);
            this.LblCustomerId.TabIndex = 236;
            this.LblCustomerId.Text = "9999999999999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(386, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 233;
            this.label3.Text = "Referencia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(386, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 231;
            this.label2.Text = "Dirección:";
            // 
            // LblTitleCustomerAddress
            // 
            this.LblTitleCustomerAddress.AutoSize = true;
            this.LblTitleCustomerAddress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerAddress.Location = new System.Drawing.Point(56, 166);
            this.LblTitleCustomerAddress.Name = "LblTitleCustomerAddress";
            this.LblTitleCustomerAddress.Size = new System.Drawing.Size(86, 16);
            this.LblTitleCustomerAddress.TabIndex = 234;
            this.LblTitleCustomerAddress.Text = "Dirección:";
            // 
            // LblTitleCustomerName
            // 
            this.LblTitleCustomerName.AutoSize = true;
            this.LblTitleCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerName.Location = new System.Drawing.Point(56, 126);
            this.LblTitleCustomerName.Name = "LblTitleCustomerName";
            this.LblTitleCustomerName.Size = new System.Drawing.Size(73, 16);
            this.LblTitleCustomerName.TabIndex = 232;
            this.LblTitleCustomerName.Text = "Nombre:";
            // 
            // LblTitleCustomer
            // 
            this.LblTitleCustomer.AutoSize = true;
            this.LblTitleCustomer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomer.Location = new System.Drawing.Point(56, 83);
            this.LblTitleCustomer.Name = "LblTitleCustomer";
            this.LblTitleCustomer.Size = new System.Drawing.Size(67, 16);
            this.LblTitleCustomer.TabIndex = 230;
            this.LblTitleCustomer.Text = "Cliente:";
            // 
            // BtnSaveOrder
            // 
            this.BtnSaveOrder.AllowFocus = false;
            this.BtnSaveOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSaveOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnSaveOrder.Appearance.Options.UseBackColor = true;
            this.BtnSaveOrder.Appearance.Options.UseFont = true;
            this.BtnSaveOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveOrder.ImageOptions.Image")));
            this.BtnSaveOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSaveOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnSaveOrder.Location = new System.Drawing.Point(431, 556);
            this.BtnSaveOrder.Name = "BtnSaveOrder";
            this.BtnSaveOrder.Size = new System.Drawing.Size(250, 45);
            this.BtnSaveOrder.TabIndex = 245;
            this.BtnSaveOrder.Text = "Guardar Orden";
            this.BtnSaveOrder.Click += new System.EventHandler(this.BtnSaveOrder_Click);
            // 
            // BtnDeliveryAddress
            // 
            this.BtnDeliveryAddress.AllowFocus = false;
            this.BtnDeliveryAddress.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDeliveryAddress.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnDeliveryAddress.Appearance.Options.UseBackColor = true;
            this.BtnDeliveryAddress.Appearance.Options.UseFont = true;
            this.BtnDeliveryAddress.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeliveryAddress.ImageOptions.Image")));
            this.BtnDeliveryAddress.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnDeliveryAddress.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnDeliveryAddress.Location = new System.Drawing.Point(389, 12);
            this.BtnDeliveryAddress.Name = "BtnDeliveryAddress";
            this.BtnDeliveryAddress.Size = new System.Drawing.Size(250, 45);
            this.BtnDeliveryAddress.TabIndex = 241;
            this.BtnDeliveryAddress.Text = "Direccion Entrega";
            this.BtnDeliveryAddress.Click += new System.EventHandler(this.BtnDeliveryAddress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(58, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 233;
            this.label1.Text = "Comanda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(386, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 233;
            this.label4.Text = "Origen de Venta";
            // 
            // CmbSalesOrderOrigin
            // 
            this.CmbSalesOrderOrigin.Location = new System.Drawing.Point(389, 244);
            this.CmbSalesOrderOrigin.Name = "CmbSalesOrderOrigin";
            this.CmbSalesOrderOrigin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbSalesOrderOrigin.Size = new System.Drawing.Size(250, 38);
            this.CmbSalesOrderOrigin.TabIndex = 249;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(386, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 233;
            this.label5.Text = "Fecha Entrega";
            // 
            // EdtDeliveryDate
            // 
            this.EdtDeliveryDate.EditValue = null;
            this.EdtDeliveryDate.Location = new System.Drawing.Point(389, 353);
            this.EdtDeliveryDate.Name = "EdtDeliveryDate";
            this.EdtDeliveryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EdtDeliveryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EdtDeliveryDate.Properties.DisplayFormat.FormatString = "";
            this.EdtDeliveryDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.EdtDeliveryDate.Properties.EditFormat.FormatString = "";
            this.EdtDeliveryDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.EdtDeliveryDate.Properties.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.EdtDeliveryDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.EdtDeliveryDate.Size = new System.Drawing.Size(250, 38);
            this.EdtDeliveryDate.TabIndex = 249;
            // 
            // FrmSalesOrderHeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(716, 627);
            this.ControlBox = false;
            this.Controls.Add(this.CmbSalesOrderOrigin);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnSaveOrder);
            this.Controls.Add(this.BtnCustomer);
            this.Controls.Add(this.BtnDeliveryAddress);
            this.Controls.Add(this.LblDeliveryAddressRef);
            this.Controls.Add(this.LblCustomerAddress);
            this.Controls.Add(this.LblDeliveryAddress);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.LblCustomerId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitleCustomerAddress);
            this.Controls.Add(this.LblTitleCustomerName);
            this.Controls.Add(this.LblTitleCustomer);
            this.Controls.Add(this.EdtDeliveryDate);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSalesOrderHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creacion Orden de Venta";
            this.Load += new System.EventHandler(this.FrmSalesOrderHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CmbSalesOrderOrigin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtDeliveryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdtDeliveryDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.SimpleButton BtnSaveOrder;
        private DevExpress.XtraEditors.SimpleButton BtnCustomer;
        private DevExpress.XtraEditors.SimpleButton BtnDeliveryAddress;
        private System.Windows.Forms.Label LblDeliveryAddressRef;
        private System.Windows.Forms.Label LblCustomerAddress;
        public System.Windows.Forms.Label LblDeliveryAddress;
        public System.Windows.Forms.Label LblCustomerName;
        public System.Windows.Forms.Label LblCustomerId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTitleCustomerAddress;
        private System.Windows.Forms.Label LblTitleCustomerName;
        private System.Windows.Forms.Label LblTitleCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbSalesOrderOrigin;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit EdtDeliveryDate;
    }
}