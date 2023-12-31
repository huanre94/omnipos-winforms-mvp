﻿namespace POS
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
            this.BtnAuthorizationKeypad = new DevExpress.XtraEditors.SimpleButton();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblTitleAmount = new System.Windows.Forms.Label();
            this.TxtNAutorization = new DevExpress.XtraEditors.TextEdit();
            this.LblGiftCard = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNRetention = new DevExpress.XtraEditors.TextEdit();
            this.BtnWithholdNumberKeypad = new DevExpress.XtraEditors.SimpleButton();
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
            // BtnAuthorizationKeypad
            // 
            this.BtnAuthorizationKeypad.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnAuthorizationKeypad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAuthorizationKeypad.Appearance.Options.UseBackColor = true;
            this.BtnAuthorizationKeypad.Appearance.Options.UseFont = true;
            this.BtnAuthorizationKeypad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnAuthorizationKeypad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypad.ImageOptions.SvgImage")));
            this.BtnAuthorizationKeypad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnAuthorizationKeypad.Location = new System.Drawing.Point(633, 240);
            this.BtnAuthorizationKeypad.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnAuthorizationKeypad.Name = "BtnAuthorizationKeypad";
            this.BtnAuthorizationKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnAuthorizationKeypad.Size = new System.Drawing.Size(94, 62);
            this.BtnAuthorizationKeypad.TabIndex = 20;
            this.BtnAuthorizationKeypad.Click += new System.EventHandler(this.BtnKeypad_Click);
            // 
            // LblAmount
            // 
            this.LblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblAmount.Location = new System.Drawing.Point(284, 171);
            this.LblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(108, 22);
            this.LblAmount.TabIndex = 30;
            this.LblAmount.Text = "0.00";
            this.LblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleAmount
            // 
            this.LblTitleAmount.AutoSize = true;
            this.LblTitleAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleAmount.Location = new System.Drawing.Point(56, 171);
            this.LblTitleAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitleAmount.Name = "LblTitleAmount";
            this.LblTitleAmount.Size = new System.Drawing.Size(221, 23);
            this.LblTitleAmount.TabIndex = 29;
            this.LblTitleAmount.Text = "Valor Retenido           $";
            // 
            // TxtNAutorization
            // 
            this.TxtNAutorization.Location = new System.Drawing.Point(354, 246);
            this.TxtNAutorization.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNAutorization.Name = "TxtNAutorization";
            this.TxtNAutorization.Size = new System.Drawing.Size(266, 30);
            this.TxtNAutorization.TabIndex = 19;
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(187, 258);
            this.LblGiftCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblGiftCard.Name = "LblGiftCard";
            this.LblGiftCard.Size = new System.Drawing.Size(160, 23);
            this.LblGiftCard.TabIndex = 24;
            this.LblGiftCard.Text = "N° Autorizacion";
            // 
            // BtnAccept
            // 
            this.BtnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAccept.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnAccept.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnAccept.Appearance.Options.UseBackColor = true;
            this.BtnAccept.Appearance.Options.UseFont = true;
            this.BtnAccept.Appearance.Options.UseForeColor = true;
            this.BtnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAccept.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAccept.ImageOptions.SvgImage = global::POS.Properties.Resources.accept2;
            this.BtnAccept.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnAccept.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnAccept.Location = new System.Drawing.Point(697, 420);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(6);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(194, 62);
            this.BtnAccept.TabIndex = 22;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.Appearance.Options.UseForeColor = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnCancel.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(489, 420);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(194, 62);
            this.BtnCancel.TabIndex = 23;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(187, 326);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "N° Retencion";
            // 
            // TxtNRetention
            // 
            this.TxtNRetention.Location = new System.Drawing.Point(354, 315);
            this.TxtNRetention.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNRetention.Name = "TxtNRetention";
            this.TxtNRetention.Size = new System.Drawing.Size(266, 30);
            this.TxtNRetention.TabIndex = 19;
            // 
            // BtnWithholdNumberKeypad
            // 
            this.BtnWithholdNumberKeypad.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnWithholdNumberKeypad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnWithholdNumberKeypad.Appearance.Options.UseBackColor = true;
            this.BtnWithholdNumberKeypad.Appearance.Options.UseFont = true;
            this.BtnWithholdNumberKeypad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnWithholdNumberKeypad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadRet.ImageOptions.SvgImage")));
            this.BtnWithholdNumberKeypad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnWithholdNumberKeypad.Location = new System.Drawing.Point(633, 309);
            this.BtnWithholdNumberKeypad.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnWithholdNumberKeypad.Name = "BtnWithholdNumberKeypad";
            this.BtnWithholdNumberKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnWithholdNumberKeypad.Size = new System.Drawing.Size(94, 62);
            this.BtnWithholdNumberKeypad.TabIndex = 20;
            this.BtnWithholdNumberKeypad.Click += new System.EventHandler(this.BtnKeypadRet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(56, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Porcentaje Retenido";
            // 
            // LblBasePercent
            // 
            this.LblBasePercent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblBasePercent.Location = new System.Drawing.Point(309, 120);
            this.LblBasePercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBasePercent.Name = "LblBasePercent";
            this.LblBasePercent.Size = new System.Drawing.Size(82, 22);
            this.LblBasePercent.TabIndex = 30;
            this.LblBasePercent.Text = "0.00";
            this.LblBasePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblBaseAmount
            // 
            this.LblBaseAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblBaseAmount.Location = new System.Drawing.Point(287, 68);
            this.LblBaseAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBaseAmount.Name = "LblBaseAmount";
            this.LblBaseAmount.Size = new System.Drawing.Size(104, 22);
            this.LblBaseAmount.TabIndex = 32;
            this.LblBaseAmount.Text = "0.00";
            this.LblBaseAmount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label5.Location = new System.Drawing.Point(56, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Base Imponible IVA  $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label3.Location = new System.Drawing.Point(499, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Valor Retenido           $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(499, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Porcentaje Retenido";
            // 
            // LblTaxAmount
            // 
            this.LblTaxAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxAmount.Location = new System.Drawing.Point(730, 171);
            this.LblTaxAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTaxAmount.Name = "LblTaxAmount";
            this.LblTaxAmount.Size = new System.Drawing.Size(120, 22);
            this.LblTaxAmount.TabIndex = 30;
            this.LblTaxAmount.Text = "0.00";
            this.LblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label8.Location = new System.Drawing.Point(499, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "Base Imponible IVA  $";
            // 
            // LblTaxBaseAmount
            // 
            this.LblTaxBaseAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblTaxBaseAmount.Location = new System.Drawing.Point(726, 68);
            this.LblTaxBaseAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTaxBaseAmount.Name = "LblTaxBaseAmount";
            this.LblTaxBaseAmount.Size = new System.Drawing.Size(120, 22);
            this.LblTaxBaseAmount.TabIndex = 32;
            this.LblTaxBaseAmount.Text = "0.00";
            this.LblTaxBaseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label10.Location = new System.Drawing.Point(56, 11);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 23);
            this.label10.TabIndex = 33;
            this.label10.Text = "Calculo Rte. Fuente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label11.Location = new System.Drawing.Point(499, 11);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "Calculo Rte. IVA";
            // 
            // CmbTaxPercent
            // 
            this.CmbTaxPercent.Location = new System.Drawing.Point(730, 109);
            this.CmbTaxPercent.Margin = new System.Windows.Forms.Padding(4);
            this.CmbTaxPercent.Name = "CmbTaxPercent";
            this.CmbTaxPercent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTaxPercent.Size = new System.Drawing.Size(133, 30);
            this.CmbTaxPercent.TabIndex = 34;
            this.CmbTaxPercent.SelectedIndexChanged += new System.EventHandler(this.CmbTaxPercent_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(398, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 22);
            this.label6.TabIndex = 35;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmPaymentWithhold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(908, 500);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbTaxPercent);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblTaxBaseAmount);
            this.Controls.Add(this.LblBaseAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnWithholdNumberKeypad);
            this.Controls.Add(this.BtnAuthorizationKeypad);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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

        private DevExpress.XtraEditors.SimpleButton BtnAuthorizationKeypad;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblTitleAmount;
        public DevExpress.XtraEditors.TextEdit TxtNAutorization;
        private System.Windows.Forms.Label LblGiftCard;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit TxtNRetention;
        private DevExpress.XtraEditors.SimpleButton BtnWithholdNumberKeypad;
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