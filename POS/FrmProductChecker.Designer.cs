﻿
namespace POS
{
    partial class FrmProductChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductChecker));
            this.BtnKeypad = new DevExpress.XtraEditors.SimpleButton();
            this.TxtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.LblGiftCard = new System.Windows.Forms.Label();
            this.LblProductName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblProductBarcode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblProductPromotionalPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblProductPrice = new System.Windows.Forms.Label();
            this.BtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.axOPOSScanner = new AxOposScanner_CCO.AxOPOSScanner();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axOPOSScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnKeypad
            // 
            this.BtnKeypad.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnKeypad.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnKeypad.Appearance.Options.UseBackColor = true;
            this.BtnKeypad.Appearance.Options.UseFont = true;
            this.BtnKeypad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnKeypad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnKeypad.ImageOptions.SvgImage")));
            this.BtnKeypad.ImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            this.BtnKeypad.Location = new System.Drawing.Point(563, 28);
            this.BtnKeypad.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.BtnKeypad.Name = "BtnKeypad";
            this.BtnKeypad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BtnKeypad.Size = new System.Drawing.Size(95, 62);
            this.BtnKeypad.TabIndex = 13;
            this.BtnKeypad.Click += new System.EventHandler(this.BtnKeypad_Click);
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Location = new System.Drawing.Point(230, 34);
            this.TxtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(323, 30);
            this.TxtBarcode.TabIndex = 12;
            // 
            // LblGiftCard
            // 
            this.LblGiftCard.AutoSize = true;
            this.LblGiftCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.LblGiftCard.Location = new System.Drawing.Point(83, 48);
            this.LblGiftCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblGiftCard.Name = "LblGiftCard";
            this.LblGiftCard.Size = new System.Drawing.Size(141, 23);
            this.LblGiftCard.TabIndex = 14;
            this.LblGiftCard.Text = "Codigo Barra";
            // 
            // LblProductName
            // 
            this.LblProductName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblProductName.Location = new System.Drawing.Point(269, 180);
            this.LblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(446, 22);
            this.LblProductName.TabIndex = 146;
            this.LblProductName.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.Location = new System.Drawing.Point(31, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 145;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.Location = new System.Drawing.Point(31, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 145;
            this.label1.Text = "Codigo Barra:";
            // 
            // LblProductBarcode
            // 
            this.LblProductBarcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblProductBarcode.Location = new System.Drawing.Point(269, 121);
            this.LblProductBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProductBarcode.Name = "LblProductBarcode";
            this.LblProductBarcode.Size = new System.Drawing.Size(446, 22);
            this.LblProductBarcode.TabIndex = 146;
            this.LblProductBarcode.Text = "Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label4.Location = new System.Drawing.Point(31, 309);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 23);
            this.label4.TabIndex = 145;
            this.label4.Text = "Precio Promocional:";
            // 
            // LblProductPromotionalPrice
            // 
            this.LblProductPromotionalPrice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblProductPromotionalPrice.Location = new System.Drawing.Point(269, 309);
            this.LblProductPromotionalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProductPromotionalPrice.Name = "LblProductPromotionalPrice";
            this.LblProductPromotionalPrice.Size = new System.Drawing.Size(446, 22);
            this.LblProductPromotionalPrice.TabIndex = 146;
            this.LblProductPromotionalPrice.Text = "Text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label6.Location = new System.Drawing.Point(31, 242);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 145;
            this.label6.Text = "Precio:";
            // 
            // LblProductPrice
            // 
            this.LblProductPrice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold);
            this.LblProductPrice.Location = new System.Drawing.Point(269, 242);
            this.LblProductPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProductPrice.Name = "LblProductPrice";
            this.LblProductPrice.Size = new System.Drawing.Size(446, 22);
            this.LblProductPrice.TabIndex = 146;
            this.LblProductPrice.Text = "Text";
            // 
            // BtnExit
            // 
            this.BtnExit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(84)))), ((int)(((byte)(105)))));
            this.BtnExit.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.BtnExit.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.BtnExit.Appearance.Options.UseBackColor = true;
            this.BtnExit.Appearance.Options.UseFont = true;
            this.BtnExit.Appearance.Options.UseForeColor = true;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.BtnExit.ImageOptions.SvgImage = global::POS.Properties.Resources.cancel3;
            this.BtnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.BtnExit.Location = new System.Drawing.Point(262, 380);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(6);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(196, 62);
            this.BtnExit.TabIndex = 148;
            this.BtnExit.Text = "Salir";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // axOPOSScanner
            // 
            this.axOPOSScanner.Enabled = true;
            this.axOPOSScanner.Location = new System.Drawing.Point(476, 247);
            this.axOPOSScanner.Margin = new System.Windows.Forms.Padding(4);
            this.axOPOSScanner.Name = "axOPOSScanner";
            this.axOPOSScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axOPOSScanner.OcxState")));
            this.axOPOSScanner.Size = new System.Drawing.Size(240, 240);
            this.axOPOSScanner.TabIndex = 149;
            this.axOPOSScanner.DataEvent += new AxOposScanner_CCO._IOPOSScannerEvents_DataEventEventHandler(this.axOPOSScanner_DataEvent);
            // 
            // FrmProductChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnExit;
            this.ClientSize = new System.Drawing.Size(733, 460);
            this.ControlBox = false;
            this.Controls.Add(this.axOPOSScanner);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.LblProductPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblProductPromotionalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblProductBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnKeypad);
            this.Controls.Add(this.TxtBarcode);
            this.Controls.Add(this.LblGiftCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProductChecker";
            this.Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)(this.TxtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axOPOSScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnKeypad;
        public DevExpress.XtraEditors.TextEdit TxtBarcode;
        private System.Windows.Forms.Label LblGiftCard;
        private System.Windows.Forms.Label LblProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblProductBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblProductPromotionalPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblProductPrice;
        private DevExpress.XtraEditors.SimpleButton BtnExit;
        private AxOposScanner_CCO.AxOPOSScanner axOPOSScanner;
    }
}