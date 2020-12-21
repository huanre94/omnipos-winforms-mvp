namespace POS
{
    partial class FrmInvoiceCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoiceCancel));
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSeqKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.LblCashierUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblBono = new System.Windows.Forms.Label();
            this.TxtSequence = new DevExpress.XtraEditors.TextEdit();
            this.LblEstablishment = new System.Windows.Forms.Label();
            this.LblLine1 = new System.Windows.Forms.Label();
            this.LblLine2 = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEmissionPointKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.TxtEmissionPoint = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCustomerIdentification = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblInvoiceId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblInvoiceAmount = new System.Windows.Forms.Label();
            this.TxtObservation = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnObservationKeyBoard = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LblInvoiceStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmissionPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservation.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnSearch.Location = new System.Drawing.Point(789, 51);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 162;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnSeqKeyPad
            // 
            this.BtnSeqKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSeqKeyPad.Appearance.Options.UseFont = true;
            this.BtnSeqKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnSeqKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnSeqKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnSeqKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSeqKeyPad.ImageOptions.SvgImage")));
            this.BtnSeqKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnSeqKeyPad.Location = new System.Drawing.Point(698, 56);
            this.BtnSeqKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnSeqKeyPad.Name = "BtnSeqKeyPad";
            this.BtnSeqKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSeqKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnSeqKeyPad.TabIndex = 161;
            this.BtnSeqKeyPad.Click += new System.EventHandler(this.BtnSeqKeyPad_Click);
            // 
            // LblCashierUser
            // 
            this.LblCashierUser.AutoSize = true;
            this.LblCashierUser.Location = new System.Drawing.Point(174, 19);
            this.LblCashierUser.Name = "LblCashierUser";
            this.LblCashierUser.Size = new System.Drawing.Size(61, 16);
            this.LblCashierUser.TabIndex = 158;
            this.LblCashierUser.Text = "N. Bono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 159;
            this.label6.Text = "Cajero";
            // 
            // LblBono
            // 
            this.LblBono.AutoSize = true;
            this.LblBono.Location = new System.Drawing.Point(31, 72);
            this.LblBono.Name = "LblBono";
            this.LblBono.Size = new System.Drawing.Size(61, 16);
            this.LblBono.TabIndex = 160;
            this.LblBono.Text = "N. Bono";
            // 
            // TxtSequence
            // 
            this.TxtSequence.Location = new System.Drawing.Point(473, 59);
            this.TxtSequence.Name = "TxtSequence";
            this.TxtSequence.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtSequence.Properties.Appearance.Options.UseFont = true;
            this.TxtSequence.Size = new System.Drawing.Size(216, 44);
            this.TxtSequence.TabIndex = 157;
            // 
            // LblEstablishment
            // 
            this.LblEstablishment.AutoSize = true;
            this.LblEstablishment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblEstablishment.Location = new System.Drawing.Point(172, 62);
            this.LblEstablishment.Name = "LblEstablishment";
            this.LblEstablishment.Size = new System.Drawing.Size(57, 28);
            this.LblEstablishment.TabIndex = 167;
            this.LblEstablishment.Text = "999";
            // 
            // LblLine1
            // 
            this.LblLine1.AutoSize = true;
            this.LblLine1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine1.Location = new System.Drawing.Point(226, 62);
            this.LblLine1.Name = "LblLine1";
            this.LblLine1.Size = new System.Drawing.Size(19, 26);
            this.LblLine1.TabIndex = 166;
            this.LblLine1.Text = "-";
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine2.Location = new System.Drawing.Point(448, 65);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(19, 26);
            this.LblLine2.TabIndex = 165;
            this.LblLine2.Text = "-";
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
            this.BtnAccept.Location = new System.Drawing.Point(696, 474);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 168;
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
            this.BtnCancel.Location = new System.Drawing.Point(526, 474);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 169;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnEmissionPointKeyPad
            // 
            this.BtnEmissionPointKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnEmissionPointKeyPad.Appearance.Options.UseFont = true;
            this.BtnEmissionPointKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnEmissionPointKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnEmissionPointKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnEmissionPointKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnEmissionPointKeyPad.ImageOptions.SvgImage")));
            this.BtnEmissionPointKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnEmissionPointKeyPad.Location = new System.Drawing.Point(367, 54);
            this.BtnEmissionPointKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnEmissionPointKeyPad.Name = "BtnEmissionPointKeyPad";
            this.BtnEmissionPointKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnEmissionPointKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnEmissionPointKeyPad.TabIndex = 161;
            this.BtnEmissionPointKeyPad.Click += new System.EventHandler(this.BtnEmissionPointKeyPad_Click);
            // 
            // TxtEmissionPoint
            // 
            this.TxtEmissionPoint.Location = new System.Drawing.Point(251, 56);
            this.TxtEmissionPoint.Name = "TxtEmissionPoint";
            this.TxtEmissionPoint.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtEmissionPoint.Properties.Appearance.Options.UseFont = true;
            this.TxtEmissionPoint.Size = new System.Drawing.Size(107, 44);
            this.TxtEmissionPoint.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 160;
            this.label1.Text = "Identificacion:";
            // 
            // LblCustomerIdentification
            // 
            this.LblCustomerIdentification.AutoSize = true;
            this.LblCustomerIdentification.Location = new System.Drawing.Point(174, 240);
            this.LblCustomerIdentification.Name = "LblCustomerIdentification";
            this.LblCustomerIdentification.Size = new System.Drawing.Size(88, 16);
            this.LblCustomerIdentification.TabIndex = 160;
            this.LblCustomerIdentification.Text = "9999999999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 160;
            this.label3.Text = "Cliente:";
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.AutoSize = true;
            this.LblCustomerName.Location = new System.Drawing.Point(174, 297);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(83, 16);
            this.LblCustomerName.TabIndex = 160;
            this.LblCustomerName.Text = "JOHN DOE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 160;
            this.label5.Text = "Estado:";
            // 
            // LblInvoiceId
            // 
            this.LblInvoiceId.AutoSize = true;
            this.LblInvoiceId.Location = new System.Drawing.Point(174, 131);
            this.LblInvoiceId.Name = "LblInvoiceId";
            this.LblInvoiceId.Size = new System.Drawing.Size(16, 16);
            this.LblInvoiceId.TabIndex = 160;
            this.LblInvoiceId.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 160;
            this.label8.Text = "Valor:";
            // 
            // LblInvoiceAmount
            // 
            this.LblInvoiceAmount.AutoSize = true;
            this.LblInvoiceAmount.Location = new System.Drawing.Point(174, 353);
            this.LblInvoiceAmount.Name = "LblInvoiceAmount";
            this.LblInvoiceAmount.Size = new System.Drawing.Size(60, 16);
            this.LblInvoiceAmount.TabIndex = 160;
            this.LblInvoiceAmount.Text = "$100.00";
            // 
            // TxtObservation
            // 
            this.TxtObservation.Location = new System.Drawing.Point(177, 403);
            this.TxtObservation.Name = "TxtObservation";
            this.TxtObservation.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtObservation.Properties.Appearance.Options.UseFont = true;
            this.TxtObservation.Size = new System.Drawing.Size(584, 44);
            this.TxtObservation.TabIndex = 157;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 419);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 16);
            this.label10.TabIndex = 160;
            this.label10.Text = "Observacion:";
            // 
            // BtnObservationKeyBoard
            // 
            this.BtnObservationKeyBoard.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnObservationKeyBoard.Appearance.Options.UseFont = true;
            this.BtnObservationKeyBoard.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnObservationKeyBoard.AppearanceHovered.Options.UseBackColor = true;
            this.BtnObservationKeyBoard.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnObservationKeyBoard.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnObservationKeyBoard.ImageOptions.SvgImage")));
            this.BtnObservationKeyBoard.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnObservationKeyBoard.Location = new System.Drawing.Point(770, 401);
            this.BtnObservationKeyBoard.Margin = new System.Windows.Forms.Padding(6);
            this.BtnObservationKeyBoard.Name = "BtnObservationKeyBoard";
            this.BtnObservationKeyBoard.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnObservationKeyBoard.Size = new System.Drawing.Size(82, 50);
            this.BtnObservationKeyBoard.TabIndex = 161;
            this.BtnObservationKeyBoard.Click += new System.EventHandler(this.BtnObservationKeyBoard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 160;
            this.label2.Text = "Trans.:";
            // 
            // LblInvoiceStatus
            // 
            this.LblInvoiceStatus.AutoSize = true;
            this.LblInvoiceStatus.Location = new System.Drawing.Point(174, 187);
            this.LblInvoiceStatus.Name = "LblInvoiceStatus";
            this.LblInvoiceStatus.Size = new System.Drawing.Size(62, 16);
            this.LblInvoiceStatus.TabIndex = 160;
            this.LblInvoiceStatus.Text = "ACTIVO";
            // 
            // FrmInvoiceCancel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(870, 538);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblEstablishment);
            this.Controls.Add(this.LblLine1);
            this.Controls.Add(this.LblLine2);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnObservationKeyBoard);
            this.Controls.Add(this.BtnEmissionPointKeyPad);
            this.Controls.Add(this.BtnSeqKeyPad);
            this.Controls.Add(this.LblCashierUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblInvoiceAmount);
            this.Controls.Add(this.LblInvoiceStatus);
            this.Controls.Add(this.LblInvoiceId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblCustomerIdentification);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblBono);
            this.Controls.Add(this.TxtObservation);
            this.Controls.Add(this.TxtEmissionPoint);
            this.Controls.Add(this.TxtSequence);
            this.Name = "FrmInvoiceCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInvoiceCancel";
            this.Load += new System.EventHandler(this.FrmInvoiceCancel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmissionPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservation.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private DevExpress.XtraEditors.SimpleButton BtnSeqKeyPad;
        private System.Windows.Forms.Label LblCashierUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblBono;
        private DevExpress.XtraEditors.TextEdit TxtSequence;
        private System.Windows.Forms.Label LblEstablishment;
        private System.Windows.Forms.Label LblLine1;
        private System.Windows.Forms.Label LblLine2;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnEmissionPointKeyPad;
        private DevExpress.XtraEditors.TextEdit TxtEmissionPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblCustomerIdentification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblInvoiceId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblInvoiceAmount;
        private DevExpress.XtraEditors.TextEdit TxtObservation;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton BtnObservationKeyBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblInvoiceStatus;
    }
}