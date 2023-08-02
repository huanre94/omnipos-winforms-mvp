using AxOposScanner_CCO;
using DevExpress.XtraEditors;
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
    public partial class FrmSupervisorAuth : XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public EmissionPoint _emissionPoint { get; set; }
        public AxOPOSScanner _scanner { get; set; }

        public bool RequireMotive { get; set; }
        public bool formActionResult;
        public int motiveId;
        public CancelReasonType ReasonType { get; set; } = 0;
        public string SupervisorAuthorization { get; set; }
        ScaleBrands scaleBrand;

        public FrmSupervisorAuth()
        {
            InitializeComponent();
        }

        public FrmSupervisorAuth(AxOPOSScanner axOPOSScanner, EmissionPoint emissionPoint, bool requireMotive, CancelReasonType reasonType)
        {
            InitializeComponent();
            AxOPOSScanner = axOPOSScanner;
            _emissionPoint = emissionPoint;
            RequireMotive = requireMotive;
            ReasonType = reasonType;
        }

        private void FrmSupervisorAuth_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            LblMotive.Visible = false;
            CmbMotive.Visible = false;

            scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), _emissionPoint.ScaleBrand, true);

            if (scaleBrand == ScaleBrands.DATALOGIC)
            {
                if (_scanner != null)
                {
                    functions.AxOPOSScanner = _scanner;
                    functions.DisableScanner();
                }

                functions.AxOPOSScanner = AxOPOSScanner;
                functions.EnableScanner(_emissionPoint.ScanBarcodeName);
            }

            if (RequireMotive)
            {
                LblMotive.Visible = true;
                CmbMotive.Visible = true;

                LoadReasons(ReasonType);
            }
        }

        private void LoadReasons(CancelReasonType reasonType)
        {
            try
            {
                IEnumerable<CancelReason> cancelReasons = new CancelReasonRepository(Program.customConnectionString).ConsultReasons(reasonType);

                if (cancelReasons?.Count() > 0)
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

            if (CmbMotive.Visible && CmbMotive.SelectedItem == null)
            {
                functions.ShowMessage("Debe seleccionar un motivo para anular.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                SP_Supervisor_Validate_Result result = new ClsAuthorizationTrans(Program.customConnectionString).GetSupervisorAuth(TxtAuthorization.Text, TxtSupervisorPassword.Text);

                if (result == null)
                {
                    functions.ShowMessage("El codigo ingresado no es correcto.", MessageType.ERROR);
                    TxtAuthorization.Text = string.Empty;
                    TxtSupervisorPassword.Text = string.Empty;
                    TxtAuthorization.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }

                if (!(bool)result.Error)
                {
                    functions.ShowMessage("Ocurrio un problema al realizar la anulacion.", MessageType.ERROR, true, result.ErrorMessage);
                    DialogResult = DialogResult.None;
                    return;
                }

                if (CmbMotive.SelectedItem != null)
                {
                    int cancelReason = int.Parse(CmbMotive.EditValue.ToString());
                    motiveId = cancelReason;
                }
                formActionResult = true;
                SupervisorAuthorization = TxtAuthorization.Text;
                TxtAuthorization.Text = "";

                if (scaleBrand == ScaleBrands.DATALOGIC)
                {
                    functions.DisableScanner();

                    if (_scanner != null)
                    {
                        functions.AxOPOSScanner = _scanner;
                        functions.EnableScanner(_emissionPoint.ScanBarcodeName);
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al verificar codigo de autorizacion.", MessageType.ERROR, true, ex.InnerException.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (scaleBrand == ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();

                if (_scanner != null)
                {
                    functions.AxOPOSScanner = _scanner;
                    functions.EnableScanner(_emissionPoint.ScanBarcodeName);
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
            FrmKeyPad passwordKeypad = new FrmKeyPad(InputFromOption.LOGIN_PASSWORD);
            passwordKeypad.ShowDialog();

            TxtSupervisorPassword.Text = passwordKeypad.GetValue();

            CmbMotive.Focus();   //06/07/2022
        }

        private void TxtAuthorization_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtAuthorization.Text == string.Empty)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                TxtSupervisorPassword.Focus();
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

        private void FrmSupervisorAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scaleBrand == ScaleBrands.DATALOGIC) functions.DisableScanner();
        }
    }
}