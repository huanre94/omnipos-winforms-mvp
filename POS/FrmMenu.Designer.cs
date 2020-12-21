namespace POS
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.BtnPOS = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnCloseCashier = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPartialClosing = new DevExpress.XtraEditors.SimpleButton();
            this.BtnLogOut = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitleUsername = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnSalesOrder = new DevExpress.XtraEditors.SimpleButton();
            this.BtnChangePaymMode = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGiftCardRedeem = new DevExpress.XtraEditors.SimpleButton();
            this.BtnInvoiceCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BtnPOS
            // 
            this.BtnPOS.AllowFocus = false;
            this.BtnPOS.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPOS.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPOS.Appearance.Options.UseBackColor = true;
            this.BtnPOS.Appearance.Options.UseFont = true;
            this.BtnPOS.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPOS.ImageOptions.SvgImage = global::POS.Properties.Resources.retail;
            this.BtnPOS.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnPOS.Location = new System.Drawing.Point(35, 120);
            this.BtnPOS.Name = "BtnPOS";
            this.BtnPOS.Size = new System.Drawing.Size(350, 200);
            this.BtnPOS.TabIndex = 134;
            this.BtnPOS.Text = "POS   ";
            this.BtnPOS.Click += new System.EventHandler(this.BtnPOS_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F, System.Drawing.FontStyle.Bold);
            this.LblTitle.Location = new System.Drawing.Point(615, 52);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(302, 34);
            this.LblTitle.TabIndex = 148;
            this.LblTitle.Text = "Menú de Opciones";
            // 
            // BtnCloseCashier
            // 
            this.BtnCloseCashier.AllowFocus = false;
            this.BtnCloseCashier.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCloseCashier.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnCloseCashier.Appearance.Options.UseBackColor = true;
            this.BtnCloseCashier.Appearance.Options.UseFont = true;
            this.BtnCloseCashier.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCloseCashier.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier;
            this.BtnCloseCashier.ImageOptions.SvgImageSize = new System.Drawing.Size(115, 115);
            this.BtnCloseCashier.Location = new System.Drawing.Point(406, 120);
            this.BtnCloseCashier.Name = "BtnCloseCashier";
            this.BtnCloseCashier.Size = new System.Drawing.Size(350, 200);
            this.BtnCloseCashier.TabIndex = 149;
            this.BtnCloseCashier.Text = "Cierre Caja";
            this.BtnCloseCashier.Click += new System.EventHandler(this.BtnCloseCashier_Click);
            // 
            // BtnPartialClosing
            // 
            this.BtnPartialClosing.AllowFocus = false;
            this.BtnPartialClosing.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPartialClosing.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPartialClosing.Appearance.Options.UseBackColor = true;
            this.BtnPartialClosing.Appearance.Options.UseFont = true;
            this.BtnPartialClosing.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPartialClosing.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier_partial;
            this.BtnPartialClosing.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnPartialClosing.Location = new System.Drawing.Point(773, 120);
            this.BtnPartialClosing.Name = "BtnPartialClosing";
            this.BtnPartialClosing.Size = new System.Drawing.Size(350, 200);
            this.BtnPartialClosing.TabIndex = 149;
            this.BtnPartialClosing.Text = "Cierre Caja \r\nParcial";
            this.BtnPartialClosing.Click += new System.EventHandler(this.BtnPartialClosing_Click);
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.AllowFocus = false;
            this.BtnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLogOut.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnLogOut.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnLogOut.Appearance.Options.UseBackColor = true;
            this.BtnLogOut.Appearance.Options.UseFont = true;
            this.BtnLogOut.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnLogOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnLogOut.ImageOptions.SvgImage")));
            this.BtnLogOut.Location = new System.Drawing.Point(1104, 711);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(250, 45);
            this.BtnLogOut.TabIndex = 150;
            this.BtnLogOut.Text = "Cerrar Sesion";
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // LblTitleUsername
            // 
            this.LblTitleUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblTitleUsername.AutoSize = true;
            this.LblTitleUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblTitleUsername.Location = new System.Drawing.Point(12, 740);
            this.LblTitleUsername.Name = "LblTitleUsername";
            this.LblTitleUsername.Size = new System.Drawing.Size(65, 16);
            this.LblTitleUsername.TabIndex = 166;
            this.LblTitleUsername.Text = "Usuario:";
            // 
            // LblUsername
            // 
            this.LblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblUsername.Location = new System.Drawing.Point(83, 740);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(275, 16);
            this.LblUsername.TabIndex = 167;
            // 
            // LblVersion
            // 
            this.LblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblVersion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblVersion.Location = new System.Drawing.Point(364, 740);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(275, 16);
            this.LblVersion.TabIndex = 168;
            this.LblVersion.Text = "Publish Version";
            // 
            // BtnSalesOrder
            // 
            this.BtnSalesOrder.AllowFocus = false;
            this.BtnSalesOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSalesOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnSalesOrder.Appearance.Options.UseBackColor = true;
            this.BtnSalesOrder.Appearance.Options.UseFont = true;
            this.BtnSalesOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSalesOrder.ImageOptions.SvgImage = global::POS.Properties.Resources.e_commerce;
            this.BtnSalesOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnSalesOrder.Location = new System.Drawing.Point(408, 345);
            this.BtnSalesOrder.Name = "BtnSalesOrder";
            this.BtnSalesOrder.Size = new System.Drawing.Size(350, 200);
            this.BtnSalesOrder.TabIndex = 134;
            this.BtnSalesOrder.Text = "Pedidos \r\nE-commerce";
            this.BtnSalesOrder.Click += new System.EventHandler(this.BtnSalesOrder_Click);
            // 
            // BtnChangePaymMode
            // 
            this.BtnChangePaymMode.AllowFocus = false;
            this.BtnChangePaymMode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnChangePaymMode.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnChangePaymMode.Appearance.Options.UseBackColor = true;
            this.BtnChangePaymMode.Appearance.Options.UseFont = true;
            this.BtnChangePaymMode.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnChangePaymMode.ImageOptions.SvgImage = global::POS.Properties.Resources.payment;
            this.BtnChangePaymMode.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnChangePaymMode.Location = new System.Drawing.Point(33, 345);
            this.BtnChangePaymMode.Name = "BtnChangePaymMode";
            this.BtnChangePaymMode.Size = new System.Drawing.Size(350, 200);
            this.BtnChangePaymMode.TabIndex = 169;
            this.BtnChangePaymMode.Text = "Cambio Forma \r\nPago";
            this.BtnChangePaymMode.Click += new System.EventHandler(this.BtnChangePaymMode_Click);
            // 
            // BtnGiftCardRedeem
            // 
            this.BtnGiftCardRedeem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnGiftCardRedeem.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnGiftCardRedeem.Appearance.Options.UseBackColor = true;
            this.BtnGiftCardRedeem.Appearance.Options.UseFont = true;
            this.BtnGiftCardRedeem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnGiftCardRedeem.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnGiftCardRedeem.Location = new System.Drawing.Point(406, 344);
            this.BtnGiftCardRedeem.Name = "BtnGiftCardRedeem";
            this.BtnGiftCardRedeem.Size = new System.Drawing.Size(350, 200);
            this.BtnGiftCardRedeem.TabIndex = 134;
            this.BtnGiftCardRedeem.Text = "Canje \r\nBonos";
            this.BtnGiftCardRedeem.Click += new System.EventHandler(this.BtnGiftCardRedeem_Click);
            // 
            // BtnInvoiceCancel
            // 
            this.BtnInvoiceCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnInvoiceCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnInvoiceCancel.Appearance.Options.UseBackColor = true;
            this.BtnInvoiceCancel.Appearance.Options.UseFont = true;
            this.BtnInvoiceCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnInvoiceCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnInvoiceCancel.Location = new System.Drawing.Point(1142, 120);
            this.BtnInvoiceCancel.Name = "BtnInvoiceCancel";
            this.BtnInvoiceCancel.Size = new System.Drawing.Size(350, 200);
            this.BtnInvoiceCancel.TabIndex = 134;
            this.BtnInvoiceCancel.Text = "Anulacion\r\nFactura";
            this.BtnInvoiceCancel.Click += new System.EventHandler(this.BtnInvoiceCancel_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.BtnChangePaymMode);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblTitleUsername);
            this.Controls.Add(this.BtnPartialClosing);
            this.Controls.Add(this.BtnLogOut);
            this.Controls.Add(this.BtnCloseCashier);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.BtnGiftCardRedeem);
            this.Controls.Add(this.BtnInvoiceCancel);
            this.Controls.Add(this.BtnSalesOrder);
            this.Controls.Add(this.BtnPOS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnPOS;
        private System.Windows.Forms.Label LblTitle;
        private DevExpress.XtraEditors.SimpleButton BtnCloseCashier;
        private DevExpress.XtraEditors.SimpleButton BtnPartialClosing;
        private DevExpress.XtraEditors.SimpleButton BtnLogOut;
        private System.Windows.Forms.Label LblTitleUsername;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblVersion;
        private DevExpress.XtraEditors.SimpleButton BtnSalesOrder;
        private DevExpress.XtraEditors.SimpleButton BtnGiftCardRedeem;
        private DevExpress.XtraEditors.SimpleButton BtnChangePaymMode;
        private DevExpress.XtraEditors.SimpleButton BtnInvoiceCancel;
    }
}