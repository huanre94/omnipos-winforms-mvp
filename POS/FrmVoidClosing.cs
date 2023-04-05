using DevExpress.XtraEditors;
using POS.DLL;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmVoidClosing : DevExpress.XtraEditors.XtraForm
    {
        public bool returnStatus { get; set; }

        public FrmVoidClosing()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtClosingId.Text == string.Empty)
            {
                new ClsFunctions().ShowMessage($"El campo {LblClosingId.Text} no puede estar vacio.", MessageType.WARNING);
                return;
            }

            
        }

        private void FrmVoidClosing_Load(object sender, EventArgs e)
        {

        }

    }
}