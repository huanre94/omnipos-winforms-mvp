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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentCredit));
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitleHolder = new System.Windows.Forms.Label();
            this.LblHolderName = new System.Windows.Forms.Label();
            this.LblCreditLimit = new System.Windows.Forms.Label();
            this.LblTitleCredit = new System.Windows.Forms.Label();
            this.TxtCreditCardCode = new DevExpress.XtraEditors.TextEdit();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCardCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
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
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAuthorization.Location = new System.Drawing.Point(51, 32);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(65, 18);
            this.LblAuthorization.TabIndex = 2;
            this.LblAuthorization.Text = "Tarjeta";
            this.LblAuthorization.Visible = false;
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
            this.BtnAccept.TabIndex = 8;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // LblTitleHolder
            // 
            this.LblTitleHolder.AutoSize = true;
            this.LblTitleHolder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleHolder.Location = new System.Drawing.Point(51, 90);
            this.LblTitleHolder.Name = "LblTitleHolder";
            this.LblTitleHolder.Size = new System.Drawing.Size(59, 18);
            this.LblTitleHolder.TabIndex = 4;
            this.LblTitleHolder.Text = "Titular";
            // 
            // LblHolderName
            // 
            this.LblHolderName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblHolderName.Location = new System.Drawing.Point(142, 90);
            this.LblHolderName.Name = "LblHolderName";
            this.LblHolderName.Size = new System.Drawing.Size(423, 18);
            this.LblHolderName.TabIndex = 3;
            // 
            // LblCreditLimit
            // 
            this.LblCreditLimit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblCreditLimit.Location = new System.Drawing.Point(144, 148);
            this.LblCreditLimit.Name = "LblCreditLimit";
            this.LblCreditLimit.Size = new System.Drawing.Size(421, 18);
            this.LblCreditLimit.TabIndex = 5;
            // 
            // LblTitleCredit
            // 
            this.LblTitleCredit.AutoSize = true;
            this.LblTitleCredit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblTitleCredit.Location = new System.Drawing.Point(51, 148);
            this.LblTitleCredit.Name = "LblTitleCredit";
            this.LblTitleCredit.Size = new System.Drawing.Size(88, 18);
            this.LblTitleCredit.TabIndex = 6;
            this.LblTitleCredit.Text = "Cupo       $";
            // 
            // TxtCreditCardCode
            // 
            this.TxtCreditCardCode.Location = new System.Drawing.Point(145, 18);
            this.TxtCreditCardCode.Name = "TxtCreditCardCode";
            this.TxtCreditCardCode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtCreditCardCode.Properties.Appearance.Options.UseFont = true;
            this.TxtCreditCardCode.Properties.PasswordChar = '•';
            this.TxtCreditCardCode.Size = new System.Drawing.Size(420, 44);
            this.TxtCreditCardCode.TabIndex = 1;
            this.TxtCreditCardCode.Visible = false;
            this.TxtCreditCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCreditCardCode_KeyDown);
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(64, 204);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(143, 92);
            this.AxOPOSScanner.TabIndex = 10;
            this.AxOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.AxOPOSScanner_DataEvent);
            // 
            // FrmPaymentCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(598, 310);
            this.ControlBox = false;
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.TxtCreditCardCode);
            this.Controls.Add(this.LblCreditLimit);
            this.Controls.Add(this.LblTitleCredit);
            this.Controls.Add(this.LblHolderName);
            this.Controls.Add(this.LblTitleHolder);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPaymentCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credito Interno";
            this.Load += new System.EventHandler(this.FrmPaymentCredit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCreditCardCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private System.Windows.Forms.Label LblTitleHolder;
        private System.Windows.Forms.Label LblHolderName;
        private System.Windows.Forms.Label LblCreditLimit;
        private System.Windows.Forms.Label LblTitleCredit;
        private DevExpress.XtraEditors.TextEdit TxtCreditCardCode;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
    }
}