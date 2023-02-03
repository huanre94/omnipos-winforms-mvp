using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSalesOrderText : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public DLL.SalesOrder salesOrder;

        public FrmSalesOrderText()
        {
            InitializeComponent();
        }

        private void FrmSalesOrderText_Load(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<DLL.SalesOrderText> command = new ClsSalesOrder(Program.customConnectionString).ConsultCommand(salesOrder.SalesOrderId);
                string list = "";

                foreach (DLL.SalesOrderText item in command)
                {
                    list = list + item.SalesOrderText1 + Environment.NewLine;
                }

                TxtOrderText.Text = list;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo mostrar comanda.", MessageType.WARNING, true, ex.Message);
            }
        }

        private void TxtOrderText_KeyDown(object sender, KeyEventArgs e)
        {
            //08/07/2022
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}