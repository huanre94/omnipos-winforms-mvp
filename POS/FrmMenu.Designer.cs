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
            this.BtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPOS = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnCloseCashier = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnExit.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnExit.Appearance.Options.UseBackColor = true;
            this.BtnExit.Appearance.Options.UseFont = true;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnExit.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnExit.Location = new System.Drawing.Point(624, 486);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(160, 50);
            this.BtnExit.TabIndex = 24;
            this.BtnExit.Text = "Salir";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPOS
            // 
            this.BtnPOS.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPOS.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.BtnPOS.Appearance.Options.UseBackColor = true;
            this.BtnPOS.Appearance.Options.UseFont = true;
            this.BtnPOS.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPOS.ImageOptions.SvgImage = global::POS.Properties.Resources.retail;
            this.BtnPOS.ImageOptions.SvgImageSize = new System.Drawing.Size(65, 65);
            this.BtnPOS.Location = new System.Drawing.Point(33, 84);
            this.BtnPOS.Name = "BtnPOS";
            this.BtnPOS.Size = new System.Drawing.Size(350, 200);
            this.BtnPOS.TabIndex = 134;
            this.BtnPOS.Text = "POS   ";
            this.BtnPOS.Click += new System.EventHandler(this.BtnPOS_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F);
            this.LblTitle.Location = new System.Drawing.Point(250, 9);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(286, 34);
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
            this.BtnCloseCashier.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnCloseCashier.Location = new System.Drawing.Point(408, 84);
            this.BtnCloseCashier.Name = "BtnCloseCashier";
            this.BtnCloseCashier.Size = new System.Drawing.Size(350, 200);
            this.BtnCloseCashier.TabIndex = 149;
            this.BtnCloseCashier.Text = "Cierre Caja";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 550);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCloseCashier);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.BtnPOS);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private DevExpress.XtraEditors.SimpleButton BtnPOS;
        private System.Windows.Forms.Label LblTitle;
        private DevExpress.XtraEditors.SimpleButton BtnCloseCashier;
    }
}