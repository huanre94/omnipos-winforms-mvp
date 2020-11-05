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
using POS.DLL.Catalog;
using POS.DLL;
using DevExpress.XtraEditors.Controls;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmCustomer : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public string customerIdentification;
        public bool isNewCustomer;
        public EmissionPoint emissionPoint;
        public Customer currentCustomer = new Customer();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (emissionPoint != null)
            {
                LoadCustomerInformation(customerIdentification);
            }
            else
            {
                functions.ShowMessage("Ha ocurrido un problema en la carga de punto de emisión.", ClsEnums.MessageType.ERROR);
                Close();
            }
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
                    customer = clsCustomer.GetCustomerByIdentification(_identification);

                    if (customer != null)
                    {
                        if (customer.CustomerId > 0)
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
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION
            };
            keyBoard.ShowDialog();
            TxtIdentification.Text = keyBoard.customerIdentification;
        }

        private void BtnKeyboardName_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_FIRSTNAME
            };
            keyBoard.ShowDialog();
            TxtFirstName.Text = keyBoard.customerFirstName;
        }

        private void BtnKeyboardLastname_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_LASTNAME
            };
            keyBoard.ShowDialog();
            TxtLastName.Text = keyBoard.customerLastName;
        }

        private void BtnKeyboardAddress_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_ADDRESS
            };
            keyBoard.ShowDialog();
            TxtAddress.Text = keyBoard.customerAddress;
        }

        private void BtnKeyboardEmail_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_EMAIL
            };
            keyBoard.ShowDialog();
            TxtEmail.Text = keyBoard.customerEmail;
        }

        private void BtnKeypadPhone_Click(object sender, EventArgs e)
        {
            FrmKeyPad keyPad = new FrmKeyPad
            {
                inputFromOption = ClsEnums.InputFromOption.CUSTOMER_PHONE
            };
            keyPad.ShowDialog();
            TxtPhone.Text = keyPad.customerPhone;
        }
        #endregion

        private void LoadIdentTypes()
        {
            ClsCustomer customer = new ClsCustomer();
            List<IdentType> custIdentTypes;

            try
            {
                custIdentTypes = customer.GetIdentTypes();

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
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar tipos de identificación."
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
                createOrUpdate = ValidateCustomerIdentification(_identification, CmbIdenType.EditValue.ToString());
            }

            if (createOrUpdate)
            {
                try
                {
                    ClsCustomer clsCustomer = new ClsCustomer();
                    SP_Customer_Insert_Result result;

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

                    result = clsCustomer.CreateOrUpdateCustomer(customerXml.ToString());

                    if (result != null)
                    {
                        if (result.CustomerId > 0)
                        {
                            if (isNewCustomer)
                            {
                                currentCustomer = clsCustomer.GetCustomerByIdentification(result.Identification);
                                functions.ShowMessage("El cliente se registró exitosamente.");
                            }
                            else
                            {
                                functions.ShowMessage("El cliente se actualizó exitosamente.");
                            }
                            
                        }
                        else
                        {
                            functions.ShowMessage("No se pudo registrar cliente.",ClsEnums.MessageType.WARNING);
                        }
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                            "Ocurrio un problema al crear / actualizar cliente."
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

        private bool ValidateCustomerIdentification(string _identification, string _identType)
        {
            bool response = false;

            try
            {
                ClsCustomer clsCustomer = new ClsCustomer();
                FN_Identification_Validate_Result validateResult;

                validateResult = clsCustomer.ValidateCustomerIdentification(_identification, _identType);

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
                        TxtIdentification.Text = "";
                    }
                }
            }
            catch(Exception ex)
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
            if(ValidateCustomerFields())
            {
                CreateOrUpdateCustomer(TxtIdentification.Text);
            }
        }

        private bool ValidateCustomerFields()
        {
            bool response = false;

            if (CmbIdenType.Text != "" && TxtIdentification.Text != ""
                && TxtFirstName.Text != "" && TxtLastName.Text != ""
                && TxtAddress.Text != "" && TxtPhone.Text != "")
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

        
    }
}