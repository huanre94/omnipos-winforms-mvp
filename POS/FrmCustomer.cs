using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmCustomer : DevExpress.XtraEditors.XtraForm, ICustomerInformationValidator
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public string customerIdentification;
        public bool isNewCustomer;
        public EmissionPoint emissionPoint;
        public Customer currentCustomer = new Customer();
        public SP_Login_Consult_Result loginInformation;

        public FrmCustomer(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //14/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //14/07/2022  Se agregó para que Cadena de conexion sea parametrizable

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (emissionPoint == null)
            {
                functions.ShowMessage("Ha ocurrido un problema en la carga de punto de emisión.", ClsEnums.MessageType.ERROR);
                Close();
            }
            LoadCustomerInformation(customerIdentification);
        }

        private void LoadCustomerInformation(string _identification)
        {
            TxtIdentification.Text = _identification;

            if (isNewCustomer)
            {
                LoadIdentTypes();
                LoadGenders();
            }
            else
            {
                ClsCustomer clsCustomer = new ClsCustomer();
                Customer customer;

                try
                {
                    customer = clsCustomer.GetCustomerByIdentification(_identification, CadenaC);

                    if (customer != null)
                    {
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
                    else
                    {
                        functions.ShowMessage("El cliente consultado no esta registrado.", ClsEnums.MessageType.WARNING);
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                        "Ocurrio un problema al cargar información del cliente."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
                }
            }
        }

        #region Keyboard Call Buttons

        private void BtnKeyboardIdentification_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION
            };
            keyBoard.ShowDialog();
            TxtIdentification.Text = keyBoard.customerIdentification;
            TxtIdentification.Focus();
        }

        private void BtnKeyboardName_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_FIRSTNAME
            };
            keyBoard.ShowDialog();
            TxtFirstName.Text = keyBoard.customerFirstName;
            TxtFirstName.Focus();
        }

        private void BtnKeyboardLastname_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_LASTNAME
            };
            keyBoard.ShowDialog();
            TxtLastName.Text = keyBoard.customerLastName;
            TxtLastName.Focus();
        }

        private void BtnKeyboardAddress_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_ADDRESS
            };
            keyBoard.ShowDialog();
            TxtAddress.Text = keyBoard.customerAddress;
            TxtAddress.Focus();
        }

        private void BtnKeyboardEmail_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_EMAIL
            };
            keyBoard.ShowDialog();
            TxtEmail.Text = keyBoard.customerEmail;
            TxtEmail.Focus();
        }

        private void BtnKeypadPhone_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad(CadenaC)
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_PHONE
            };
            keyPad.ShowDialog();
            TxtPhone.Text = keyPad.customerPhone;
            TxtPhone.Focus();
        }
        #endregion

        private void LoadIdentTypes()
        {
            List<IdentType> custIdentTypes;

            try
            {
                custIdentTypes = new ClsCustomer().GetIdentTypes(CadenaC);

                if (custIdentTypes != null)
                {
                    if (custIdentTypes.Count > 0)
                    {
                        foreach (var identType in custIdentTypes)
                        {
                            CmbIdenType.Properties.Items.Add(new ImageComboBoxItem { Value = identType.Prefix, ImageIndex = identType.IdentTypeId, Description = identType.Name });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar tipos de identificación."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void LoadGenders()
        {
            CmbGender.Properties.Items.Clear();
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "M", Description = "MASCULINO" });
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "F", Description = "FEMENINO" });
        }

        private void CreateOrUpdateCustomer(string _identification)
        {
            bool createOrUpdate = true;

            if (isNewCustomer)
            {
                createOrUpdate = ValidateCustomerIdentification(_identification, CmbIdenType.EditValue.ToString(), CadenaC);
            }

            if (createOrUpdate)
            {
                try
                {
                    ClsCustomer clsCustomer = new ClsCustomer();
                    SP_Customer_Insert_Result result;
                    int cityId;

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
                    result = clsCustomer.CreateOrUpdateCustomer(customerXml.ToString(), CadenaC);

                    if (result != null)
                    {
                        if (result.CustomerId > 0)
                        {
                            if (isNewCustomer)
                            {
                                currentCustomer = clsCustomer.GetCustomerByIdentification(result.Identification, CadenaC);
                                functions.ShowMessage("El cliente se registró exitosamente.");
                            }
                            else
                            {
                                functions.ShowMessage("El cliente se actualizó exitosamente.");
                            }
                        }
                        else
                        {
                            functions.ShowMessage("No se pudo registrar cliente.", ClsEnums.MessageType.WARNING, true, result.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al crear / actualizar cliente."
                                            , ClsEnums.MessageType.ERROR
                                            , true
                                            , ex.InnerException.Message
                                        );
                }
            }
            else
            {
                functions.ShowMessage("El cliente no puede ser registrado.", ClsEnums.MessageType.WARNING);
            }
        }

        private bool ValidateCustomerIdentification(string _identification, string _identType, string _CadenaC = "")
        {
            bool response = false;

            try
            {
                ClsCustomer clsCustomer = new ClsCustomer();
                FN_Identification_Validate_Result validateResult;

                validateResult = clsCustomer.ValidateCustomerIdentification(_identification, _identType, _CadenaC);

                if (validateResult != null)
                {
                    if (validateResult.Validated > 0)
                    {
                        LblPersonType.Text = validateResult.PersonType;
                        CmbIdenType.Properties.Items[CmbIdenType.SelectedIndex].ImageIndex = (int)validateResult.IdentTypeId;
                        response = true;
                    }
                    else
                    {
                        functions.ShowMessage(validateResult.Text, ClsEnums.MessageType.WARNING);
                        TxtIdentification.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al validar identificación del cliente."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }

            return response;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerFields())
            {
                CreateOrUpdateCustomer(TxtIdentification.Text);
            }
        }

        public bool ValidateCustomerFields()
        {
            if (CmbIdenType.Text == string.Empty || TxtIdentification.Text == string.Empty
                     || TxtFirstName.Text == string.Empty || TxtLastName.Text == string.Empty
                     || TxtAddress.Text == string.Empty || TxtPhone.Text == string.Empty)
            {
                functions.ShowMessage("Debe llenar los campos necesarios del formulario", ClsEnums.MessageType.WARNING);
                DialogResult = DialogResult.None;
                return false;
            }

            return true;
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
                    BtnKeypadPhone_Click(null,null);
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
                    BtnKeyboardIdentification_Click(null,null);
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
                    BtnKeyboardName_Click(null,null);
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
    }
}
