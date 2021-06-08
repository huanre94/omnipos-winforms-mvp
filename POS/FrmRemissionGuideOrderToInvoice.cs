using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
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
        ClsEnums.ScaleBrands scaleBrand;
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
                        scaleBrand = (ClsEnums.ScaleBrands)Enum.Parse(typeof(ClsEnums.ScaleBrands), emissionPoint.ScaleBrand, true);

                        if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                        {
                            functions.AxOPOSScanner = AxOPOSScanner;
                            //functions.EnableScanner(emissionPoint.ScanBarcodeName);
                        }
                        else
                        {
                            string[] portNames = SerialPort.GetPortNames();
                            portName = string.Empty;

                            foreach (var item in portNames)
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
                functions.ShowMessage("Ocurrio un error al cargar Guia de Remision.", ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
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
                List<SP_RemissionGuideSalesOrder_Consult_Result> list = new ClsSalesOrder().GetSalesOrderByRemissionGuideNumber(remission.SalesRemissionId);
                BindingList<SP_RemissionGuideSalesOrder_Consult_Result> bind = new BindingList<SP_RemissionGuideSalesOrder_Consult_Result>(list);
                GrcSalesOrder.DataSource = bind;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("No se pudo cargar las ordenes de venta de esta guia", Classes.ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
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
            if (functions.ShowMessage("Se procedera a anular la guia ¿Desea continuar?", ClsEnums.MessageType.CONFIRM))
            {
                functions.emissionPoint = emissionPoint;
                bool isApproved = functions.RequestSupervisorAuth(true, (int)ClsEnums.CancelReasonType.REMISSIONGUIDE_CANCEL);
                if (isApproved)
                {
                    ClsSalesOrderTrans clsSalesOrder = new ClsSalesOrderTrans();
                    clsSalesOrder.loginInformation = loginInformation;
                    SP_RemissionGuide_Cancel_Result result = clsSalesOrder.CancelRemissionGuide(remission.SalesRemissionId);
                    if (!(bool)result.Error)
                    {
                        functions.ShowMessage("Guia de remision anulada exitosamente", ClsEnums.MessageType.INFO);
                        isUpdated = true;
                        Close();
                    }
                    else
                    {
                        functions.ShowMessage("No se pudo anular guia de remision", ClsEnums.MessageType.ERROR, true, result.TextError);
                    }
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
                functions.ShowMessage("El valor a pagar debe ser mayor a 0", ClsEnums.MessageType.WARNING);
            }
            else
            {
                if (!(bool)result.IsCancelled)
                {
                    if (!(bool)result.HavePaymentMethod)
                    {
                        decimal baseAmount = 0;
                        decimal taxAmount = 0;

                        var list = new ClsSalesOrder().GetSalesOrderProductsById(result.SalesOrderId);
                        if (list.Count != 0)
                        {
                            foreach (var item in list)
                            {
                                baseAmount = (decimal)(item.BaseAmount + item.BaseTaxAmount - item.LineDiscount);
                                taxAmount = (decimal)item.TaxAmount;
                            }
                        }

                        Customer customer = new ClsCustomer().GetCustomerById(result.CustomerId);

                        FrmPayment payment = new FrmPayment
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
                                    SP_SalesOrderPayment_Insert_Result update = new ClsSalesOrder().UpdateSalesOrderPayment(payment.paymentXml.ToString(), result.SalesOrderId);
                                    if ((bool)update.Error)
                                    {
                                        result.HavePaymentMethod = update.Error;
                                        GrcSalesOrder.RefreshDataSource();
                                    }
                                    else
                                    {
                                        functions.ShowMessage("No se pudo actualizar forma de pago", ClsEnums.MessageType.ERROR, true, update.TextError);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    functions.ShowMessage("Ocurrio un error al guardar forma de pago", ClsEnums.MessageType.ERROR, true, ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (functions.ShowMessage("Pedido ya cuenta con un metodo de pago. Desea reemplazar el metodo de pago actual?", ClsEnums.MessageType.CONFIRM))
                        {
                            bool isWebPayment = false;
                            try
                            {
                                var webPayment = (from sp in new POSEntities().SalesOrderPayment
                                                  where sp.SalesOrderId == result.SalesOrderId
                                                  && sp.PaymModeId == (int)ClsEnums.PaymModeEnum.PAGOS_WEB
                                                  select sp).ToList().Count();
                                isWebPayment = webPayment > 0;
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            if (isWebPayment)
                            {
                                functions.ShowMessage("No se puede modificar un pedido con pago web", ClsEnums.MessageType.ERROR);
                                return;
                            }

                            functions.emissionPoint = emissionPoint;
                            bool isApproved = functions.RequestSupervisorAuth();
                            if (isApproved)
                            {
                                {
                                    decimal baseAmount = 0;
                                    decimal taxAmount = 0;

                                    var list = new ClsSalesOrder().GetSalesOrderProductsById(result.SalesOrderId);
                                    if (list.Count != 0)
                                    {
                                        foreach (var item in list)
                                        {
                                            baseAmount = (decimal)(item.BaseAmount + item.BaseTaxAmount - item.LineDiscount);
                                            taxAmount = (decimal)item.TaxAmount;
                                        }
                                    }

                                    Customer customer = new ClsCustomer().GetCustomerById(result.CustomerId);

                                    FrmPayment payment = new FrmPayment
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
                                                SP_SalesOrderPayment_Insert_Result update = new ClsSalesOrder().UpdateSalesOrderPayment(payment.paymentXml.ToString(), result.SalesOrderId);
                                                if ((bool)update.Error)
                                                {
                                                    result.HavePaymentMethod = update.Error;
                                                    GrcSalesOrder.RefreshDataSource();
                                                }
                                                else
                                                {
                                                    functions.ShowMessage("No se pudo actualizar forma de pago", ClsEnums.MessageType.ERROR, true, update.TextError);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                functions.ShowMessage("Ocurrio un error al guardar forma de pago", ClsEnums.MessageType.ERROR, true, ex.Message);
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
                    functions.ShowMessage("No puedes asignar un metodo de pago a un pedido cancelado.", ClsEnums.MessageType.WARNING);
                }
            }
        }

        private void BtnSaveRemissionGuide_Click(object sender, EventArgs e)
        {
            if (functions.ShowMessage("Los pedidos de la guia seran convertidos en factura. ¿Desea continuar?", ClsEnums.MessageType.CONFIRM))
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
                        ClsSalesOrderTrans sales = new ClsSalesOrderTrans();
                        sales.loginInformation = loginInformation;

                        SP_RemissionGuideInvoice_Insert_Result response = sales.FinishRemissionGuide(remission.SalesRemissionId, emissionPoint.EmissionPointId, emissionPoint.LocationId);

                        if (!(bool)response.Error)
                        {
                            functions.PrintDocument(remission.SalesRemissionId, ClsEnums.DocumentType.REMISSIONGUIDE);
                            functions.ShowMessage("Facturas generadas exitosamente", ClsEnums.MessageType.INFO);
                            isUpdated = true;
                            Close();
                        }
                        else
                        {
                            functions.ShowMessage("No se pudieron generar las facturas", ClsEnums.MessageType.ERROR, true, response.TextError);
                        }
                    }
                    catch (Exception ex)
                    {
                        functions.ShowMessage("Ocurrio un error al generar las facturas", ClsEnums.MessageType.ERROR, true, ex.Message);
                    }
                }
                else
                {
                    functions.ShowMessage("Alguno de los pedidos no se encuentra pagado.", ClsEnums.MessageType.WARNING);
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
            if ((bool)!result.HavePaymentMethod)
            {
                ClsSalesOrderTrans sales = new ClsSalesOrderTrans();
                if (functions.ShowMessage("¿Esta seguro de cancelar la orden?", ClsEnums.MessageType.CONFIRM))
                {
                    functions.emissionPoint = emissionPoint;
                    if (functions.RequestSupervisorAuth(true, (int)ClsEnums.CancelReasonType.SALESORDER_CANCEL))
                    {
                        sales.loginInformation = loginInformation;
                        if (sales.CancelSalesOrder(result.SalesOrderId, true))
                        {
                            functions.ShowMessage("Orden Cancelada Exitosamente", ClsEnums.MessageType.INFO);
                            result.IsCancelled = true;
                            GrcSalesOrder.RefreshDataSource();
                        }
                        else
                        {
                            functions.ShowMessage("Orden no pudo ser cancelada, valide que no este ingresada en una guia.", ClsEnums.MessageType.WARNING);
                        }
                    }
                }
            }
            else
            {
                functions.ShowMessage("La orden ya tiene asignado un metodo de pago.", ClsEnums.MessageType.WARNING);
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

            if (emissionPoint != null)
            {
                response = true;
                functions.PrinterName = emissionPoint.PrinterName;
            }
            else
            {
                functions.ShowMessage("No existe punto de emisión asignado a este equipo.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        private void FrmRemissionGuideOrderToInvoice_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
            {
                functions.DisableScanner();
            }
        }
    }
}