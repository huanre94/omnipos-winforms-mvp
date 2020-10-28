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
        public bool formActionResult; 

        public FrmSupervisorAuth()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (TxtAuthorization.Text != "")
            {
                ClsFunctions functions = new ClsFunctions();
                DLL.Transaction.ClsAuthorization authorization = new DLL.Transaction.ClsAuthorization();
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
                            functions.ShowMessage("El codigo ingresado no retorno valores.", ClsEnums.MessageType.ERROR);
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(ex.Message, ClsEnums.MessageType.ERROR);
                }                
            }
            else
            {
                ClsFunctions functions = new ClsFunctions();
                functions.ShowMessage("Debe proporcionar autorizacion del supervisor.", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}