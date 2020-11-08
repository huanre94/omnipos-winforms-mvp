using POS.Classes;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSupervisorAuth : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public bool formActionResult;

        public FrmSupervisorAuth()
        {
            InitializeComponent();
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
                        TxtAuthorization.Text = "";
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
    }
}