namespace POS
{
    partial class FrmSupervisorAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupervisorAuth));
            this.LblAuthorization = new System.Windows.Forms.Label();
            this.TxtAuthorization = new DevExpress.XtraEditors.TextEdit();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.LblMotive = new System.Windows.Forms.Label();
            this.CmbMotive = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSupervisorPassword = new DevExpress.XtraEditors.TextEdit();
            this.BtnKeypadPassword = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbMotive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSupervisorPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LblAuthorization
            // 
            this.LblAuthorization.AutoSize = true;
            this.LblAuthorization.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblAuthorization.Location = new System.Drawing.Point(51, 57);
            this.LblAuthorization.Name = "LblAuthorization";
            this.LblAuthorization.Size = new System.Drawing.Size(64, 18);
            this.LblAuthorization.TabIndex = 7;
            this.LblAuthorization.Text = "Codigo";
            // 
            // TxtAuthorization
            // 
            this.TxtAuthorization.EditValue = "";
            this.TxtAuthorization.Location = new System.Drawing.Point(132, 48);
            this.TxtAuthorization.Name = "TxtAuthorization";
            this.TxtAuthorization.Properties.PasswordChar = '•';
            this.TxtAuthorization.Properties.UseSystemPasswordChar = true;
            this.TxtAuthorization.Size = new System.Drawing.Size(220, 38);
            this.TxtAuthorization.TabIndex = 1;
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
            this.BtnAccept.Location = new System.Drawing.Point(299, 233);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 9;
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
            this.BtnCancel.Location = new System.Drawing.Point(129, 233);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblMotive
            // 
            this.LblMotive.AutoSize = true;
            this.LblMotive.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblMotive.Location = new System.Drawing.Point(51, 174);
            this.LblMotive.Name = "LblMotive";
            this.LblMotive.Size = new System.Drawing.Size(60, 18);
            this.LblMotive.TabIndex = 7;
            this.LblMotive.Text = "Motivo";
            // 
            // CmbMotive
            // 
            this.CmbMotive.Location = new System.Drawing.Point(132, 165);
            this.CmbMotive.Name = "CmbMotive";
            this.CmbMotive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbMotive.Size = new System.Drawing.Size(306, 38);
            this.CmbMotive.TabIndex = 12;
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(12, -2);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(50, 56);
            this.AxOPOSScanner.TabIndex = 13;
            this.AxOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.AxOPOSScanner_DataEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(51, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Clave";
            // 
            // TxtSupervisorPassword
            // 
            this.TxtSupervisorPassword.EditValue = "";
            this.TxtSupervisorPassword.Location = new System.Drawing.Point(132, 107);
            this.TxtSupervisorPassword.Name = "TxtSupervisorPassword";
            this.TxtSupervisorPassword.Properties.PasswordChar = '•';
            this.TxtSupervisorPassword.Properties.UseSystemPasswordChar = true;
            this.TxtSupervisorPassword.Size = new System.Drawing.Size(220, 38);
            this.TxtSupervisorPassword.TabIndex = 14;
            // 
            // BtnKeypadPassword
            // 
            this.BtnKeypadPassword.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadPassword.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadPassword.Appearance.Options.UseBackColor = true;
            this.BtnKeypadPassword.Appearance.Options.UseFont = true;
            this.BtnKeypadPassword.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadPassword.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadPassword.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadPassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadPassword.ImageOptions.SvgImage")));
            this.BtnKeypadPassword.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadPassword.Location = new System.Drawing.Point(358, 100);
            this.BtnKeypadPassword.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadPassword.Name = "BtnKeypadPassword";
            this.BtnKeypadPassword.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadPassword.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadPassword.TabIndex = 170;
            this.BtnKeypadPassword.Click += new System.EventHandler(this.BtnKeypadPassword_Click);
            // 
            // FrmSupervisorAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 298);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeypadPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSupervisorPassword);
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblMotive);
            this.Controls.Add(this.LblAuthorization);
            this.Controls.Add(this.TxtAuthorization);
            this.Controls.Add(this.CmbMotive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSupervisorAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizacion de Supervisor";
            this.Load += new System.EventHandler(this.FrmSupervisorAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuthorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbMotive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSupervisorPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAuthorization;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        public DevExpress.XtraEditors.TextEdit TxtAuthorization;
        private System.Windows.Forms.Label LblMotive;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbMotive;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit TxtSupervisorPassword;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadPassword;
    }
}