namespace POS
{
    partial class FrmPaymentWithhold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentWithhold));
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
            this.LblBasePercent = new System.Windows.Forms.Label();
            this.LblBaseAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTaxAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblTaxBaseAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbTaxPercent = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNAutorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNRetention.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTaxPercent.Properties)).BeginInit();
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
            this.BtnKeypad.Location = new System.Drawing.Point(518, 192);
            this.BtnKeypad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypad.Name = "BtnKeypad";
            this.BtnKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypad.Size = new System.Drawing.Size(77, 50);
            this.BtnKeypad.TabIndex = 20;
            this.BtnKeypad.Click += new System.EventHandler(this.BtnKeypad_Click);
            // 
            // LblAmount
            // 
            this.LblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblAmount.Location = new System.Drawing.Point(232, 137);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(88, 18);
            this.LblAmount.TabIndex = 30;
            this.LblAmount.Text = "0.00";
            this.LblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleAmount
            // 
            this.LblTitleAmount.AutoSize = true;
            this.LblTitleAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleAmount.Location = new System.Drawing.Point(46, 137);
            this.LblTitleAmount.Name = "LblTitleAmount";
            this.LblTitleAmount.Size = new System.Drawing.Size(180, 18);
            this.LblTitleAmount.TabIndex = 29;
            this.LblTitleAmount.Text = "Valor Retenido           $";
            // 
            // TxtNAutorization
            // 
            this.TxtNAutorization.Location = new System.Drawing.Point(290, 197);
            this.TxtNAutorization.Name = "TxtNAutorization";
            this.TxtNAutorization.Size = new System.Drawing.Size(218, 38);
            this.TxtNAutorization.TabIndex = 19;
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(153, 206);
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
            this.BtnAccept.Location = new System.Drawing.Point(570, 327);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(159, 50);
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
            this.BtnCancel.Location = new System.Drawing.Point(400, 327);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(159, 50);
            this.BtnCancel.TabIndex = 23;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(153, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "N° Retencion";
            // 
            // TxtNRetention
            // 
            this.TxtNRetention.Location = new System.Drawing.Point(290, 252);
            this.TxtNRetention.Name = "TxtNRetention";
            this.TxtNRetention.Size = new System.Drawing.Size(218, 38);
            this.TxtNRetention.TabIndex = 19;
            // 
            // BtnKeypadRet
            // 
            this.BtnKeypadRet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadRet.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadRet.Appearance.Options.UseBackColor = true;
            this.BtnKeypadRet.Appearance.Options.UseFont = true;
            this.BtnKeypadRet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadRet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadRet.ImageOptions.SvgImage")));
            this.BtnKeypadRet.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadRet.Location = new System.Drawing.Point(518, 247);
            this.BtnKeypadRet.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadRet.Name = "BtnKeypadRet";
            this.BtnKeypadRet.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadRet.Size = new System.Drawing.Size(77, 50);
            this.BtnKeypadRet.TabIndex = 20;
            this.BtnKeypadRet.Click += new System.EventHandler(this.BtnKeypadRet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(46, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "Porcentaje Retenido";
            // 
            // LblBasePercent
            //            
            this.LblBasePercent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblBasePercent.Location = new System.Drawing.Point(253, 96);
            this.LblBasePercent.Name = "LblBasePercent";
            this.LblBasePercent.Size = new System.Drawing.Size(67, 18);
            this.LblBasePercent.TabIndex = 30;
            this.LblBasePercent.Text = "0.00";
            this.LblBasePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblBaseAmount
            // 
            this.LblBaseAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblBaseAmount.Location = new System.Drawing.Point(235, 54);
            this.LblBaseAmount.Name = "LblBaseAmount";
            this.LblBaseAmount.Size = new System.Drawing.Size(85, 18);
            this.LblBaseAmount.TabIndex = 32;
            this.LblBaseAmount.Text = "0.00";
            this.LblBaseAmount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(46, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Base Imponible IVA  $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label3.Location = new System.Drawing.Point(408, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Valor Retenido           $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(408, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Porcentaje Retenido";
            // 
            // LblTaxAmount
            // 
            this.LblTaxAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxAmount.Location = new System.Drawing.Point(597, 137);
            this.LblTaxAmount.Name = "LblTaxAmount";
            this.LblTaxAmount.Size = new System.Drawing.Size(98, 18);
            this.LblTaxAmount.TabIndex = 30;
            this.LblTaxAmount.Text = "0.00";
            this.LblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label8.Location = new System.Drawing.Point(408, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Base Imponible IVA  $";
            // 
            // LblTaxBaseAmount
            // 
            this.LblTaxBaseAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxBaseAmount.Location = new System.Drawing.Point(594, 54);
            this.LblTaxBaseAmount.Name = "LblTaxBaseAmount";
            this.LblTaxBaseAmount.Size = new System.Drawing.Size(98, 18);
            this.LblTaxBaseAmount.TabIndex = 32;
            this.LblTaxBaseAmount.Text = "0.00";
            this.LblTaxBaseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label10.Location = new System.Drawing.Point(46, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "Calculo Rte. Fuente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label11.Location = new System.Drawing.Point(408, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 18);
            this.label11.TabIndex = 33;
            this.label11.Text = "Calculo Rte. IVA";
            // 
            // CmbTaxPercent
            // 
            this.CmbTaxPercent.Location = new System.Drawing.Point(597, 87);
            this.CmbTaxPercent.Name = "CmbTaxPercent";
            this.CmbTaxPercent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTaxPercent.Size = new System.Drawing.Size(109, 38);
            this.CmbTaxPercent.TabIndex = 34;
            this.CmbTaxPercent.SelectedIndexChanged += new System.EventHandler(this.CmbTaxPercent_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(326, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmPaymentWithhold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 400);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbTaxPercent);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblTaxBaseAmount);
            this.Controls.Add(this.LblBaseAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnKeypadRet);
            this.Controls.Add(this.BtnKeypad);
            this.Controls.Add(this.LblBasePercent);
            this.Controls.Add(this.LblTaxAmount);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTitleAmount);
            this.Controls.Add(this.TxtNRetention);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNAutorization);
            this.Controls.Add(this.LblGiftCard);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentWithhold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retencion";
            this.Load += new System.EventHandler(this.FrmPaymentWithhold2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNAutorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNRetention.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTaxPercent.Properties)).EndInit();
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
        private System.Windows.Forms.Label LblBasePercent;
        private System.Windows.Forms.Label LblBaseAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblTaxAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblTaxBaseAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public DevExpress.XtraEditors.ImageComboBoxEdit CmbTaxPercent;
        private System.Windows.Forms.Label label6;
    }
}