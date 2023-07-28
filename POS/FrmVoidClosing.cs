using POS.DLL.Enums;
using System;

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