namespace POS
{
    partial class FrmSalesOrderPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesOrderPicker));
            this.GrcSalesOrder = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // GrcSalesOrder
            // 
            this.GrcSalesOrder.Location = new System.Drawing.Point(26, 23);
            this.GrcSalesOrder.MainView = this.GrvSalesOrder;
            this.GrcSalesOrder.Name = "GrcSalesOrder";
            this.GrcSalesOrder.Size = new System.Drawing.Size(1312, 655);
            this.GrcSalesOrder.TabIndex = 139;
            this.GrcSalesOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesOrder});
            // 
            // GrvSalesOrder
            // 
            this.GrvSalesOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductDescription,
            this.Qty,
            this.Price,
            this.Discount,
            this.LineAmount,
            this.ProductId});
            this.GrvSalesOrder.GridControl = this.GrcSalesOrder;
            this.GrvSalesOrder.Name = "GrvSalesOrder";
            this.GrvSalesOrder.OptionsView.ShowGroupPanel = false;
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
            this.BtnAccept.TabIndex = 140;
            this.BtnAccept.Text = "Aceptar";
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
            this.BtnCancel.Location = new System.Drawing.Point(1022, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 141;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnRefresh.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnRefresh.Appearance.Options.UseBackColor = true;
            this.BtnRefresh.Appearance.Options.UseFont = true;
            this.BtnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.ImageOptions.Image")));
            this.BtnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnRefresh.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnRefresh.Location = new System.Drawing.Point(852, 704);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(160, 50);
            this.BtnRefresh.TabIndex = 141;
            this.BtnRefresh.Text = "Actualizar";
            // 
            // FrmSalesOrderPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrcSalesOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalesOrderPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSalesOrderPicker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSalesOrderPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrcSalesOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesOrder;
        private DevExpress.XtraGrid.Columns.GridColumn ProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn Qty;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Discount;
        private DevExpress.XtraGrid.Columns.GridColumn LineAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
    }
}