namespace POS
{
    partial class FrmPaymentCredit
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
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.TxtCreditCardCode = new DevExpress.XtraEditors.TextEdit();
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitleHolder = new System.Windows.Forms.Label();
            this.LblHolderName = new System.Windows.Forms.Label();
            this.LblCreditLimit = new System.Windows.Forms.Label();
            this.LblTitleCredit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCardCode.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnCancel.Location = new System.Drawing.Point(254, 246);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtCreditCardCode
            // 
            this.TxtCreditCardCode.EditValue = "";
            this.TxtCreditCardCode.Location = new System.Drawing.Point(147, 29);
            this.TxtCreditCardCode.Name = "TxtCreditCardCode";
            this.TxtCreditCardCode.Properties.PasswordChar = '•';
            this.TxtCreditCardCode.Properties.UseSystemPasswordChar = true;
            this.TxtCreditCardCode.Size = new System.Drawing.Size(220, 38);
            this.TxtCreditCardCode.TabIndex = 1;
            this.TxtCreditCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCreditCardCode_KeyDown);
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAuthorization.Location = new System.Drawing.Point(51, 40);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(65, 18);
            this.LblAuthorization.TabIndex = 5;
            this.LblAuthorization.Text = "Tarjeta";
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
            this.BtnAccept.Location = new System.Drawing.Point(424, 246);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 2;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // LblTitleHolder
            // 
            this.LblTitleHolder.AutoSize = true;
            this.LblTitleHolder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleHolder.Location = new System.Drawing.Point(51, 100);
            this.LblTitleHolder.Name = "LblTitleHolder";
            this.LblTitleHolder.Size = new System.Drawing.Size(59, 18);
            this.LblTitleHolder.TabIndex = 8;
            this.LblTitleHolder.Text = "Titular";
            // 
            // LblHolderName
            // 
            this.LblHolderName.AutoSize = true;
            this.LblHolderName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblHolderName.Location = new System.Drawing.Point(142, 100);
            this.LblHolderName.Name = "LblHolderName";
            this.LblHolderName.Size = new System.Drawing.Size(0, 18);
            this.LblHolderName.TabIndex = 9;
            // 
            // LblCreditLimit
            // 
            this.LblCreditLimit.AutoSize = true;
            this.LblCreditLimit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblCreditLimit.Location = new System.Drawing.Point(144, 158);
            this.LblCreditLimit.Name = "LblCreditLimit";
            this.LblCreditLimit.Size = new System.Drawing.Size(0, 18);
            this.LblCreditLimit.TabIndex = 11;
            // 
            // LblTitleCredit
            // 
            this.LblTitleCredit.AutoSize = true;
            this.LblTitleCredit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleCredit.Location = new System.Drawing.Point(51, 158);
            this.LblTitleCredit.Name = "LblTitleCredit";
            this.LblTitleCredit.Size = new System.Drawing.Size(88, 18);
            this.LblTitleCredit.TabIndex = 10;
            this.LblTitleCredit.Text = "Cupo       $";
            // 
            // FrmPaymentCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 310);
            this.ControlBox = false;
            this.Controls.Add(this.LblCreditLimit);
            this.Controls.Add(this.LblTitleCredit);
            this.Controls.Add(this.LblHolderName);
            this.Controls.Add(this.LblTitleHolder);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.TxtCreditCardCode);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credito Interno";
            this.Load += new System.EventHandler(this.FrmPaymentCredit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCardCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.TextEdit TxtCreditCardCode;
        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private System.Windows.Forms.Label LblTitleHolder;
        private System.Windows.Forms.Label LblHolderName;
        private System.Windows.Forms.Label LblCreditLimit;
        private System.Windows.Forms.Label LblTitleCredit;
    }
}