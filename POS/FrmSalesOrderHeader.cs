using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmSalesOrderHeader : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        ClsSalesOrder sales = new ClsSalesOrder(Program.customConnectionString);
        Customer currentCustomer = new Customer();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        CustomerAddress customerAddress;
        public bool formActionResult = false;
        IEnumerable<SalesOrigin> salesOrigins;

        public FrmSalesOrderHeader()
        {
            InitializeComponent();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = InputFromOption.CUSTOMER_IDENTIFICATION
            };
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification == string.Empty)
            {
                return;
            }

            string identification = keyBoard.customerIdentification;

            try
            {
                currentCustomer = new ClsCustomer(Program.customConnectionString).GetCustomerByIdentification(identification);

                if ((currentCustomer?.CustomerId) <= 0)
                {
                    bool response = functions.ShowMessage("El cliente ingresado no esta registrado, desea ingresarlo?.", MessageType.CONFIRM);

                    if (response)
                    {
                        currentCustomer = CreateCustomer(identification);

                        if (currentCustomer != null)
                        {
                            LblCustomerId.Text = currentCustomer.Identification;
                            LblCustomerName.Text = $"{currentCustomer.Firtsname} {currentCustomer.Lastname}";
                            LblCustomerAddress.Text = currentCustomer.Address;
                            LblCustomerEmail.Text = currentCustomer.Email;
                        }
                        else
                        {
                            functions.ShowMessage("No se pudo cargar datos de cliente.", MessageType.WARNING);
                        }
                    }
                }

                LblCustomerId.Text = currentCustomer.Identification;
                LblCustomerName.Text = $"{currentCustomer.Firtsname} {currentCustomer.Lastname}";
                LblCustomerAddress.Text = currentCustomer.Address;
                LblCustomerEmail.Text = currentCustomer.Email;

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información del cliente.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private Customer CreateCustomer(string _identification)
        {
            FrmCustomer frmCustomer = new FrmCustomer()
            {
                emissionPoint = emissionPoint,
                isNewCustomer = true,
                customerIdentification = _identification,
                loginInformation = loginInformation
            };
            frmCustomer.ShowDialog();

            return frmCustomer.currentCustomer;
        }

        private void FrmSalesOrderHeader_Load(object sender, EventArgs e)
        {
            if (GetEmissionPointInformation())
            {
                ClearSalesOrderHeader();
                LoadSalesOrigin();
                EdtDeliveryDate.DateTime = DateTime.Now;
            }
        }

        private bool GetEmissionPointInformation()
        {
            string addressIP = loginInformation.AddressIP;

            if (addressIP == "")
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
                return false;
            }

            try
            {
                emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);

                if (emissionPoint == null)
                {
                    functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
                    return false;
                }

                functions.PrinterName = emissionPoint.PrinterName;
                return true;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
                return false;
            }
        }

        private void LoadSalesOrigin()
        {
            try
            {
                salesOrigins = new ClsSalesOrder(Program.customConnectionString).GetSalesOrderOrigin(false);

                if (salesOrigins?.Count() > 0)
                {
                    foreach (SalesOrigin identType in salesOrigins)
                    {
                        CmbSalesOrderOrigin.Properties.Items.Add(new ImageComboBoxItem { Value = identType.SalesOriginId, Description = identType.Name });
                    }
                    CmbSalesOrderOrigin.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar origenes de orden."
                                        , MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void ClearSalesOrderHeader()
        {
            BtnCustomer.Enabled = true;
            BtnDeliveryAddress.Enabled = true;

            currentCustomer = new ClsCustomer(Program.customConnectionString).GetCustomerById(1);
            LblCustomerId.Text = currentCustomer.Identification;
            LblCustomerName.Text = $"{ currentCustomer.Firtsname} {currentCustomer.Lastname}";
            LblCustomerAddress.Text = currentCustomer.Address;
            LblCustomerEmail.Text = currentCustomer.Email;

            LblDeliveryAddress.Text = string.Empty;
            LblDeliveryAddressRef.Text = string.Empty;

            EdtDeliveryDate.Properties.MinValue = DateTime.Today;
            EdtDeliveryDate.Properties.MaxValue = DateTime.Today.AddDays(15);
        }

        private void BtnDeliveryAddress_Click(object sender, EventArgs e)
        {
            if (currentCustomer.CustomerId == 1)
            {
                functions.ShowMessage("No puede seleccionar direccion para un cliente CONSUMIDOR FINAL.", MessageType.WARNING);
                return;
            }

            FrmAddressPicker frmCustomer = new FrmAddressPicker()
            {
                emissionPoint = emissionPoint,
                currentCustomer = currentCustomer,
                loginInformation = loginInformation
            };
            frmCustomer.ShowDialog();

            if (frmCustomer.formResult)
            {
                customerAddress = frmCustomer.response;
                LblDeliveryAddress.Text = customerAddress.Address;
                LblDeliveryAddressRef.Text = customerAddress.AddressReference;
            }

        }

        private void BtnSaveOrder_Click(object sender, EventArgs e)
        {
            if (currentCustomer.CustomerId == 1)
            {
                functions.ShowMessage("No puede guardar orden de venta para un cliente CONSUMIDOR FINAL.", MessageType.WARNING);
                return;
            }

            if (richTextBox1.Text == string.Empty)
            {
                functions.ShowMessage("Comanda no puede esta vacia.", MessageType.WARNING);
                return;
            }

            if (customerAddress == null)
            {
                functions.ShowMessage("Debe seleccionar un direccion de entrega.", MessageType.WARNING);
                return;
            }

            SalesOrigin origin = salesOrigins
                .Where(li => li.SalesOriginId == int.Parse(CmbSalesOrderOrigin.EditValue.ToString()))
                .FirstOrDefault();

            XElement header = new XElement("SalesOrder");
            XElement headerNode = new XElement("SalesOrder");
            SalesOrder salesOrder = new SalesOrder
            {
                CustomerId = currentCustomer.CustomerId,
                LocationId = emissionPoint.LocationId,
                DeliveryDate = EdtDeliveryDate.Text == string.Empty ? DateTime.Now : DateTime.Parse(EdtDeliveryDate.Text),
                Recipient = string.Format("{0} {1}", currentCustomer.Firtsname, currentCustomer.Lastname),
                DeliveryAddress = customerAddress.Address,
                CustomerAddressId = customerAddress.CustomerAddressId,
                SalesmanId = origin.SalesmanId,
                SalesOriginId = origin.SalesOriginId,
                Observation = TxtObservation.Text,
                Status = "O",
                CreatedBy = (int)loginInformation.UserId,
                ModifiedBy = (int)loginInformation.UserId,
                Workstation = loginInformation.Workstation
            };

            Type type = salesOrder.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                string name = prop.Name;
                object value = prop.GetValue(salesOrder);

                if (value == null)
                {
                    value = "";
                }

                headerNode.Add(new XElement(name, value));
            }
            header.Add(headerNode);

            string[] array = richTextBox1.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < array.Length; i++)
            {
                XElement textNode = new XElement("SalesOrderText");
                SalesOrderText orderText = new SalesOrderText
                {
                    Sequence = i + 1,
                    SalesOrderText1 = array[i].ToUpper(),
                    CreatedBy = (int)loginInformation.UserId,
                    ModifiedBy = (int)loginInformation.UserId,
                    Workstation = loginInformation.Workstation
                };

                type = orderText.GetType();
                properties = type.GetProperties();

                foreach (PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(orderText);

                    if (value == null)
                    {
                        value = "";
                    }

                    textNode.Add(new XElement(name, value));
                }
                header.Add(textNode);
            }

            try
            {
                SP_SalesOrderOmnipos_Insert_Result result = new ClsSalesOrderTrans(Program.customConnectionString).CreateOrUpdateSalesOrder(header.ToString());
                if ((bool)result.Error)
                {
                    functions.ShowMessage("No se pudo crear orden de venta.", MessageType.WARNING, true, result.TextError);
                    return;
                }

                functions.emissionPoint = emissionPoint;
                if (functions.PrintDocument((long)result.SalesOrderId, DocumentType.SALESORDER, false))
                {
                    functions.ShowMessage("Orden de Venta generada exitosamente.", MessageType.INFO);
                }
                else
                {
                    functions.ShowMessage("La orden de venta fue generada exitosamente pero no se pudo imprimir.", MessageType.WARNING);
                }

                formActionResult = true;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al generar orden.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnSaveOrder_Click(null, null);
                    break;
                case Keys.F3:
                    BtnDeliveryAddress_Click(null, null);
                    break;
                case Keys.F6:
                    BtnCustomer_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode) == 27)
            {
                BtnExit_Click(null, null);
            }
        }

        private void CmbSalesOrderOrigin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    EdtDeliveryDate.Focus();
                    break;
                default:
                    break;
            }
        }

        private void TxtObservation_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnSaveOrder_Click(null, null);
                    break;
                case Keys.F3:
                    BtnDeliveryAddress_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtObservation_KeyUp(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode) == 27)
            {
                BtnExit_Click(null, null);
            }
        }
    }
}