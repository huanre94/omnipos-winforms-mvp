using AxOposScanner_CCO;
using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
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

        ScaleBrands scaleBrand;

        public FrmSupervisorAuth()
        {
            InitializeComponent();
        }

        private void FrmSupervisorAuth_Load(object sender, EventArgs e)
        {
            LblMotive.Visible = false;
            CmbMotive.Visible = false;

            scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

            if (scaleBrand == ScaleBrands.DATALOGIC)
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
            try
            {
                IEnumerable<CancelReason> cancelReasons = new ClsAuthorizationTrans(Program.customConnectionString).ConsultReasons(reasonType);

                if (cancelReasons.Any())
                {
                    foreach (CancelReason reason in cancelReasons)
                    {
                        CmbMotive.Properties.Items.Add(new ImageComboBoxItem { Value = reason.ReasonId, Description = reason.Name });
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de motivos de anulacion.",
                     MessageType.ERROR,
                    true,
                    ex.InnerException.Message);
            }

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (TxtAuthorization.Text == string.Empty)
            {
                functions.ShowMessage("Debe proporcionar autorizacion del supervisor.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            if (TxtSupervisorPassword.Text == string.Empty)
            {
                functions.ShowMessage("Debe proporcionar el pin del supervisor.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            if (CmbMotive.Visible)
            {
                if (CmbMotive.SelectedItem != null)
                {
                    SP_Supervisor_Validate_Result result;

                    try
                    {
                        result = new ClsAuthorizationTrans(Program.customConnectionString).GetSupervisorAuth(TxtAuthorization.Text, TxtSupervisorPassword.Text);

                        if (result == null)
                        {
                            functions.ShowMessage("El codigo ingresado no es correcto.", MessageType.ERROR);
                            TxtAuthorization.Text = "";
                            TxtAuthorization.Focus();
                            TxtSupervisorPassword.Text = string.Empty;
                            DialogResult = DialogResult.None;
                            return;
                        }

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

                            if (scaleBrand == ScaleBrands.DATALOGIC)
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
                            functions.ShowMessage("Ocurrio un problema al anular producto.", MessageType.ERROR, true, result.ErrorMessage);
                            DialogResult = DialogResult.None;
                        }

                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un problema al verificar codigo de autorizacion.", MessageType.ERROR, true, ex.InnerException.Message);
                    }
                }
            }
            else
            {
                functions.ShowMessage("Debe seleccionar un motivo para anular.", MessageType.WARNING);
                DialogResult = DialogResult.None;
            }

            Cursor.Current = Cursors.Default;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (scaleBrand == ScaleBrands.DATALOGIC)
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
            FrmKeyPad passwordKeypad = new FrmKeyPad()
            {
                inputFromOption = InputFromOption.LOGIN_PASSWORD
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