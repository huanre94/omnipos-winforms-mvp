namespace POS
{
    partial class FrmPaymentGiftcard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentGiftcard));
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.LblGiftCard = new System.Windows.Forms.Label();
            this.TxtGiftCard = new DevExpress.XtraEditors.TextEdit();
            this.LblTitleDocument = new System.Windows.Forms.Label();
            this.LblDocument = new System.Windows.Forms.Label();
            this.LblReference = new System.Windows.Forms.Label();
            this.LblTitleReference = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblTitleAmount = new System.Windows.Forms.Label();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeypad = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCard.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnAccept.Location = new System.Drawing.Point(395, 263);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 3;
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
            this.BtnCancel.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(225, 263);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(45, 43);
            this.LblGiftCard.Name = "LblGiftCard";
            this.LblGiftCard.Size = new System.Drawing.Size(81, 18);
            this.LblGiftCard.TabIndex = 11;
            this.LblGiftCard.Text = "No. Bono";
            // 
            // TxtGiftCard
            // 
            this.TxtGiftCard.Location = new System.Drawing.Point(162, 32);
            this.TxtGiftCard.Name = "TxtGiftCard";
            this.TxtGiftCard.Size = new System.Drawing.Size(219, 38);
            this.TxtGiftCard.TabIndex = 1;
            // 
            // LblTitleDocument
            // 
            this.LblTitleDocument.AutoSize = true;
            this.LblTitleDocument.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleDocument.Location = new System.Drawing.Point(45, 95);
            this.LblTitleDocument.Name = "LblTitleDocument";
            this.LblTitleDocument.Size = new System.Drawing.Size(100, 18);
            this.LblTitleDocument.TabIndex = 13;
            this.LblTitleDocument.Text = "Documento";
            // 
            // LblDocument
            // 
            this.LblDocument.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblDocument.Location = new System.Drawing.Point(159, 95);
            this.LblDocument.Name = "LblDocument";
            this.LblDocument.Size = new System.Drawing.Size(363, 18);
            this.LblDocument.TabIndex = 14;
            // 
            // LblReference
            // 
            this.LblReference.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblReference.Location = new System.Drawing.Point(159, 147);
            this.LblReference.Name = "LblReference";
            this.LblReference.Size = new System.Drawing.Size(363, 18);
            this.LblReference.TabIndex = 16;
            // 
            // LblTitleReference
            // 
            this.LblTitleReference.AutoSize = true;
            this.LblTitleReference.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleReference.Location = new System.Drawing.Point(45, 147);
            this.LblTitleReference.Name = "LblTitleReference";
            this.LblTitleReference.Size = new System.Drawing.Size(96, 18);
            this.LblTitleReference.TabIndex = 15;
            this.LblTitleReference.Text = "Referencia";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblAmount.Location = new System.Drawing.Point(159, 199);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(0, 18);
            this.LblAmount.TabIndex = 18;
            // 
            // LblTitleAmount
            // 
            this.LblTitleAmount.AutoSize = true;
            this.LblTitleAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleAmount.Location = new System.Drawing.Point(45, 199);
            this.LblTitleAmount.Name = "LblTitleAmount";
            this.LblTitleAmount.Size = new System.Drawing.Size(100, 18);
            this.LblTitleAmount.TabIndex = 17;
            this.LblTitleAmount.Text = "Valor          $";
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
            this.BtnSearch.Location = new System.Drawing.Point(469, 22);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnKeypad
            // 
            this.BtnKeypad.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypad.Appearance.Options.UseBackColor = true;
            this.BtnKeypad.Appearance.Options.UseFont = true;
            this.BtnKeypad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypad.ImageOptions.SvgImage")));
            this.BtnKeypad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypad.Location = new System.Drawing.Point(390, 27);
            this.BtnKeypad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypad.Name = "BtnKeypad";
            this.BtnKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypad.Size = new System.Drawing.Size(78, 50);
            this.BtnKeypad.TabIndex = 2;
            this.BtnKeypad.Click += new System.EventHandler(this.BtnKeypad_Click);
            // 
            // FrmPaymentGiftcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 327);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeypad);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblTitleAmount);
            this.Controls.Add(this.LblReference);
            this.Controls.Add(this.LblTitleReference);
            this.Controls.Add(this.LblDocument);
            this.Controls.Add(this.LblTitleDocument);
            this.Controls.Add(this.TxtGiftCard);
            this.Controls.Add(this.LblGiftCard);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentGiftcard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bono / Gift Card";
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCard.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label LblGiftCard;
        public DevExpress.XtraEditors.TextEdit TxtGiftCard;
        private System.Windows.Forms.Label LblTitleDocument;
        private System.Windows.Forms.Label LblDocument;
        private System.Windows.Forms.Label LblReference;
        private System.Windows.Forms.Label LblTitleReference;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblTitleAmount;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private DevExpress.XtraEditors.SimpleButton BtnKeypad;
    }
}