using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS
{
    public partial class FrmRemissionGuideOrderToInvoice : DevExpress.XtraEditors.XtraForm
    {
        public SP_RemissionGuide_Consult_Result remission;
        public SP_Login_Consult_Result loginInformation;
        public EmissionPoint emissionPoint;
        public bool isUpdated = false;
        ClsFunctions functions = new ClsFunctions();
        XElement salesOrderXml = new XElement("SalesOrder");
        ScaleBrands scaleBrand;
        private string portName = "";

        public FrmRemissionGuideOrderToInvoice()
        {
            InitializeComponent();
        }

        private void FrmRemissionGuideOrderToInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (GetEmissionPointInformation())
                {
                    if (emissionPoint.ScaleBrand != "")
                    {
                        scaleBrand = (ScaleBrands)Enum.Parse(typeof(ScaleBrands), emissionPoint.ScaleBrand, true);

                        if (scaleBrand == ScaleBrands.DATALOGIC)
                        {
                            functions.AxOPOSScanner = AxOPOSScanner;
                            //functions.EnableScanner(emissionPoint.ScanBarcodeName);
                        }
                        else
                        {
                            string[] portNames = SerialPort.GetPortNames();
                            portName = string.Empty;

                            foreach (string item in portNames)
                            {
                                portName = item;
                                break;
                            }
                        }
                    }

                    if (remission != null)
                    {
                        CheckGridView();
                        LoadLabels();
                        LoadSalesOrders();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un error al cargar Guia de Remision.", MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void LoadLabels()
        {
            LblRemissionGuideNumber.Text = remission.SalesRemissionId.ToString();
            LblDriverName.Text = remission.Name;
            LblTransportPlate.Text = remission.LicencePlate;
        }

        private void LoadSalesOrders()
        {
            try
            {
                IEnumerable<SP_RemissionGuideSalesOrder_Consult_Result> list = new SalesOrderRepository(Program.customConnectionString).GetSalesOrderByRemissionGuideNumber(remission.SalesRemissionId);
                BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bind = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>(list.ToList());
                GrcSalesOrder.DataSource = bind;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las ordenes de venta de esta guia", MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void CheckGridView()
        {
            GrvSalesOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesOrder.DataSource = null;
            //GrvSalesDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;            

            BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bindingList = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>
            {
                AllowNew = true
            };

            GrcSalesOrder.DataSource = bindingList;
        }

        private void BtnCancelRemissionGuide_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("Se procedera a anular la guia ¿Desea continuar?", MessageType.CONFIRM))
            {
                functions.emissionPoint = emissionPoint;
                bool isApproved = functions.RequestSupervisorAuth(true, CancelReasonType.REMISSIONGUIDE_CANCEL);
                if (isApproved)
                {
                    SP_RemissionGuide_Cancel_Result result = new RemissionSaleRepository(Program.customConnectionString)
                    {
                        LoginInformation = loginInformation
                    }.CancelRemissionGuide(remission.SalesRemissionId);
                    if ((bool)result.Error)
                    {
                        functions.ShowMessage("No se pudo anular guia de remision", MessageType.ERROR, true, result.TextError);
                        return;
                    }

                    functions.ShowMessage("Guia de remision anulada exitosamente", MessageType.INFO);
                    isUpdated = true;
                    Close();
                }
            }
        }

        private void BtnOrderPaymentMethod_Click(object sender, EventArgs e)
        {
            if (GrvSalesOrder.FocusedRowHandle < 0)
            {
                GrvSalesOrder.FocusedRowHandle = 0;
            }

            SP_RemissionGuideSalesOrder_Consult_Result result = (SP_RemissionGuideSalesOrder_Consult_Result)GrvSalesOrder.GetRow(GrvSalesOrder.FocusedRowHandle);
            if (result.Amount <= 0)
            {
                functions.ShowMessage("El valor a pagar debe ser mayor a 0", MessageType.WARNING);
            }
            else
            {
                if (!(bool)result.IsCancelled)
                {
                    if (!(bool)result.HavePaymentMethod)
                    {
                        decimal baseAmount = 0;
                        decimal taxAmount = 0;

                        IEnumerable<SP_SalesOrderProduct_Consult_Result> list = new SalesOrderRepository(Program.customConnectionString).GetSalesOrderProductsById(result.SalesOrderId);
                        if (list.Count() != 0)
                        {
                            foreach (SP_SalesOrderProduct_Consult_Result item in list)
                            {
                                baseAmount = (decimal)(item.BaseAmount + item.BaseTaxAmount - item.LineDiscount);
                                taxAmount = (decimal)item.TaxAmount;
                            }
                        }

                        Customer customer = new CustomerRepository(Program.customConnectionString).GetCustomerById(result.CustomerId);

                        FrmPayment payment = new FrmPayment()
                        {
                            invoiceAmount = (decimal)result.Amount,
                            customer = customer,
                            emissionPoint = emissionPoint,
                            taxAmount = taxAmount,
                            baseAmount = baseAmount,
                            loginInformation = loginInformation,
                            internalCreditCardCode = "",
                            invoiceXml = salesOrderXml
                        };
                        payment.ShowDialog();

                        if (payment.canCloseInvoice)
                        {
                            if (payment.isInvoicePaymentDiscount)
                            {
                                salesOrderXml = payment.invoiceXml;
                            }

                            if (payment.paymentXml.HasElements)
                            {
                                try
                                {
                                    SP_SalesOrderPayment_Insert_Result update = new SalesOrderRepository(Program.customConnectionString).UpdateSalesOrderPayment(payment.paymentXml.ToString(), result.SalesOrderId);
                                    if ((bool)update.Error)
                                    {
                                        result.HavePaymentMethod = update.Error;
                                        GrcSalesOrder.RefreshDataSource();
                                    }
                                    else
                                    {
                                        functions.ShowMessage("No se pudo actualizar forma de pago", MessageType.ERROR, true, update.TextError);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    functions.ShowMessage("Ocurrio un error al guardar forma de pago", MessageType.ERROR, true, ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (functions.ShowMessage("Pedido ya cuenta con un metodo de pago. Desea reemplazar el metodo de pago actual?", MessageType.CONFIRM))
                        {
                            bool isWebPayment = false;
                            try
                            {
                                isWebPayment = new SalesOrderRepository(Program.customConnectionString).SalesOrderHaveWebPayments(result.SalesOrderId);
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            if (isWebPayment)
                            {
                                functions.ShowMessage("No se puede modificar un pedido con pago web", MessageType.ERROR);
                                return;
                            }

                            functions.emissionPoint = emissionPoint;
                            bool isApproved = functions.RequestSupervisorAuth(false, 0);
                            if (isApproved)
                            {
                                {
                                    decimal baseAmount = 0;
                                    decimal taxAmount = 0;

                                    IEnumerable<SP_SalesOrderProduct_Consult_Result> list = new SalesOrderRepository(Program.customConnectionString).GetSalesOrderProductsById(result.SalesOrderId);
                                    if (list.Count() != 0)
                                    {
                                        foreach (SP_SalesOrderProduct_Consult_Result item in list)
                                        {
                                            baseAmount = (decimal)(item.BaseAmount + item.BaseTaxAmount - item.LineDiscount);
                                            taxAmount = (decimal)item.TaxAmount;
                                        }
                                    }

                                    Customer customer = new CustomerRepository(Program.customConnectionString).GetCustomerById(result.CustomerId);

                                    FrmPayment payment = new FrmPayment()
                                    {
                                        invoiceAmount = (decimal)result.Amount,
                                        customer = customer,
                                        emissionPoint = emissionPoint,
                                        taxAmount = taxAmount,
                                        baseAmount = baseAmount,
                                        loginInformation = loginInformation,
                                        internalCreditCardCode = "",
                                        invoiceXml = salesOrderXml
                                    };
                                    payment.ShowDialog();

                                    if (payment.canCloseInvoice)
                                    {
                                        if (payment.isInvoicePaymentDiscount)
                                        {
                                            salesOrderXml = payment.invoiceXml;
                                        }

                                        if (payment.paymentXml.HasElements)
                                        {
                                            try
                                            {
                                                SP_SalesOrderPayment_Insert_Result update = new SalesOrderRepository(Program.customConnectionString).UpdateSalesOrderPayment(payment.paymentXml.ToString(), result.SalesOrderId);
                                                if ((bool)update.Error)
                                                {
                                                    result.HavePaymentMethod = update.Error;
                                                    GrcSalesOrder.RefreshDataSource();
                                                }
                                                else
                                                {
                                                    functions.ShowMessage("No se pudo actualizar forma de pago", MessageType.ERROR, true, update.TextError);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                functions.ShowMessage("Ocurrio un error al guardar forma de pago", MessageType.ERROR, true, ex.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    functions.ShowMessage("No puedes asignar un metodo de pago a un pedido cancelado.", MessageType.WARNING);
                }
            }
        }

        private void BtnSaveRemissionGuide_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("Los pedidos de la guia seran convertidos en factura. ¿Desea continuar?", MessageType.CONFIRM))
            {
                BindingList<SP_RemissionGuideSalesOrder_Consult_Result> result = (BindingList<SP_RemissionGuideSalesOrder_Consult_Result>)GrcSalesOrder.DataSource;
                int resultCount = result.Count;
                int countPayed = 0;
                for (int i = 0; i < resultCount; i++)
                {
                    if ((bool)result[i].HavePaymentMethod || (bool)result[i].IsCancelled)
                    {
                        countPayed++;
                    }
                }
                if (resultCount == countPayed)
                {
                    try
                    {

                        SP_RemissionGuideInvoice_Insert_Result response = new RemissionSaleRepository(Program.customConnectionString)
                        { LoginInformation = loginInformation }
                        .FinishRemissionGuide(remission.SalesRemissionId, emissionPoint.EmissionPointId, emissionPoint.LocationId);

                        if (!(bool)response.Error)
                        {
                            functions.PrintDocument(remission.SalesRemissionId, DocumentType.REMISSIONGUIDE, false);
                            functions.ShowMessage("Facturas generadas exitosamente", MessageType.INFO);
                            isUpdated = true;
                            Close();
                        }
                        else
                        {
                            functions.ShowMessage("No se pudieron generar las facturas", MessageType.ERROR, true, response.TextError);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un error al generar las facturas", MessageType.ERROR, true, ex.Message);
                    }
                }
                else
                {
                    functions.ShowMessage("Alguno de los pedidos no se encuentra pagado.", MessageType.WARNING);
                }
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (GrvSalesOrder.FocusedRowHandle < 0)
            {
                GrvSalesOrder.FocusedRowHandle = 0;
            }

            SP_RemissionGuideSalesOrder_Consult_Result result = (SP_RemissionGuideSalesOrder_Consult_Result)GrvSalesOrder.GetRow(GrvSalesOrder.FocusedRowHandle);
            if (!(bool)!result.HavePaymentMethod)
            {
                functions.ShowMessage("La orden ya tiene asignado un metodo de pago.", MessageType.WARNING);
                return;
            }

            if (functions.ShowMessage("¿Esta seguro de cancelar la orden?", MessageType.CONFIRM))
            {
                functions.emissionPoint = emissionPoint;
                if (functions.RequestSupervisorAuth(true, CancelReasonType.SALESORDER_CANCEL))
                {
                    if (!new SalesOrderRepository(Program.customConnectionString)
                    {
                        LoginInformation = loginInformation
                    }.CancelSalesOrder(result.SalesOrderId, true))
                    {
                        functions.ShowMessage("Orden no pudo ser cancelada, valide que no este ingresada en una guia.", MessageType.WARNING);
                        return;
                    }

                    functions.ShowMessage("Orden Cancelada Exitosamente", MessageType.INFO);
                    result.IsCancelled = true;
                    GrcSalesOrder.RefreshDataSource();
                }
            }
        }

        private bool GetEmissionPointInformation()
        {

            bool response = false;
            string addressIP = loginInformation.AddressIP;

            if (addressIP != "")
            {
                try
                {
                    emissionPoint = new ClsGeneral(Program.customConnectionString).GetEmissionPointByIP(addressIP);
                }
                catch (Exception ex)
                {
                    functions.ShowMessage("Ocurrio un problema al cargar información de punto de emisión.",
                        MessageType.ERROR,
                        true,
                        ex.Message);
                }
            }
            else
            {
                functions.ShowMessage("No se proporcionó dirección IP del equipo.", MessageType.WARNING);
            }

            if (emissionPoint != null)
            {
                response = true;
                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", MessageType.WARNING);
            }

            return response;
        }

        private void FrmRemissionGuideOrderToInvoice_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (scaleBrand == ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
            }
        }

        private void GrcSalesOrder_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnCancelRemissionGuide_Click(null, null);
                    break;
                case Keys.F3:
                    BtnSaveRemissionGuide_Click(null, null);
                    break;
                case Keys.F6:
                    BtnOrderPaymentMethod_Click(null, null);
                    break;
                case Keys.F7:
                    BtnCancelOrder_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}