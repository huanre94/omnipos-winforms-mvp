namespace POS
{
    partial class FrmPaymentWithhold2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentWithhold2));
            this.BtnKeypad = new DevExpress.XtraEditors.SimpleButton();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblTitleAmount = new System.Windows.Forms.Label();
            this.TxtNAutorization = new DevExpress.XtraEditors.TextEdit();
            this.LblGiftCard = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNRetention = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeypadRet = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTaxPercent = new System.Windows.Forms.Label();
            this.LblTaxBase = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNAutorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNRetention.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnKeypad.Location = new System.Drawing.Point(428, 178);
            this.BtnKeypad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypad.Name = "BtnKeypad";
            this.BtnKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypad.Size = new System.Drawing.Size(78, 50);
            this.BtnKeypad.TabIndex = 20;
            this.BtnKeypad.Click += new System.EventHandler(this.BtnKeypad_Click);
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblAmount.Location = new System.Drawing.Point(280, 117);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(47, 18);
            this.LblAmount.TabIndex = 30;
            this.LblAmount.Text = "0.00";
            this.LblAmount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LblTitleAmount
            // 
            this.LblTitleAmount.AutoSize = true;
            this.LblTitleAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleAmount.Location = new System.Drawing.Point(63, 117);
            this.LblTitleAmount.Name = "LblTitleAmount";
            this.LblTitleAmount.Size = new System.Drawing.Size(172, 18);
            this.LblTitleAmount.TabIndex = 29;
            this.LblTitleAmount.Text = "Valor Retenido         $";
            // 
            // TxtNAutorization
            // 
            this.TxtNAutorization.Location = new System.Drawing.Point(200, 183);
            this.TxtNAutorization.Name = "TxtNAutorization";
            this.TxtNAutorization.Size = new System.Drawing.Size(219, 38);
            this.TxtNAutorization.TabIndex = 19;
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(63, 192);
            this.LblGiftCard.Name = "LblGiftCard";
            this.LblGiftCard.Size = new System.Drawing.Size(131, 18);
            this.LblGiftCard.TabIndex = 24;
            this.LblGiftCard.Text = "N° Autorizacion";
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
            this.BtnAccept.Location = new System.Drawing.Point(414, 328);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 22;
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
            this.BtnCancel.Location = new System.Drawing.Point(244, 328);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 23;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(63, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "N° Retencion";
            // 
            // TxtNRetention
            // 
            this.TxtNRetention.Location = new System.Drawing.Point(200, 238);
            this.TxtNRetention.Name = "TxtNRetention";
            this.TxtNRetention.Size = new System.Drawing.Size(219, 38);
            this.TxtNRetention.TabIndex = 19;
            // 
            // BtnKeypadRet
            // 
            this.BtnKeypadRet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadRet.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadRet.Appearance.Options.UseBackColor = true;
            this.BtnKeypadRet.Appearance.Options.UseFont = true;
            this.BtnKeypadRet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadRet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.BtnKeypadRet.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadRet.Location = new System.Drawing.Point(428, 233);
            this.BtnKeypadRet.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadRet.Name = "BtnKeypadRet";
            this.BtnKeypadRet.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadRet.Size = new System.Drawing.Size(78, 50);
            this.BtnKeypadRet.TabIndex = 20;
            this.BtnKeypadRet.Click += new System.EventHandler(this.BtnKeypadRet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(63, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "Porcentaje Retenido";
            // 
            // LblTaxPercent
            // 
            this.LblTaxPercent.AutoSize = true;
            this.LblTaxPercent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxPercent.Location = new System.Drawing.Point(280, 76);
            this.LblTaxPercent.Name = "LblTaxPercent";
            this.LblTaxPercent.Size = new System.Drawing.Size(67, 18);
            this.LblTaxPercent.TabIndex = 30;
            this.LblTaxPercent.Text = "0.00 %";
            // 
            // LblTaxBase
            // 
            this.LblTaxBase.AutoSize = true;
            this.LblTaxBase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxBase.Location = new System.Drawing.Point(280, 34);
            this.LblTaxBase.Name = "LblTaxBase";
            this.LblTaxBase.Size = new System.Drawing.Size(47, 18);
            this.LblTaxBase.TabIndex = 32;
            this.LblTaxBase.Text = "0.00";
            this.LblTaxBase.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(63, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Base Imponible        $";
            // 
            // FrmPaymentWithhold2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 392);
            this.ControlBox = false;
            this.Controls.Add(this.LblTaxBase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnKeypadRet);
            this.Controls.Add(this.BtnKeypad);
            this.Controls.Add(this.LblTaxPercent);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitleAmount);
            this.Controls.Add(this.TxtNRetention);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNAutorization);
            this.Controls.Add(this.LblGiftCard);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentWithhold2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retencion";
            this.Load += new System.EventHandler(this.FrmPaymentWithhold2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNAutorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNRetention.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnKeypad;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblTitleAmount;
        public DevExpress.XtraEditors.TextEdit TxtNAutorization;
        private System.Windows.Forms.Label LblGiftCard;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit TxtNRetention;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadRet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTaxPercent;
        private System.Windows.Forms.Label LblTaxBase;
        private System.Windows.Forms.Label label5;
    }
}