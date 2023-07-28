using POS.DLL;
using POS.DLL.Enums;
using POS.DLL.Repository;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmProductChecker : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        readonly IProductRepository _productRepository;

        public FrmProductChecker(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
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

        private void BtnKeypad_Click(object sender, System.EventArgs e)
        {
            FrmKeyPad frmKeyPad = new FrmKeyPad(InputFromOption.PRODUCT_BARCODE);
            frmKeyPad.ShowDialog();

            Product product = _productRepository.GetProductsByBarcode(frmKeyPad.GetValue()).FirstOrDefault();
            LoadProductInformation(product);
        }

        private void LoadProductInformation(Product product)
        {
            LblProductBarcode.Text = product.ProductBarcode.ToString();
            LblProductName.Text = product.Name;
            LblProductPrice.Text = product.ProductModule.Select(s => s.Price).FirstOrDefault().ToString();
            LblProductPromotionalPrice.Text = product.ProductBarcode.ToString();
            TxtBarcode.Focus();
        }

    }
}