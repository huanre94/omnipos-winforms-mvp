using DevExpress.XtraEditors.Controls;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
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
        ClsSalesOrder sales = new ClsSalesOrder();
        Customer currentCustomer = new Customer();
        public EmissionPoint emissionPoint;
        public SP_Login_Consult_Result loginInformation;
        CustomerAddress customerAddress;
        public bool formActionResult = false;
        List<SalesOrigin> salesOrigins;

        public FrmSalesOrderHeader()
        {
            InitializeComponent();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            FrmKeyBoard keyBoard = new FrmKeyBoard();
            keyBoard.inputFromOption = Classes.ClsEnums.InputFromOption.CUSTOMER_IDENTIFICATION;
            keyBoard.ShowDialog();

            if (keyBoard.customerIdentification != "")
            {
                ClsCustomer clsCustomer = new ClsCustomer();
                string identification = keyBoard.customerIdentification;

                try
                {
                    currentCustomer = clsCustomer.GetCustomerByIdentification(identification);

                    if (currentCustomer != null)
                    {
                        if (currentCustomer.CustomerId > 0)
                        {
                            //if (currentCustomer.IsEmployee)
                            //{
                            //    bool response = functions.ShowMessage("El cliente es un empleado, desea utilizar la tarjeta de afiliado?.", ClsEnums.MessageType.CONFIRM);

                            //    if (response)
                            //    {
                            //        FrmPaymentCredit paymentCredit = new FrmPaymentCredit();
                            //        paymentCredit.customer = currentCustomer;
                            //        paymentCredit.emissionPoint = emissionPoint;
                            //        paymentCredit.scanner = AxOPOSScanner;
                            //        paymentCredit.isPresentingCreditCard = true;
                            //        paymentCredit.ShowDialog();

                            //        if (paymentCredit.formActionResult)
                            //        {
                            //            internalCreditCardId = paymentCredit.internalCreditCardId;
                            //            internalCreditCardCode = paymentCredit.internalCreditCardCode;
                            //        }
                            //    }
                            //}

                            LblCustomerId.Text = currentCustomer.Identification;
                            LblCustomerName.Text = $"{currentCustomer.Firtsname} {currentCustomer.Lastname}";
                            LblCustomerAddress.Text = currentCustomer.Address;
                            LblCustomerEmail.Text = currentCustomer.Email;
                        }
                    }
                    else
                    {
                        bool response = functions.ShowMessage("El cliente ingresado no esta registrado, desea ingresarlo?.", ClsEnums.MessageType.CONFIRM);

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

        private Customer CreateCustomer(string _identification)
        {
            FrmCustomer frmCustomer = new FrmCustomer
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
            }
        }

        private bool GetEmissionPointInformation()
        {
            ClsGeneral clsGeneral = new ClsGeneral();

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = clsGeneral.GetEmissionPointByIP(addressIP);

                    if (emissionPoint != null)
                    {
                        response = true;
                        functions.PrinterName = emissionPoint.PrinterName;
                    }
                    else
                    {
                        functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
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
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void LoadSalesOrigin()
        {
            ClsSalesOrder customer = new ClsSalesOrder();
            try
            {
                salesOrigins = customer.GetSalesOrderOrigin(false);

                if (salesOrigins != null)
                {
                    if (salesOrigins.Count > 0)
                    {
                        foreach (SalesOrigin identType in salesOrigins)
                        {
                            CmbSalesOrderOrigin.Properties.Items.Add(new ImageComboBoxItem { Value = identType.SalesOriginId, Description = identType.Name });
                        }
                        CmbSalesOrderOrigin.SelectedIndex = 0;
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

        private void ClearSalesOrderHeader()
        {
            BtnCustomer.Enabled = true;
            BtnDeliveryAddress.Enabled = true;

            currentCustomer = new ClsCustomer().GetCustomerById(1);
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
                functions.ShowMessage("No puede seleccionar direccion para un cliente CONSUMIDOR FINAL.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                FrmAddressPicker frmCustomer = new FrmAddressPicker
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
        }

        private void BtnSaveOrder_Click(object sender, EventArgs e)
        {
            if (currentCustomer.CustomerId == 1)
            {
                functions.ShowMessage("No puede guardar orden de venta para un cliente CONSUMIDOR FINAL.", ClsEnums.MessageType.WARNING);
            }
            else
            {
                if (richTextBox1.Text == string.Empty)
                {
                    functions.ShowMessage("Comanda no puede esta vacia.", ClsEnums.MessageType.WARNING);
                    return;
                }

                if (customerAddress == null)
                {
                    functions.ShowMessage("Debe seleccionar un direccion de entrega.", ClsEnums.MessageType.WARNING);
                    return;
                }

                SalesOrigin origin = (from li in salesOrigins
                                      where li.SalesOriginId == int.Parse(CmbSalesOrderOrigin.EditValue.ToString())
                                      select li).FirstOrDefault();

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

                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(salesOrder);

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

                    foreach (var prop in properties)
                    {
                        var name = prop.Name;
                        var value = prop.GetValue(orderText);

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
                    SP_SalesOrderOmnipos_Insert_Result result = new ClsSalesOrderTrans().CreateOrUpdateSalesOrder(header.ToString());
                    if ((bool)result.Error)
                    {
                        functions.ShowMessage("No se pudo crear orden de venta.", ClsEnums.MessageType.WARNING, true, result.TextError);
                    }
                    else
                    {
                        functions.emissionPoint = emissionPoint;
                        if (functions.PrintDocument((long)result.SalesOrderId, ClsEnums.DocumentType.SALESORDER))
                        {
                            functions.ShowMessage("Orden de Venta generada exitosamente.", ClsEnums.MessageType.INFO);
                        }
                        else
                        {
                            functions.ShowMessage("La orden de venta fue generada exitosamente pero no se pudo imprimir.", ClsEnums.MessageType.WARNING);
                        }
                        formActionResult = true;
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    functions.ShowMessage(
                                                          "Ocurrio un problema al generar orden."
                                                          , ClsEnums.MessageType.ERROR
                                                          , true
                                                          , ex.InnerException.Message
                                                      );
                }
            }
        }
    }
}