namespace POS
{
    partial class FrmRemissionGuideOrderSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemissionGuideOrderSelector));
            this.GrcSalesOrder = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CmbTransport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnModify = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.CmbTransportDriver = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTransportReason = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.LblLine2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblEmissionPoint = new System.Windows.Forms.Label();
            this.LblEstablishment = new System.Windows.Forms.Label();
            this.LblRemissionGuideNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCashier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GrcSalesOrder
            // 
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GrcSalesOrder.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GrcSalesOrder.Location = new System.Drawing.Point(15, 127);
            this.GrcSalesOrder.MainView = this.GrvSalesOrder;
            this.GrcSalesOrder.Name = "GrcSalesOrder";
            this.GrcSalesOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.GrcSalesOrder.Size = new System.Drawing.Size(1019, 437);
            this.GrcSalesOrder.TabIndex = 141;
            this.GrcSalesOrder.UseEmbeddedNavigator = true;
            this.GrcSalesOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesOrder});
            // 
            // GrvSalesOrder
            // 
            this.GrvSalesOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn3});
            this.GrvSalesOrder.GridControl = this.GrcSalesOrder;
            this.GrvSalesOrder.Name = "GrvSalesOrder";
            this.GrvSalesOrder.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = " ";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "isSelected";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 99;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "# Ord";
            this.gridColumn2.FieldName = "SalesOrderId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 93;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fecha";
            this.gridColumn5.FieldName = "OrderDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 145;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Canal";
            this.gridColumn4.FieldName = "SalesOrigin";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 160;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cliente";
            this.gridColumn6.FieldName = "CustomerName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 291;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Direccion";
            this.gridColumn3.FieldName = "Address";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 337;
            // 
            // CmbTransport
            // 
            this.CmbTransport.Location = new System.Drawing.Point(257, 69);
            this.CmbTransport.Name = "CmbTransport";
            this.CmbTransport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTransport.Size = new System.Drawing.Size(208, 38);
            this.CmbTransport.TabIndex = 251;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(254, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 250;
            this.label4.Text = "Vehiculo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(484, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 250;
            this.label1.Text = "Conductor";
            // 
            // BtnModify
            // 
            this.BtnModify.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnModify.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnModify.Appearance.Options.UseBackColor = true;
            this.BtnModify.Appearance.Options.UseFont = true;
            this.BtnModify.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModify.ImageOptions.Image")));
            this.BtnModify.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnModify.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnModify.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnModify.Location = new System.Drawing.Point(874, 581);
            this.BtnModify.Margin = new System.Windows.Forms.Padding(5);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(160, 50);
            this.BtnModify.TabIndex = 252;
            this.BtnModify.Text = "Guardar";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnCancel.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnCancel.Location = new System.Drawing.Point(704, 581);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(160, 50);
            this.BtnCancel.TabIndex = 253;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CmbTransportDriver
            // 
            this.CmbTransportDriver.Location = new System.Drawing.Point(487, 69);
            this.CmbTransportDriver.Name = "CmbTransportDriver";
            this.CmbTransportDriver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTransportDriver.Size = new System.Drawing.Size(291, 38);
            this.CmbTransportDriver.TabIndex = 251;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(796, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 250;
            this.label2.Text = "Motivo";
            // 
            // CmbTransportReason
            // 
            this.CmbTransportReason.Enabled = false;
            this.CmbTransportReason.Location = new System.Drawing.Point(799, 69);
            this.CmbTransportReason.Name = "CmbTransportReason";
            this.CmbTransportReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbTransportReason.Size = new System.Drawing.Size(235, 38);
            this.CmbTransportReason.TabIndex = 251;
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.LblLine2.Location = new System.Drawing.Point(12, 9);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(79, 26);
            this.LblLine2.TabIndex = 259;
            this.LblLine2.Text = "Guia #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(225, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 28);
            this.label3.TabIndex = 254;
            this.label3.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(149, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 28);
            this.label5.TabIndex = 255;
            this.label5.Text = "-";
            // 
            // LblEmissionPoint
            // 
            this.LblEmissionPoint.AutoSize = true;
            this.LblEmissionPoint.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblEmissionPoint.Location = new System.Drawing.Point(176, 6);
            this.LblEmissionPoint.Name = "LblEmissionPoint";
            this.LblEmissionPoint.Size = new System.Drawing.Size(57, 28);
            this.LblEmissionPoint.TabIndex = 256;
            this.LblEmissionPoint.Text = "999";
            // 
            // LblEstablishment
            // 
            this.LblEstablishment.AutoSize = true;
            this.LblEstablishment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblEstablishment.Location = new System.Drawing.Point(97, 6);
            this.LblEstablishment.Name = "LblEstablishment";
            this.LblEstablishment.Size = new System.Drawing.Size(57, 28);
            this.LblEstablishment.TabIndex = 257;
            this.LblEstablishment.Text = "999";
            // 
            // LblRemissionGuideNumber
            // 
            this.LblRemissionGuideNumber.AutoSize = true;
            this.LblRemissionGuideNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Bold);
            this.LblRemissionGuideNumber.Location = new System.Drawing.Point(252, 6);
            this.LblRemissionGuideNumber.Name = "LblRemissionGuideNumber";
            this.LblRemissionGuideNumber.Size = new System.Drawing.Size(147, 28);
            this.LblRemissionGuideNumber.TabIndex = 258;
            this.LblRemissionGuideNumber.Text = "999999999";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 260;
            this.label6.Text = "Cajero";
            // 
            // LblCashier
            // 
            this.LblCashier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.LblCashier.Location = new System.Drawing.Point(12, 80);
            this.LblCashier.Name = "LblCashier";
            this.LblCashier.Size = new System.Drawing.Size(232, 27);
            this.LblCashier.TabIndex = 260;
            this.LblCashier.Text = "Usuario";
            // 
            // FrmRemissionGuideOrderSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1082, 657);
            this.ControlBox = false;
            this.Controls.Add(this.LblCashier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblLine2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblEmissionPoint);
            this.Controls.Add(this.LblEstablishment);
            this.Controls.Add(this.LblRemissionGuideNumber);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CmbTransportReason);
            this.Controls.Add(this.CmbTransportDriver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTransport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GrcSalesOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRemissionGuideOrderSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Guia de Remision";
            this.Load += new System.EventHandler(this.FrmRemissionGuideOrderSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbTransportReason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrcSalesOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesOrder;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbTransport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnModify;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbTransportDriver;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ImageComboBoxEdit CmbTransportReason;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Label LblLine2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblEmissionPoint;
        private System.Windows.Forms.Label LblEstablishment;
        private System.Windows.Forms.Label LblRemissionGuideNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCashier;
    }
}