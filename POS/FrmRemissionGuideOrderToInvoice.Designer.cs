
namespace POS
{
    partial class FrmRemissionGuideOrderToInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemissionGuideOrderToInvoice));
            this.BtnSaveRemissionGuide = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.LblDriverName = new System.Windows.Forms.Label();
            this.LblTransportPlate = new System.Windows.Forms.Label();
            this.LblLine2 = new System.Windows.Forms.Label();
            this.LblTitleCustomerName = new System.Windows.Forms.Label();
            this.LblTitleCustomer = new System.Windows.Forms.Label();
            this.LblRemissionGuideNumber = new System.Windows.Forms.Label();
            this.BtnModifyOrder = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOrderPaymentMethod = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancelOrder = new DevExpress.XtraEditors.SimpleButton();
            this.GrcSalesOrder = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.BtnCancelRemissionGuide = new DevExpress.XtraEditors.SimpleButton();
            this.AxOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaveRemissionGuide
            // 
            this.BtnSaveRemissionGuide.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSaveRemissionGuide.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSaveRemissionGuide.Appearance.Options.UseBackColor = true;
            this.BtnSaveRemissionGuide.Appearance.Options.UseFont = true;
            this.BtnSaveRemissionGuide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveRemissionGuide.ImageOptions.Image")));
            this.BtnSaveRemissionGuide.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnSaveRemissionGuide.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnSaveRemissionGuide.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnSaveRemissionGuide.Location = new System.Drawing.Point(1026, 704);
            this.BtnSaveRemissionGuide.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSaveRemissionGuide.Name = "BtnSaveRemissionGuide";
            this.BtnSaveRemissionGuide.Size = new System.Drawing.Size(326, 50);
            this.BtnSaveRemissionGuide.TabIndex = 142;
            this.BtnSaveRemissionGuide.Text = "Convertir Pedidos En Factura";
            this.BtnSaveRemissionGuide.Click += new System.EventHandler(this.BtnSaveRemissionGuide_Click);
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
            this.BtnCancel.Location = new System.Drawing.Point(856, 704);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 143;
            this.BtnCancel.Text = "Cancelar";
            // 
            // LblDriverName
            // 
            this.LblDriverName.AutoSize = true;
            this.LblDriverName.Location = new System.Drawing.Point(159, 93);
            this.LblDriverName.Name = "LblDriverName";
            this.LblDriverName.Size = new System.Drawing.Size(81, 16);
            this.LblDriverName.TabIndex = 200;
            this.LblDriverName.Text = "Repartidor";
            // 
            // LblTransportPlate
            // 
            this.LblTransportPlate.AutoSize = true;
            this.LblTransportPlate.Location = new System.Drawing.Point(161, 62);
            this.LblTransportPlate.Name = "LblTransportPlate";
            this.LblTransportPlate.Size = new System.Drawing.Size(75, 16);
            this.LblTransportPlate.TabIndex = 199;
            this.LblTransportPlate.Text = "GTA-1234";
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine2.Location = new System.Drawing.Point(21, 21);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(79, 26);
            this.LblLine2.TabIndex = 198;
            this.LblLine2.Text = "Guia #";
            // 
            // LblTitleCustomerName
            // 
            this.LblTitleCustomerName.AutoSize = true;
            this.LblTitleCustomerName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomerName.Location = new System.Drawing.Point(21, 93);
            this.LblTitleCustomerName.Name = "LblTitleCustomerName";
            this.LblTitleCustomerName.Size = new System.Drawing.Size(96, 16);
            this.LblTitleCustomerName.TabIndex = 197;
            this.LblTitleCustomerName.Text = "Repartidor:";
            // 
            // LblTitleCustomer
            // 
            this.LblTitleCustomer.AutoSize = true;
            this.LblTitleCustomer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblTitleCustomer.Location = new System.Drawing.Point(23, 62);
            this.LblTitleCustomer.Name = "LblTitleCustomer";
            this.LblTitleCustomer.Size = new System.Drawing.Size(126, 16);
            this.LblTitleCustomer.TabIndex = 196;
            this.LblTitleCustomer.Text = "Placa Vehiculo:";
            // 
            // LblRemissionGuideNumber
            // 
            this.LblRemissionGuideNumber.AutoSize = true;
            this.LblRemissionGuideNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblRemissionGuideNumber.Location = new System.Drawing.Point(106, 18);
            this.LblRemissionGuideNumber.Name = "LblRemissionGuideNumber";
            this.LblRemissionGuideNumber.Size = new System.Drawing.Size(255, 28);
            this.LblRemissionGuideNumber.TabIndex = 195;
            this.LblRemissionGuideNumber.Text = "999-999-999999999";
            // 
            // BtnModifyOrder
            // 
            this.BtnModifyOrder.AllowFocus = false;
            this.BtnModifyOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModifyOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnModifyOrder.Appearance.Options.UseBackColor = true;
            this.BtnModifyOrder.Appearance.Options.UseFont = true;
            this.BtnModifyOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModifyOrder.ImageOptions.Image")));
            this.BtnModifyOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnModifyOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnModifyOrder.Location = new System.Drawing.Point(1259, 338);
            this.BtnModifyOrder.Margin = new System.Windows.Forms.Padding(6);
            this.BtnModifyOrder.Name = "BtnModifyOrder";
            this.BtnModifyOrder.Size = new System.Drawing.Size(91, 92);
            this.BtnModifyOrder.TabIndex = 201;
            this.BtnModifyOrder.Text = "Edit";
            this.BtnModifyOrder.Visible = false;
            // 
            // BtnOrderPaymentMethod
            // 
            this.BtnOrderPaymentMethod.AllowFocus = false;
            this.BtnOrderPaymentMethod.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnOrderPaymentMethod.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnOrderPaymentMethod.Appearance.Options.UseBackColor = true;
            this.BtnOrderPaymentMethod.Appearance.Options.UseFont = true;
            this.BtnOrderPaymentMethod.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnOrderPaymentMethod.ImageOptions.SvgImage = global::POS.Properties.Resources.creditCard;
            this.BtnOrderPaymentMethod.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnOrderPaymentMethod.Location = new System.Drawing.Point(1260, 130);
            this.BtnOrderPaymentMethod.Margin = new System.Windows.Forms.Padding(6);
            this.BtnOrderPaymentMethod.Name = "BtnOrderPaymentMethod";
            this.BtnOrderPaymentMethod.Size = new System.Drawing.Size(91, 92);
            this.BtnOrderPaymentMethod.TabIndex = 202;
            this.BtnOrderPaymentMethod.Text = "Pago";
            this.BtnOrderPaymentMethod.Click += new System.EventHandler(this.BtnOrderPaymentMethod_Click);
            // 
            // BtnCancelOrder
            // 
            this.BtnCancelOrder.AllowFocus = false;
            this.BtnCancelOrder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancelOrder.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancelOrder.Appearance.Options.UseBackColor = true;
            this.BtnCancelOrder.Appearance.Options.UseFont = true;
            this.BtnCancelOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelOrder.ImageOptions.Image")));
            this.BtnCancelOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.BtnCancelOrder.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            this.BtnCancelOrder.Location = new System.Drawing.Point(1259, 234);
            this.BtnCancelOrder.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCancelOrder.Name = "BtnCancelOrder";
            this.BtnCancelOrder.Size = new System.Drawing.Size(92, 92);
            this.BtnCancelOrder.TabIndex = 202;
            this.BtnCancelOrder.Text = "Anular";
            this.BtnCancelOrder.Click += new System.EventHandler(this.BtnCancelOrder_Click);
            // 
            // GrcSalesOrder
            // 
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcSalesOrder.Location = new System.Drawing.Point(24, 130);
            this.GrcSalesOrder.MainView = this.GrvSalesOrder;
            this.GrcSalesOrder.Name = "GrcSalesOrder";
            this.GrcSalesOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.GrcSalesOrder.Size = new System.Drawing.Size(1207, 554);
            this.GrcSalesOrder.TabIndex = 203;
            this.GrcSalesOrder.UseEmbeddedNavigator = true;
            this.GrcSalesOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesOrder});
            // 
            // GrvSalesOrder
            // 
            this.GrvSalesOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn5});
            this.GrvSalesOrder.GridControl = this.GrcSalesOrder;
            this.GrvSalesOrder.Name = "GrvSalesOrder";
            this.GrvSalesOrder.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "# Ord";
            this.gridColumn2.FieldName = "SalesOrderId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 122;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Canal";
            this.gridColumn4.FieldName = "ChannelName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 248;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Cliente";
            this.gridColumn6.FieldName = "CustomerName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 301;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Monto";
            this.gridColumn3.DisplayFormat.FormatString = "c2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Amount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 154;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Pagado";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "HavePaymentMethod";
            this.gridColumn1.MaxWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Anulado";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn5.FieldName = "IsCancelled";
            this.gridColumn5.MaxWidth = 100;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 100;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // BtnCancelRemissionGuide
            // 
            this.BtnCancelRemissionGuide.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancelRemissionGuide.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancelRemissionGuide.Appearance.Options.UseBackColor = true;
            this.BtnCancelRemissionGuide.Appearance.Options.UseFont = true;
            this.BtnCancelRemissionGuide.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnCancelRemissionGuide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelRemissionGuide.ImageOptions.Image")));
            this.BtnCancelRemissionGuide.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancelRemissionGuide.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnCancelRemissionGuide.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancelRemissionGuide.Location = new System.Drawing.Point(556, 704);
            this.BtnCancelRemissionGuide.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancelRemissionGuide.Name = "BtnCancelRemissionGuide";
            this.BtnCancelRemissionGuide.Size = new System.Drawing.Size(203, 50);
            this.BtnCancelRemissionGuide.TabIndex = 142;
            this.BtnCancelRemissionGuide.Text = "Cancelar Guia";
            this.BtnCancelRemissionGuide.Click += new System.EventHandler(this.BtnCancelRemissionGuide_Click);
            // 
            // AxOPOSScanner
            // 
            this.AxOPOSScanner.Enabled = true;
            this.AxOPOSScanner.Location = new System.Drawing.Point(1039, 30);
            this.AxOPOSScanner.Name = "AxOPOSScanner";
            this.AxOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxOPOSScanner.OcxState")));
            this.AxOPOSScanner.Size = new System.Drawing.Size(192, 192);
            this.AxOPOSScanner.TabIndex = 205;
            // 
            // FrmRemissionGuideOrderToInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.AxOPOSScanner);
            this.Controls.Add(this.GrcSalesOrder);
            this.Controls.Add(this.BtnModifyOrder);
            this.Controls.Add(this.BtnCancelOrder);
            this.Controls.Add(this.BtnOrderPaymentMethod);
            this.Controls.Add(this.LblDriverName);
            this.Controls.Add(this.LblTransportPlate);
            this.Controls.Add(this.LblLine2);
            this.Controls.Add(this.LblTitleCustomerName);
            this.Controls.Add(this.LblTitleCustomer);
            this.Controls.Add(this.LblRemissionGuideNumber);
            this.Controls.Add(this.BtnCancelRemissionGuide);
            this.Controls.Add(this.BtnSaveRemissionGuide);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRemissionGuideOrderToInvoice";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FrmRemissionGuideOrderToInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRemissionGuideOrderToInvoice_FormClosing);
            this.Load += new System.EventHandler(this.FrmRemissionGuideOrderToInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxOPOSScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnSaveRemissionGuide;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        public System.Windows.Forms.Label LblDriverName;
        public System.Windows.Forms.Label LblTransportPlate;
        private System.Windows.Forms.Label LblLine2;
        private System.Windows.Forms.Label LblTitleCustomerName;
        private System.Windows.Forms.Label LblTitleCustomer;
        private System.Windows.Forms.Label LblRemissionGuideNumber;
        private DevExpress.XtraEditors.SimpleButton BtnModifyOrder;
        private DevExpress.XtraEditors.SimpleButton BtnOrderPaymentMethod;
        private DevExpress.XtraEditors.SimpleButton BtnCancelOrder;
        private DevExpress.XtraGrid.GridControl GrcSalesOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton BtnCancelRemissionGuide;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner;
    }
}