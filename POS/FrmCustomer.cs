using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmCustomer : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public string customerIdentification;
        public bool IsNewCustomer { get; set; }
        public EmissionPoint emissionPoint;
        public Customer currentCustomer { get; set; } = new Customer();
        public SP_Login_Consult_Result loginInformation;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (emissionPoint == null)
            {
                functions.ShowMessage("Ha ocurrido un problema en la carga de punto de emisión.", MessageType.ERROR);
                Close();
                return;
            }
            LoadCustomerInformation(customerIdentification);
        }

        private void LoadCustomerInformation(string _identification)
        {
            TxtIdentification.Text = _identification;

            if (IsNewCustomer)
            {
                LoadIdentTypes();
                LoadGenders();
            }
            else
            {
                Customer customer;

                try
                {
                    customer = new ClsCustomer(Program.customConnectionString).GetCustomerByIdentification(_identification);

                    if (customer == null)
                    {
                        functions.ShowMessage("El cliente consultado no esta registrado.", MessageType.WARNING);
                        return;
                    }

                    if (customer?.CustomerId > 0)
                    {
                        CmbIdenType.EditValue = customer.IdentTypeId;
                        LblPersonType.Text = customer.PersonType;
                        TxtIdentification.Text = customer.Identification;
                        TxtFirstName.Text = customer.Firtsname;
                        TxtFirstName.Text = customer.Lastname;
                        TxtAddress.Text = customer.Address;
                        TxtEmail.Text = customer.Email;
                        TxtPhone.Text = customer.Phone;
                        CmbGender.EditValue = customer.Gender;
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar información del cliente.",
                                          MessageType.ERROR,
                                          true,
                                          ex.InnerException.Message);
                }
            }
        }

        #region Keyboard Call Buttons

        private void BtnKeyboardIdentification_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_IDENTIFICATION
            };
            keyBoard.ShowDialog();
            TxtIdentification.Text = keyBoard.customerIdentification;
            TxtIdentification.Focus();
        }

        private void BtnKeyboardName_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_FIRSTNAME
            };
            keyBoard.ShowDialog();
            TxtFirstName.Text = keyBoard.customerFirstName;
            TxtFirstName.Focus();
        }

        private void BtnKeyboardLastname_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_LASTNAME
            };
            keyBoard.ShowDialog();
            TxtLastName.Text = keyBoard.customerLastName;
            TxtLastName.Focus();
        }

        private void BtnKeyboardAddress_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_ADDRESS
            };
            keyBoard.ShowDialog();
            TxtAddress.Text = keyBoard.customerAddress;
            TxtAddress.Focus();
        }

        private void BtnKeyboardEmail_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard()
            {
                inputFromOption = InputFromOption.CUSTOMER_EMAIL
            };
            keyBoard.ShowDialog();
            TxtEmail.Text = keyBoard.customerEmail;
            TxtEmail.Focus();
        }

        private void BtnKeypadPhone_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad()
            {
                inputFromOption = InputFromOption.CUSTOMER_PHONE
            };
            keyPad.ShowDialog();
            TxtPhone.Text = keyPad.customerPhone;
            TxtPhone.Focus();
        }
        #endregion

        private void LoadIdentTypes()
        {
            try
            {
                IEnumerable<IdentType> custIdentTypes = new ClsCustomer(Program.customConnectionString).GetIdentTypes();

                if (custIdentTypes?.Count() > 0)
                {
                    foreach (IdentType identType in custIdentTypes)
                    {
                        CmbIdenType.Properties.Items.Add(new ImageComboBoxItem { Value = identType.Prefix, ImageIndex = identType.IdentTypeId, Description = identType.Name });
                    }
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar tipos de identificación.",
                     MessageType.ERROR,
                    true,
                    ex.InnerException.Message);
            }
        }

        private void LoadGenders()
        {
            CmbGender.Properties.Items.Clear();
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "N", Description = "NO DEFINIDO" });
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "M", Description = "MASCULINO" });
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "F", Description = "FEMENINO" });
            CmbGender.SelectedIndex = 0;
        }

        private bool CreateOrUpdateCustomer(string _identification)
        {
            bool isValidCustomerIdentification = true;

            if (IsNewCustomer)
            {
                isValidCustomerIdentification = ValidateCustomerIdentification(_identification, CmbIdenType.EditValue.ToString());
            }

            if (!isValidCustomerIdentification)
            {
                functions.ShowMessage("El cliente no puede ser registrado.", MessageType.WARNING);
                return false;
            }

            try
            {
                XElement customerXml = new XElement("Customer");
                customerXml.Add(new XElement("CustomerId", currentCustomer.CustomerId));
                customerXml.Add(new XElement("LocationId", emissionPoint.LocationId));
                customerXml.Add(new XElement("IdentTypeId", CmbIdenType.Properties.Items[CmbIdenType.SelectedIndex].ImageIndex));
                customerXml.Add(new XElement("PersonType", LblPersonType.Text));
                customerXml.Add(new XElement("Identification", _identification));
                customerXml.Add(new XElement("Firtsname", TxtFirstName.Text));
                customerXml.Add(new XElement("Lastname", TxtLastName.Text));
                customerXml.Add(new XElement("Address", TxtAddress.Text));
                customerXml.Add(new XElement("Email", TxtEmail.Text));
                customerXml.Add(new XElement("Phone", TxtPhone.Text));
                customerXml.Add(new XElement("Gender", CmbGender.EditValue.ToString()));
                customerXml.Add(new XElement("CreatedBy", loginInformation.UserId));
                customerXml.Add(new XElement("Workstation", loginInformation.Workstation));

                int cityId;
                switch (emissionPoint.LocationId) //While city does not select on customer register
                {
                    case 1:
                        cityId = 3;
                        break;
                    case 2:
                        cityId = 2;
                        break;
                    default:
                        cityId = 1;
                        break;
                }

                customerXml.Add(new XElement("CityId", cityId));

                SP_Customer_Insert_Result result = new ClsCustomer(Program.customConnectionString).CreateOrUpdateCustomer(customerXml.ToString());

                if ((result?.CustomerId) <= 0)
                {
                    functions.ShowMessage("No se pudo registrar cliente.", MessageType.WARNING, true, result.Text);
                    return false;
                }

                if (IsNewCustomer)
                {
                    currentCustomer = new ClsCustomer(Program.customConnectionString).GetCustomerByIdentification(result.Identification);
                    functions.ShowMessage("El cliente se registró exitosamente.");
                    return true;
                }

                functions.ShowMessage("El cliente se actualizó exitosamente.");
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al crear / actualizar cliente.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);

                return false;
            }

            return true;
        }

        private bool ValidateCustomerIdentification(string _identification, string _identType)
        {
            try
            {
                FN_Identification_Validate_Result validateResult = new ClsCustomer(Program.customConnectionString).ValidateCustomerIdentification(_identification, _identType);

                if ((validateResult?.Validated) <= 0)
                {
                    functions.ShowMessage(validateResult.Text, MessageType.WARNING);
                    TxtIdentification.Text = string.Empty;
                    return false;
                }

                LblPersonType.Text = validateResult.PersonType;
                CmbIdenType.Properties.Items[CmbIdenType.SelectedIndex].ImageIndex = (int)validateResult.IdentTypeId;
                return true;

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al validar identificación del cliente.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
                return false;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerFields())
            {
                if (CreateOrUpdateCustomer(TxtIdentification.Text))
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private bool TextValidations(object obj, string fieldName)
        {
            if (((TextEdit)obj).Text == string.Empty)
            {
                functions.ShowMessage($"El campo {fieldName} no puede estar vacio.", MessageType.WARNING);
                ((TextEdit)obj).Focus();
                return true;
            }

            if (((TextEdit)obj).Name == "TxtPhone" && ((TextEdit)obj).Text.Length == 10)
            {
                return false;
            }

            //if (((TextEdit)obj).Name == "TxtEmail" && ((TextEdit)obj).Text.Length == 10)
            //{
            //    return true;
            //}

            return false;
        }

        private bool ValidateCustomerFields()
        {
            Dictionary<object, string> controls = new Dictionary<object, string>()
            {
                { CmbIdenType, LblIdentType.Text },
                { TxtIdentification, LblIdentification.Text },
                { TxtFirstName, LblName.Text },
                { TxtLastName, LblLastname.Text },
                { TxtAddress, LblAddress.Text },
                { TxtPhone, LblPhone.Text },
                { TxtEmail, LblEmail.Text }
            };

            foreach (var control in controls)
            {
                if (TextValidations(control.Key, control.Value.Replace("*", "")))
                {
                    DialogResult = DialogResult.None;
                    return false;
                }
            }

            return true;
            //if (CmbIdenType.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    CmbIdenType.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtIdentification.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtIdentification.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtFirstName.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtFirstName.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtLastName.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtLastName.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtAddress.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtAddress.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtPhone.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtPhone.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

            //if (TxtEmail.Text == string.Empty)
            //{
            //    functions.ShowMessage("Debe llenar los campos necesarios del formulario", MessageType.WARNING);
            //    TxtEmail.Focus();
            //    DialogResult = DialogResult.None;
            //    return false;
            //}

        }

        private void TxtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CmbGender.Focus();
                    break;
                case Keys.F1:
                    BtnKeypadPhone_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtFirstName.Focus();
                    break;
                case Keys.F1:
                    BtnKeyboardIdentification_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtLastName.Focus();
                    break;
                case Keys.F1:
                    BtnKeyboardName_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtAddress.Focus();
                    break;
                case Keys.F1:
                    BtnKeyboardLastname_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtEmail.Focus();
                    break;
                case Keys.F1:
                    BtnKeyboardAddress_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtPhone.Focus();
                    break;
                case Keys.F1:
                    BtnKeyboardEmail_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void CmbIdenType_KeyDown(object sender, KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TxtIdentification.Focus();
                    break;
                default:
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
