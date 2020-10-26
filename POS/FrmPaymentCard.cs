using System;
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
    public partial class FrmPaymentCard : DevExpress.XtraEditors.XtraForm
    {
        

        public FrmPaymentCard()
        {
            InitializeComponent();
        }

        private void BtnKeyPad_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.fromOption = "CreditCardAuthorization";
            keyPad.ShowDialog();
            TxtAuthorization.Text = keyPad.creditCardAuthorization;
        }
               
        private void BtnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}