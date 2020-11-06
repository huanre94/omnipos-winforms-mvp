namespace POS
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.LblIdentification = new System.Windows.Forms.Label();
            this.TxtUsername = new DevExpress.XtraEditors.TextEdit();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtPassword = new DevExpress.XtraEditors.TextEdit();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ImgLogo = new System.Windows.Forms.PictureBox();
            this.BtnKeypadUsername = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeypadPassword = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblIdentification
            // 
            this.LblIdentification.AutoSize = true;
            this.LblIdentification.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblIdentification.Location = new System.Drawing.Point(609, 379);
            this.LblIdentification.Name = "LblIdentification";
            this.LblIdentification.Size = new System.Drawing.Size(116, 18);
            this.LblIdentification.TabIndex = 18;
            this.LblIdentification.Text = "Identificación";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(731, 370);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(211, 38);
            this.TxtUsername.TabIndex = 17;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblPassword.Location = new System.Drawing.Point(609, 436);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(106, 18);
            this.LblPassword.TabIndex = 20;
            this.LblPassword.Text = "Contraseña ";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(731, 427);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Properties.PasswordChar = '•';
            this.TxtPassword.Properties.UseSystemPasswordChar = true;
            this.TxtPassword.Size = new System.Drawing.Size(211, 38);
            this.TxtPassword.TabIndex = 19;
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
            this.BtnAccept.Location = new System.Drawing.Point(804, 506);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 21;
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
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(634, 506);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 22;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ImgLogo
            // 
            this.ImgLogo.Image = global::POS.Properties.Resources.Logo_LaEspanola;
            this.ImgLogo.Location = new System.Drawing.Point(702, 177);
            this.ImgLogo.Name = "ImgLogo";
            this.ImgLogo.Size = new System.Drawing.Size(194, 169);
            this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgLogo.TabIndex = 23;
            this.ImgLogo.TabStop = false;
            // 
            // BtnKeypadUsername
            // 
            this.BtnKeypadUsername.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadUsername.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadUsername.Appearance.Options.UseBackColor = true;
            this.BtnKeypadUsername.Appearance.Options.UseFont = true;
            this.BtnKeypadUsername.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnKeypadUsername.AppearanceHovered.Options.UseBackColor = true;
            this.BtnKeypadUsername.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadUsername.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeyboardOwner.ImageOptions.SvgImage")));
            this.BtnKeypadUsername.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadUsername.Location = new System.Drawing.Point(951, 366);
            this.BtnKeypadUsername.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadUsername.Name = "BtnKeypadUsername";
            this.BtnKeypadUsername.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadUsername.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadUsername.TabIndex = 168;
            this.BtnKeypadUsername.Click += new System.EventHandler(this.BtnKeypadUsername_Click);
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
            this.BtnKeypadPassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.BtnKeypadPassword.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadPassword.Location = new System.Drawing.Point(951, 423);
            this.BtnKeypadPassword.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeypadPassword.Name = "BtnKeypadPassword";
            this.BtnKeypadPassword.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadPassword.Size = new System.Drawing.Size(80, 50);
            this.BtnKeypadPassword.TabIndex = 169;
            this.BtnKeypadPassword.Click += new System.EventHandler(this.BtnKeypadPassword_Click);
            // 
            // FrmLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 718);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeypadPassword);
            this.Controls.Add(this.BtnKeypadUsername);
            this.Controls.Add(this.ImgLogo);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblIdentification);
            this.Controls.Add(this.TxtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.TxtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblIdentification;
        private DevExpress.XtraEditors.TextEdit TxtUsername;
        private System.Windows.Forms.Label LblPassword;
        private DevExpress.XtraEditors.TextEdit TxtPassword;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private System.Windows.Forms.PictureBox ImgLogo;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadUsername;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadPassword;
    }
}