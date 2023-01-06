using AxOposScanner_CCO;
using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
// IG001 Israel Gonzalez 2021-01-14: Disable scanner only when using Datalogic
namespace POS
{
    public partial class FrmSupervisorAuth : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public EmissionPoint emissionPoint;
        public AxOPOSScanner scanner;
        public int motiveId;
        public string supervisorAuthorization;
        public bool requireMotive;
        public int reasonType = 1;        
        
        ClsEnums.ScaleBrands scaleBrand;

        public FrmSupervisorAuth(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //13/07/2022  Se agregó para que Cadena de conexion sea parametrizable

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

                LoadReasons(reasonType);
            }
        }

        private void LoadReasons(int reasonType)
        {
            ClsAuthorizationTrans paymMode = new ClsAuthorizationTrans();
            List<DLL.CancelReason> cancelReasons;

            try
            {
                cancelReasons = paymMode.ConsultReasons(reasonType, CadenaC);

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
                                        "Ocurrio un problema al cargar lista de motivos de anulacion."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (TxtAuthorization.Text != "")
            {
                if (TxtSupervisorPassword.Text != "")
                {
                    if (CmbMotive.Visible)
                    {
                        if (CmbMotive.SelectedItem != null)
                        {
                            SP_Supervisor_Validate_Result result;

                            try
                            {
                                result = new ClsAuthorizationTrans().GetSupervisorAuth(TxtAuthorization.Text, TxtSupervisorPassword.Text, CadenaC);

                                if (result != null)
                                {
                                    if ((bool)result.Error)
                                    {

                                        if (CmbMotive.SelectedItem != null)
                                        {
                                            motiveId = int.Parse($"{CmbMotive.EditValue}");
                                        }

                                        formActionResult = true;
                                        supervisorAuthorization = TxtAuthorization.Text;
                                        TxtAuthorization.Text = "";

                                        // Begin(IG001)
                                        if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                                        {
                                            functions.DisableScanner();
                                            functions.AxOPOSScanner = scanner;
                                            functions.EnableScanner(emissionPoint.ScanBarcodeName);
                                        }
                                        // End(IG001)
                                    }
                                    else
                                    {
                                        functions.ShowMessage("Ocurrio un problema al procesar transaccion.", ClsEnums.MessageType.ERROR, true, result.ErrorMessage);
                                        DialogResult = DialogResult.None;
                                    }
                                }
                                else
                                {
                                    functions.ShowMessage("El codigo ingresado no es correcto.", ClsEnums.MessageType.ERROR);
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
                            functions.ShowMessage("Debe seleccionar un motivo para anular.", ClsEnums.MessageType.WARNING);
                            CmbMotive.Focus();
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        ClsAuthorizationTrans authorization = new ClsAuthorizationTrans();
                        SP_Supervisor_Validate_Result result;

                        try
                        {
                            result = authorization.GetSupervisorAuth(TxtAuthorization.Text, TxtSupervisorPassword.Text, CadenaC);

                            if (result != null)
                            {
                                if ((bool)result.Error)
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
                                    functions.ShowMessage("Ocurrio un problema al anular producto.", ClsEnums.MessageType.ERROR, true, result.ErrorMessage);
                                    DialogResult = DialogResult.None;
                                }
                            }
                            else
                            {
                                functions.ShowMessage("El codigo ingresado no es correcto.", ClsEnums.MessageType.ERROR);
                                TxtAuthorization.Text = "";
                                TxtAuthorization.Focus();
                                TxtSupervisorPassword.Text = string.Empty;
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
                }
                else
                {
                    functions.ShowMessage("Debe proporcionar clave del supervisor.", ClsEnums.MessageType.WARNING);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                functions.ShowMessage("Debe proporcionar autorizacion del supervisor.", ClsEnums.MessageType.WARNING);
                DialogResult = DialogResult.None;
            }
            System.Windows.Forms.Cursor.Current = Cursors.Default;
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

        private void BtnKeypadPassword_Click(object sender, EventArgs e)
        {
            FrmKeyPad passwordKeypad = new FrmKeyPad(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.LOGIN_PASSWORD
            };
            passwordKeypad.ShowDialog();
            TxtSupervisorPassword.Text = passwordKeypad.loginPassword;
            CmbMotive.Focus();   //06/07/2022
        }

        private void TxtAuthorization_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtAuthorization.Text != "")
            {
                if (((int)e.KeyCode) == 13)
                {
                    TxtSupervisorPassword.Focus();
                }
            }            
        }

        private void TxtSupervisorPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (TxtSupervisorPassword.Text != "")
                    {
                        if (CmbMotive.Visible == true)
                        {
                            CmbMotive.Focus();
                        }
                        else
                        {
                            BtnAccept.Focus();
                        }
                        //CmbMotive.Focus();
                    }
                    break;
                case Keys.F1:
                    BtnKeypadPassword_Click(null, null);
                    break;
                default:
                    break;
            }            
        }

        private void CmbMotive_KeyDown(object sender, KeyEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Enter:                    
                    BtnAccept.Focus();
                    break;
                default:
                    break;
            }        
        }
    }
}