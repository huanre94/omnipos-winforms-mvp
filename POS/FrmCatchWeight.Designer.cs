namespace POS
{
    partial class FrmCatchWeight
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
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblCatchedWeight = new System.Windows.Forms.Label();
            this.BtnCatchWeight = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.LblKg = new System.Windows.Forms.Label();
            this.LblProductName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblTitle.ForeColor = System.Drawing.Color.Goldenrod;
            this.LblTitle.Location = new System.Drawing.Point(117, 41);
            this.LblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(497, 35);
            this.LblTitle.TabIndex = 149;
            this.LblTitle.Text = "Coloque el Producto en la Balanza";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCatchedWeight
            // 
            this.LblCatchedWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 72F, System.Drawing.FontStyle.Bold);
            this.LblCatchedWeight.Location = new System.Drawing.Point(100, 158);
            this.LblCatchedWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCatchedWeight.Name = "LblCatchedWeight";
            this.LblCatchedWeight.Size = new System.Drawing.Size(450, 135);
            this.LblCatchedWeight.TabIndex = 150;
            this.LblCatchedWeight.Text = "0.000";
            this.LblCatchedWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnCatchWeight
            // 
            this.BtnCatchWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCatchWeight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCatchWeight.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCatchWeight.Appearance.Options.UseBackColor = true;
            this.BtnCatchWeight.Appearance.Options.UseFont = true;
            this.BtnCatchWeight.Appearance.Options.UseTextOptions = true;
            this.BtnCatchWeight.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.BtnCatchWeight.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnCatchWeight.ImageOptions.SvgImage = global::POS.Properties.Resources.scale;
            this.BtnCatchWeight.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnCatchWeight.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnCatchWeight.Location = new System.Drawing.Point(533, 151);
            this.BtnCatchWeight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnCatchWeight.Name = "BtnCatchWeight";
            this.BtnCatchWeight.Size = new System.Drawing.Size(154, 148);
            this.BtnCatchWeight.TabIndex = 155;
            this.BtnCatchWeight.Text = "Capturar Peso";
            this.BtnCatchWeight.Click += new System.EventHandler(this.BtnCatchWeight_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAccept.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAccept.Appearance.Options.UseBackColor = true;
            this.BtnAccept.Appearance.Options.UseFont = true;
            this.BtnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAccept.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAccept.ImageOptions.SvgImage = global::POS.Properties.Resources.accept2;
            this.BtnAccept.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAccept.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnAccept.Location = new System.Drawing.Point(263, 339);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(207, 69);
            this.BtnAccept.TabIndex = 154;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // LblKg
            // 
            this.LblKg.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.LblKg.Location = new System.Drawing.Point(22, 182);
            this.LblKg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblKg.Name = "LblKg";
            this.LblKg.Size = new System.Drawing.Size(94, 109);
            this.LblKg.TabIndex = 156;
            this.LblKg.Text = "Kg";
            this.LblKg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblProductName
            // 
            this.LblProductName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Bold);
            this.LblProductName.Location = new System.Drawing.Point(26, 108);
            this.LblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(661, 35);
            this.LblProductName.TabIndex = 157;
            this.LblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCatchWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 425);
            this.ControlBox = false;
            this.Controls.Add(this.LblProductName);
            this.Controls.Add(this.BtnCatchWeight);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.LblCatchedWeight);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblKg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCatchWeight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCatchWeight_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblCatchedWeight;
        private DevExpress.XtraEditors.SimpleButton BtnCatchWeight;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private System.Windows.Forms.Label LblKg;
        private System.Windows.Forms.Label LblProductName;
    }
}