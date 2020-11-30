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
            this.SuspendLayout();
            // 
            // BtnPOS
            // 
            this.BtnPOS.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPOS.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPOS.Appearance.Options.UseBackColor = true;
            this.BtnPOS.Appearance.Options.UseFont = true;
            this.BtnPOS.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPOS.ImageOptions.SvgImage = global::POS.Properties.Resources.retail;
            this.BtnPOS.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.BtnPOS.Location = new System.Drawing.Point(33, 120);
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
            this.BtnCloseCashier.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCloseCashier.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnCloseCashier.Appearance.Options.UseBackColor = true;
            this.BtnCloseCashier.Appearance.Options.UseFont = true;
            this.BtnCloseCashier.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCloseCashier.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier;
            this.BtnCloseCashier.ImageOptions.SvgImageSize = new System.Drawing.Size(115, 115);
            this.BtnCloseCashier.Location = new System.Drawing.Point(408, 120);
            this.BtnCloseCashier.Name = "BtnCloseCashier";
            this.BtnCloseCashier.Size = new System.Drawing.Size(350, 200);
            this.BtnCloseCashier.TabIndex = 149;
            this.BtnCloseCashier.Text = "Cierre Caja";
            this.BtnCloseCashier.Click += new System.EventHandler(this.BtnCloseCashier_Click);
            // 
            // BtnPartialClosing
            // 
            this.BtnPartialClosing.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPartialClosing.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPartialClosing.Appearance.Options.UseBackColor = true;
            this.BtnPartialClosing.Appearance.Options.UseFont = true;
            this.BtnPartialClosing.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPartialClosing.ImageOptions.SvgImage = global::POS.Properties.Resources.cashier_partial;
            this.BtnPartialClosing.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnPartialClosing.Location = new System.Drawing.Point(783, 120);
            this.BtnPartialClosing.Name = "BtnPartialClosing";
            this.BtnPartialClosing.Size = new System.Drawing.Size(350, 200);
            this.BtnPartialClosing.TabIndex = 149;
            this.BtnPartialClosing.Text = "Cierre Caja \r\nParcial";
            this.BtnPartialClosing.Click += new System.EventHandler(this.BtnPartialClosing_Click);
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLogOut.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnLogOut.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnLogOut.Appearance.Options.UseBackColor = true;
            this.BtnLogOut.Appearance.Options.UseFont = true;
            this.BtnLogOut.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnLogOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnLogOut.ImageOptions.SvgImage")));
            this.BtnLogOut.Location = new System.Drawing.Point(1102, 661);
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
            this.LblTitleUsername.Location = new System.Drawing.Point(12, 690);
            this.LblTitleUsername.Name = "LblTitleUsername";
            this.LblTitleUsername.Size = new System.Drawing.Size(65, 16);
            this.LblTitleUsername.TabIndex = 166;
            this.LblTitleUsername.Text = "Usuario:";
            // 
            // LblUsername
            // 
            this.LblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblUsername.Location = new System.Drawing.Point(83, 690);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(275, 16);
            this.LblUsername.TabIndex = 167;
            // 
            // LblVersion
            // 
            this.LblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblVersion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.LblVersion.Location = new System.Drawing.Point(364, 690);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(275, 16);
            this.LblVersion.TabIndex = 168;
            this.LblVersion.Text = "Publish Version";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 718);
            this.ControlBox = false;
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblTitleUsername);
            this.Controls.Add(this.BtnPartialClosing);
            this.Controls.Add(this.BtnLogOut);
            this.Controls.Add(this.BtnCloseCashier);
            this.Controls.Add(this.LblTitle);
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
    }
}