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

namespace POS
{
    public partial class FrmCustomer : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public string customerIdentification;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            TxtIdentification.Text = customerIdentification;

            LoadIdentTypes();
            LoadGenders();
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
                            CmbIdenType.Properties.Items.Add(new ImageComboBoxItem { Value = identType.IdentTypeId, Description = identType.Name });
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
                                        , ex.Message
                                    );
            }
        }

        private void LoadGenders()
        {
            CmbGender.Properties.Items.Clear();
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "M", Description = "MASCULINO" });
            CmbGender.Properties.Items.Add(new ImageComboBoxItem { Value = "F", Description = "FEMENINO" });
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if(ValidateCustomerFields())
            {
                
                ClsCustomer clsCustomer = new ClsCustomer();
                Customer customer = new Customer
                {
                    CustomerTypeId = int.Parse(CmbIdenType.EditValue.ToString()),
                };

                clsCustomer.CreateCustomer(customer);
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