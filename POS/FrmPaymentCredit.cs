﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace POS
{
    public partial class FrmPaymentCredit : DevExpress.XtraEditors.XtraForm
    {
        public FrmPaymentCredit()
        {
            InitializeComponent();
        }

        private void FrmPaymentCredit_Load(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            LblHolderName.Text = main.LblCustomerName.Text;
        }
    }
}