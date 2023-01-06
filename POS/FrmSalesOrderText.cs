using POS.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSalesOrderText : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public DLL.SalesOrder salesOrder;

        public FrmSalesOrderText(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        private void FrmSalesOrderText_Load(object sender, EventArgs e)
        {
            try
            {
                List<DLL.SalesOrderText> command = new DLL.Catalog.ClsSalesOrder().ConsultCommand(salesOrder.SalesOrderId, CadenaC);
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