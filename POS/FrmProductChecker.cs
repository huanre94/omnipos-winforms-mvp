using System.Windows.Forms;

namespace POS
{
    public partial class FrmProductChecker : DevExpress.XtraEditors.XtraForm
    {
        public ClsFunctions functions;

        public FrmProductChecker(string CadenaC = "")
        {
            InitializeComponent();
            this.CadenaC = CadenaC;     //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        }

        string CadenaC;    //15/07/2022  Se agregó para que Cadena de conexion sea parametrizable
        private void axOPOSScanner_DataEvent(object sender, AxOposScanner_CCO._IOPOSScannerEvents_DataEventEvent e)
        {
            TxtBarcode.Text = functions.AxOPOSScanner.ScanDataLabel;
            SendKeys.Send("{ENTER}");
            functions.AxOPOSScanner.DataEventEnabled = true;
        }

        private void BtnExit_Click(object sender, System.EventArgs e)
        {

        }
    }
}