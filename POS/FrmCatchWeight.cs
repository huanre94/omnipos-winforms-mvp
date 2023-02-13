
using AxOposScale_CCO;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCatchWeight : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public AxOPOSScale axOposScale;
        public bool formActionResult;
        decimal weight;
        public string productName = string.Empty;
        public IEnumerable<GlobalParameter> globalParameters;
        private ClsCatchWeight catchWeight;
        private string strWaitTime = string.Empty;

        ScaleBrands ScaleBrand { get; set; }
        string PortName { get; set; }

        public FrmCatchWeight(ScaleBrands _scaleBrand, string _portName)
        {
            InitializeComponent();
            ScaleBrand = _scaleBrand;
            PortName = _portName;
        }

        public decimal GetWeight() => weight;

        private void FrmCatchWeight_Load(object sender, EventArgs e)
        {
            try
            {
                switch (ScaleBrand)
                {
                    case ScaleBrands.DATALOGIC:
                        LblTitle.Text = "Coloque el Producto en la Balanza";
                        break;
                    default:
                        strWaitTime = new ClsGeneral(Program.customConnectionString).GetParameterByName("MaxScaleWaitTime").Value;

                        LblTitle.Text = string.Empty;
                        BtnCatchWeight.Visible = false;

                        if (ScaleBrand == ScaleBrands.NONE || PortName == string.Empty)
                        {
                            functions.ShowMessage("No se ha especificado la marca o puerto serial de la balanza.", MessageType.WARNING);
                            DialogResult = DialogResult.Cancel;
                            return;
                        }

                        catchWeight = new ClsCatchWeight(ScaleBrand, PortName, false, true, false);
                        catchWeight.OpenScale();

                        if (functions.ShowMessage("Coloque el producto en la balanza.", MessageType.CONFIRM))
                        {
                            CatchWeightProduct(ScaleBrand, PortName);
                        }
                        else
                        {
                            if (ScaleBrand != ScaleBrands.DATALOGIC)
                                catchWeight.CloseScale();

                            DialogResult = DialogResult.Cancel;
                        }

                        break;
                }

                LblProductName.Text = productName;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ha ocurrido un error al inicializar la balanza.", MessageType.WARNING, true, ex.InnerException.Message);
            }
        }

        private void BtnCatchWeight_Click(object sender, EventArgs e)
        {
            CatchWeightProduct(ScaleBrand, PortName);
            BtnAccept.Focus();
        }

        private void CatchWeightProduct(ScaleBrands _scaleBrand, string _portName)
        {
            weight = 0;

            try
            {
                switch (_scaleBrand)
                {
                    case ScaleBrands.DATALOGIC:
                        axOposScale.ReadWeight(out int request, 5000);
                        weight = request / 1000M;

                        if (weight <= 0)
                        {
                            LblTitle.Text = "Peso no Capturado";
                            LblTitle.ForeColor = Color.Red;
                            functions.ShowMessage("El peso no ha sido capturado. Por favor intente nuevamente.", MessageType.WARNING);
                            return;
                        }

                        break;

                    default:
                        double waitTime = double.Parse(strWaitTime);
                        //catchWeight = new ClsCatchWeight(_scaleBrand, _portName, false, true, false);
                        //catchWeight.OpenScale();
                        catchWeight.Serial.WriteLine(string.Format("W", Convert.ToString("\x0D"), Convert.ToString("\x0A")));

                        DateTime endTime = DateTime.Now.AddSeconds(waitTime);
                        while (DateTime.Now < endTime && catchWeight.Weight == 0)
                        {
                            weight = catchWeight.Weight;
                        }

                        if (catchWeight.Weight <= 0)
                        {
                            LblTitle.Text = "Peso no Capturado";
                            LblTitle.ForeColor = Color.Red;

                            functions.ShowMessage("El peso no ha sido capturado. Por favor intente nuevamente", MessageType.CONFIRM);

                            return;
                        }

                        // if (catchWeight.Weight > 0)

                        LblCatchedWeight.Text = catchWeight.Weight.ToString();
                        LblTitle.Text = "Peso Capturado Correctamente";
                        LblTitle.ForeColor = Color.Green;


                        catchWeight.CloseScale();

                        break;
                }

                LblCatchedWeight.Text = weight.ToString();
                LblTitle.Text = "Peso Capturado Correctamente";
                LblTitle.ForeColor = Color.Green;

            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al capturar peso.",
                                      MessageType.ERROR,
                                      true,
                                      ex.Message);
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            switch (ScaleBrand)
            {
                case ScaleBrands.DATALOGIC:
                    if (weight > 0)
                        formActionResult = true;
                    break;
                default:
                    if (catchWeight.Weight > 0)
                    {
                        weight = catchWeight.Weight;
                        LblCatchedWeight.Text = $"{weight}";
                        LblTitle.Text = "Peso Capturado Correctamente";
                        LblTitle.ForeColor = Color.Green;
                        formActionResult = true;
                    }
                    break;
            }
        }

    }
}