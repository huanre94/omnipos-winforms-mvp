﻿namespace POS
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
            this.BtnPhysicalInventory = new DevExpress.XtraEditors.SimpleButton();
            this.btnArqueo = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BtnPOS
            // 
            this.BtnPOS.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPOS.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPOS.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnPOS.Appearance.Options.UseBackColor = true;
            this.BtnPOS.Appearance.Options.UseFont = true;
            this.BtnPOS.Appearance.Options.UseForeColor = true;
            this.BtnPOS.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPOS.ImageOptions.SvgImage = global::POS.Properties.Resources.retail;
            this.BtnPOS.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnPOS.Location = new System.Drawing.Point(15, 120);
            this.BtnPOS.Name = "BtnPOS";
            this.BtnPOS.Size = new System.Drawing.Size(314, 189);
            this.BtnPOS.TabIndex = 0;
            this.BtnPOS.Text = "POS   ";
            this.BtnPOS.Click += new System.EventHandler(this.BtnPOS_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F, System.Drawing.FontStyle.Bold);
            this.LblTitle.Location = new System.Drawing.Point(516, 52);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(365, 43);
            this.LblTitle.TabIndex = 148;
            this.LblTitle.Text = "Menú de Opciones";
            // 
            // BtnCloseCashier
            // 
            this.BtnCloseCashier.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCloseCashier.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnCloseCashier.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCloseCashier.Appearance.Options.UseBackColor = true;
            this.BtnCloseCashier.Appearance.Options.UseFont = true;
            this.BtnCloseCashier.Appearance.Options.UseForeColor = true;
            this.BtnCloseCashier.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCloseCashier.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier;
            this.BtnCloseCashier.ImageOptions.SvgImageSize = new System.Drawing.Size(115, 115);
            this.BtnCloseCashier.Location = new System.Drawing.Point(335, 120);
            this.BtnCloseCashier.Name = "BtnCloseCashier";
            this.BtnCloseCashier.Size = new System.Drawing.Size(311, 189);
            this.BtnCloseCashier.TabIndex = 1;
            this.BtnCloseCashier.Text = "Cierre \r\nCaja ";
            this.BtnCloseCashier.Click += new System.EventHandler(this.BtnCloseCashier_Click);
            // 
            // BtnPartialClosing
            // 
            this.BtnPartialClosing.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPartialClosing.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPartialClosing.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnPartialClosing.Appearance.Options.UseBackColor = true;
            this.BtnPartialClosing.Appearance.Options.UseFont = true;
            this.BtnPartialClosing.Appearance.Options.UseForeColor = true;
            this.BtnPartialClosing.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPartialClosing.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier_partial;
            this.BtnPartialClosing.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnPartialClosing.Location = new System.Drawing.Point(652, 120);
            this.BtnPartialClosing.Name = "BtnPartialClosing";
            this.BtnPartialClosing.Size = new System.Drawing.Size(311, 189);
            this.BtnPartialClosing.TabIndex = 2;
            this.BtnPartialClosing.Text = "Cierre Caja \r\nParcial";
            this.BtnPartialClosing.Click += new System.EventHandler(this.BtnPartialClosing_Click);
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLogOut.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnLogOut.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnLogOut.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnLogOut.Appearance.Options.UseBackColor = true;
            this.BtnLogOut.Appearance.Options.UseFont = true;
            this.BtnLogOut.Appearance.Options.UseForeColor = true;
            this.BtnLogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnLogOut.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnLogOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnLogOut.ImageOptions.SvgImage")));
            this.BtnLogOut.Location = new System.Drawing.Point(1095, 652);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(250, 45);
            this.BtnLogOut.TabIndex = 9;
            this.BtnLogOut.Text = "Cerrar Sesion";
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // LblTitleUsername
            // 
            this.LblTitleUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblTitleUsername.AutoSize = true;
            this.LblTitleUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblTitleUsername.Location = new System.Drawing.Point(12, 719);
            this.LblTitleUsername.Name = "LblTitleUsername";
            this.LblTitleUsername.Size = new System.Drawing.Size(78, 20);
            this.LblTitleUsername.TabIndex = 166;
            this.LblTitleUsername.Text = "Usuario:";
            // 
            // LblUsername
            // 
            this.LblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblUsername.Location = new System.Drawing.Point(82, 716);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(275, 16);
            this.LblUsername.TabIndex = 167;
            // 
            // LblVersion
            // 
            this.LblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblVersion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblVersion.Location = new System.Drawing.Point(363, 716);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(275, 16);
            this.LblVersion.TabIndex = 168;
            this.LblVersion.Text = "Publish Version";
            // 
            // BtnSalesOrder
            // 
            this.BtnSalesOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSalesOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnSalesOrder.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnSalesOrder.Appearance.Options.UseBackColor = true;
            this.BtnSalesOrder.Appearance.Options.UseFont = true;
            this.BtnSalesOrder.Appearance.Options.UseForeColor = true;
            this.BtnSalesOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSalesOrder.ImageOptions.SvgImage = global::POS.Properties.Resources.e_commerce;
            this.BtnSalesOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnSalesOrder.Location = new System.Drawing.Point(15, 316);
            this.BtnSalesOrder.Name = "BtnSalesOrder";
            this.BtnSalesOrder.Size = new System.Drawing.Size(314, 188);
            this.BtnSalesOrder.TabIndex = 4;
            this.BtnSalesOrder.Text = "Pedidos \r\nDomicilio";
            this.BtnSalesOrder.Click += new System.EventHandler(this.BtnSalesOrder_Click);
            // 
            // BtnChangePaymMode
            // 
            this.BtnChangePaymMode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnChangePaymMode.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnChangePaymMode.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnChangePaymMode.Appearance.Options.UseBackColor = true;
            this.BtnChangePaymMode.Appearance.Options.UseFont = true;
            this.BtnChangePaymMode.Appearance.Options.UseForeColor = true;
            this.BtnChangePaymMode.Appearance.Options.UseTextOptions = true;
            this.BtnChangePaymMode.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.BtnChangePaymMode.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnChangePaymMode.ImageOptions.SvgImage = global::POS.Properties.Resources.payment;
            this.BtnChangePaymMode.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnChangePaymMode.Location = new System.Drawing.Point(968, 120);
            this.BtnChangePaymMode.Name = "BtnChangePaymMode";
            this.BtnChangePaymMode.Size = new System.Drawing.Size(311, 189);
            this.BtnChangePaymMode.TabIndex = 3;
            this.BtnChangePaymMode.Text = "Cambio Forma \r\nPago";
            this.BtnChangePaymMode.Click += new System.EventHandler(this.BtnChangePaymMode_Click);
            // 
            // BtnGiftCardRedeem
            // 
            this.BtnGiftCardRedeem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnGiftCardRedeem.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnGiftCardRedeem.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnGiftCardRedeem.Appearance.Options.UseBackColor = true;
            this.BtnGiftCardRedeem.Appearance.Options.UseFont = true;
            this.BtnGiftCardRedeem.Appearance.Options.UseForeColor = true;
            this.BtnGiftCardRedeem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnGiftCardRedeem.ImageOptions.SvgImage = global::POS.Properties.Resources.bonus_exchange;
            this.BtnGiftCardRedeem.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnGiftCardRedeem.Location = new System.Drawing.Point(335, 315);
            this.BtnGiftCardRedeem.Name = "BtnGiftCardRedeem";
            this.BtnGiftCardRedeem.Size = new System.Drawing.Size(311, 188);
            this.BtnGiftCardRedeem.TabIndex = 5;
            this.BtnGiftCardRedeem.Text = "Canje \r\nBonos";
            this.BtnGiftCardRedeem.Click += new System.EventHandler(this.BtnGiftCardRedeem_Click);
            // 
            // BtnInvoiceCancel
            // 
            this.BtnInvoiceCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnInvoiceCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnInvoiceCancel.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnInvoiceCancel.Appearance.Options.UseBackColor = true;
            this.BtnInvoiceCancel.Appearance.Options.UseFont = true;
            this.BtnInvoiceCancel.Appearance.Options.UseForeColor = true;
            this.BtnInvoiceCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnInvoiceCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel_invoice;
            this.BtnInvoiceCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnInvoiceCancel.Location = new System.Drawing.Point(969, 316);
            this.BtnInvoiceCancel.Name = "BtnInvoiceCancel";
            this.BtnInvoiceCancel.Size = new System.Drawing.Size(311, 188);
            this.BtnInvoiceCancel.TabIndex = 7;
            this.BtnInvoiceCancel.Text = "Anulacion\r\nFactura";
            this.BtnInvoiceCancel.Click += new System.EventHandler(this.BtnInvoiceCancel_Click);
            // 
            // BtnPhysicalInventory
            // 
            this.BtnPhysicalInventory.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPhysicalInventory.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPhysicalInventory.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnPhysicalInventory.Appearance.Options.UseBackColor = true;
            this.BtnPhysicalInventory.Appearance.Options.UseFont = true;
            this.BtnPhysicalInventory.Appearance.Options.UseForeColor = true;
            this.BtnPhysicalInventory.Appearance.Options.UseTextOptions = true;
            this.BtnPhysicalInventory.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.BtnPhysicalInventory.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPhysicalInventory.ImageOptions.SvgImage = global::POS.Properties.Resources.inventory;
            this.BtnPhysicalInventory.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnPhysicalInventory.Location = new System.Drawing.Point(652, 315);
            this.BtnPhysicalInventory.Name = "BtnPhysicalInventory";
            this.BtnPhysicalInventory.Size = new System.Drawing.Size(311, 188);
            this.BtnPhysicalInventory.TabIndex = 6;
            this.BtnPhysicalInventory.Text = "Toma de Inventario";
            this.BtnPhysicalInventory.Click += new System.EventHandler(this.BtnPhysicalInventory_Click);
            // 
            // btnArqueo
            // 
            this.btnArqueo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.btnArqueo.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.btnArqueo.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.btnArqueo.Appearance.Options.UseBackColor = true;
            this.btnArqueo.Appearance.Options.UseFont = true;
            this.btnArqueo.Appearance.Options.UseForeColor = true;
            this.btnArqueo.ImageOptions.Image = global::POS.Properties.Resources.CajaRegi3;
            this.btnArqueo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnArqueo.ImageOptions.SvgImageSize = new System.Drawing.Size(115, 115);
            this.btnArqueo.Location = new System.Drawing.Point(15, 510);
            this.btnArqueo.Name = "btnArqueo";
            this.btnArqueo.Size = new System.Drawing.Size(314, 184);
            this.btnArqueo.TabIndex = 8;
            this.btnArqueo.Text = "Arqueo";
            this.btnArqueo.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.BtnLogOut;
            this.ClientSize = new System.Drawing.Size(1378, 744);
            this.ControlBox = false;
            this.Controls.Add(this.btnArqueo);
            this.Controls.Add(this.BtnPhysicalInventory);
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
        private DevExpress.XtraEditors.SimpleButton BtnPhysicalInventory;
        private DevExpress.XtraEditors.SimpleButton btnArqueo;
    }
}