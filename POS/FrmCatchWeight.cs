
using AxOposScale_CCO;
using POS.Classes;
using POS.DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCatchWeight : DevExpress.XtraEditors.XtraForm
    {
         ClsFunctions functions = new ClsFunctions();
        public AxOPOSScale axOposScale;
        public bool formActionResult;
        public decimal weight;
        public string productName = string.Empty;
        public List<GlobalParameter> globalParameters;
        private ClsCatchWeight catchWeight;
        private string strWaitTime = string.Empty;

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
            try
            {
                if (ScaleBrand == ClsEnums.ScaleBrands.DATALOGIC)
                {
                    LblTitle.Text = "Coloque el Producto en la Balanza";
                }
                else
                {
                    strWaitTime =
                        new POSEntities()
                        .GlobalParameter
                        .Where(par => par.Name == "MaxScaleWaitTime")
                        .Select(par => par.Value)
                        .FirstOrDefault();

                    LblTitle.Text = string.Empty;
                    BtnCatchWeight.Visible = false;

                    if (ScaleBrand == ClsEnums.ScaleBrands.NONE || PortName == string.Empty)
                    {
                        functions.ShowMessage("No se ha especificado la marca o puerto serial de la balanza.", ClsEnums.MessageType.WARNING);
                        DialogResult = DialogResult.Cancel;
                        return;
                    }

                    catchWeight = new ClsCatchWeight(ScaleBrand, PortName, false, true, false);
                    catchWeight.OpenScale();

                    if (functions.ShowMessage("Coloque el producto en la balanza.", ClsEnums.MessageType.CONFIRM))
                    {
                     CatchWeightProduct(ScaleBrand, PortName);
                    }
                    else
                    {
                        if (ScaleBrand != ClsEnums.ScaleBrands.DATALOGIC)
                            catchWeight.CloseScale();

                        DialogResult = DialogResult.Cancel;
                    }

                }

                LblProductName.Text = productName;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ha ocurrido un error al inicializar la balanza.", ClsEnums.MessageType.WARNING, true, ex.InnerException.Message);
            }
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
                switch (_scaleBrand)
                {
                    case ClsEnums.ScaleBrands.DATALOGIC:
                        axOposScale.ReadWeight(out int request, 5000);
                        weight = request / 1000M;

                        if (weight <= 0)
                        {
                            LblTitle.Text = "Peso no Capturado";
                            LblTitle.ForeColor = Color.Red;
                            functions.ShowMessage("El peso no ha sido capturado. Por favor intente nuevamente", ClsEnums.MessageType.WARNING);
                        }
                        else
                        {
                            LblCatchedWeight.Text = weight.ToString();
                            LblTitle.Text = "Peso Capturado Correctamente";
                            LblTitle.ForeColor = Color.Green;
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

                            if (functions.ShowMessage("El peso no ha sido capturado. Por favor intente nuevamente", ClsEnums.MessageType.CONFIRM))
                            {
                                if (catchWeight.Weight > 0)
                                {
                                    LblCatchedWeight.Text = catchWeight.Weight.ToString();
                                    LblTitle.Text = "Peso Capturado Correctamente";
                                    LblTitle.ForeColor = Color.Green;
                                }
                            }
                        }
                        else
                        {
                            LblCatchedWeight.Text = catchWeight.Weight.ToString();
                            LblTitle.Text = "Peso Capturado Correctamente";
                            LblTitle.ForeColor = Color.Green;
                        }

                        catchWeight.CloseScale();

                        break;
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al capturar peso.",
                                        ClsEnums.MessageType.ERROR,
                                        true,
                                        ex.Message);
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ScaleBrand != ClsEnums.ScaleBrands.DATALOGIC)
            {
                if (catchWeight.Weight > 0)
                {
                    weight = catchWeight.Weight;
                    LblCatchedWeight.Text = $"{weight}";
                    LblTitle.Text = "Peso Capturado Correctamente";
                    LblTitle.ForeColor = Color.Green;
                    formActionResult = true;
                }
            }
            else
            {
                if (weight > 0)
                    formActionResult = true;
            }
        }

    }
}