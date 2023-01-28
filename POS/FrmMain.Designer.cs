namespace POS
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnCancelSale = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSuspendSale = new DevExpress.XtraEditors.SimpleButton();
            this.BtnProductSearch = new DevExpress.XtraEditors.SimpleButton();
            this.Btn9 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPayment = new DevExpress.XtraEditors.SimpleButton();
            this.Btn8 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn7 = new DevExpress.XtraEditors.SimpleButton();
            this.LblBarcode = new System.Windows.Forms.Label();
            this.Btn6 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn4 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.Btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.GrcSalesDetail = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.ImgLogo = new System.Windows.Forms.PictureBox();
            this.LblInvoiceNumber = new System.Windows.Forms.Label();
            this.LblTitleCustomer = new System.Windows.Forms.Label();
            this.LblTitleCustomerName = new System.Windows.Forms.Label();
            this.LblEmissionPoint = new System.Windows.Forms.Label();
            this.LblTitleCustomerAddress = new System.Windows.Forms.Label();
            this.LblLine2 = new System.Windows.Forms.Label();
            this.LblLine1 = new System.Windows.Forms.Label();
            this.LblEstablishment = new System.Windows.Forms.Label();
            this.LblCustomerId = new System.Windows.Forms.Label();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.LblCustomerAddress = new System.Windows.Forms.Label();
            this.BtnCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.BtnQty = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblTitleTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblDiscAmount = new System.Windows.Forms.Label();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            this.BtnPrintLastInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.LblCashier = new System.Windows.Forms.Label();
            this.LblTitleCashier = new System.Windows.Forms.Label();
            this.BtnSalesOrigin = new DevExpress.XtraEditors.SimpleButton();
            this.ImgSalesOrigin = new DevExpress.XtraEditors.SvgImageBox();
            this.BtnAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReturns = new DevExpress.XtraEditors.SimpleButton();
            this.BtnProductChecker = new DevExpress.XtraEditors.SimpleButton();
            this.LblTitleCustomerEmail = new System.Windows.Forms.Label();
            this.LblCustomerEmail = new System.Windows.Forms.Label();
            this.ChbBbqZone = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AxOPOSScale = new AxOposScale_CCO.AxOPOSScale();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSalesOrigin)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScale)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelSale
            // 
            this.BtnCancelSale.AllowFocus = false;
            this.BtnCancelSale.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancelSale.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnCancelSale.Appearance.Options.UseBackColor = true;
            this.BtnCancelSale.Appearance.Options.UseFont = true;
            this.BtnCancelSale.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancelSale.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnCancelSale.ImageOptions.SvgImage")));
            this.BtnCancelSale.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnCancelSale.Location = new System.Drawing.Point(1132, 435);
            this.BtnCancelSale.Name = "BtnCancelSale";
            this.BtnCancelSale.Size = new System.Drawing.Size(220, 80);
            this.BtnCancelSale.TabIndex = 137;
            this.BtnCancelSale.Text = "Anular Venta";
            this.BtnCancelSale.Click += new System.EventHandler(this.BtnCancelSale_Click);
            // 
            // BtnSuspendSale
            // 
            this.BtnSuspendSale.AllowFocus = false;
            this.BtnSuspendSale.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSuspendSale.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnSuspendSale.Appearance.Options.UseBackColor = true;
            this.BtnSuspendSale.Appearance.Options.UseFont = true;
            this.BtnSuspendSale.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSuspendSale.ImageOptions.SvgImage = global::POS.Properties.Resources.SuspendSale;
            this.BtnSuspendSale.ImageOptions.SvgImageSize = new System.Drawing.Size(55, 55);
            this.BtnSuspendSale.Location = new System.Drawing.Point(1132, 349);
            this.BtnSuspendSale.Name = "BtnSuspendSale";
            this.BtnSuspendSale.Size = new System.Drawing.Size(220, 80);
            this.BtnSuspendSale.TabIndex = 136;
            this.BtnSuspendSale.Text = "Suspender";
            this.BtnSuspendSale.Click += new System.EventHandler(this.BtnSuspendSale_Click);
            // 
            // BtnProductSearch
            // 
            this.BtnProductSearch.AllowFocus = false;
            this.BtnProductSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnProductSearch.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnProductSearch.Appearance.Options.UseBackColor = true;
            this.BtnProductSearch.Appearance.Options.UseFont = true;
            this.BtnProductSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnProductSearch.ImageOptions.SvgImage = global::POS.Properties.Resources.productSearch2;
            this.BtnProductSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.BtnProductSearch.Location = new System.Drawing.Point(1132, 263);
            this.BtnProductSearch.Name = "BtnProductSearch";
            this.BtnProductSearch.Size = new System.Drawing.Size(220, 80);
            this.BtnProductSearch.TabIndex = 134;
            this.BtnProductSearch.Text = "Productos";
            this.BtnProductSearch.Click += new System.EventHandler(this.BtnProductSearch_Click);
            // 
            // Btn9
            // 
            this.Btn9.AllowFocus = false;
            this.Btn9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn9.Appearance.Options.UseBackColor = true;
            this.Btn9.Appearance.Options.UseFont = true;
            this.Btn9.Location = new System.Drawing.Point(1026, 231);
            this.Btn9.Margin = new System.Windows.Forms.Padding(8);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(75, 65);
            this.Btn9.TabIndex = 132;
            this.Btn9.Text = "9";
            this.Btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // BtnPayment
            // 
            this.BtnPayment.AllowFocus = false;
            this.BtnPayment.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPayment.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnPayment.Appearance.Options.UseBackColor = true;
            this.BtnPayment.Appearance.Options.UseFont = true;
            this.BtnPayment.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPayment.ImageOptions.SvgImage = global::POS.Properties.Resources.payment;
            this.BtnPayment.ImageOptions.SvgImageSize = new System.Drawing.Size(65, 65);
            this.BtnPayment.Location = new System.Drawing.Point(1132, 177);
            this.BtnPayment.Name = "BtnPayment";
            this.BtnPayment.Size = new System.Drawing.Size(220, 80);
            this.BtnPayment.TabIndex = 133;
            this.BtnPayment.Text = "Pagos";
            this.BtnPayment.Click += new System.EventHandler(this.BtnPayment_Click);
            // 
            // Btn8
            // 
            this.Btn8.AllowFocus = false;
            this.Btn8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn8.Appearance.Options.UseBackColor = true;
            this.Btn8.Appearance.Options.UseFont = true;
            this.Btn8.Location = new System.Drawing.Point(940, 231);
            this.Btn8.Margin = new System.Windows.Forms.Padding(8);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(75, 65);
            this.Btn8.TabIndex = 131;
            this.Btn8.Text = "8";
            this.Btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // Btn7
            // 
            this.Btn7.AllowFocus = false;
            this.Btn7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn7.Appearance.Options.UseBackColor = true;
            this.Btn7.Appearance.Options.UseFont = true;
            this.Btn7.Location = new System.Drawing.Point(856, 231);
            this.Btn7.Margin = new System.Windows.Forms.Padding(6);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(75, 65);
            this.Btn7.TabIndex = 130;
            this.Btn7.Text = "7";
            this.Btn7.Click += new System.EventHandler(this.Btn7_Click);
            // 
            // LblBarcode
            // 
            this.LblBarcode.AutoSize = true;
            this.LblBarcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.LblBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.LblBarcode.Location = new System.Drawing.Point(850, 151);
            this.LblBarcode.Name = "LblBarcode";
            this.LblBarcode.Size = new System.Drawing.Size(216, 28);
            this.LblBarcode.TabIndex = 119;
            this.LblBarcode.Text = "Código de Barras";
            // 
            // Btn6
            // 
            this.Btn6.AllowFocus = false;
            this.Btn6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn6.Appearance.Options.UseBackColor = true;
            this.Btn6.Appearance.Options.UseFont = true;
            this.Btn6.Location = new System.Drawing.Point(1026, 307);
            this.Btn6.Margin = new System.Windows.Forms.Padding(8);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(75, 65);
            this.Btn6.TabIndex = 129;
            this.Btn6.Text = "6";
            this.Btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // Btn5
            // 
            this.Btn5.AllowFocus = false;
            this.Btn5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn5.Appearance.Options.UseBackColor = true;
            this.Btn5.Appearance.Options.UseFont = true;
            this.Btn5.Location = new System.Drawing.Point(940, 307);
            this.Btn5.Margin = new System.Windows.Forms.Padding(6);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(75, 65);
            this.Btn5.TabIndex = 128;
            this.Btn5.Text = "5";
            this.Btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // Btn1
            // 
            this.Btn1.AllowFocus = false;
            this.Btn1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn1.Appearance.Options.UseBackColor = true;
            this.Btn1.Appearance.Options.UseFont = true;
            this.Btn1.Location = new System.Drawing.Point(856, 381);
            this.Btn1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(75, 65);
            this.Btn1.TabIndex = 124;
            this.Btn1.Text = "1";
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn4
            // 
            this.Btn4.AllowFocus = false;
            this.Btn4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn4.Appearance.Options.UseBackColor = true;
            this.Btn4.Appearance.Options.UseFont = true;
            this.Btn4.Location = new System.Drawing.Point(856, 307);
            this.Btn4.Margin = new System.Windows.Forms.Padding(5);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(75, 65);
            this.Btn4.TabIndex = 127;
            this.Btn4.Text = "4";
            this.Btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // Btn2
            // 
            this.Btn2.AllowFocus = false;
            this.Btn2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn2.Appearance.Options.UseBackColor = true;
            this.Btn2.Appearance.Options.UseFont = true;
            this.Btn2.Location = new System.Drawing.Point(940, 381);
            this.Btn2.Margin = new System.Windows.Forms.Padding(5);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(75, 65);
            this.Btn2.TabIndex = 125;
            this.Btn2.Text = "2";
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.AllowFocus = false;
            this.BtnDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnDelete.Appearance.Options.UseBackColor = true;
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnDelete.ImageOptions.SvgImage")));
            this.BtnDelete.Location = new System.Drawing.Point(856, 531);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(159, 45);
            this.BtnDelete.TabIndex = 122;
            this.BtnDelete.Text = "Borrar";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // Btn3
            // 
            this.Btn3.AllowFocus = false;
            this.Btn3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn3.Appearance.Options.UseBackColor = true;
            this.Btn3.Appearance.Options.UseFont = true;
            this.Btn3.Location = new System.Drawing.Point(1026, 381);
            this.Btn3.Margin = new System.Windows.Forms.Padding(6);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(75, 65);
            this.Btn3.TabIndex = 126;
            this.Btn3.Text = "3";
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.AllowFocus = false;
            this.BtnEnter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnEnter.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnEnter.Appearance.Options.UseBackColor = true;
            this.BtnEnter.Appearance.Options.UseFont = true;
            this.BtnEnter.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnEnter.ImageOptions.SvgImage")));
            this.BtnEnter.Location = new System.Drawing.Point(1027, 455);
            this.BtnEnter.Margin = new System.Windows.Forms.Padding(6);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(75, 121);
            this.BtnEnter.TabIndex = 121;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // Btn0
            // 
            this.Btn0.AllowFocus = false;
            this.Btn0.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.Btn0.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.Btn0.Appearance.Options.UseBackColor = true;
            this.Btn0.Appearance.Options.UseFont = true;
            this.Btn0.Location = new System.Drawing.Point(856, 455);
            this.Btn0.Margin = new System.Windows.Forms.Padding(5);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(159, 65);
            this.Btn0.TabIndex = 123;
            this.Btn0.Text = "0";
            this.Btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // GrcSalesDetail
            // 
            this.GrcSalesDetail.Location = new System.Drawing.Point(12, 159);
            this.GrcSalesDetail.MainView = this.GrvSalesDetail;
            this.GrcSalesDetail.Name = "GrcSalesDetail";
            this.GrcSalesDetail.Size = new System.Drawing.Size(823, 417);
            this.GrcSalesDetail.TabIndex = 138;
            this.GrcSalesDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesDetail});
            // 
            // GrvSalesDetail
            // 
            this.GrvSalesDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductDescription,
            this.Qty,
            this.Price,
            this.Discount,
            this.LineAmount,
            this.ProductId});
            this.GrvSalesDetail.GridControl = this.GrcSalesDetail;
            this.GrvSalesDetail.Name = "GrvSalesDetail";
            this.GrvSalesDetail.OptionsView.ShowGroupPanel = false;
            // 
            // ProductDescription
            // 
            this.ProductDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.ProductDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ProductDescription.Caption = "Producto";
            this.ProductDescription.FieldName = "ProductName";
            this.ProductDescription.MaxWidth = 455;
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.OptionsColumn.AllowEdit = false;
            this.ProductDescription.OptionsColumn.AllowMove = false;
            this.ProductDescription.OptionsColumn.AllowSize = false;
            this.ProductDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductDescription.OptionsColumn.FixedWidth = true;
            this.ProductDescription.OptionsColumn.ReadOnly = true;
            this.ProductDescription.Visible = true;
            this.ProductDescription.VisibleIndex = 0;
            this.ProductDescription.Width = 455;
            // 
            // Qty
            // 
            this.Qty.AppearanceHeader.Options.UseTextOptions = true;
            this.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Qty.Caption = "Cantidad";
            this.Qty.DisplayFormat.FormatString = "n3";
            this.Qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Qty.FieldName = "Quantity";
            this.Qty.MaxWidth = 85;
            this.Qty.Name = "Qty";
            this.Qty.OptionsColumn.AllowEdit = false;
            this.Qty.OptionsColumn.AllowMove = false;
            this.Qty.OptionsColumn.AllowSize = false;
            this.Qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Qty.OptionsColumn.FixedWidth = true;
            this.Qty.OptionsColumn.ReadOnly = true;
            this.Qty.Visible = true;
            this.Qty.VisibleIndex = 1;
            this.Qty.Width = 85;
            // 
            // Price
            // 
            this.Price.AppearanceHeader.Options.UseTextOptions = true;
            this.Price.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Price.Caption = "Precio";
            this.Price.DisplayFormat.FormatString = "c2";
            this.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Price.FieldName = "FinalPrice";
            this.Price.MaxWidth = 75;
            this.Price.Name = "Price";
            this.Price.OptionsColumn.AllowEdit = false;
            this.Price.OptionsColumn.AllowMove = false;
            this.Price.OptionsColumn.AllowSize = false;
            this.Price.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Price.OptionsColumn.FixedWidth = true;
            this.Price.OptionsColumn.ReadOnly = true;
            this.Price.Visible = true;
            this.Price.VisibleIndex = 2;
            // 
            // Discount
            // 
            this.Discount.AppearanceHeader.Options.UseTextOptions = true;
            this.Discount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Discount.Caption = "Descuento";
            this.Discount.DisplayFormat.FormatString = "c2";
            this.Discount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Discount.FieldName = "LineDiscount";
            this.Discount.MaxWidth = 85;
            this.Discount.Name = "Discount";
            this.Discount.OptionsColumn.AllowEdit = false;
            this.Discount.OptionsColumn.AllowMove = false;
            this.Discount.OptionsColumn.AllowSize = false;
            this.Discount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Discount.OptionsColumn.FixedWidth = true;
            this.Discount.OptionsColumn.ReadOnly = true;
            this.Discount.Visible = true;
            this.Discount.VisibleIndex = 3;
            this.Discount.Width = 85;
            // 
            // LineAmount
            // 
            this.LineAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.LineAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LineAmount.Caption = "Total";
            this.LineAmount.DisplayFormat.FormatString = "c2";
            this.LineAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LineAmount.FieldName = "LineAmount";
            this.LineAmount.MaxWidth = 85;
            this.LineAmount.Name = "LineAmount";
            this.LineAmount.OptionsColumn.AllowEdit = false;
            this.LineAmount.OptionsColumn.AllowMove = false;
            this.LineAmount.OptionsColumn.AllowSize = false;
            this.LineAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.LineAmount.OptionsColumn.FixedWidth = true;
            this.LineAmount.OptionsColumn.ReadOnly = true;
            this.LineAmount.Visible = true;
            this.LineAmount.VisibleIndex = 4;
            this.LineAmount.Width = 85;
            // 
            // ProductId
            // 
            this.ProductId.FieldName = "ProductId";
            this.ProductId.Name = "ProductId";
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(856, 178);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtBarcode.Properties.Appearance.Options.UseFont = true;
            this.TxtBarcode.Size = new System.Drawing.Size(245, 34);
            this.TxtBarcode.TabIndex = 1;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // ImgLogo
            // 
            this.ImgLogo.Image = global::POS.Properties.Resources.Logo_LaEspanola_New;
            this.ImgLogo.Location = new System.Drawing.Point(1, 1);
            this.ImgLogo.Margin = new System.Windows.Forms.Padding(0);
            this.ImgLogo.Name = "ImgLogo";
            this.ImgLogo.Size = new System.Drawing.Size(196, 155);
            this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgLogo.TabIndex = 139;
            this.ImgLogo.TabStop = false;
            // 
            // LblInvoiceNumber
            // 
            this.LblInvoiceNumber.AutoSize = true;
            this.LblInvoiceNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblInvoiceNumber.Location = new System.Drawing.Point(336, 12);
            this.LblInvoiceNumber.Name = "LblInvoiceNumber";
            this.LblInvoiceNumber.Size = new System.Drawing.Size(186, 34);
            this.LblInvoiceNumber.TabIndex = 140;
            this.LblInvoiceNumber.Text = "999999999";
            // 
            // LblTitleCustomer
            // 
            this.LblTitleCustomer.AutoSize = true;
            this.LblTitleCustomer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomer.Location = new System.Drawing.Point(200, 48);
            this.LblTitleCustomer.Name = "LblTitleCustomer";
            this.LblTitleCustomer.Size = new System.Drawing.Size(81, 20);
            this.LblTitleCustomer.TabIndex = 141;
            this.LblTitleCustomer.Text = "Cliente:";
            // 
            // LblTitleCustomerName
            // 
            this.LblTitleCustomerName.AutoSize = true;
            this.LblTitleCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerName.Location = new System.Drawing.Point(200, 75);
            this.LblTitleCustomerName.Name = "LblTitleCustomerName";
            this.LblTitleCustomerName.Size = new System.Drawing.Size(87, 20);
            this.LblTitleCustomerName.TabIndex = 142;
            this.LblTitleCustomerName.Text = "Nombre:";
            // 
            // LblEmissionPoint
            // 
            this.LblEmissionPoint.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblEmissionPoint.Location = new System.Drawing.Point(271, 12);
            this.LblEmissionPoint.Name = "LblEmissionPoint";
            this.LblEmissionPoint.Size = new System.Drawing.Size(59, 28);
            this.LblEmissionPoint.TabIndex = 143;
            this.LblEmissionPoint.Text = "999";
            // 
            // LblTitleCustomerAddress
            // 
            this.LblTitleCustomerAddress.AutoSize = true;
            this.LblTitleCustomerAddress.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerAddress.Location = new System.Drawing.Point(200, 102);
            this.LblTitleCustomerAddress.Name = "LblTitleCustomerAddress";
            this.LblTitleCustomerAddress.Size = new System.Drawing.Size(104, 20);
            this.LblTitleCustomerAddress.TabIndex = 144;
            this.LblTitleCustomerAddress.Text = "Dirección:";
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine2.Location = new System.Drawing.Point(321, 12);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(24, 32);
            this.LblLine2.TabIndex = 145;
            this.LblLine2.Text = "-";
            // 
            // LblLine1
            // 
            this.LblLine1.AutoSize = true;
            this.LblLine1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine1.Location = new System.Drawing.Point(254, 12);
            this.LblLine1.Name = "LblLine1";
            this.LblLine1.Size = new System.Drawing.Size(24, 32);
            this.LblLine1.TabIndex = 146;
            this.LblLine1.Text = "-";
            // 
            // LblEstablishment
            // 
            this.LblEstablishment.AutoSize = true;
            this.LblEstablishment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblEstablishment.Location = new System.Drawing.Point(200, 12);
            this.LblEstablishment.Name = "LblEstablishment";
            this.LblEstablishment.Size = new System.Drawing.Size(72, 34);
            this.LblEstablishment.TabIndex = 147;
            this.LblEstablishment.Text = "999";
            // 
            // LblCustomerId
            // 
            this.LblCustomerId.AutoSize = true;
            this.LblCustomerId.Location = new System.Drawing.Point(292, 48);
            this.LblCustomerId.Name = "LblCustomerId";
            this.LblCustomerId.Size = new System.Drawing.Size(139, 20);
            this.LblCustomerId.TabIndex = 148;
            this.LblCustomerId.Text = "9999999999999";
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.AutoSize = true;
            this.LblCustomerName.Location = new System.Drawing.Point(292, 75);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(183, 20);
            this.LblCustomerName.TabIndex = 149;
            this.LblCustomerName.Text = "CONSUMIDOR FINAL";
            // 
            // LblCustomerAddress
            // 
            this.LblCustomerAddress.AutoSize = true;
            this.LblCustomerAddress.Location = new System.Drawing.Point(292, 102);
            this.LblCustomerAddress.Name = "LblCustomerAddress";
            this.LblCustomerAddress.Size = new System.Drawing.Size(111, 20);
            this.LblCustomerAddress.TabIndex = 150;
            this.LblCustomerAddress.Text = "GUAYAQUIL";
            // 
            // BtnCustomer
            // 
            this.BtnCustomer.AllowFocus = false;
            this.BtnCustomer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCustomer.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCustomer.Appearance.Options.UseBackColor = true;
            this.BtnCustomer.Appearance.Options.UseFont = true;
            this.BtnCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCustomer.ImageOptions.SvgImage = global::POS.Properties.Resources.user4;
            this.BtnCustomer.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCustomer.Location = new System.Drawing.Point(268, 709);
            this.BtnCustomer.Name = "BtnCustomer";
            this.BtnCustomer.Size = new System.Drawing.Size(250, 45);
            this.BtnCustomer.TabIndex = 151;
            this.BtnCustomer.Text = "Cliente";
            this.BtnCustomer.Click += new System.EventHandler(this.BtnCustomer_Click);
            // 
            // BtnQty
            // 
            this.BtnQty.AllowFocus = false;
            this.BtnQty.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnQty.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnQty.Appearance.Options.UseBackColor = true;
            this.BtnQty.Appearance.Options.UseFont = true;
            this.BtnQty.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnQty.ImageOptions.SvgImage = global::POS.Properties.Resources.calculator2;
            this.BtnQty.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.BtnQty.Location = new System.Drawing.Point(15, 585);
            this.BtnQty.Margin = new System.Windows.Forms.Padding(6);
            this.BtnQty.Name = "BtnQty";
            this.BtnQty.Size = new System.Drawing.Size(80, 115);
            this.BtnQty.TabIndex = 152;
            this.BtnQty.Text = "Cant";
            this.BtnQty.Click += new System.EventHandler(this.BtnQty_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.AllowFocus = false;
            this.BtnRemove.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRemove.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRemove.Appearance.Options.UseBackColor = true;
            this.BtnRemove.Appearance.Options.UseFont = true;
            this.BtnRemove.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnRemove.ImageOptions.SvgImage = global::POS.Properties.Resources.remove;
            this.BtnRemove.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnRemove.Location = new System.Drawing.Point(104, 585);
            this.BtnRemove.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(80, 115);
            this.BtnRemove.TabIndex = 153;
            this.BtnRemove.Text = "Anul";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Bold);
            this.LblTotal.Location = new System.Drawing.Point(1132, 41);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(228, 49);
            this.LblTotal.TabIndex = 154;
            this.LblTotal.Text = "0.00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleTotal
            // 
            this.LblTitleTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblTitleTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.LblTitleTotal.Location = new System.Drawing.Point(1043, 55);
            this.LblTitleTotal.Name = "LblTitleTotal";
            this.LblTitleTotal.Size = new System.Drawing.Size(105, 32);
            this.LblTitleTotal.TabIndex = 155;
            this.LblTitleTotal.Text = "Total $";
            this.LblTitleTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.label1.Location = new System.Drawing.Point(1041, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 157;
            this.label1.Text = "Descuento $";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblDiscAmount
            // 
            this.LblDiscAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblDiscAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F, System.Drawing.FontStyle.Bold);
            this.LblDiscAmount.Location = new System.Drawing.Point(1192, 93);
            this.LblDiscAmount.Name = "LblDiscAmount";
            this.LblDiscAmount.Size = new System.Drawing.Size(163, 36);
            this.LblDiscAmount.TabIndex = 156;
            this.LblDiscAmount.Text = "0.00";
            this.LblDiscAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(452, 41);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(240, 240);
            this.AxOPOSScanner.TabIndex = 169;
            this.AxOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.AxOPOSScanner_DataEvent);
            // 
            // BtnPrintLastInvoice
            // 
            this.BtnPrintLastInvoice.AllowFocus = false;
            this.BtnPrintLastInvoice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnPrintLastInvoice.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnPrintLastInvoice.Appearance.Options.UseBackColor = true;
            this.BtnPrintLastInvoice.Appearance.Options.UseFont = true;
            this.BtnPrintLastInvoice.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnPrintLastInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPrintLastInvoice.ImageOptions.SvgImage")));
            this.BtnPrintLastInvoice.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnPrintLastInvoice.Location = new System.Drawing.Point(524, 709);
            this.BtnPrintLastInvoice.Name = "BtnPrintLastInvoice";
            this.BtnPrintLastInvoice.Size = new System.Drawing.Size(250, 45);
            this.BtnPrintLastInvoice.TabIndex = 151;
            this.BtnPrintLastInvoice.Text = "Ultima Factura";
            this.BtnPrintLastInvoice.Click += new System.EventHandler(this.BtnPrintLastInvoice_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.AllowFocus = false;
            this.BtnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnExit.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnExit.Appearance.Options.UseBackColor = true;
            this.BtnExit.Appearance.Options.UseFont = true;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnExit.ImageOptions.SvgImage")));
            this.BtnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnExit.Location = new System.Drawing.Point(1102, 709);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(5);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(250, 45);
            this.BtnExit.TabIndex = 160;
            this.BtnExit.Text = "Salir";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LblCashier
            // 
            this.LblCashier.AutoSize = true;
            this.LblCashier.Location = new System.Drawing.Point(292, 594);
            this.LblCashier.Name = "LblCashier";
            this.LblCashier.Size = new System.Drawing.Size(80, 20);
            this.LblCashier.TabIndex = 162;
            this.LblCashier.Text = "CAJERO";
            // 
            // LblTitleCashier
            // 
            this.LblTitleCashier.AutoSize = true;
            this.LblTitleCashier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCashier.Location = new System.Drawing.Point(200, 594);
            this.LblTitleCashier.Name = "LblTitleCashier";
            this.LblTitleCashier.Size = new System.Drawing.Size(76, 20);
            this.LblTitleCashier.TabIndex = 161;
            this.LblTitleCashier.Text = "Cajero:";
            // 
            // BtnSalesOrigin
            // 
            this.BtnSalesOrigin.AllowFocus = false;
            this.BtnSalesOrigin.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSalesOrigin.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSalesOrigin.Appearance.Options.UseBackColor = true;
            this.BtnSalesOrigin.Appearance.Options.UseFont = true;
            this.BtnSalesOrigin.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSalesOrigin.ImageOptions.SvgImage = global::POS.Properties.Resources.salesOrigin1;
            this.BtnSalesOrigin.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.BtnSalesOrigin.Location = new System.Drawing.Point(780, 709);
            this.BtnSalesOrigin.Name = "BtnSalesOrigin";
            this.BtnSalesOrigin.Size = new System.Drawing.Size(250, 45);
            this.BtnSalesOrigin.TabIndex = 163;
            this.BtnSalesOrigin.Text = "Origen Venta";
            this.BtnSalesOrigin.Click += new System.EventHandler(this.BtnSalesOrigin_Click);
            // 
            // ImgSalesOrigin
            // 
            this.ImgSalesOrigin.Location = new System.Drawing.Point(875, 12);
            this.ImgSalesOrigin.Name = "ImgSalesOrigin";
            this.ImgSalesOrigin.Size = new System.Drawing.Size(120, 120);
            this.ImgSalesOrigin.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Squeeze;
            this.ImgSalesOrigin.TabIndex = 164;
            this.ImgSalesOrigin.Text = "svgImageBox1";
            this.ImgSalesOrigin.Visible = false;
            // 
            // BtnAdvance
            // 
            this.BtnAdvance.AllowFocus = false;
            this.BtnAdvance.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnAdvance.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnAdvance.Appearance.Options.UseBackColor = true;
            this.BtnAdvance.Appearance.Options.UseFont = true;
            this.BtnAdvance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdvance.ImageOptions.Image")));
            this.BtnAdvance.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnAdvance.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnAdvance.Location = new System.Drawing.Point(1132, 521);
            this.BtnAdvance.Name = "BtnAdvance";
            this.BtnAdvance.Size = new System.Drawing.Size(220, 80);
            this.BtnAdvance.TabIndex = 137;
            this.BtnAdvance.Text = "Anticipos";
            this.BtnAdvance.Visible = false;
            this.BtnAdvance.Click += new System.EventHandler(this.BtnAdvance_Click);
            // 
            // BtnReturns
            // 
            this.BtnReturns.AllowFocus = false;
            this.BtnReturns.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnReturns.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.BtnReturns.Appearance.Options.UseBackColor = true;
            this.BtnReturns.Appearance.Options.UseFont = true;
            this.BtnReturns.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnReturns.ImageOptions.Image")));
            this.BtnReturns.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnReturns.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.BtnReturns.Location = new System.Drawing.Point(1132, 607);
            this.BtnReturns.Name = "BtnReturns";
            this.BtnReturns.Size = new System.Drawing.Size(220, 80);
            this.BtnReturns.TabIndex = 165;
            this.BtnReturns.Text = "Nota Crédito";
            this.BtnReturns.Visible = false;
            this.BtnReturns.Click += new System.EventHandler(this.BtnReturns_Click);
            // 
            // BtnProductChecker
            // 
            this.BtnProductChecker.AllowFocus = false;
            this.BtnProductChecker.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnProductChecker.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnProductChecker.Appearance.Options.UseBackColor = true;
            this.BtnProductChecker.Appearance.Options.UseFont = true;
            this.BtnProductChecker.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnProductChecker.ImageOptions.Image")));
            this.BtnProductChecker.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnProductChecker.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.BtnProductChecker.Location = new System.Drawing.Point(12, 709);
            this.BtnProductChecker.Name = "BtnProductChecker";
            this.BtnProductChecker.Size = new System.Drawing.Size(250, 45);
            this.BtnProductChecker.TabIndex = 163;
            this.BtnProductChecker.Text = "Producto";
            this.BtnProductChecker.Visible = false;
            this.BtnProductChecker.Click += new System.EventHandler(this.BtnProductChecker_Click);
            // 
            // LblTitleCustomerEmail
            // 
            this.LblTitleCustomerEmail.AutoSize = true;
            this.LblTitleCustomerEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerEmail.Location = new System.Drawing.Point(200, 132);
            this.LblTitleCustomerEmail.Name = "LblTitleCustomerEmail";
            this.LblTitleCustomerEmail.Size = new System.Drawing.Size(66, 20);
            this.LblTitleCustomerEmail.TabIndex = 144;
            this.LblTitleCustomerEmail.Text = "Email:";
            // 
            // LblCustomerEmail
            // 
            this.LblCustomerEmail.AutoSize = true;
            this.LblCustomerEmail.Location = new System.Drawing.Point(292, 132);
            this.LblCustomerEmail.Name = "LblCustomerEmail";
            this.LblCustomerEmail.Size = new System.Drawing.Size(181, 20);
            this.LblCustomerEmail.TabIndex = 150;
            this.LblCustomerEmail.Text = "@laespanola.com.ec";
            // 
            // ChbBbqZone
            // 
            this.ChbBbqZone.AutoSize = true;
            this.ChbBbqZone.Location = new System.Drawing.Point(10, 26);
            this.ChbBbqZone.Name = "ChbBbqZone";
            this.ChbBbqZone.Size = new System.Drawing.Size(153, 24);
            this.ChbBbqZone.TabIndex = 166;
            this.ChbBbqZone.Text = "Zona Parrillera";
            this.ChbBbqZone.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChbBbqZone);
            this.groupBox1.Location = new System.Drawing.Point(524, 587);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 100);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            this.groupBox1.Visible = false;
            // 
            // AxOPOSScale
            // 
            this.AxOPOSScale.Enabled = true;
            this.AxOPOSScale.Location = new System.Drawing.Point(619, 41);
            this.AxOPOSScale.Name = "AxOPOSScale";
            this.AxOPOSScale.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScale.OcxState")));
            this.AxOPOSScale.Size = new System.Drawing.Size(240, 240);
            this.AxOPOSScale.TabIndex = 170;
            // 
            // FrmMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.AxOPOSScale);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnReturns);
            this.Controls.Add(this.ImgSalesOrigin);
            this.Controls.Add(this.BtnProductChecker);
            this.Controls.Add(this.BtnSalesOrigin);
            this.Controls.Add(this.LblCashier);
            this.Controls.Add(this.LblTitleCashier);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblDiscAmount);
            this.Controls.Add(this.LblTitleTotal);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnQty);
            this.Controls.Add(this.BtnPrintLastInvoice);
            this.Controls.Add(this.BtnCustomer);
            this.Controls.Add(this.LblCustomerEmail);
            this.Controls.Add(this.LblCustomerAddress);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.LblCustomerId);
            this.Controls.Add(this.LblEstablishment);
            this.Controls.Add(this.LblLine1);
            this.Controls.Add(this.LblLine2);
            this.Controls.Add(this.LblTitleCustomerEmail);
            this.Controls.Add(this.LblTitleCustomerAddress);
            this.Controls.Add(this.LblEmissionPoint);
            this.Controls.Add(this.LblTitleCustomerName);
            this.Controls.Add(this.LblTitleCustomer);
            this.Controls.Add(this.LblInvoiceNumber);
            this.Controls.Add(this.ImgLogo);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.GrcSalesDetail);
            this.Controls.Add(this.BtnAdvance);
            this.Controls.Add(this.BtnCancelSale);
            this.Controls.Add(this.BtnSuspendSale);
            this.Controls.Add(this.BtnProductSearch);
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.BtnPayment);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.LblBarcode);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.Btn0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSalesOrigin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnCancelSale;
        private DevExpress.XtraEditors.SimpleButton BtnSuspendSale;
        private DevExpress.XtraEditors.SimpleButton BtnProductSearch;
        private DevExpress.XtraEditors.SimpleButton Btn9;
        private DevExpress.XtraEditors.SimpleButton BtnPayment;
        private DevExpress.XtraEditors.SimpleButton Btn8;
        private DevExpress.XtraEditors.SimpleButton Btn7;
        private System.Windows.Forms.Label LblBarcode;
        private DevExpress.XtraEditors.SimpleButton Btn6;
        private DevExpress.XtraEditors.SimpleButton Btn5;
        private DevExpress.XtraEditors.SimpleButton Btn1;
        private DevExpress.XtraEditors.SimpleButton Btn4;
        private DevExpress.XtraEditors.SimpleButton Btn2;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton Btn3;
        private DevExpress.XtraEditors.SimpleButton BtnEnter;
        private DevExpress.XtraEditors.SimpleButton Btn0;
        private DevExpress.XtraGrid.GridControl GrcSalesDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesDetail;
        private DevExpress.XtraEditors.TextEdit TxtBarcode;
        private System.Windows.Forms.PictureBox ImgLogo;
        private System.Windows.Forms.Label LblInvoiceNumber;
        private System.Windows.Forms.Label LblTitleCustomer;
        private System.Windows.Forms.Label LblTitleCustomerName;
        private System.Windows.Forms.Label LblEmissionPoint;
        private System.Windows.Forms.Label LblTitleCustomerAddress;
        private System.Windows.Forms.Label LblLine2;
        private System.Windows.Forms.Label LblLine1;
        private System.Windows.Forms.Label LblEstablishment;
        private System.Windows.Forms.Label LblCustomerAddress;
        private DevExpress.XtraEditors.SimpleButton BtnCustomer;
        private DevExpress.XtraEditors.SimpleButton BtnQty;
        private DevExpress.XtraEditors.SimpleButton BtnRemove;
        public System.Windows.Forms.Label LblCustomerId;
        public System.Windows.Forms.Label LblCustomerName;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblTitleTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDiscAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn Qty;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn LineAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private DevExpress.XtraEditors.SimpleButton BtnPrintLastInvoice;
        private System.Windows.Forms.Label LblCashier;
        private System.Windows.Forms.Label LblTitleCashier;
        private DevExpress.XtraEditors.SimpleButton BtnSalesOrigin;
        private DevExpress.XtraEditors.SvgImageBox ImgSalesOrigin;
        private DevExpress.XtraEditors.SimpleButton BtnAdvance;
        private DevExpress.XtraEditors.SimpleButton BtnReturns;
        private DevExpress.XtraEditors.SimpleButton BtnProductChecker;
        private System.Windows.Forms.Label LblTitleCustomerEmail;
        private System.Windows.Forms.Label LblCustomerEmail;
        private System.Windows.Forms.CheckBox ChbBbqZone;
        private System.Windows.Forms.GroupBox groupBox1;
        private AxOposScale_CCO.AxOPOSScale AxOPOSScale;
    }
}