using POS.Classes;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSupervisorAuth : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;
        public DLL.EmissionPoint emissionPoint;
        public string supervisorAuthorization;
        public AxOposScanner_CCO.AxOPOSScanner scanner;

        public FrmSupervisorAuth()
        {
            InitializeComponent();
        }

        private void FrmSupervisorAuth_Load(object sender, EventArgs e)
        {
            functions.AxOPOSScanner = scanner;
            functions.DisableScanner();
            functions.AxOPOSScanner = AxOPOSScanner;
            functions.EnableScanner(emissionPoint.ScanBarcodeName);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtAuthorization.Text != "")
            {
                DLL.Transaction.ClsAuthorizationTrans authorization = new DLL.Transaction.ClsAuthorizationTrans();
                DLL.SP_Supervisor_Validate_Result result;

                try
                {
                    result = authorization.GetSupervisorAuth(TxtAuthorization.Text);

                    if (result != null)
                    {
                        formActionResult = true;
                        functions.supervisorAuthorization = TxtAuthorization.Text;
                        TxtAuthorization.Text = "";
                        functions.DisableScanner();
                        functions.AxOPOSScanner = scanner;
                        functions.EnableScanner(emissionPoint.ScanBarcodeName);
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
                functions.ShowMessage("Debe proporcionar autorizacion del supervisor.", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            functions.DisableScanner();
            functions.AxOPOSScanner = scanner;
            functions.EnableScanner(emissionPoint.ScanBarcodeName);
        }

        private void AxOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtAuthorization.Text = functions.AxOPOSScanner.ScanDataLabel;
            functions.AxOPOSScanner.DataEventEnabled = true;
        }
    }
}