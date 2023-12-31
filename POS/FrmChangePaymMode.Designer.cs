﻿namespace POS
{
    partial class FrmChangePaymMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePaymMode));
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeypadInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.TxtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.LblInvoice = new System.Windows.Forms.Label();
            this.GrcPayments = new DevExpress.XtraGrid.GridControl();
            this.GrvPayments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PaymMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CmbPaymMode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.LblPaymMode = new System.Windows.Forms.Label();
            this.BtnKeypadEmission = new DevExpress.XtraEditors.SimpleButton();
            this.TxtEmissionPoint = new DevExpress.XtraEditors.TextEdit();
            this.LblEmission = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPaymMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmissionPoint.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.BtnAccept.Location = new System.Drawing.Point(452, 590);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(6);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(196, 62);
            this.BtnAccept.TabIndex = 4;
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
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(244, 590);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(196, 62);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancelar";
            // 
            // BtnKeypadInvoice
            // 
            this.BtnKeypadInvoice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadInvoice.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadInvoice.Appearance.Options.UseBackColor = true;
            this.BtnKeypadInvoice.Appearance.Options.UseFont = true;
            this.BtnKeypadInvoice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadInvoice.ImageOptions.SvgImage")));
            this.BtnKeypadInvoice.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadInvoice.Location = new System.Drawing.Point(395, 84);
            this.BtnKeypadInvoice.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnKeypadInvoice.Name = "BtnKeypadInvoice";
            this.BtnKeypadInvoice.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadInvoice.Size = new System.Drawing.Size(95, 62);
            this.BtnKeypadInvoice.TabIndex = 13;
            this.BtnKeypadInvoice.Click += new System.EventHandler(this.BtnKeypadInvoice_Click);
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
            this.BtnSearch.Location = new System.Drawing.Point(491, 78);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(6);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(77, 69);
            this.BtnSearch.TabIndex = 14;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtInvoiceNumber
            // 
            this.TxtInvoiceNumber.Location = new System.Drawing.Point(123, 90);
            this.TxtInvoiceNumber.Margin = new System.Windows.Forms.Padding(4);
            this.TxtInvoiceNumber.Name = "TxtInvoiceNumber";
            this.TxtInvoiceNumber.Properties.MaxLength = 9;
            this.TxtInvoiceNumber.Size = new System.Drawing.Size(268, 30);
            this.TxtInvoiceNumber.TabIndex = 1;
            this.TxtInvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInvoiceNumber_KeyDown);
            // 
            // LblInvoice
            // 
            this.LblInvoice.AutoSize = true;
            this.LblInvoice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblInvoice.Location = new System.Drawing.Point(29, 104);
            this.LblInvoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblInvoice.Name = "LblInvoice";
            this.LblInvoice.Size = new System.Drawing.Size(86, 23);
            this.LblInvoice.TabIndex = 15;
            this.LblInvoice.Text = "Factura";
            // 
            // GrcPayments
            // 
            this.GrcPayments.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.GrcPayments.Location = new System.Drawing.Point(33, 171);
            this.GrcPayments.MainView = this.GrvPayments;
            this.GrcPayments.Margin = new System.Windows.Forms.Padding(4);
            this.GrcPayments.Name = "GrcPayments";
            this.GrcPayments.Size = new System.Drawing.Size(535, 270);
            this.GrcPayments.TabIndex = 2;
            this.GrcPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvPayments});
            // 
            // GrvPayments
            // 
            this.GrvPayments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PaymMode,
            this.PaymentAmount});
            this.GrvPayments.DetailHeight = 437;
            this.GrvPayments.GridControl = this.GrcPayments;
            this.GrvPayments.Name = "GrvPayments";
            this.GrvPayments.OptionsView.ShowGroupPanel = false;
            // 
            // PaymMode
            // 
            this.PaymMode.Caption = "Forma de Pago";
            this.PaymMode.FieldName = "Name";
            this.PaymMode.MinWidth = 24;
            this.PaymMode.Name = "PaymMode";
            this.PaymMode.OptionsColumn.AllowEdit = false;
            this.PaymMode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.PaymMode.Visible = true;
            this.PaymMode.VisibleIndex = 0;
            this.PaymMode.Width = 92;
            // 
            // PaymentAmount
            // 
            this.PaymentAmount.Caption = "Valor";
            this.PaymentAmount.DisplayFormat.FormatString = "c2";
            this.PaymentAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PaymentAmount.FieldName = "Amount";
            this.PaymentAmount.MinWidth = 24;
            this.PaymentAmount.Name = "PaymentAmount";
            this.PaymentAmount.OptionsColumn.AllowEdit = false;
            this.PaymentAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.PaymentAmount.Visible = true;
            this.PaymentAmount.VisibleIndex = 1;
            this.PaymentAmount.Width = 92;
            // 
            // CmbPaymMode
            // 
            this.CmbPaymMode.Location = new System.Drawing.Point(180, 465);
            this.CmbPaymMode.Margin = new System.Windows.Forms.Padding(4);
            this.CmbPaymMode.Name = "CmbPaymMode";
            this.CmbPaymMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbPaymMode.Size = new System.Drawing.Size(389, 30);
            this.CmbPaymMode.TabIndex = 3;
            this.CmbPaymMode.SelectedValueChanged += new System.EventHandler(this.CmbPaymMode_SelectedValueChanged);
            this.CmbPaymMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbPaymMode_KeyDown);
            // 
            // LblPaymMode
            // 
            this.LblPaymMode.AutoSize = true;
            this.LblPaymMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblPaymMode.Location = new System.Drawing.Point(29, 479);
            this.LblPaymMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPaymMode.Name = "LblPaymMode";
            this.LblPaymMode.Size = new System.Drawing.Size(85, 23);
            this.LblPaymMode.TabIndex = 18;
            this.LblPaymMode.Text = "Cambio";
            // 
            // BtnKeypadEmission
            // 
            this.BtnKeypadEmission.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypadEmission.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypadEmission.Appearance.Options.UseBackColor = true;
            this.BtnKeypadEmission.Appearance.Options.UseFont = true;
            this.BtnKeypadEmission.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypadEmission.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypadEmission.ImageOptions.SvgImage")));
            this.BtnKeypadEmission.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypadEmission.Location = new System.Drawing.Point(395, 11);
            this.BtnKeypadEmission.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnKeypadEmission.Name = "BtnKeypadEmission";
            this.BtnKeypadEmission.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypadEmission.Size = new System.Drawing.Size(95, 62);
            this.BtnKeypadEmission.TabIndex = 20;
            this.BtnKeypadEmission.Visible = false;
            this.BtnKeypadEmission.Click += new System.EventHandler(this.BtnKeypadEmission_Click);
            // 
            // TxtEmissionPoint
            // 
            this.TxtEmissionPoint.Location = new System.Drawing.Point(123, 18);
            this.TxtEmissionPoint.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEmissionPoint.Name = "TxtEmissionPoint";
            this.TxtEmissionPoint.Properties.MaxLength = 3;
            this.TxtEmissionPoint.Size = new System.Drawing.Size(268, 30);
            this.TxtEmissionPoint.TabIndex = 0;
            this.TxtEmissionPoint.Visible = false;
            this.TxtEmissionPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEmissionPoint_KeyDown);
            // 
            // LblEmission
            // 
            this.LblEmission.AutoSize = true;
            this.LblEmission.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblEmission.Location = new System.Drawing.Point(29, 31);
            this.LblEmission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmission.Name = "LblEmission";
            this.LblEmission.Size = new System.Drawing.Size(86, 23);
            this.LblEmission.TabIndex = 21;
            this.LblEmission.Text = "Emision";
            this.LblEmission.Visible = false;
            // 
            // FrmChangePaymMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(665, 670);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeypadEmission);
            this.Controls.Add(this.TxtEmissionPoint);
            this.Controls.Add(this.LblEmission);
            this.Controls.Add(this.LblPaymMode);
            this.Controls.Add(this.CmbPaymMode);
            this.Controls.Add(this.GrcPayments);
            this.Controls.Add(this.BtnKeypadInvoice);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtInvoiceNumber);
            this.Controls.Add(this.LblInvoice);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmChangePaymMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Forma de Pago";
            this.Load += new System.EventHandler(this.FrmChangePaymMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtInvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPaymMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmissionPoint.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadInvoice;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        public DevExpress.XtraEditors.TextEdit TxtInvoiceNumber;
        private System.Windows.Forms.Label LblInvoice;
        private DevExpress.XtraGrid.GridControl GrcPayments;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvPayments;
        private DevExpress.XtraGrid.Columns.GridColumn PaymMode;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentAmount;
        public DevExpress.XtraEditors.ImageComboBoxEdit CmbPaymMode;
        private System.Windows.Forms.Label LblPaymMode;
        private DevExpress.XtraEditors.SimpleButton BtnKeypadEmission;
        public DevExpress.XtraEditors.TextEdit TxtEmissionPoint;
        private System.Windows.Forms.Label LblEmission;
    }
}