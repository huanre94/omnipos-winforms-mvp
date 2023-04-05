
namespace POS
{
    partial class FrmVoidClosing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoidClosing));
            this.BtnVoid = new DevExpress.XtraEditors.SimpleButton();
            this.BtnClosingId = new DevExpress.XtraEditors.SimpleButton();
            this.TxtClosingId = new DevExpress.XtraEditors.TextEdit();
            this.LblClosingId = new System.Windows.Forms.Label();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClosingId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnVoid
            // 
            this.BtnVoid.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnVoid.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnVoid.Appearance.Options.UseBackColor = true;
            this.BtnVoid.Appearance.Options.UseFont = true;
            this.BtnVoid.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnVoid.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnVoid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnVoid.ImageOptions.SvgImage")));
            this.BtnVoid.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnVoid.Location = new System.Drawing.Point(604, 453);
            this.BtnVoid.Margin = new System.Windows.Forms.Padding(6);
            this.BtnVoid.Name = "BtnVoid";
            this.BtnVoid.Size = new System.Drawing.Size(196, 62);
            this.BtnVoid.TabIndex = 150;
            this.BtnVoid.Text = "Cancelar";
            // 
            // BtnClosingId
            // 
            this.BtnClosingId.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnClosingId.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnClosingId.Appearance.Options.UseBackColor = true;
            this.BtnClosingId.Appearance.Options.UseFont = true;
            this.BtnClosingId.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnClosingId.AppearanceHovered.Options.UseBackColor = true;
            this.BtnClosingId.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnClosingId.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnClosingId.ImageOptions.SvgImage")));
            this.BtnClosingId.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnClosingId.Location = new System.Drawing.Point(519, 6);
            this.BtnClosingId.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnClosingId.Name = "BtnClosingId";
            this.BtnClosingId.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnClosingId.Size = new System.Drawing.Size(98, 62);
            this.BtnClosingId.TabIndex = 171;
            // 
            // TxtClosingId
            // 
            this.TxtClosingId.Location = new System.Drawing.Point(250, 24);
            this.TxtClosingId.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClosingId.Name = "TxtClosingId";
            this.TxtClosingId.Size = new System.Drawing.Size(258, 30);
            this.TxtClosingId.TabIndex = 169;
            // 
            // LblClosingId
            // 
            this.LblClosingId.AutoSize = true;
            this.LblClosingId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblClosingId.Location = new System.Drawing.Point(100, 26);
            this.LblClosingId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClosingId.Name = "LblClosingId";
            this.LblClosingId.Size = new System.Drawing.Size(96, 23);
            this.LblClosingId.TabIndex = 170;
            this.LblClosingId.Text = "Id Cierre";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnSearch.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSearch.Appearance.Options.UseBackColor = true;
            this.BtnSearch.Appearance.Options.UseFont = true;
            this.BtnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnSearch.ImageOptions.SvgImage = global::POS.Properties.Resources.find;
            this.BtnSearch.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnSearch.Location = new System.Drawing.Point(629, 6);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 172;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmVoidClosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 530);
            this.ControlBox = false;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnClosingId);
            this.Controls.Add(this.TxtClosingId);
            this.Controls.Add(this.LblClosingId);
            this.Controls.Add(this.BtnVoid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVoidClosing";
            this.Text = "Anulacion Cierre";
            this.Load += new System.EventHandler(this.FrmVoidClosing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtClosingId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnVoid;
        private DevExpress.XtraEditors.SimpleButton BtnClosingId;
        private DevExpress.XtraEditors.TextEdit TxtClosingId;
        private System.Windows.Forms.Label LblClosingId;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
    }
}