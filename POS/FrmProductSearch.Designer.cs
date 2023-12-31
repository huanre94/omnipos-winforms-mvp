﻿namespace POS
{
    partial class FrmProductSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductSearch));
            this.TxtSearchName = new DevExpress.XtraEditors.TextEdit();
            this.GrcSalesDetail = new DevExpress.XtraGrid.GridControl();
            this.GrvSalesDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LblCustomerAddress = new System.Windows.Forms.Label();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKeyPad = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSearchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtSearchName
            // 
            this.TxtSearchName.Location = new System.Drawing.Point(141, 15);
            this.TxtSearchName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtSearchName.Name = "TxtSearchName";
            this.TxtSearchName.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.TxtSearchName.Properties.Appearance.Options.UseFont = true;
            this.TxtSearchName.Size = new System.Drawing.Size(551, 34);
            this.TxtSearchName.TabIndex = 139;

            // 
            // GrcSalesDetail
            // 
            this.GrcSalesDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrcSalesDetail.Location = new System.Drawing.Point(27, 80);
            this.GrcSalesDetail.MainView = this.GrvSalesDetail;
            this.GrcSalesDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrcSalesDetail.Name = "GrcSalesDetail";
            this.GrcSalesDetail.Size = new System.Drawing.Size(785, 521);
            this.GrcSalesDetail.TabIndex = 141;
            this.GrcSalesDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrvSalesDetail});
            
            // 
            // GrvSalesDetail
            // 
            this.GrvSalesDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductId,
            this.ProductDescription,
            this.Stock});
            this.GrvSalesDetail.DetailHeight = 437;
            this.GrvSalesDetail.GridControl = this.GrcSalesDetail;
            this.GrvSalesDetail.Name = "GrvSalesDetail";
            this.GrvSalesDetail.OptionsView.ShowGroupPanel = false;
            // 
            // ProductId
            // 
            this.ProductId.FieldName = "ProductId";
            this.ProductId.MinWidth = 24;
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 92;
            // 
            // ProductDescription
            // 
            this.ProductDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.ProductDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ProductDescription.Caption = "Producto";
            this.ProductDescription.FieldName = "Name";
            this.ProductDescription.MaxWidth = 733;
            this.ProductDescription.MinWidth = 24;
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.OptionsColumn.AllowEdit = false;
            this.ProductDescription.OptionsColumn.AllowMove = false;
            this.ProductDescription.OptionsColumn.AllowSize = false;
            this.ProductDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.ProductDescription.OptionsColumn.FixedWidth = true;
            this.ProductDescription.OptionsColumn.ReadOnly = true;
            this.ProductDescription.Visible = true;
            this.ProductDescription.VisibleIndex = 0;
            this.ProductDescription.Width = 559;
            // 
            // Stock
            // 
            this.Stock.Caption = "Stock";
            this.Stock.FieldName = "Stock";
            this.Stock.MinWidth = 24;
            this.Stock.Name = "Stock";
            this.Stock.Width = 816;
            // 
            // LblCustomerAddress
            // 
            this.LblCustomerAddress.AutoSize = true;
            this.LblCustomerAddress.Location = new System.Drawing.Point(23, 34);
            this.LblCustomerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCustomerAddress.Name = "LblCustomerAddress";
            this.LblCustomerAddress.Size = new System.Drawing.Size(109, 20);
            this.LblCustomerAddress.TabIndex = 151;
            this.LblCustomerAddress.Text = "Descripción";
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
            this.BtnAccept.Location = new System.Drawing.Point(790, 629);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(196, 62);
            this.BtnAccept.TabIndex = 153;
            this.BtnAccept.Text = "Aceptar";
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
            this.BtnCancel.Location = new System.Drawing.Point(582, 629);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(196, 62);
            this.BtnCancel.TabIndex = 154;
            this.BtnCancel.Text = "Cancelar";
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
            this.BtnKeyPad.Location = new System.Drawing.Point(699, 14);
            this.BtnKeyPad.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnKeyPad.Name = "BtnKeyPad";
            this.BtnKeyPad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeyPad.Size = new System.Drawing.Size(100, 62);
            this.BtnKeyPad.TabIndex = 152;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnSearch.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnSearch.Appearance.Options.UseBackColor = true;
            this.BtnSearch.Appearance.Options.UseFont = true;
            this.BtnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.BtnSearch.ImageOptions.SvgImage = global::POS.Properties.Resources.find;
            this.BtnSearch.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.BtnSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.BtnSearch.Location = new System.Drawing.Point(836, 80);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(149, 109);
            this.BtnSearch.TabIndex = 153;
            this.BtnSearch.Text = "Buscar";
            // 
            // FrmProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 709);
            this.ControlBox = false;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnKeyPad);
            this.Controls.Add(this.LblCustomerAddress);
            this.Controls.Add(this.TxtSearchName);
            this.Controls.Add(this.GrcSalesDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda Producto";
            ((System.ComponentModel.ISupportInitialize)(this.TxtSearchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrcSalesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrvSalesDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtSearchName;
        private DevExpress.XtraGrid.GridControl GrcSalesDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView GrvSalesDetail;
        private DevExpress.XtraGrid.Columns.GridColumn ProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn ProductId;
        private System.Windows.Forms.Label LblCustomerAddress;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnKeyPad;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn Stock;
    }
}