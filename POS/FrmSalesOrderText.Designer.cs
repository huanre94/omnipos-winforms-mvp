﻿namespace POS
{
    partial class FrmSalesOrderText
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
            this.TxtOrderText = new System.Windows.Forms.RichTextBox();
            this.BtnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // TxtOrderText
            // 
            this.TxtOrderText.Location = new System.Drawing.Point(55, 15);
            this.TxtOrderText.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOrderText.Name = "TxtOrderText";
            this.TxtOrderText.ReadOnly = true;
            this.TxtOrderText.Size = new System.Drawing.Size(488, 305);
            this.TxtOrderText.TabIndex = 0;
            this.TxtOrderText.Text = "";
            this.TxtOrderText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOrderText_KeyDown);
            // 
            // BtnAccept
            // 
            this.BtnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.BtnAccept.Location = new System.Drawing.Point(191, 339);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(6);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(207, 69);
            this.BtnAccept.TabIndex = 1;
            this.BtnAccept.Text = "Aceptar";
            // 
            // FrmSalesOrderText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 425);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.TxtOrderText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSalesOrderText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comanda";
            this.Load += new System.EventHandler(this.FrmSalesOrderText_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.RichTextBox TxtOrderText;
        private DevExpress.XtraEditors.SimpleButton BtnAccept;
    }
}