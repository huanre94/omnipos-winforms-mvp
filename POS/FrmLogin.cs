using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm, ICustomerInformationValidator
    {
        readonly ClsFunctions functions = new ClsFunctions();
        SP_Login_Consult_Result loginInfomation = new SP_Login_Consult_Result();
        List<GlobalParameter> globalParameters = new List<GlobalParameter>();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            if (ValidateCustomerFields())
            {
                bool allowLogin = false;
                var ipAddressList = GetLocalIPAddress();

                foreach (var ipAddress in ipAddressList)
                {
                    allowLogin = GetLoginInformation(TxtUsername.Text, TxtPassword.Text, Environment.MachineName, ipAddress);
                    if (allowLogin)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (allowLogin && GetGlobalParameters())
                {
                    TxtUsername.Text = string.Empty;
                    TxtPassword.Text = string.Empty;

                    FrmMenu frmMenu = new FrmMenu
                    {
                        loginInformation = loginInfomation,
                        globalParameters = globalParameters
                    };
                    functions.globalParameters = globalParameters;
                    Hide();
                    frmMenu.Show();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool GetLoginInformation(string _identification, string _password, string _workstation, string _addressIP)
        {
            SP_Login_Consult_Result result;

            try
            {
                result = new ClsAdministration().GetLoginInformation(
                                                    _identification
                                                    , _password
                                                    , _workstation
                                                    , _addressIP
                                                    );

                if ((bool)result?.Error)
                {
                    functions.ShowMessage("No se ha podido iniciar sesión.", ClsEnums.MessageType.WARNING, true, result.TextError);
                    return false;
                }

                loginInfomation = result;
                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrió un problema al iniciar sesión."
                                        , ClsEnums.MessageType.WARNING
                                        , true
                                        , ex.Message
                                        );
                return false;
            }
        }

        private bool GetGlobalParameters()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            try
            {
                globalParameters = clsGeneral.GetGlobalParameters();


                if (!globalParameters.Any())
                {
                    functions.ShowMessage("No se pudieron cargar parámetros globales.", ClsEnums.MessageType.WARNING);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar parámetros globales.",
                    ClsEnums.MessageType.ERROR,
                    true,
                    ex.Message);
                return false;
            }
        }

        private List<string> GetLocalIPAddress()
        {
            List<string> addressIP = new List<string>();
            bool networkOK = NetworkInterface.GetIsNetworkAvailable();

            if (!networkOK)
            {
                functions.ShowMessage("El equipo no se encuentra conectado a la red.", ClsEnums.MessageType.ERROR);
                return new List<string>();
            }

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        addressIP.Add($"{ip}");
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

            return addressIP;
        }

        private void BtnKeypadUsername_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.LOGIN_USERNAME
            };
            keyPad.ShowDialog();
            TxtUsername.Text = keyPad.loginUsername;
        }

        private void BtnKeypadPassword_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.LOGIN_PASSWORD
            };
            keyPad.ShowDialog();
            TxtPassword.Text = keyPad.loginPassword;
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessLogin();
        }

        public bool ValidateCustomerFields()
        {
            if (TxtUsername.Text == string.Empty || TxtPassword.Text == string.Empty)
            {
                functions.ShowMessage("Debe llenar los campos necesarios del formulario", ClsEnums.MessageType.WARNING);
                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }
    }
}