namespace POS
{
    partial class FrmRedeemGiftCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRedeemGiftCard));
            this.BtnKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.LblCustomerAddress = new System.Windows.Forms.Label();
            this.TxtGiftCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRedeemIdentification = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnIdentificationKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.TxtRedeemName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRedeemCustomerName = new DevExpress.XtraEditors.SimpleButton();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBarcodeKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCashierUser = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblGiftCardInvoice = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.LblExpirationDate = new System.Windows.Forms.Label();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.LblCustomerNameRegistered = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.AxOPOSScale = new AxOposScale_CCO.AxOPOSScale();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            this.GrcProduct = new DevExpress.XtraGrid.GridControl();
            this.GrvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.LblGiftCardStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRedeemIdentification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRedeemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvProduct)).BeginInit();
            this.SuspendLayout();
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
            this.BtnKeyPad.Location = new System.Drawing.Point(402, 87);
            this.BtnKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnKeyPad.Name = "BtnKeyPad";
            this.BtnKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnKeyPad.TabIndex = 155;
            this.BtnKeyPad.Click += new System.EventHandler(this.BtnKeyPad_Click);
            // 
            // LblCustomerAddress
            // 
            this.LblCustomerAddress.AutoSize = true;
            this.LblCustomerAddress.Location = new System.Drawing.Point(31, 106);
            this.LblCustomerAddress.Name = "LblCustomerAddress";
            this.LblCustomerAddress.Size = new System.Drawing.Size(61, 16);
            this.LblCustomerAddress.TabIndex = 154;
            this.LblCustomerAddress.Text = "N. Bono";
            // 
            // TxtGiftCardNumber
            // 
            this.TxtGiftCardNumber.Location = new System.Drawing.Point(177, 90);
            this.TxtGiftCardNumber.Name = "TxtGiftCardNumber";
            this.TxtGiftCardNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtGiftCardNumber.Properties.Appearance.Options.UseFont = true;
            this.TxtGiftCardNumber.Size = new System.Drawing.Size(216, 44);
            this.TxtGiftCardNumber.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(856, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 154;
            this.label2.Text = "Fecha Expiracion";
            // 
            // TxtRedeemIdentification
            // 
            this.TxtRedeemIdentification.Location = new System.Drawing.Point(177, 247);
            this.TxtRedeemIdentification.Name = "TxtRedeemIdentification";
            this.TxtRedeemIdentification.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtRedeemIdentification.Properties.Appearance.Options.UseFont = true;
            this.TxtRedeemIdentification.Size = new System.Drawing.Size(216, 44);
            this.TxtRedeemIdentification.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 154;
            this.label3.Text = "Doc. Canje";
            // 
            // BtnIdentificationKeyPad
            // 
            this.BtnIdentificationKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnIdentificationKeyPad.Appearance.Options.UseFont = true;
            this.BtnIdentificationKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnIdentificationKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnIdentificationKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnIdentificationKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnIdentificationKeyPad.ImageOptions.SvgImage")));
            this.BtnIdentificationKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnIdentificationKeyPad.Location = new System.Drawing.Point(402, 245);
            this.BtnIdentificationKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnIdentificationKeyPad.Name = "BtnIdentificationKeyPad";
            this.BtnIdentificationKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnIdentificationKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnIdentificationKeyPad.TabIndex = 155;
            this.BtnIdentificationKeyPad.Click += new System.EventHandler(this.BtnIdentificationKeyPad_Click);
            // 
            // TxtRedeemName
            // 
            this.TxtRedeemName.Location = new System.Drawing.Point(665, 247);
            this.TxtRedeemName.Name = "TxtRedeemName";
            this.TxtRedeemName.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtRedeemName.Properties.Appearance.Options.UseFont = true;
            this.TxtRedeemName.Size = new System.Drawing.Size(570, 44);
            this.TxtRedeemName.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 154;
            this.label4.Text = "Usuario Canje";
            // 
            // BtnRedeemCustomerName
            // 
            this.BtnRedeemCustomerName.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRedeemCustomerName.Appearance.Options.UseFont = true;
            this.BtnRedeemCustomerName.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnRedeemCustomerName.AppearanceHovered.Options.UseBackColor = true;
            this.BtnRedeemCustomerName.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnRedeemCustomerName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnRedeemCustomerName.ImageOptions.SvgImage")));
            this.BtnRedeemCustomerName.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnRedeemCustomerName.Location = new System.Drawing.Point(1247, 245);
            this.BtnRedeemCustomerName.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRedeemCustomerName.Name = "BtnRedeemCustomerName";
            this.BtnRedeemCustomerName.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnRedeemCustomerName.Size = new System.Drawing.Size(82, 50);
            this.BtnRedeemCustomerName.TabIndex = 155;
            this.BtnRedeemCustomerName.Click += new System.EventHandler(this.BtnRedeemCustomerName_Click);
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(177, 323);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtBarcode.Properties.Appearance.Options.UseFont = true;
            this.TxtBarcode.Size = new System.Drawing.Size(216, 44);
            this.TxtBarcode.TabIndex = 153;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 154;
            this.label5.Text = "Cod. Barra";
            // 
            // BtnBarcodeKeyPad
            // 
            this.BtnBarcodeKeyPad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnBarcodeKeyPad.Appearance.Options.UseFont = true;
            this.BtnBarcodeKeyPad.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.BtnBarcodeKeyPad.AppearanceHovered.Options.UseBackColor = true;
            this.BtnBarcodeKeyPad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnBarcodeKeyPad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnBarcodeKeyPad.ImageOptions.SvgImage")));
            this.BtnBarcodeKeyPad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnBarcodeKeyPad.Location = new System.Drawing.Point(402, 321);
            this.BtnBarcodeKeyPad.Margin = new System.Windows.Forms.Padding(6);
            this.BtnBarcodeKeyPad.Name = "BtnBarcodeKeyPad";
            this.BtnBarcodeKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnBarcodeKeyPad.Size = new System.Drawing.Size(82, 50);
            this.BtnBarcodeKeyPad.TabIndex = 155;
            this.BtnBarcodeKeyPad.Click += new System.EventHandler(this.BtnBarcodeKeyPad_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 154;
            this.label6.Text = "Cajero";
            // 
            // LblCashierUser
            // 
            this.LblCashierUser.AutoSize = true;
            this.LblCashierUser.Location = new System.Drawing.Point(174, 53);
            this.LblCashierUser.Name = "LblCashierUser";
            this.LblCashierUser.Size = new System.Drawing.Size(61, 16);
            this.LblCashierUser.TabIndex = 154;
            this.LblCashierUser.Text = "N. Bono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(453, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 154;
            this.label8.Text = "N. Factura";
            // 
            // LblGiftCardInvoice
            // 
            this.LblGiftCardInvoice.AutoSize = true;
            this.LblGiftCardInvoice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblGiftCardInvoice.Location = new System.Drawing.Point(559, 171);
            this.LblGiftCardInvoice.Name = "LblGiftCardInvoice";
            this.LblGiftCardInvoice.Size = new System.Drawing.Size(146, 16);
            this.LblGiftCardInvoice.TabIndex = 154;
            this.LblGiftCardInvoice.Text = "001-001-00000001";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.simpleButton4.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton4.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButton4.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.simpleButton4.Location = new System.Drawing.Point(1613, 253);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(6);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton4.Size = new System.Drawing.Size(82, 50);
            this.simpleButton4.TabIndex = 155;
            // 
            // LblExpirationDate
            // 
            this.LblExpirationDate.AutoSize = true;
            this.LblExpirationDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblExpirationDate.Location = new System.Drawing.Point(999, 171);
            this.LblExpirationDate.Name = "LblExpirationDate";
            this.LblExpirationDate.Size = new System.Drawing.Size(90, 16);
            this.LblExpirationDate.TabIndex = 154;
            this.LblExpirationDate.Text = "11/12/2020";
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
            this.BtnSearch.Location = new System.Drawing.Point(493, 82);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnSearch.Size = new System.Drawing.Size(63, 55);
            this.BtnSearch.TabIndex = 156;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(31, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 154;
            this.label9.Text = "Registrado A";
            // 
            // LblCustomerNameRegistered
            // 
            this.LblCustomerNameRegistered.AutoSize = true;
            this.LblCustomerNameRegistered.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblCustomerNameRegistered.Location = new System.Drawing.Point(174, 170);
            this.LblCustomerNameRegistered.Name = "LblCustomerNameRegistered";
            this.LblCustomerNameRegistered.Size = new System.Drawing.Size(168, 16);
            this.LblCustomerNameRegistered.TabIndex = 154;
            this.LblCustomerNameRegistered.Text = "CONSUMIDOR FINAL";
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
            this.BtnAccept.Location = new System.Drawing.Point(1192, 704);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(160, 50);
            this.BtnAccept.TabIndex = 157;
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
            this.BtnCancel.Location = new System.Drawing.Point(1022, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 158;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AxOPOSScale
            // 
            this.AxOPOSScale.Enabled = true;
            this.AxOPOSScale.Location = new System.Drawing.Point(690, 472);
            this.AxOPOSScale.Name = "AxOPOSScale";
            this.AxOPOSScale.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScale.OcxState")));
            this.AxOPOSScale.Size = new System.Drawing.Size(192, 192);
            this.AxOPOSScale.TabIndex = 160;
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(423, 472);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(192, 192);
            this.AxOPOSScanner.TabIndex = 159;
            this.AxOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.AxOPOSScanner_DataEvent);
            // 
            // GrcProduct
            // 
            this.GrcProduct.Location = new System.Drawing.Point(17, 402);
            this.GrcProduct.MainView = this.GrvProduct;
            this.GrcProduct.Name = "GrcProduct";
            this.GrcProduct.Size = new System.Drawing.Size(1218, 262);
            this.GrcProduct.TabIndex = 161;
            this.GrcProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvProduct});
            // 
            // GrvProduct
            // 
            this.GrvProduct.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.GrvProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.ProductName,
            this.gridColumn2});
            this.GrvProduct.GridControl = this.GrcProduct;
            this.GrvProduct.Name = "GrvProduct";
            this.GrvProduct.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvProduct.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GrvProduct.OptionsBehavior.ReadOnly = true;
            this.GrvProduct.OptionsCustomization.AllowColumnMoving = false;
            this.GrvProduct.OptionsCustomization.AllowColumnResizing = false;
            this.GrvProduct.OptionsCustomization.AllowFilter = false;
            this.GrvProduct.OptionsCustomization.AllowGroup = false;
            this.GrvProduct.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.GrvProduct.OptionsCustomization.AllowSort = false;
            this.GrvProduct.OptionsView.RowAutoHeight = true;
            this.GrvProduct.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "ProductId";
            this.gridColumn1.MaxWidth = 10;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 10;
            // 
            // ProductName
            // 
            this.ProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.ProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ProductName.Caption = "Nombre Producto";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.MaxWidth = 500;
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowEdit = false;
            this.ProductName.OptionsColumn.AllowSize = false;
            this.ProductName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductName.OptionsColumn.FixedWidth = true;
            this.ProductName.OptionsColumn.ReadOnly = true;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 0;
            this.ProductName.Width = 500;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Cantidad";
            this.gridColumn2.FieldName = "Quantity";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 680;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRemove.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRemove.Appearance.Options.UseBackColor = true;
            this.BtnRemove.Appearance.Options.UseFont = true;
            this.BtnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRemove.ImageOptions.Image")));
            this.BtnRemove.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnRemove.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnRemove.Location = new System.Drawing.Point(1247, 402);
            this.BtnRemove.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(80, 92);
            this.BtnRemove.TabIndex = 162;
            this.BtnRemove.Text = "Elim";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(594, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 154;
            this.label1.Text = "Estado Bono";
            // 
            // LblGiftCardStatus
            // 
            this.LblGiftCardStatus.AutoSize = true;
            this.LblGiftCardStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblGiftCardStatus.Location = new System.Drawing.Point(737, 106);
            this.LblGiftCardStatus.Name = "LblGiftCardStatus";
            this.LblGiftCardStatus.Size = new System.Drawing.Size(98, 16);
            this.LblGiftCardStatus.TabIndex = 154;
            this.LblGiftCardStatus.Text = "PENDIENTE";
            // 
            // FrmRedeemGiftCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.GrcProduct);
            this.Controls.Add(this.AxOPOSScale);
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.BtnRedeemCustomerName);
            this.Controls.Add(this.BtnIdentificationKeyPad);
            this.Controls.Add(this.BtnBarcodeKeyPad);
            this.Controls.Add(this.LblCustomerNameRegistered);
            this.Controls.Add(this.LblExpirationDate);
            this.Controls.Add(this.LblGiftCardStatus);
            this.Controls.Add(this.LblGiftCardInvoice);
            this.Controls.Add(this.BtnKeyPad);
            this.Controls.Add(this.LblCashierUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblCustomerAddress);
            this.Controls.Add(this.TxtRedeemName);
            this.Controls.Add(this.TxtRedeemIdentification);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.TxtGiftCardNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRedeemGiftCard";
            this.Text = "FrmRedeemGiftCard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRedeemGiftCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtGiftCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRedeemIdentification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRedeemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnKeyPad;
        private System.Windows.Forms.Label LblCustomerAddress;
        private DevExpress.XtraEditors.TextEdit TxtGiftCardNumber;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit TxtRedeemIdentification;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton BtnIdentificationKeyPad;
        private DevExpress.XtraEditors.TextEdit TxtRedeemName;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton BtnRedeemCustomerName;
        private DevExpress.XtraEditors.TextEdit TxtBarcode;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton BtnBarcodeKeyPad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCashierUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblGiftCardInvoice;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.Label LblExpirationDate;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblCustomerNameRegistered;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
        private AxOposScale_CCO.AxOPOSScale AxOPOSScale;
        private DevExpress.XtraGrid.GridControl GrcProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvProduct;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraEditors.SimpleButton BtnRemove;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblGiftCardStatus;
    }
}