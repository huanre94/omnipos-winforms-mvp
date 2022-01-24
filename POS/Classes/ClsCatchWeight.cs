using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;

namespace POS.Classes
{
    public class ClsCatchWeight
    {
        private ClsFunctions functions = new ClsFunctions();
        private SerialPort serialPort;
        private string portName;
        private decimal weight;
        private ClsEnums.ScaleBrands scaleBrand;
        private bool useScanner = false;
        private bool requestWeight = false;
        private bool useCatchWeight = false;

        public AxOposScale_CCO.AxOPOSScale AxOPOSScale { get; set; }
        public ClsEnums.ScaleBrands ScaleBrand
        {
            get { return scaleBrand; }
            set
            {
                scaleBrand = value;
                if (value != ClsEnums.ScaleBrands.DATALOGIC)
                {
                    if (serialPort.IsOpen)
                    {
                        CloseScale();
                    }

                    OpenScale();
                }
            }
        }
        public bool IsOpen => serialPort != null ? serialPort.IsOpen : false;

        public SerialPort Serial { get { return serialPort; } }

        public decimal Weight { get { return weight; } }

        public System.Windows.Forms.Control ControlToShowText { get; set; }

        public string PortName { get { return portName; } set { portName = value; } }

        public ClsCatchWeight(
                                ClsEnums.ScaleBrands _scaleBrand
                                , string _portName = ""
                                , bool _useScanner = false
                                , bool _requestWeight = false
                                , bool _useCatchWeight = false
                            )
        {
            scaleBrand = _scaleBrand;
            portName = _portName;
            useScanner = _useScanner;
            requestWeight = _requestWeight;
            useCatchWeight = _useCatchWeight;
        }

        public delegate void UpdateControlText(string _text);

        private void UpdateText(string _text)
        {
            ControlToShowText.Text = _text;
            //if (useScanner)
            //{
            //    if (this.ScannerDataReceived != null)
            //    {
            //        this.ScannerDataReceived(this, new EventArgs());
            //    }
            //}
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
                    functions.ShowMessage("El puerto de la balanza esta cerrado.", ClsEnums.MessageType.WARNING);
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
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
                    functions.ShowMessage(
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

        public void OpenScale()
        {
            try
            {
                if (scaleBrand != ClsEnums.ScaleBrands.DATALOGIC)
                {
                    // SerialPortFixer.Execute(this.portName);
                    //serial = new SerialPort(this.portName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    using (serialPort = new SerialPort(portName, 38400, Parity.None, 8, StopBits.One)
                    {
                        PortName = portName,
                        RtsEnable = true
                    })
                    {
                        serialPort.Open();

                        if (serialPort.IsOpen)
                        {
                            switch (scaleBrand)
                            {
                                case ClsEnums.ScaleBrands.CAS:
                                    {
                                        serialPort.NewLine = "\n";
                                        serialPort.WriteLine("P");
                                        break;
                                    }


                                case ClsEnums.ScaleBrands.METTLER_TOLEDO:
                                    {
                                        serialPort.NewLine = "\r";
                                        break;
                                    }
                                case ClsEnums.ScaleBrands.DATALOGIC:
                                    {
                                        serialPort.NewLine = "\r";
                                        break;
                                    }
                            }

                            if (requestWeight)
                            {
                                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                            }
                        }
                    };

                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                         "Ocurrio un problema al abrir puerto serial de la balanza."
                                         , ClsEnums.MessageType.ERROR
                                         , true
                                         , ex.Message
                                     );
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    //MessageBox.Show("Data");
                    Thread.Sleep(50);
                    string data = serialPort.ReadExisting();
                    serialPort.DiscardInBuffer();

                    if (IsWeight(data))
                    {
                        weight = decimal.Parse(ReadWeight(data).ToString());
                        //ControlToShowText.BeginInvoke(new UpdateControlText(this.UpdateText), new object[] { weight.ToString("N2") });
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                         "Ocurrio un problema en la lectura desde el puerto serial de la balanza."
                                         , ClsEnums.MessageType.ERROR
                                         , true
                                         , ex.Message
                                     );
            }
        }

        public bool IsWeight(string _data)
        {
            //Regex inicio = new Regex("^11\\w");
            Regex inicio = new Regex("\r\nS0pp7\r");
            if (inicio.Match(_data).Success)
                return true;
            return false;
        }

        public string ReadWeight(string _data)
        {
            _data = _data.Substring(1, 6);
            //Regex inicio = new Regex("^11");
            //Regex inicio = new Regex("\n");
            //Regex fin = new Regex("+(\\w*\\W*|\\W*\\w*)$");
            //Regex fin = new Regex("KG\r\nS0pp7\r\u0003");

            //decimal result = decimal.Parse(fin.Replace(inicio.Replace(_data, ""), ""));
            //decimal result = decimal.Parse(inicio.Replace(_data, ""));
            decimal result = decimal.Parse(_data);
            return result.ToString();
        }

        public void CloseScale()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            //if (ControlToShowText != null)
            //    ControlToShowText.BeginInvoke(new UpdateControlText(this.UpdateText), new object[] { "" });
        }

    }
}
