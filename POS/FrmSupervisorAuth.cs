using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSupervisorAuth : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public DLL.EmissionPoint emissionPoint;        
        public AxOposScanner_CCO.AxOPOSScanner scanner;
        public int motiveId;
        public string supervisorAuthorization;
        public bool requireMotive;
        ClsEnums.ScaleBrands scaleBrand;

        public FrmSupervisorAuth()
        {
            InitializeComponent();
        }

        private void FrmSupervisorAuth_Load(object sender, EventArgs e)
        {
            LblMotive.Visible = false;
            CmbMotive.Visible = false;

            scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

            if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
            {
                if (scanner != null)
                {
                    functions.AxOPOSScanner = scanner;
                    functions.DisableScanner();
                }

                functions.AxOPOSScanner = AxOPOSScanner;
                functions.EnableScanner(emissionPoint.ScanBarcodeName);
            }            

            if (requireMotive)
            {
                LblMotive.Visible = true;
                CmbMotive.Visible = true;

                LoadReasons();
            }
        }

        private void LoadReasons()
        {
            ClsAuthorizationTrans paymMode = new ClsAuthorizationTrans();
            List<DLL.CancelReason> cancelReasons;

            try
            {
                cancelReasons = paymMode.ConsultReasons(1);

                if (cancelReasons != null)
                {
                    if (cancelReasons.Count > 0)
                    {
                        foreach (var reason in cancelReasons)
                        {
                            CmbMotive.Properties.Items.Add(new ImageComboBoxItem { Value = reason.ReasonId, Description = reason.Name });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Bancos."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtAuthorization.Text != "")
            {
                ClsAuthorizationTrans authorization = new ClsAuthorizationTrans();
                DLL.SP_Supervisor_Validate_Result result;

                try
                {
                    result = authorization.GetSupervisorAuth(TxtAuthorization.Text);

                    if (result != null)
                    {

                        if (CmbMotive.SelectedItem != null)
                        {
                            int cancelReason = int.Parse(CmbMotive.EditValue.ToString());
                            motiveId = cancelReason;
                        }
                        formActionResult = true;
                        supervisorAuthorization = TxtAuthorization.Text;
                        TxtAuthorization.Text = "";

                        if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                        {
                            functions.DisableScanner();

                            if (scanner != null)
                            {
                                functions.AxOPOSScanner = scanner;
                                functions.EnableScanner(emissionPoint.ScanBarcodeName);
                            }
                        }
                    }
                    else
                    {
                        functions.ShowMessage("El codigo ingresado no es correcto.", ClsEnums.MessageType.ERROR);
                        TxtAuthorization.Text = "";
                        TxtAuthorization.Focus();
                        DialogResult = DialogResult.None;
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al verificar codigo de autorizacion."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                            );
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar autorizacion del supervisor.", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();

                if (scanner != null)
                {
                    functions.AxOPOSScanner = scanner;
                    functions.EnableScanner(emissionPoint.ScanBarcodeName);
                }
            }
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtAuthorization.Text = functions.AxOPOSScanner.ScanDataLabel;
            functions.AxOPOSScanner.DataEventEnabled = true;
        }
    }
}