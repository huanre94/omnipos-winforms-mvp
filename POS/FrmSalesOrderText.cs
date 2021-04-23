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
using POS.Classes;
using System.Threading;

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
                List<DLL.SalesOrderText> command = new DLL.Catalog.ClsSalesOrder().ConsultCommand(salesOrder.SalesOrderId);
                string list = "";

                foreach (var item in command)
                {
                    list = list + item.SalesOrderText1 + Environment.NewLine;
                }

                TxtOrderText.Text = list;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo mostrar comanda.", ClsEnums.MessageType.WARNING, true, ex.Message);
            }
        }
    }
}