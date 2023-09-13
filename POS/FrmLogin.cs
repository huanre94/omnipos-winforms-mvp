using DevExpress.XtraEditors;
using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLogin : XtraForm//, ILoginView
    {
        readonly ClsFunctions functions = new ClsFunctions();
        SP_Login_Consult_Result loginInfomation = new SP_Login_Consult_Result();
        IEnumerable<GlobalParameter> globalParameters = new List<GlobalParameter>();

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
            Cursor.Current = Cursors.WaitCursor;

            if (ValidateCustomerFields())
            {
                bool allowLogin = false;
                IEnumerable<string> ipAddressList = GetLocalIPAddress();

                foreach (string ipAddress in ipAddressList)
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

                    FrmMenu frmMenu = new FrmMenu() //13/07/2022 Se envia parametro de conexion
                    {
                        loginInformation = loginInfomation,
                        globalParameters = globalParameters
                    };
                    functions.globalParameters = globalParameters;
                    Hide();

                    frmMenu.Show();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool GetLoginInformation(string _identification, string _password, string _workstation, string _addressIP)
        {
            try
            {
                SP_Login_Consult_Result result = new ClsAdministration(Program.customConnectionString).GetLoginInformation(_identification, _password, _workstation, _addressIP);

                if ((bool)result?.Error)
                {
                    functions.ShowMessage("No se ha podido iniciar sesión.", MessageType.WARNING, true, result.TextError);
                    return false;
                }

                loginInfomation = result;
                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrió un problema al iniciar sesión.",
                                      MessageType.WARNING,
                                      true,
                                      ex.Message);
                return false;
            }
        }

        private bool GetGlobalParameters()
        {
            try
            {
                globalParameters = new ClsGeneral(Program.customConnectionString).GetGlobalParameters();

                if (globalParameters?.Count() <= 0)
                {
                    functions.ShowMessage("No se pudieron cargar parámetros globales.",
                                          MessageType.WARNING);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar parámetros globales.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
                return false;
            }
        }

        private IEnumerable<string> GetLocalIPAddress()
        {
            List<string> addressIP = new List<string>();
            bool networkOK = NetworkInterface.GetIsNetworkAvailable();

            if (!networkOK)
            {
                functions.ShowMessage("El equipo no se encuentra conectado a la red.",
                                      MessageType.ERROR);
                return null;
            }

            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        addressIP.Add($"{ip}");
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se encontraron adaptadores de red IPv4 en el sistema.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

            return addressIP;
        }

        private void BtnKeypadUsername_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.LOGIN_USERNAME);
            keyPad.ShowDialog();
            TxtUsername.Text = keyPad.GetValue();
        }

        private void BtnKeypadPassword_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(InputFromOption.LOGIN_PASSWORD);
            keyPad.ShowDialog();
            TxtPassword.Text = keyPad.GetValue();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (TxtPassword.Text != "")
                    {
                        ProcessLogin();
                    }
                    break;
                case Keys.F1:
                    BtnKeypadPassword_Click(null, null);
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (TxtUsername.Text != "")
                    {
                        TxtPassword.Focus();
                    }
                    break;
                case Keys.F1:
                    BtnKeypadUsername_Click(null, null);
                    break;
                case Keys.F9:
                    BtnCancel_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        public bool ValidateCustomerFields()
        {
            if (TxtUsername.Text == string.Empty)
            {
                functions.ShowMessage("El usuario no puede estar vacio.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return false;
            }

            if (TxtPassword.Text == string.Empty)
            {
                functions.ShowMessage("La clave no puede estar vacia.", MessageType.WARNING);
                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }
    }

    public interface ILoginView
    {

        string Username { get; set; }
        string Password { get; set; }
        bool IsLoggedIn { get; set; }

        event EventHandler SubmitLogin;

    }
}
