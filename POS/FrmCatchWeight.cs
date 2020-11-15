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

namespace POS
{
    public partial class FrmCatchWeight : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public AxOposScale_CCO.AxOPOSScale axOposScale;
        public bool formActionResult;
        public decimal weight = 0;
        public string productName = string.Empty;

        public FrmCatchWeight()
        {
            InitializeComponent();
        }

        private void FrmCatchWeight_Load(object sender, EventArgs e)
        {
            LblTitle.Text = "Coloque el Producto en la Balanza";
            LblProductName.Text = productName;
        }

        private void BtnCatchWeight_Click(object sender, EventArgs e)
        {
            CatchWeightProduct(axOposScale);
        }

        private decimal CatchWeightProduct(AxOposScale_CCO.AxOPOSScale _axOposScale)
        {
            try
            {
                _axOposScale.ReadWeight(out int request, 5000);
                weight = request / 1000M;

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

            return weight;
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