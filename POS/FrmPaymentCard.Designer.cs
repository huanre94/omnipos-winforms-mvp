namespace POS
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
            this.CmbCardBrand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CmbCardBank = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LblCardType = new System.Windows.Forms.Label();
            this.LblCardBank = new System.Windows.Forms.Label();
            this.LblCardBrand = new System.Windows.Forms.Label();
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.BtnKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.TxtAuthorization = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbCardType
            // 
            this.CmbCardType.Location = new System.Drawing.Point(147, 47);
            this.CmbCardType.Name = "CmbCardType";
            this.CmbCardType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardType.Size = new System.Drawing.Size(151, 38);
            this.CmbCardType.TabIndex = 0;
            // 
            // CmbCardBrand
            // 
            this.CmbCardBrand.Location = new System.Drawing.Point(147, 135);
            this.CmbCardBrand.Name = "CmbCardBrand";
            this.CmbCardBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardBrand.Size = new System.Drawing.Size(151, 38);
            this.CmbCardBrand.TabIndex = 1;
            // 
            // CmbCardBank
            // 
            this.CmbCardBank.Location = new System.Drawing.Point(147, 91);
            this.CmbCardBank.Name = "CmbCardBank";
            this.CmbCardBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCardBank.Size = new System.Drawing.Size(151, 38);
            this.CmbCardBank.TabIndex = 2;
            // 
            // LblCardType
            // 
            this.LblCardType.AutoSize = true;
            this.LblCardType.Location = new System.Drawing.Point(30, 58);
            this.LblCardType.Name = "LblCardType";
            this.LblCardType.Size = new System.Drawing.Size(38, 16);
            this.LblCardType.TabIndex = 3;
            this.LblCardType.Text = "Tipo";
            // 
            // LblCardBank
            // 
            this.LblCardBank.AutoSize = true;
            this.LblCardBank.Location = new System.Drawing.Point(30, 102);
            this.LblCardBank.Name = "LblCardBank";
            this.LblCardBank.Size = new System.Drawing.Size(50, 16);
            this.LblCardBank.TabIndex = 4;
            this.LblCardBank.Text = "Banco";
            // 
            // LblCardBrand
            // 
            this.LblCardBrand.AutoSize = true;
            this.LblCardBrand.Location = new System.Drawing.Point(30, 146);
            this.LblCardBrand.Name = "LblCardBrand";
            this.LblCardBrand.Size = new System.Drawing.Size(50, 16);
            this.LblCardBrand.TabIndex = 5;
            this.LblCardBrand.Text = "Marca";
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Location = new System.Drawing.Point(30, 194);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(92, 16);
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
            this.BtnKeyPad.Location = new System.Drawing.Point(302, 178);
            this.BtnKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyPad.Name = "BtnKeyPad";
            this.BtnKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyPad.TabIndex = 135;
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
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(114, 251);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 150;
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
            this.BtnAccept.Location = new System.Drawing.Point(284, 251);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 151;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // TxtAuthorization
            // 
            this.TxtAuthorization.Location = new System.Drawing.Point(147, 179);
            this.TxtAuthorization.Name = "TxtAuthorization";
            this.TxtAuthorization.Size = new System.Drawing.Size(151, 38);
            this.TxtAuthorization.TabIndex = 152;
            // 
            // FrmPaymentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.ControlBox = false;
            this.Controls.Add(this.TxtAuthorization);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnKeyPad);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.LblCardBrand);
            this.Controls.Add(this.LblCardBank);
            this.Controls.Add(this.LblCardType);
            this.Controls.Add(this.CmbCardBank);
            this.Controls.Add(this.CmbCardBrand);
            this.Controls.Add(this.CmbCardType);
            this.MaximizeBox = false;
            this.Name = "FrmPaymentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas de Credito";
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCardBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit CmbCardType;
        private DevExpress.XtraEditors.ComboBoxEdit CmbCardBrand;
        private DevExpress.XtraEditors.ComboBoxEdit CmbCardBank;
        private System.Windows.Forms.Label LblCardType;
        private System.Windows.Forms.Label LblCardBank;
        private System.Windows.Forms.Label LblCardBrand;
        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnKeyPad;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.TextEdit TxtAuthorization;
    }
}