﻿namespace POS
{
    partial class FrmPaymentCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentCard));
            this.CmbCardType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LblCardType = new System.Windows.Forms.Label();
            this.LblCardBank = new System.Windows.Forms.Label();
            this.LblCardBrand = new System.Windows.Forms.Label();
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.BtnKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.TxtAuthorization = new DevExpress.XtraEditors.TextEdit();
            this.CmbCardBank = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CmbCardBrand = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBrand.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbCardType
            // 
            this.CmbCardType.Location = new System.Drawing.Point(147, 47);
            this.CmbCardType.Name = "CmbCardType";
            this.CmbCardType.Properties.AutoComplete = false;
            this.CmbCardType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardType.Properties.CycleOnDblClick = false;
            this.CmbCardType.Properties.DropDownRows = 5;
            this.CmbCardType.Properties.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO"});
            this.CmbCardType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbCardType.Size = new System.Drawing.Size(286, 38);
            this.CmbCardType.TabIndex = 1;
            this.CmbCardType.SelectedIndexChanged += new System.EventHandler(this.CmbCardType_SelectedIndexChanged);
            // 
            // LblCardType
            // 
            this.LblCardType.AutoSize = true;
            this.LblCardType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCardType.Location = new System.Drawing.Point(30, 56);
            this.LblCardType.Name = "LblCardType";
            this.LblCardType.Size = new System.Drawing.Size(42, 18);
            this.LblCardType.TabIndex = 3;
            this.LblCardType.Text = "Tipo";
            // 
            // LblCardBank
            // 
            this.LblCardBank.AutoSize = true;
            this.LblCardBank.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCardBank.Location = new System.Drawing.Point(30, 110);
            this.LblCardBank.Name = "LblCardBank";
            this.LblCardBank.Size = new System.Drawing.Size(60, 18);
            this.LblCardBank.TabIndex = 4;
            this.LblCardBank.Text = "Banco";
            // 
            // LblCardBrand
            // 
            this.LblCardBrand.AutoSize = true;
            this.LblCardBrand.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblCardBrand.Location = new System.Drawing.Point(30, 162);
            this.LblCardBrand.Name = "LblCardBrand";
            this.LblCardBrand.Size = new System.Drawing.Size(58, 18);
            this.LblCardBrand.TabIndex = 5;
            this.LblCardBrand.Text = "Marca";
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAuthorization.Location = new System.Drawing.Point(30, 212);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(109, 18);
            this.LblAuthorization.TabIndex = 6;
            this.LblAuthorization.Text = "Autorizacion";
            // 
            // BtnKeyPad
            // 
            this.BtnKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeyPad.Appearance.Options.UseFont = true;
            this.BtnKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyPad.ImageOptions.SvgImage")));
            this.BtnKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeyPad.Location = new System.Drawing.Point(359, 202);
            this.BtnKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyPad.Name = "BtnKeyPad";
            this.BtnKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyPad.TabIndex = 5;
            this.BtnKeyPad.Click += new System.EventHandler(this.BtnKeyPad_Click);
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
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(174, 316);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancelar";
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
            this.BtnAccept.Location = new System.Drawing.Point(344, 316);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 6;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // TxtAuthorization
            // 
            this.TxtAuthorization.Location = new System.Drawing.Point(147, 203);
            this.TxtAuthorization.Name = "TxtAuthorization";
            this.TxtAuthorization.Size = new System.Drawing.Size(202, 38);
            this.TxtAuthorization.TabIndex = 4;
            // 
            // CmbCardBank
            // 
            this.CmbCardBank.Location = new System.Drawing.Point(147, 99);
            this.CmbCardBank.Name = "CmbCardBank";
            this.CmbCardBank.Properties.AutoComplete = false;
            this.CmbCardBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardBank.Properties.DropDownRows = 10;
            this.CmbCardBank.Size = new System.Drawing.Size(286, 38);
            this.CmbCardBank.TabIndex = 8;
            this.CmbCardBank.SelectedIndexChanged += new System.EventHandler(this.CmbCardBank_SelectedIndexChanged);
            // 
            // CmbCardBrand
            // 
            this.CmbCardBrand.Location = new System.Drawing.Point(147, 151);
            this.CmbCardBrand.Name = "CmbCardBrand";
            this.CmbCardBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardBrand.Properties.DropDownRows = 10;
            this.CmbCardBrand.Size = new System.Drawing.Size(286, 38);
            this.CmbCardBrand.TabIndex = 9;
            // 
            // FrmPaymentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 380);
            this.ControlBox = false;
            this.Controls.Add(this.CmbCardBrand);
            this.Controls.Add(this.CmbCardBank);
            this.Controls.Add(this.TxtAuthorization);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnKeyPad);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.LblCardBrand);
            this.Controls.Add(this.LblCardBank);
            this.Controls.Add(this.LblCardType);
            this.Controls.Add(this.CmbCardType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmPaymentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas de Credito";
            this.Load += new System.EventHandler(this.FrmPaymentCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBrand.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblCardType;
        private System.Windows.Forms.Label LblCardBank;
        private System.Windows.Forms.Label LblCardBrand;
        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnKeyPad;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.TextEdit TxtAuthorization;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbCardBank;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbCardBrand;
        public DevExpress.XtraEditors.ComboBoxEdit CmbCardType;
    }
}