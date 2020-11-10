using POS.Classes;
using POS.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public class ClsFunctions
    {
        public List<GlobalParameter> globalParameters;
        public DLL.EmissionPoint emissionPoint;

        public AxOposScanner_CCO.AxOPOSScanner AxOPOSScanner { get; set; }
        public AxOposScale_CCO.AxOPOSScale AxOPOSScale { get; set; }        

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

        public bool RequestSupervisorAuth()
        {
            FrmSupervisorAuth auth = new FrmSupervisorAuth();
            auth.scanner = AxOPOSScanner;
            auth.emissionPoint = emissionPoint;
            auth.ShowDialog();

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
                                , ex.InnerException.Message
                            );
            }
        }
        
       public void DisableScale()
       {
           if (AxOPOSScale != null)
           {
               try
               {
                    // Close the active scanner
                    AxOPOSScale.DeviceEnabled = false;
                    AxOPOSScale.Close();
               }
               catch (Exception ex)
               {
                   ShowMessage(
                                "Ocurrio un problema al deshabilitar balanza."
                                , ClsEnums.MessageType.ERROR
                                , true
                                , ex.InnerException.Message
                            );
               }
               finally
               {
                    AxOPOSScale = null;
               }
           }
       }

        public bool ValidateCatchWeightProduct(AxOposScale_CCO.AxOPOSScale _axOposScale, decimal _qty)
        {            
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight();
            frmCatchWeight.axOposScale = _axOposScale;
            frmCatchWeight.ShowDialog();
            bool response = true;
            decimal lostWeight = 0;
            decimal catchWeight = frmCatchWeight.weight;

            string parameter = (from par in globalParameters.ToList()
                             where par.Name == "LostWeightQty"
                             select par.Value).FirstOrDefault();

            lostWeight = _qty - catchWeight;

            if (lostWeight > decimal.Parse(parameter))
            {
                response = false;
                ShowMessage("El peso es incorrecto. Vuelva a pesar el Producto.", ClsEnums.MessageType.WARNING);
            }

            return response;
        }

        public decimal CatchWeightProduct(AxOposScale_CCO.AxOPOSScale _axOposScale)
        {
            FrmCatchWeight frmCatchWeight = new FrmCatchWeight();
            frmCatchWeight.axOposScale = _axOposScale;
            frmCatchWeight.ShowDialog();

            return frmCatchWeight.weight;;
        }
    }
}
