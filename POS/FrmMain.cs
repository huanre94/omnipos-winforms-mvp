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
using POS.DLL.Catalog;
using POS.DLL;
using POS.Classes;
using System.Net;
using System.Net.Sockets;
using POS.DLL.Transaction;

namespace POS
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        List<GlobalParameter> globalParameters = new List<GlobalParameter>();
        EmissionPoint emissionPoint = new EmissionPoint();
        Customer currentCustomer = new Customer();
        DataTable dataTable = new DataTable();
        long sequenceNumber;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Global Load Definitions

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                GetGlobalParameters();
            }
            else
            {
                Close();
            }
        }

        private void GetGlobalParameters()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            try
            {
                globalParameters = clsGeneral.GetGlobalParameters();
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar parámetros globales."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }

        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = GetLocalIPAddress();

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);

                    if (emissionPoint != null)
                    {
                        response = true;
                        LblEstablishment.Text = emissionPoint.Establishment;
                        LblEmissionPoint.Text = emissionPoint.Emission;

                        GetNewSequenceNumber(emissionPoint.EmissionPointId);
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información de punto de emisión."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
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
                                            , ex.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("El equipo no se encuentra conectado a la red.", ClsEnums.MessageType.ERROR);
            }

            return addressIP;
        }

        private void GetNewSequenceNumber(int _emissionPointId)
        {
            ClsGeneral clsGeneral = new ClsGeneral();
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = clsGeneral.GetSequenceByEmissionPointId(_emissionPointId);

                if (sequenceTable != null)
                {
                    sequenceNumber = sequenceTable.Sequence;
                    string stringSequence = sequenceNumber.ToString();
                    LblInvoiceNumber.Text = stringSequence.PadLeft(9, '0');
                }
                else
                {
                    functions.ShowMessage("No existe secuencia asignada a este punto de emisión.", ClsEnums.MessageType.WARNING);
                    Close();
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al obtener secuencia."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                    );
            }
        }
        #endregion

        #region Keypad Buttons

        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text += "9";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = "";
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            GetProductInformation(
                                    emissionPoint.LocationId
                                    , TxtBarcode.Text
                                    , 1
                                    , currentCustomer.CustomerId
                                    , 0
                                    , ""
                                );
        }
        #endregion

        #region Bottom Side Buttons

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = Classes.ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION;
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification != "")
            {
                ClsCustomer clsCustomer = new ClsCustomer();

                try
                {
                    currentCustomer = clsCustomer.GetCustomerByIdentification(keyBoard.customerIdentification);

                    if (currentCustomer != null)
                    {
                        if (currentCustomer.CustomerId > 0)
                        {
                            LblCustomerId.Text = currentCustomer.Identification;
                            LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
                            LblCustomerAddress.Text = currentCustomer.Address;
                            TxtBarcode.Focus();
                        }
                    }
                    else
                    {
                        bool response = functions.ShowMessage("El cliente ingresado no esta registrado, desea ingresarlo?.", ClsEnums.MessageType.CONFIRM);

                        if (response)
                        {
                            FrmCustomer frmCustomer = new FrmCustomer();
                            frmCustomer.emissionPoint = emissionPoint;
                            frmCustomer.isNewCustomer = true;
                            frmCustomer.customerIdentification = keyBoard.customerIdentification;
                            frmCustomer.ShowDialog();

                            currentCustomer = frmCustomer.currentCustomer;

                            if (currentCustomer != null)
                            {
                                LblCustomerId.Text = currentCustomer.Identification;
                                LblCustomerName.Text = currentCustomer.Firtsname + " " + currentCustomer.Lastname;
                                LblCustomerAddress.Text = currentCustomer.Address;
                                TxtBarcode.Focus();
                            }
                            else
                            {
                                functions.ShowMessage("No se pudo cargar datos de cliente.", ClsEnums.MessageType.WARNING);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al cargar información del cliente."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.Message
                                        );
                }
            }
        }
        #endregion

        #region Right Side Buttons

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            FrmPayment payment = new FrmPayment();
            payment.invoiceAmount = decimal.Parse(LblTotal.Text);
            payment.customer = currentCustomer;
            payment.ShowDialog();
        }
        #endregion

        #region Form Control Events
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetProductInformation(
                                        emissionPoint.LocationId
                                        , TxtBarcode.Text
                                        , 1
                                        , currentCustomer.CustomerId
                                        , 0
                                        , ""
                                        );
            }
        }
        #endregion

        #region Main Functions

        private void GetProductInformation(
                                            short _locationId
                                            , string _barcode
                                            , decimal _qty
                                            , long _customerId
                                            , int _internalCreditCardId
                                            , string _paymMode
                                            )
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans();
            SP_Product_Consult_Result result;

            try
            {
                result = clsInvoiceTrans.ProductConsult(
                                                        _locationId
                                                        , _barcode
                                                        , _qty
                                                        , _customerId
                                                        , _internalCreditCardId
                                                        , _paymMode
                                                        );

                if (result != null)
                {
                    DataRow NewRow = dataTable.NewRow();
                    NewRow[0] = result.Name;
                    NewRow[1] = result.Quantity;
                    NewRow[2] = result.Price;
                    NewRow[3] = result.DiscountAmount;
                    NewRow[4] = result.SubTotal;
                    dataTable.Rows.Add(NewRow);
                    GrcSalesDetail.DataSource = dataTable;
                }
                else
                {
                    functions.ShowMessage("El producto con codigo de barras " + _barcode + " no se encuentra registrado.",ClsEnums.MessageType.WARNING);
                    TxtBarcode.Text = "";
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Hubo un problema al consultar producto."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.Message
                                        );
            }


        }
        #endregion
    }
}