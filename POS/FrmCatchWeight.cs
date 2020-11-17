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
using System.Threading;

namespace POS
{
    public partial class FrmCatchWeight : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public AxOposScale_CCO.AxOPOSScale axOposScale;
        public bool formActionResult;
        public decimal weight;
        public string productName = string.Empty;
        private ClsCatchWeight catchWeight;
        public List<DLL.GlobalParameter> globalParameters;
        string strWaitTime = string.Empty;

        public ClsEnums.ScaleBrands ScaleBrand { get; set; }
        public string PortName { get; set; }

        public FrmCatchWeight(ClsEnums.ScaleBrands _scaleBrand, string _portName)
        {
            InitializeComponent();

            ScaleBrand = _scaleBrand;
            PortName = _portName;
        }

        private void FrmCatchWeight_Load(object sender, EventArgs e)
        {
            if (ScaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
            {
                LblTitle.Text = "Coloque el Producto en la Balanza";                
            }
            else
            {
                strWaitTime = (from par in globalParameters.ToList()
                                    where par.Name == "MaxScaleWaitTime"
                                    select par.Value).FirstOrDefault();

                LblTitle.Text = string.Empty;
                BtnCatchWeight.Visible = false;

                if (functions.ShowMessage("Coloque el producto en la balanza.", ClsEnums.MessageType.CONFIRM))
                {
                    CatchWeightProduct(ScaleBrand, PortName);
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }

            LblProductName.Text = productName;
        }

        private void BtnCatchWeight_Click(object sender, EventArgs e)
        {           
            CatchWeightProduct(ScaleBrand, PortName);
        }

        private void CatchWeightProduct(ClsEnums.ScaleBrands _scaleBrand, string _portName)
        {
            weight = 0;

            try
            {
                if (_scaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                {
                    axOposScale.ReadWeight(out int request, 5000);
                    weight = request / 1000M;
                }
                else
                {
                    double waitTime = double.Parse(strWaitTime);
                    catchWeight = new ClsCatchWeight(_scaleBrand, _portName, false, true, false);
                    catchWeight.OpenScale();
                    catchWeight.Serial.WriteLine(string.Format("W", Convert.ToString("\x0D"), Convert.ToString("\x0A")));
                    
                    DateTime endTime = DateTime.Now.AddSeconds(waitTime);
                    while (DateTime.Now < endTime)
                    {
                        weight = catchWeight.Weight;
                    }                    
                }

                if (weight <= 0)
                {
                    LblTitle.Text = "El Peso es Erroneo!";
                    LblTitle.ForeColor = Color.Red;
                    functions.ShowMessage("El peso tiene que ser mayor a cero.", ClsEnums.MessageType.WARNING);                    
                }
                else
                {                    
                    LblCatchedWeight.Text = weight.ToString();                                        
                    LblTitle.Text = "Peso Capturado Correctamente";
                    LblTitle.ForeColor = Color.Green;
                }

                if (_scaleBrand != ClsEnums.ScaleBrands.DATALOGIC)
                    catchWeight.CloseScale();
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al capturar peso."
                                        , ClsEnums.MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (weight > 0)
            {
                formActionResult = true;
            }                
        }
        
    }
}