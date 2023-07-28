using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSalesOrderText : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        readonly long _salesOrderId;

        public FrmSalesOrderText(long salesOrderId)
        {
            InitializeComponent();
            _salesOrderId = salesOrderId;
        }

        public FrmSalesOrderText()
        {
            InitializeComponent();
        }

        private void FrmSalesOrderText_Load(object sender, EventArgs e)
        {
            PrintCommandOnScreen();
        }

        private void PrintCommandOnScreen()
        {
            try
            {
                SalesOrder order = new SalesOrderRepository(Program.customConnectionString).GetSalesOrder(_salesOrderId);

                string list = "";

                foreach (SalesOrderText item in order.SalesOrderText)
                {
                    list += item.SalesOrderText1 + Environment.NewLine;
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