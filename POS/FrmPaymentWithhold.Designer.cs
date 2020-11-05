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
            this.BtnKeypad = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblTitleAmount = new System.Windows.Forms.Label();
            this.LblReference = new System.Windows.Forms.Label();
            this.LblTitleReference = new System.Windows.Forms.Label();
            this.LblDocument = new System.Windows.Forms.Label();
            this.LblTitleDocument = new System.Windows.Forms.Label();
            this.TxtGiftCard = new DevExpress.XtraEditors.TextEdit();
            this.LblGiftCard = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCard.Properties)).BeginInit();
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
            this.BtnKeypad.Location = new System.Drawing.Point(381, 81);
            this.BtnKeypad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypad.Name = "BtnKeypad";
            this.BtnKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypad.Size = new System.Drawing.Size(78, 50);
            this.BtnKeypad.TabIndex = 20;
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
            this.BtnSearch.Location = new System.Drawing.Point(460, 76);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 21;
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblAmount.Location = new System.Drawing.Point(150, 253);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(0, 18);
            this.LblAmount.TabIndex = 30;
            // 
            // LblTitleAmount
            // 
            this.LblTitleAmount.AutoSize = true;
            this.LblTitleAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleAmount.Location = new System.Drawing.Point(36, 253);
            this.LblTitleAmount.Name = "LblTitleAmount";
            this.LblTitleAmount.Size = new System.Drawing.Size(100, 18);
            this.LblTitleAmount.TabIndex = 29;
            this.LblTitleAmount.Text = "Valor          $";
            // 
            // LblReference
            // 
            this.LblReference.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblReference.Location = new System.Drawing.Point(150, 201);
            this.LblReference.Name = "LblReference";
            this.LblReference.Size = new System.Drawing.Size(363, 18);
            this.LblReference.TabIndex = 28;
            // 
            // LblTitleReference
            // 
            this.LblTitleReference.AutoSize = true;
            this.LblTitleReference.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleReference.Location = new System.Drawing.Point(36, 201);
            this.LblTitleReference.Name = "LblTitleReference";
            this.LblTitleReference.Size = new System.Drawing.Size(96, 18);
            this.LblTitleReference.TabIndex = 27;
            this.LblTitleReference.Text = "Referencia";
            // 
            // LblDocument
            // 
            this.LblDocument.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblDocument.Location = new System.Drawing.Point(150, 149);
            this.LblDocument.Name = "LblDocument";
            this.LblDocument.Size = new System.Drawing.Size(363, 18);
            this.LblDocument.TabIndex = 26;
            // 
            // LblTitleDocument
            // 
            this.LblTitleDocument.AutoSize = true;
            this.LblTitleDocument.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleDocument.Location = new System.Drawing.Point(36, 149);
            this.LblTitleDocument.Name = "LblTitleDocument";
            this.LblTitleDocument.Size = new System.Drawing.Size(100, 18);
            this.LblTitleDocument.TabIndex = 25;
            this.LblTitleDocument.Text = "Documento";
            // 
            // TxtGiftCard
            // 
            this.TxtGiftCard.Location = new System.Drawing.Point(153, 86);
            this.TxtGiftCard.Name = "TxtGiftCard";
            this.TxtGiftCard.Size = new System.Drawing.Size(219, 38);
            this.TxtGiftCard.TabIndex = 19;
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(36, 97);
            this.LblGiftCard.Name = "LblGiftCard";
            this.LblGiftCard.Size = new System.Drawing.Size(81, 18);
            this.LblGiftCard.TabIndex = 24;
            this.LblGiftCard.Text = "No. Bono";
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
            this.BtnAccept.Location = new System.Drawing.Point(386, 317);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 22;
            this.BtnAccept.Text = "Aceptar";
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
            this.BtnCancel.Location = new System.Drawing.Point(216, 317);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 23;
            this.BtnCancel.Text = "Cancelar";
            // 
            // FrmPaymentWithhold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
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
            this.Name = "FrmPaymentWithhold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPaymentWithhold";
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCard.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnKeypad;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblTitleAmount;
        private System.Windows.Forms.Label LblReference;
        private System.Windows.Forms.Label LblTitleReference;
        private System.Windows.Forms.Label LblDocument;
        private System.Windows.Forms.Label LblTitleDocument;
        public DevExpress.XtraEditors.TextEdit TxtGiftCard;
        private System.Windows.Forms.Label LblGiftCard;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
    }
}