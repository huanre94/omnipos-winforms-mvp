using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
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
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        public Customer currentCustomer;
        public CustomerAddress response;
        public bool formResult;
        public long addressId;
        readonly ClsFunctions functions = new ClsFunctions();
        bool newAddress = false;
        List<CustomerAddress> addressList;


        public FrmAddressPicker()
        {
            InitializeComponent();
        }

        private void FrmAddressPicker_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadAddressesByCustomer(currentCustomer);

            LblCustomerId.Text = currentCustomer.Identification;
            LblCustomerName.Text = string.Format("{0} {1}", currentCustomer.Firtsname, currentCustomer.Lastname);
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
            try
            {
                CmbAddressPicker.Properties.Items.Clear();
                addressList = new ClsCustomer().GetCustomerAddressesById(_currentCustomer);
                if (addressList.Count == 0)
                {
                    EnableAddressInput(true);
                    functions.ShowMessage("Cliente no cuenta con direcciones de entrega registradas, por favor registre una.", ClsEnums.MessageType.WARNING);
                    newAddress = true;
                    BtnAddressPicker.Text = "Guardar";
                }
                else
                {
                    EnableAddressInput(false);

                    foreach (CustomerAddress address in addressList)
                    {
                        CmbAddressPicker.Properties.Items.Add(new ImageComboBoxItem { Value = address.CustomerAddressId, Description = address.Address });
                        CmbAddressPicker.EditValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                       "Ocurrio un problema al cargar origenes de orden."
                                       , ClsEnums.MessageType.ERROR
                                       , true
                                       , ex.InnerException.Message
                                   );
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
            BtnAddressPicker.Text = "Guardar";
        }

        private void BtnKeyboardAddress_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_ADDRESS
            };
            frmKeyBoard.ShowDialog();
            TxtAddress.Text = frmKeyBoard.customerAddress;
        }

        private void BtnKeyboardAddressRef_Click(object sender, EventArgs e)
        {
            FrmKeyBoard frmKeyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_ADDRESS
            };
            frmKeyBoard.ShowDialog();
            TxtAddressRef.Text = frmKeyBoard.customerAddress;
        }

        private void CmbAddressPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAddressPicker.EditValue != null)
            {
                response = (from re in addressList
                            where re.CustomerAddressId == int.Parse(CmbAddressPicker.EditValue.ToString())
                            select re).FirstOrDefault();
                TxtAddress.Text = response.Address;
                TxtAddressRef.Text = response.AddressReference;
                TxtTelephoneAddress.Text = response.Telephone;
            }
            else
            {
                TxtAddress.Text = string.Empty;
                TxtAddressRef.Text = string.Empty;
                TxtTelephoneAddress.Text = string.Empty;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAddressesByCustomer(currentCustomer);
            BtnAddressPicker.Text = "Elegir";
            newAddress = false;
        }

        private void BtnKeypadTelephone_Click(object sender, EventArgs e)
        {
            FrmKeyPad frmKeyBoard = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_PHONE
            };
            frmKeyBoard.ShowDialog();
            TxtTelephoneAddress.Text = frmKeyBoard.customerPhone;
        }

        private void BtnAddressPicker_Click(object sender, EventArgs e)
        {
            if (newAddress)
            {
                if (TxtAddress.Text == string.Empty)
                {
                    functions.ShowMessage("La direccion no puede estar vacia.", ClsEnums.MessageType.WARNING);
                    return;
                }

                if (TxtAddressRef.Text == string.Empty)
                {
                    functions.ShowMessage("La referencia de la direccion no puede estar vacia.", ClsEnums.MessageType.WARNING);
                    return;
                }

                if (TxtTelephoneAddress.Text == string.Empty)
                {
                    functions.ShowMessage("El numero de telefono no puede estar vacia.", ClsEnums.MessageType.WARNING);
                    return;
                }

                long customerAddressId = CmbAddressPicker.EditValue == null ? 0 : (long)CmbAddressPicker.EditValue;
                if (customerAddressId > 0)
                {
                    response.Address = TxtAddress.Text;
                    response.AddressReference = TxtAddressRef.Text;
                    response.Telephone = TxtTelephoneAddress.Text;
                    response.ModifiedBy = loginInformation.UserId;
                    response.ModifiedDatetime = DateTime.Now;

                    bool result = new ClsCustomer().UpdateCustomerDeliveryAddress(response);
                    if (result)
                    {
                        functions.ShowMessage("Direccion de entrega actualizada exitosamente.", ClsEnums.MessageType.INFO);
                        newAddress = false;
                        ClearFields();
                        LoadAddressesByCustomer(currentCustomer);
                        BtnAddressPicker.Text = "Elegir";
                    }
                    else
                    {
                        functions.ShowMessage("No se pudo actualizar direccion de entrega.", ClsEnums.MessageType.WARNING);
                    }
                }
                else
                {
                    XElement customer = new XElement("Customer");
                    XElement address = new XElement("CustomerAddress");

                    CustomerAddress customerAddress = new CustomerAddress
                    {
                        CustomerId = currentCustomer.CustomerId,
                        Sequence = 1,
                        Address = TxtAddress.Text.ToUpper(),
                        AddressReference = TxtAddressRef.Text.ToUpper(),
                        Telephone = TxtTelephoneAddress.Text,
                        Coordinates = "",
                        CreatedDatetime = DateTime.Now,
                        CreatedBy = (int)loginInformation.UserId,
                        Status = "A",
                        Workstation = loginInformation.Workstation
                    };

                    Type type = customerAddress.GetType();
                    PropertyInfo[] properties = type.GetProperties();

                    foreach (var prop in properties)
                    {
                        var name = prop.Name;
                        var value = prop.GetValue(customerAddress);

                        if (value == null)
                        {
                            value = "";
                        }

                        address.Add(new XElement(name, value));
                    }
                    customer.Add(address);

                    try
                    {
                        SP_CustomerAddress_Insert_Result result = new ClsCustomer().CreateCustomerDeliveryAddress(customer.ToString());
                        if ((bool)result.Error)
                        {
                            functions.ShowMessage("No se pudo crear direccion de entrega.", ClsEnums.MessageType.WARNING, true, result.TextError);
                        }
                        else
                        {
                            functions.ShowMessage("Direccion de entrega registrada exitosamente.", ClsEnums.MessageType.INFO);
                            newAddress = false;
                            ClearFields();
                            LoadAddressesByCustomer(currentCustomer);
                            BtnAddressPicker.Text = "Elegir";
                        }

                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage(
                                          "Ocurrio un problema al cargar origenes de orden."
                                          , ClsEnums.MessageType.ERROR
                                          , true
                                          , ex.InnerException.Message
                                      );
                    }
                }
            }
            else
            {
                if (CmbAddressPicker.SelectedIndex < 0)
                {
                    functions.ShowMessage("Debe seleccionar una direccion.", ClsEnums.MessageType.WARNING);
                }
                else
                {
                    formResult = true;
                    //addressId = long.Parse(CmbAddressPicker.EditValue.ToString());
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (CmbAddressPicker.SelectedIndex < 0)
            {
                functions.ShowMessage("Debe seleccionar una direccion.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                EnableAddressInput(true);
                newAddress = true;
                BtnAddressPicker.Text = "Guardar";
            }
        }
    }
}