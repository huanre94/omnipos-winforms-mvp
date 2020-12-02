namespace POS
{
    partial class FrmSalesOrigin
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
            this.ILBSalesOrigin = new DevExpress.XtraEditors.ImageListBoxControl();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ILBSalesOrigin)).BeginInit();
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
            this.BtnExit.Location = new System.Drawing.Point(204, 412);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(160, 50);
            this.BtnExit.TabIndex = 155;
            this.BtnExit.Text = "Salir";
            // 
            // ILBSalesOrigin
            // 
            this.ILBSalesOrigin.ItemHeight = 84;
            this.ILBSalesOrigin.Location = new System.Drawing.Point(12, 12);
            this.ILBSalesOrigin.Name = "ILBSalesOrigin";
            this.ILBSalesOrigin.Size = new System.Drawing.Size(522, 388);
            this.ILBSalesOrigin.TabIndex = 156;
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
            this.BtnAccept.Location = new System.Drawing.Point(374, 412);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 157;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // FrmSalesOrigin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 476);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.ILBSalesOrigin);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSalesOrigin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Origen de Venta";
            this.Load += new System.EventHandler(this.FrmSalesOrigin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ILBSalesOrigin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private DevExpress.XtraEditors.ImageListBoxControl ILBSalesOrigin;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
    }
}