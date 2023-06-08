using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmAddressPicker : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();

        //EmissionPoint EmissionPoint { get; set; }
        SP_Login_Consult_Result LoginInformation { get; set; }
        Customer CurrentCustomer { get; set; }

        public CustomerAddress response;
        bool FormResult { get; set; } = false;
        public long addressId;
        bool newAddress = false;
        IEnumerable<CustomerAddress> addressList;

        public bool GetResult() => FormResult;

        public FrmAddressPicker()
        {
            InitializeComponent();
        }

        public FrmAddressPicker(EmissionPoint _emissionPoint, SP_Login_Consult_Result _loginInformation, Customer _currentCustomer)
        {
            InitializeComponent();
            //EmissionPoint = _emissionPoint;
            LoginInformation = _loginInformation;
            CurrentCustomer = _currentCustomer;
        }

        private void FrmAddressPicker_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadAddressesByCustomer(CurrentCustomer);

            LblCustomerId.Text = CurrentCustomer.Identification;
            LblCustomerName.Text = $"{CurrentCustomer.Firtsname} {CurrentCustomer.Lastname}";
        }

        private void ClearFields()
        {
            CmbAddressPicker.Properties.Items.Clear();
            TxtAddress.Text = string.Empty;
            TxtAddressRef.Text = string.Empty;
            TxtTelephoneAddress.Text = string.Empty;
        }

        private void EnableAddressInput(bool value)
        {
            CmbAddressPicker.Enabled = (!value);
            TxtAddress.Enabled = value;
            TxtAddressRef.Enabled = value;
            TxtTelephoneAddress.Enabled = value;
            BtnKeyboardAddress.Enabled = value;
            BtnKeyboardAddressRef.Enabled = value;
            BtnKeypadTelephone.Enabled = value;
        }

        private void LoadAddressesByCustomer(Customer _currentCustomer)
        {
            CmbAddressPicker.Properties.Items.Clear();
            try
            {
                addressList = new ClsCustomer(Program.customConnectionString).GetCustomerAddressesById(_currentCustomer);

                if (addressList?.Count() == 0)
                {
                    functions.ShowMessage("Cliente no cuenta con direcciones de entrega registradas, por favor registre una.", MessageType.WARNING);
                    newAddress = true;
                    BtnAddressPicker.Text = "F6 Guardar";
                    EnableAddressInput(true);
                    return;
                }

                foreach (CustomerAddress address in addressList)
                {
                    CmbAddressPicker.Properties.Items.Add(new ImageComboBoxItem { Value = address.CustomerAddressId, Description = address.Address });
                    CmbAddressPicker.EditValue = null;
                }
                EnableAddressInput(false);

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar origenes de orden.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }

        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnNewAddress_Click(object sender, EventArgs e)
        {
            newAddress = true;
            ClearFields();
            EnableAddressInput(true);
            BtnAddressPicker.Text = "F6 Guardar";
        }

        private void BtnKeyboardAddress_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_ADDRESS
            };
            frmKeyBoard.ShowDialog();

            TxtAddress.Text = frmKeyBoard.customerAddress;
            TxtAddress.Focus();
        }

        private void BtnKeyboardAddressRef_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_ADDRESS
            };
            frmKeyBoard.ShowDialog();

            TxtAddressRef.Text = frmKeyBoard.customerAddress;
            TxtAddressRef.Focus();
        }

        private void CmbAddressPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAddressPicker.EditValue != null)
            {
                response = addressList
                    .Where(re => re.CustomerAddressId == int.Parse(CmbAddressPicker.EditValue.ToString()))
                    .FirstOrDefault();

                TxtAddress.Text = response.Address;
                TxtAddressRef.Text = response.AddressReference;
                TxtTelephoneAddress.Text = response.Telephone;
                return;
            }

            TxtAddress.Text = string.Empty;
            TxtAddressRef.Text = string.Empty;
            TxtTelephoneAddress.Text = string.Empty;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAddressesByCustomer(CurrentCustomer);
            BtnAddressPicker.Text = "F6 Elegir";
            newAddress = false;
        }

        private void BtnKeypadTelephone_Click(object sender, EventArgs e)
        {
            FrmKeyPad frmKeyBoard = new FrmKeyPad(InputFromOption.CUSTOMER_PHONE);
            frmKeyBoard.ShowDialog();
            TxtTelephoneAddress.Text = frmKeyBoard.GetValue();
            TxtTelephoneAddress.Focus();
        }

        private void BtnAddressPicker_Click(object sender, EventArgs e)
        {
            if (!newAddress)
            {
                if (CmbAddressPicker.SelectedIndex < 0)
                {
                    functions.ShowMessage("Debe seleccionar una direccion.", MessageType.WARNING);
                    return;
                }

                FormResult = true;
                DialogResult = DialogResult.OK;
                return;
            }

            if (TxtAddress.Text == string.Empty)
            {
                functions.ShowMessage("La direccion no puede estar vacia.", MessageType.WARNING);
                return;
            }

            if (TxtAddressRef.Text == string.Empty)
            {
                functions.ShowMessage("La referencia de la direccion no puede estar vacia.", MessageType.WARNING);
                return;
            }

            if (TxtTelephoneAddress.Text == string.Empty)
            {
                functions.ShowMessage("El numero de telefono no puede estar vacia.", MessageType.WARNING);
                return;
            }

            long customerAddressId = CmbAddressPicker.EditValue == null ? 0 : (long)CmbAddressPicker.EditValue;
            if (customerAddressId > 0)
            {
                response.Address = TxtAddress.Text;
                response.AddressReference = TxtAddressRef.Text;
                response.Telephone = TxtTelephoneAddress.Text;
                response.ModifiedBy = LoginInformation.UserId;
                response.ModifiedDatetime = DateTime.Now;

                if (!new ClsCustomer(Program.customConnectionString).UpdateCustomerDeliveryAddress(response))
                {
                    functions.ShowMessage("No se pudo actualizar direccion de entrega.", MessageType.WARNING);
                    return;
                }

                functions.ShowMessage("Direccion de entrega actualizada exitosamente.", MessageType.INFO);
                newAddress = false;
                ClearFields();
                LoadAddressesByCustomer(CurrentCustomer);
                BtnAddressPicker.Text = "F6 Elegir";
                CmbAddressPicker.Focus();//08/07/2022
                return;
            }
            else
            {
                XElement customer = new XElement("Customer");
                XElement address = new XElement("CustomerAddress");

                CustomerAddress customerAddress = new CustomerAddress
                {
                    CustomerId = CurrentCustomer.CustomerId,
                    Sequence = 1,
                    Address = TxtAddress.Text.ToUpper(),
                    AddressReference = TxtAddressRef.Text.ToUpper(),
                    Telephone = TxtTelephoneAddress.Text,
                    Coordinates = "",
                    CreatedDatetime = DateTime.Now,
                    CreatedBy = (int)LoginInformation.UserId,
                    Status = "A",
                    Workstation = LoginInformation.Workstation
                };

                Type type = customerAddress.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(customerAddress);

                    if (value == null)
                    {
                        value = "";
                    }

                    address.Add(new XElement(name, value));
                }
                customer.Add(address);

                try
                {
                    SP_CustomerAddress_Insert_Result result = new ClsCustomer(Program.customConnectionString).CreateCustomerDeliveryAddress(customer.ToString());
                    if ((bool)result.Error)
                    {
                        functions.ShowMessage("No se pudo crear direccion de entrega.", MessageType.WARNING, true, result.TextError);
                    }
                    else
                    {
                        functions.ShowMessage("Direccion de entrega registrada exitosamente.", MessageType.INFO);
                        newAddress = false;
                        ClearFields();
                        LoadAddressesByCustomer(CurrentCustomer);
                        BtnAddressPicker.Text = "F6 Elegir";
                        CmbAddressPicker.Focus();//07/07/2022
                    }

                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar origenes de orden.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (CmbAddressPicker.SelectedIndex < 0)
            {
                functions.ShowMessage("Debe seleccionar una direccion.", MessageType.WARNING);
                return;
            }

            EnableAddressInput(true);
            newAddress = true;
            BtnAddressPicker.Text = "F6 Guardar";
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnKeyboardAddress_Click(null, null);
                    break;
                case Keys.Enter:
                    TxtAddressRef.Focus();
                    break;
                default:
                    break;
            }
        }

        private void TxtAddressRef_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnKeyboardAddressRef_Click(null, null);
                    break;
                case Keys.Enter:
                    TxtTelephoneAddress.Focus();
                    break;
                default:
                    break;
            }
        }

        private void TxtTelephoneAddress_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnKeypadTelephone_Click(null, null);
                    break;
                case Keys.F6:
                    BtnAddressPicker_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void CmbAddressPicker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnRefresh_Click(null, null);
                    break;
                case Keys.F2:
                    BtnModify_Click(null, null);
                    TxtAddress.Focus();
                    break;
                case Keys.F3:
                    BtnNewAddress_Click(null, null);
                    TxtAddress.Focus();
                    break;
                case Keys.F6:
                    BtnAddressPicker_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}