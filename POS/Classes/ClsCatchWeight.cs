using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            get { return this.scaleBrand; }
            set
            {
                this.scaleBrand = value;
                if (value != ClsEnums.ScaleBrands.DATALOGIC)
                {
                    if (this.serialPort.IsOpen)
                    {
                        CloseScale();
                    }

                    OpenScale();
                }
            }
        }
        public bool IsOpen
        {
            get
            {
                if (serialPort != null)
                    return this.serialPort.IsOpen;
                else
                    return false;
            }
        }

        public SerialPort Serial
        { get { return serialPort; } }

        public decimal Weight
        {
            get { return this.weight; }
        }              

        public System.Windows.Forms.Control ControlToShowText
        {
            get;
            set;
        }       

        public string PortName
        {
            get { return this.portName; }
            set { this.portName = value; }
        }

        public ClsCatchWeight(
                                ClsEnums.ScaleBrands _scaleBrand 
                                , string _portName = ""
                                , bool _useScanner = false
                                , bool _requestWeight = false
                                , bool _useCatchWeight = false
                            )
        {
            this.scaleBrand = _scaleBrand;
            this.portName = _portName;            
            this.useScanner = _useScanner;
            this.requestWeight = _requestWeight;
            this.useCatchWeight = _useCatchWeight;
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
                if (this.scaleBrand != ClsEnums.ScaleBrands.DATALOGIC)
                {
                    // SerialPortFixer.Execute(this.portName);
                    //serial = new SerialPort(this.portName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialPort = new SerialPort(this.portName, 38400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialPort.PortName = this.portName;
                    serialPort.RtsEnable = true;
                    serialPort.Open();

                    if (serialPort.IsOpen)
                    {
                        if (this.scaleBrand == ClsEnums.ScaleBrands.CAS)
                        {
                            serialPort.NewLine = "\n";
                            serialPort.WriteLine("P");
                        }
                        else if (this.scaleBrand == ClsEnums.ScaleBrands.METTLER_TOLEDO)
                        {
                            serialPort.NewLine = "\r";
                        }
                        else if (this.scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                        {
                            serialPort.NewLine = "\r";
                        }

                        if (requestWeight)
                        {
                            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                        }                        
                    }
                }
            }
            catch(Exception ex)
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
            catch(Exception ex)
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
                this.serialPort.Close();

            //if (ControlToShowText != null)
            //    ControlToShowText.BeginInvoke(new UpdateControlText(this.UpdateText), new object[] { "" });
        }

    }
}
