using System.Windows.Forms;

namespace POS
{
    public partial class FrmProductChecker : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions;


        public FrmProductChecker()
        {
            InitializeComponent();
        }

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