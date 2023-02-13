using DevExpress.Utils;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS
{
    public partial class FrmSalesOrigin : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;
        public SP_SalesOrigin_Consult_Result result;

        public FrmSalesOrigin()
        {
            InitializeComponent();
        }

        private void FrmSalesOrigin_Load(object sender, EventArgs e)
        {
            SvgImageCollection collection = new SvgImageCollection();
            try
            {
                IEnumerable<SP_SalesOrigin_Consult_Result> salesOrigins = new ClsSalesOrder(Program.customConnectionString).GetSalesOrigins();

                BindingList<SP_SalesOrigin_Consult_Result> bindingOrigins = new BindingList<SP_SalesOrigin_Consult_Result>();
                foreach (SP_SalesOrigin_Consult_Result item in salesOrigins)
                {
                    DevExpress.Utils.Svg.SvgImage svgImage;
                    svgImage = (DevExpress.Utils.Svg.SvgImage)Properties.Resources.ResourceManager.GetObject(item.Name);

                    collection.Add(svgImage);
                    bindingOrigins.Add(item);
                }
                ILBSalesOrigin.ImageList = collection;
                ILBSalesOrigin.DataSource = bindingOrigins;
                ILBSalesOrigin.ValueMember = "SalesOriginId";
                ILBSalesOrigin.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar origenes de venta.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ILBSalesOrigin.SelectedItem == null)
            {
                functions.ShowMessage("Debe seleccionar un tipo de origen de venta.", MessageType.WARNING);
                return;
            }

            SP_SalesOrigin_Consult_Result item = (SP_SalesOrigin_Consult_Result)ILBSalesOrigin.SelectedItem;
            result = item;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ILBSalesOrigin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (((int)e.KeyCode) == 13)
            {
                BtnAccept.Focus();
            }
        }
    }
}