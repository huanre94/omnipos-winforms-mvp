using POS.Classes;
using POS.DLL;
using POS.DLL.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Vip.Printer;
using Vip.Printer.Enums;

namespace POS
{
    public class ClsFunctions
    {
        public AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner { get; set; }
        public AxOposScale_CCO.AxOPOSScale AxOPOSScale { get; set; }

        public List<GlobalParameter> globalParameters;
        public DLL.EmissionPoint emissionPoint;
        public string PrinterName { get; set; }
        public int motiveId;
        public string supervisorAuthorization;
        public int reasonType;

        public bool ShowMessage(
                                string _messageText
                                , ClsEnums.MessageType _messageType = ClsEnums.MessageType.INFO
                                , bool _showMessageDetail = false
                                , string _messageTextDetail = ""
                                )
        {
            FrmMessage frmMessage = new FrmMessage
            {
                messagetype = _messageType,
                messageText = _messageText,
                showMessageDetail = _showMessageDetail,
                messageTextDetail = _messageTextDetail
            };
            frmMessage.ShowDialog();

            return frmMessage.messageResponse;
        }

        public bool RequestSupervisorAuth(bool requireMotive = false, int reasonType = 1)
        {
            FrmSupervisorAuth auth = new FrmSupervisorAuth();
            auth.scanner = AxOPOSScanner;
            auth.emissionPoint = emissionPoint;
            auth.requireMotive = requireMotive;
            auth.reasonType = reasonType;
            auth.ShowDialog();



            if (auth.formActionResult)
            {
                this.motiveId = auth.motiveId;
                this.reasonType = auth.reasonType;
                this.supervisorAuthorization = auth.supervisorAuthorization;
            }

            return auth.formActionResult;
        }

        public void EnableScanner(string _scannerName)
        {            
            try
            {
                AxOPOSScanner.BeginInit();
                int isOpen = AxOPOSScanner.Open(_scannerName);

                if (isOpen == 0)
                {
                    AxOPOSScanner.ClaimDevice(1000);

                    if (AxOPOSScanner.Claimed)
                    {
                        AxOPOSScanner.DeviceEnabled = true;
                        AxOPOSScanner.DataEventEnabled = true;
                        AxOPOSScanner.PowerNotify = 1; //(OPOS_PN_ENABLED);
                        AxOPOSScanner.DecodeData = true;
                    }
                }
                else
                {
                    ShowMessage("El puerto del scanner esta cerrado.", ClsEnums.MessageType.WARNING);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(
                                "Ocurrio un problema al habilitar scanner."
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.Message
                            );
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
                    ShowMessage(
                                    "Ocurrio un problema al deshabilitar scanner."
                                    , ClsEnums.MessageType.ERROR
                                    , true
                                    , ex.Message
                                );
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

                if (isOpen == 0)
                {
                    AxOPOSScale.ClaimDevice(1000);

                    if (AxOPOSScale.Claimed)
                    {
                        AxOPOSScale.DeviceEnabled = true;
                        AxOPOSScale.PowerNotify = 1; //(OPOS_PN_ENABLED);
                    }
                }
                else
                {
                    ShowMessage("El puerto de la balanza esta cerrado.", ClsEnums.MessageType.WARNING);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(
                                "Ocurrio un problema al habilitar balanza."
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.Message
                            );
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
                   ShowMessage(
                                "Ocurrio un problema al deshabilitar balanza."
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.Message
                            );
               }
               finally
               {
                    AxOPOSScale = null;
               }
           }
       }

        public bool ValidateCatchWeightProduct(
                                                AxOposScale_CCO.AxOPOSScale _axOposScale
                                                , decimal _qty
                                                , string _productName
                                                , ClsEnums.ScaleBrands _scaleBrand
                                                , string _portName = ""
                                                )
        {
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight(_scaleBrand, _portName);
            frmCatchWeight.axOposScale = _axOposScale;
            frmCatchWeight.productName = _productName;
            frmCatchWeight.globalParameters = globalParameters;
            frmCatchWeight.ShowDialog();
            bool response = true;
            decimal lostWeight = 0;
            decimal catchWeight = 0;
            string parameter = String.Empty;

            catchWeight = frmCatchWeight.weight;
            parameter = (from par in globalParameters.ToList()
                         where par.Name == "LostWeightQty"
                         select par.Value).FirstOrDefault();

            lostWeight = _qty - catchWeight;
            lostWeight = Math.Abs(lostWeight);

            if (lostWeight > decimal.Parse(parameter))
            {
                response = false;
                ShowMessage("El peso es incorrecto. Vuelva a pesar el Producto.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        public decimal CatchWeightProduct(
                                            AxOposScale_CCO.AxOPOSScale _axOposScale
                                            , string _productName
                                            , ClsEnums.ScaleBrands _scaleBrand
                                            , string _portName = ""
                                        )
        {
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight(_scaleBrand, _portName);
            frmCatchWeight.axOposScale = _axOposScale;
            frmCatchWeight.productName = _productName;
            frmCatchWeight.globalParameters = globalParameters;
            frmCatchWeight.ShowDialog();

            return frmCatchWeight.weight;;
        }

        public bool ProcessDocumentToPrint(string TextDocument)
        {
            bool response = false;

            try
            {
                var printer = new Printer(PrinterName, GetTypePrinter(PrinterName));

                printer.WriteLine(TextDocument);
                printer.PrintDocument();
                response = true;
            }
            catch (Exception ex)
            {
                ShowMessage(
                                "Ocurrió un problema al Imprimir el Documento."
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.Message
                            );
            }

            return response;
        }

        private PrinterType GetTypePrinter(String PrinterName)
        {
            return PrinterName == "LR2000" ? PrinterType.Bematech : PrinterType.Epson;
        }

        public string GetPublishVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return string.Format("{4}, Version: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
            }
            else
            {
                var ver = Assembly.GetExecutingAssembly().GetName().Version;
                return string.Format("{4}, Version: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
            }
        }

        public bool PrintDocument(
                                    long _documentId
                                    , ClsEnums.DocumentType _documentType
                                    , bool _openCashier = false
                                )
        {
            ClsInvoiceTrans clsInvoiceTrans = new ClsInvoiceTrans();
            ClsClosingTrans clsClosingTrans = new ClsClosingTrans();
            List<SP_InvoiceTicket_Consult_Result> invoiceTicket;
            List<SP_ClosingCashierTicket_Consult_Result> closingCashierTicket;
            bool response = false;
            string bodyText = "";

            try
            {
                switch (_documentType)
                {
                    case ClsEnums.DocumentType.INVOICE:
                        invoiceTicket = clsInvoiceTrans.GetInvoiceTicket(_documentId, _openCashier);

                        if (invoiceTicket != null)
                        {
                            if (invoiceTicket.Count > 0)
                            {
                                foreach (var line in invoiceTicket)
                                {
                                    bodyText += line.BodyText + Environment.NewLine;
                                }
                            }
                        }
                        break;
                    case ClsEnums.DocumentType.CLOSINGCASHIER:
                        closingCashierTicket = clsClosingTrans.GetClosingTicket(_documentId);

                        if (closingCashierTicket != null)
                        {
                            if (closingCashierTicket.Count > 0)
                            {
                                foreach (var line in closingCashierTicket)
                                {
                                    bodyText += line.BodyText + Environment.NewLine;
                                }
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
                ShowMessage(
                                "Ha ocurrido un problema al imprimir " + _documentType.ToString()
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.Message
                            );
            }

            return response;
        }
    }
}
