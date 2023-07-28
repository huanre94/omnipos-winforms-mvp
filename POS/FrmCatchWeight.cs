
using AxOposScale_CCO;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCatchWeight : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        ClsCatchWeight catchWeight;
        string strWaitTime = string.Empty;

        decimal Weight { get; set; } = 0;
        bool ActionResult { get; set; } = false;


        ScaleBrands ScaleBrand { get; set; }
        string PortName { get; set; }
        SP_Product_Consult_Result Product { get; set; }
        AxOPOSScale AxOposScale { get; set; }

        public FrmCatchWeight(ScaleBrands _scaleBrand, string _portName, AxOPOSScale _axOposScale, SP_Product_Consult_Result _product)
        {
            InitializeComponent();
            ScaleBrand = _scaleBrand;
            PortName = _portName;
            AxOposScale = _axOposScale;
            Product = _product;
        }

        public decimal GetWeight() => Weight;

        public bool GetActionResult() => ActionResult;

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
                            break;
                        }

                        if (ScaleBrand != ScaleBrands.DATALOGIC) catchWeight.CloseScale();

                        DialogResult = DialogResult.Cancel;

                        break;
                }

                LblProductName.Text = Product.ProductName;
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
            try
            {
                switch (_scaleBrand)
                {
                    case ScaleBrands.DATALOGIC:
                        AxOposScale.ReadWeight(out int request, 5000);
                        Weight = request / 1000M;

                        if (Weight <= 0)
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
                            Weight = catchWeight.Weight;
                        }

                        if (catchWeight.Weight <= 0)
                        {
                            LblTitle.Text = "Peso no Capturado";
                            LblTitle.ForeColor = Color.Red;

                            functions.ShowMessage("El peso no ha sido capturado. Por favor intente nuevamente", MessageType.CONFIRM);

                            return;
                        }

                        Weight = catchWeight.Weight;
                        catchWeight.CloseScale();
                        break;
                }

                LblCatchedWeight.Text = $"{Weight:0.###}";
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
                    if (Weight > 0)
                    {
                        ActionResult = true;
                    }
                    break;
                default:
                    if (catchWeight.Weight > 0)
                    {
                        Weight = catchWeight.Weight;
                        LblCatchedWeight.Text = $"{Weight}";
                        LblTitle.Text = "Peso Capturado Correctamente";
                        LblTitle.ForeColor = Color.Green;
                        ActionResult = true;
                    }
                    break;
            }
        }

    }
}