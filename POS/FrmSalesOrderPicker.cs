using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;

namespace POS
{
    public partial class FrmSalesOrderPicker : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public List<GlobalParameter> globalParameters;
        public FrmSalesOrderPicker()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.loginInformation = loginInformation;
            frmMenu.globalParameters = globalParameters;
            frmMenu.Visible = true;
            Close();
        }

        private void FrmSalesOrderPicker_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                //LoadGridInformation();
                CheckGridView();
            }
            else
            {
                FrmMenu frmMenu = new FrmMenu();
                frmMenu.loginInformation = loginInformation;
                frmMenu.globalParameters = globalParameters;
                frmMenu.Visible = true;
                Close();
            }
        }

        #region Functions
        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);

                    if (emissionPoint != null)
                    {
                        response = true;
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void CheckGridView()
        {
            //GrvDenomination.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            //GrcDenomination.DataSource = null;
            //BindingList<SP_SalesOrder_Consult_Result> bindingList = new BindingList<SP_SalesOrder_Consult_Result>();
            //bindingList.AllowNew = false;
            //GrcDenomination.DataSource = bindingList;
        }
        #endregion
    }
}