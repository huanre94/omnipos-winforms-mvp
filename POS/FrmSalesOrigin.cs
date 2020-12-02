using DevExpress.Utils;
using POS.Classes;
using POS.DLL;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS
{
    public partial class FrmSalesOrigin : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
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
                List<SP_SalesOrigin_Consult_Result> salesOrigins = new ClsSalesOrderTrans().GetSalesOrigins();

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
                //ILBSalesOrigin.ImageMember = "SalesOriginId";
                //ILBSalesOrigin.ImageIndexMember = "Name";                
                ILBSalesOrigin.ValueMember = "SalesOriginId";
                ILBSalesOrigin.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar origenes de venta."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ILBSalesOrigin.SelectedItem != null)
            {
                SP_SalesOrigin_Consult_Result item = (SP_SalesOrigin_Consult_Result)ILBSalesOrigin.SelectedItem;
                result = item;
            }
            else
            {
                functions.ShowMessage(
                                        "Debe seleccionar un tipo de origen de venta."
                                        , ClsEnums.MessageType.WARNING
                                    );
            }
        }
    }
}