using AxOposScale_CCO;
using POS.DLL.Enums;
using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace POS.Classes
{
    public class ClsCatchWeight
    {
        readonly ClsFunctions functions = new ClsFunctions();

        private SerialPort serialPort;
        private string portName;
        private decimal weight;
        private ScaleBrands scaleBrand;
        private bool useScanner { get; set; } = false;
        private bool requestWeight { get; set; } = false;
        private bool useCatchWeight { get; set; } = false;

        public AxOPOSScale AxOPOSScale { get; set; }
        public ScaleBrands ScaleBrand
        {
            get => scaleBrand;
            set
            {
                scaleBrand = value;
                if (value != ScaleBrands.DATALOGIC)
                {
                    if (serialPort.IsOpen)
                    {
                        CloseScale();
                    }

                    OpenScale();
                }
            }
        }
        //public bool IsOpen => serialPort != null && serialPort.IsOpen;
        public SerialPort Serial { get { return serialPort; } }
        public decimal Weight { get { return weight; } }
        public Control ControlToShowText { get; set; }

        public string PortName { get { return portName; } set { portName = value; } }

        public ClsCatchWeight(ScaleBrands _scaleBrand,
                              string _portName = "",
                              bool _useScanner = false,
                              bool _requestWeight = false,
                              bool _useCatchWeight = false)
        {
            scaleBrand = _scaleBrand;
            portName = _portName;
            useScanner = _useScanner;
            requestWeight = _requestWeight;
            useCatchWeight = _useCatchWeight;
        }

        public delegate void UpdateControlText(string _text);

        private void UpdateText(string _text) => ControlToShowText.Text = _text;



        private bool IsWeight(string _data) => new Regex("\r\nS0pp7\r").Match(_data).Success;

        private string ReadWeight(string _data) => decimal.Parse(_data.Substring(1, 6)).ToString();

        public void OpenScale()
        {
            try
            {
                if (scaleBrand != ScaleBrands.DATALOGIC)
                {
                    // SerialPortFixer.Execute(this.portName);
                    //serial = new SerialPort(this.portName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialPort = new SerialPort(portName, 38400, Parity.None, 8, StopBits.One)
                    {
                        PortName = portName,
                        RtsEnable = true
                    };
                    serialPort.Open();

                    if (serialPort.IsOpen)
                    {
                        switch (scaleBrand)
                        {
                            case ScaleBrands.CAS:
                                {
                                    serialPort.NewLine = "\n";
                                    serialPort.WriteLine("P");
                                    break;
                                }

                            case ScaleBrands.METTLER_TOLEDO:
                            case ScaleBrands.DATALOGIC:
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
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al abrir puerto serial de la balanza.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
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
                    functions.ShowMessage("El puerto de la balanza esta cerrado.", MessageType.WARNING);
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
                functions.ShowMessage("Ocurrio un problema al habilitar balanza.",
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
                    functions.ShowMessage("Ocurrio un problema al deshabilitar balanza.",
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

        public void CloseScale()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
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
                        Console.WriteLine($"Puerto abierto: { serialPort.IsOpen}  data: {data}");
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema en la lectura desde el puerto serial de la balanza.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }
    }
}
