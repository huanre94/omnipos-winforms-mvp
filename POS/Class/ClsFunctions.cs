using AxOposScale_CCO;
using AxOposScanner_CCO;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Vip.Printer;
using Vip.Printer.Enums;
// IG001 Israel Gonzalez 2021-01-30: Validate catched weight
namespace POS
{
    public class ClsFunctions
    {
        public AxOPOSScanner AxOPOSScanner { get; set; }
        public AxOPOSScale AxOPOSScale { get; set; }
        public IEnumerable<GlobalParameter> globalParameters;
        public EmissionPoint emissionPoint;
        public string PrinterName { get; set; }
        public int motiveId;
        public string supervisorAuthorization;
        public int reasonType;

        /// <summary>
        /// Common message box to show information or warnings.
        /// </summary>
        /// <param name="_messageText"></param>
        /// <param name="_messageType"></param>
        /// <param name="_showMessageDetail"></param>
        /// <param name="_messageTextDetail"></param>
        /// <returns></returns>
        public bool ShowMessage(string _messageText,
                                MessageType _messageType = MessageType.INFO,
                                bool _showMessageDetail = false,
                                string _messageTextDetail = "")
        {
            FrmMessage frmMessage = new FrmMessage(_messageText, _messageType, _showMessageDetail, _messageTextDetail);
            frmMessage.ShowDialog();

            return frmMessage.GetMessageResponse();
        }

        public bool RequestSupervisorAuth(bool requireMotive = false, int reasonType = 0)
        {
            FrmSupervisorAuth auth = new FrmSupervisorAuth(AxOPOSScanner, emissionPoint, requireMotive, reasonType);
            auth.ShowDialog();

            if (auth.formActionResult)
            {
                this.reasonType = auth.ReasonType;
                this.motiveId = auth.motiveId;
                this.supervisorAuthorization = auth.SupervisorAuthorization;
            }

            return auth.formActionResult;

        }

        public void EnableScanner(string _scannerName)
        {
            try
            {
                AxOPOSScanner.BeginInit();
                int isOpen = AxOPOSScanner.Open(_scannerName);

                if (isOpen != 0)
                {
                    ShowMessage("El puerto del scanner esta cerrado.", MessageType.WARNING);
                    return;
                }

                AxOPOSScanner.ClaimDevice(1000);

                if (AxOPOSScanner.Claimed)
                {
                    AxOPOSScanner.DeviceEnabled = true;
                    AxOPOSScanner.DataEventEnabled = true;
                    AxOPOSScanner.PowerNotify = 1; //(OPOS_PN_ENABLED);
                    AxOPOSScanner.DecodeData = true;
                }

            }
            catch (Exception ex)
            {
                ShowMessage("Ocurrio un problema al habilitar scanner.",
                            MessageType.ERROR,
                            true,
                            ex.Message);
            }
        }

        public void DisableScanner()
        {
            if (AxOPOSScanner != null)
            {
                try
                {
                    // Close the active scanner                    
                    AxOPOSScanner.DeviceEnabled = false;
                    AxOPOSScanner.Close();
                }
                catch (Exception ex)
                {
                    ShowMessage("Ocurrio un problema al deshabilitar scanner.",
                                MessageType.ERROR,
                                true,
                                ex.Message);
                }
                finally
                {
                    AxOPOSScanner = null;
                }
            }
        }

        public void EnableScale(string _scaleName)
        {
            try
            {
                AxOPOSScale.BeginInit();
                int isOpen = AxOPOSScale.Open(_scaleName);

                if (isOpen != 0)
                {
                    ShowMessage("El puerto de la balanza esta cerrado.", MessageType.WARNING);
                    return;
                }

                AxOPOSScale.ClaimDevice(1000);

                if (AxOPOSScale.Claimed)
                {
                    AxOPOSScale.DeviceEnabled = true;
                    AxOPOSScale.PowerNotify = 1; //(OPOS_PN_ENABLED);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Ocurrio un problema al habilitar balanza.",
                            MessageType.ERROR,
                            true,
                            ex.Message);
            }
        }

        public void DisableScale()
        {
            if (AxOPOSScale != null)
            {
                try
                {
                    AxOPOSScale.DeviceEnabled = false;
                    AxOPOSScale.Close();
                }
                catch (Exception ex)
                {
                    ShowMessage("Ocurrio un problema al deshabilitar balanza.",
                                MessageType.ERROR,
                                true,
                                ex.Message);
                }
                finally
                {
                    AxOPOSScale = null;
                }
            }
        }

        public bool ValidateCatchWeightProduct(AxOPOSScale _axOposScale,
                                               decimal _qty,
                                               SP_Product_Consult_Result _product,
                                               ScaleBrands _scaleBrand,
                                               string _portName = "",
                                               bool isTestMode = false)
        {
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight(_scaleBrand, _portName, _axOposScale, _product);
            frmCatchWeight.ShowDialog();

            if (!frmCatchWeight.GetActionResult())
            {
                ShowMessage("No se ha realizado captura de peso.", MessageType.WARNING);
                return false;
            }

            decimal catchWeight = isTestMode ? _qty : frmCatchWeight.GetWeight();

            //Begin(IG001)
            if (catchWeight == 0)
            {
                ShowMessage("Por favor volver a intentarlo, existio un problema al validar peso.", MessageType.WARNING);
                return false;
            }
            //End(IG001)

            decimal minimumLostWeightQty = decimal.Parse(new ClsGeneral(Program.customConnectionString).GetParameterByName("LostWeightQty").Value);

            if (Math.Abs(_qty - catchWeight) > minimumLostWeightQty)
            {
                ShowMessage($"La diferencia de peso sobrepasa el minimo de merma ({minimumLostWeightQty}). Vuelva a pesar el Producto.", MessageType.WARNING);
                return false;
            }

            //string entere = _product.BarcodeBefore.Substring(7, 3);
            //string decimals = _product.BarcodeBefore.Substring(10, 3);
            //decimal newAmount = decimal.Parse($"{entere}.{decimals}");

            //decimal ticketBaseValue = newAmount / catchWeight;
            //decimal priceDiff = Math.Abs((decimal)_product.Price - Math.Round(ticketBaseValue, 2, MidpointRounding.AwayFromZero));

            ////VALIDACION DE PRECIO BASE VS PRECIO TICKET
            //if (priceDiff > minimumLostWeightQty)
            //{
            //    ShowMessage("Existe una diferencia de precio en articulo en balanza. Por favor validar valor en balanza.",
            //                MessageType.WARNING,
            //                true,
            //                $"El valor descuadrado por: {priceDiff} {Environment.NewLine} Valor calculado: ${Math.Round(ticketBaseValue, 2, MidpointRounding.AwayFromZero)} {Environment.NewLine} Valor Sistema: ${_product.Price}");
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// Show catchweight form
        /// </summary>
        /// <param name="_axOposScale"></param>
        /// <param name="_productName"></param>
        /// <param name="_scaleBrand"></param>
        /// <param name="_portName"></param>
        /// <returns></returns>
        public decimal CatchWeightProduct(AxOPOSScale _axOposScale,
                                          SP_Product_Consult_Result _product,
                                          ScaleBrands _scaleBrand,
                                          string _portName = "")
        {
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight(_scaleBrand, _portName, _axOposScale, _product);
            frmCatchWeight.ShowDialog();


            if (!frmCatchWeight.GetActionResult())
            {
                ShowMessage("No se ha realizado captura de peso.", MessageType.WARNING);
                return 0;
            }

            return frmCatchWeight.GetWeight();
        }

        public string GetPublishVersion()
        {
            Version ver = System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed ? System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion : Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{4}, Version: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);

        }

        public bool ProcessDocumentToPrint(string TextDocument)
        {
            try
            {
                Printer printer = new Printer(PrinterName, GetTypePrinter(PrinterName));
                printer.WriteLine(TextDocument);
                printer.PrintDocument();
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("Ocurrió un problema al Imprimir el Documento.",
                            MessageType.ERROR,
                            true,
                            ex.Message);

                return false;
            }
        }

        private PrinterType GetTypePrinter(string PrinterName)
        {
            return PrinterName == "LR2000" ? PrinterType.Bematech : PrinterType.Epson;
        }

        public bool PrintDocument(long _documentId, DocumentType _documentType, bool _openCashier = false)
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans(Program.customConnectionString);
            ClsClosingTrans clsClosingTrans = new ClsClosingTrans(Program.customConnectionString);
            ClsSalesOrderTrans clsSalesOrderTrans = new ClsSalesOrderTrans(Program.customConnectionString);

            IEnumerable<SP_InvoiceTicket_Consult_Result> invoiceTicket;
            IEnumerable<SP_ClosingCashierTicket_Consult_Result> closingCashierTicket;
            IEnumerable<SP_SalesOrderTicket_Consult_Result> salesOrderTicket;
            IEnumerable<string> remissionGuideTicket;
            bool response = false;
            string bodyText = "";

            try
            {
                switch (_documentType)
                {
                    case DocumentType.INVOICE:
                        invoiceTicket = clsInvoiceTrans.GetInvoiceTicket(_documentId, _openCashier);

                        if (invoiceTicket?.Count() > 0)
                        {
                            foreach (SP_InvoiceTicket_Consult_Result line in invoiceTicket)
                            {
                                bodyText += line.BodyText + Environment.NewLine;
                            }

                        }
                        break;
                    case DocumentType.CLOSINGCASHIER:
                        closingCashierTicket = clsClosingTrans.GetClosingTicket(_documentId);

                        if (closingCashierTicket?.Count() > 0)
                        {
                            foreach (SP_ClosingCashierTicket_Consult_Result line in closingCashierTicket)
                            {
                                bodyText += line.BodyText + Environment.NewLine;
                            }
                        }

                        break;
                    case DocumentType.SALESORDER:
                        salesOrderTicket = clsSalesOrderTrans.GetSalesOrderTicket(_documentId, (short)emissionPoint.EmissionPointId, false);

                        if (salesOrderTicket?.Count() > 0)
                        {
                            foreach (SP_SalesOrderTicket_Consult_Result line in salesOrderTicket)
                            {
                                bodyText += line.BodyText + Environment.NewLine;
                            }
                        }

                        break;
                    case DocumentType.REMISSIONGUIDE:
                        remissionGuideTicket = clsSalesOrderTrans.GetRemissionGuideTicket(_documentId);

                        if (remissionGuideTicket?.Count() > 0)
                        {
                            foreach (string line in remissionGuideTicket)
                            {
                                bodyText += line + Environment.NewLine;
                            }
                        }

                        break;
                    default:
                        return response;
                }

                response = ProcessDocumentToPrint(bodyText);
            }
            catch (Exception ex)
            {
                ShowMessage($"Ha ocurrido un problema al imprimir {_documentType}",
                            MessageType.ERROR,
                            true,
                            ex.Message);
            }

            return response;
        }
    }
}
