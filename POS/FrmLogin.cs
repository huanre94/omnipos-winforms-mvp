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
using System.Net;
using System.Net.Sockets;
using POS.DLL;

namespace POS
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        SP_Login_Consult_Result loginInfomation = new SP_Login_Consult_Result();
        List<GlobalParameter> globalParameters = new List<GlobalParameter>();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private bool ValidateCustomerFields()
        {
            bool response = false;

            if (TxtUsername.Text != "" && TxtPassword.Text != "")
            {
                response = true;
            }
            else
            {
                functions.ShowMessage("Debe llenar los campos necesarios del formulario", ClsEnums.MessageType.WARNING);
                this.DialogResult = DialogResult.None;
            }

            return response;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerFields())
            {
                bool alowLogin = false;
                TxtPassword.Text = "";

                alowLogin = GetLoginInformation(
                                                TxtUsername.Text
                                                , TxtPassword.Text
                                                , Environment.MachineName
                                                , GetLocalIPAddress()
                                                );

                if (alowLogin && GetGlobalParameters())
                {
                    FrmMenu frmMenu = new FrmMenu();
                    frmMenu.loginInformation = loginInfomation;                    
                    frmMenu.ShowDialog();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool GetLoginInformation(
                                            string _identification
                                            , string _password
                                            , string _workstation
                                            , string _addressIP
                                        )
        {
            DLL.Catalog.ClsAdministration admin = new DLL.Catalog.ClsAdministration();
            DLL.SP_Login_Consult_Result result;
            bool response = false;

            try
            {
                result = admin.GetLoginInformation(
                                                    _identification
                                                    , _password
                                                    , _workstation
                                                    , _addressIP
                                                    );

                if (result != null)
                {
                    if (!(bool)result.Error)
                    {
                        response = true;
                        loginInfomation = result;
                    }
                    else
                    {
                        functions.ShowMessage(
                                                "No se ha podido iniciar sesión."
                                                , ClsEnums.MessageType.WARNING
                                                , true
                                                , result.TextError
                                                );
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrió un problema al iniciar sesión."
                                        , ClsEnums.MessageType.WARNING
                                        , true
                                        , ex.Message
                                        );
            }

            return response;
        }

        private bool GetGlobalParameters()
        {
            DLL.Catalog.ClsGeneral clsGeneral = new DLL.Catalog.ClsGeneral();
            bool response = false;

            try
            {
                globalParameters = clsGeneral.GetGlobalParameters();

                if (globalParameters != null)
                {
                    if (globalParameters.Count > 0)
                    {
                        response = true;
                    }
                    else
                    {
                        functions.ShowMessage("No se pudieron cargar parámetros globales.", ClsEnums.MessageType.WARNING);
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar parámetros globales."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }

            return response;
        }

        private string GetLocalIPAddress()
        {
            string addressIP = "";
            bool networkOK = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (networkOK)
            {
                try
                {

                    var host = Dns.GetHostEntry(Dns.GetHostName());

                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            addressIP = ip.ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "No se encontraron adaptadores de red IPv4 en el sistema."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("El equipo no se encuentra conectado a la red.", ClsEnums.MessageType.ERROR);
            }

            return addressIP;
        }

        private void BtnKeypadUsername_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.LOGIN_USERNAME;
            keyPad.ShowDialog();
            TxtUsername.Text = keyPad.loginUsername;
        }

        private void BtnKeypadPassword_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad();
            keyPad.inputFromOption = ClsEnums.InputFromOption.LOGIN_PASSWORD;
            keyPad.ShowDialog();
            TxtPassword.Text = keyPad.loginPassword;
        }
    }
}