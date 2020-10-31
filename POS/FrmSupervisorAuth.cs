using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using POS.Classes;

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
                List<DLL.SP_Supervisor_Validate_Result> result;

                try
                {
                    result = authorization.GetSupervisorAuth(TxtAuthorization.Text);

                    if (result != null)
                    {
                        if (result.Count > 0)
                        {
                            formActionResult = true;
                            TxtAuthorization.Text = "";
                        }
                        else
                        {
                            functions.ShowMessage("El codigo ingresado no es correcto.", ClsEnums.MessageType.ERROR);
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al verificar codigo de autorizacion."
                                            ,ClsEnums.MessageType.ERROR
                                            ,true
                                            ,ex.Message
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