using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace POS
{
    public partial class FrmProductSearch : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        public string barcode = "";
        public bool useCatchWeight;
        public long productId;
        public EmissionPoint emissionPoint;
        public bool returnProduct = false;
        public string productName = "";

        public FrmProductSearch()
        {
            InitializeComponent();
        }

        private void BtnKeyPad_Click(object sender, System.EventArgs e)
        {
            FrmKeyBoard keyPad = new FrmKeyBoard();
            keyPad.inputFromOption = InputFromOption.CUSTOMER_FIRSTNAME;
            keyPad.ShowDialog();
            TxtSearchName.Text = keyPad.customerFirstName;
        }

        private void SearchProduct(string _searchProduct, int _locationId)
        {
            IEnumerable<SP_ProductBarcode_Consult_Result> products;

            try
            {
                products = new ClsProduct(Program.customConnectionString).GetProductsWithBarcode(_searchProduct, _locationId);


                if (products?.Count() > 0)
                {
                    BindingList<SP_ProductBarcode_Consult_Result> bindingList = new BindingList<SP_ProductBarcode_Consult_Result>(products.ToList());
                    bindingList.AllowNew = true;

                    GrcSalesDetail.DataSource = bindingList;
                }
                else
                {
                    TxtSearchName.Text = "";
                    TxtSearchName.Focus();
                    GrcSalesDetail.DataSource = null;
                    functions.ShowMessage("Producto no encontrado", MessageType.WARNING);
                }

            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Productos."
                                        , MessageType.ERROR
                                        , true
                                        , ex.InnerException.Message
                                    );
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            int rowIndex = GrvSalesDetail.FocusedRowHandle;
            if (rowIndex < 0)
            {
                functions.ShowMessage("No se ha seleccionado item por agregar.", MessageType.ERROR);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            SP_ProductBarcode_Consult_Result selectedProduct = (SP_ProductBarcode_Consult_Result)GrvSalesDetail.GetRow(rowIndex);
            barcode = selectedProduct.Barcode;
            productId = selectedProduct.ProductId;
            useCatchWeight = selectedProduct.UseCatchWeight;
            productName = selectedProduct.Name;
            returnProduct = true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearchName.Text == "")
            {
                functions.ShowMessage("El filtro de busqueda no puede estar vacio.", MessageType.ERROR);
                TxtSearchName.Focus();
                return;
            }

            SearchProduct(TxtSearchName.Text, emissionPoint.LocationId);
            GrcSalesDetail.Focus();
        }

        private void FrmProductSearch_Load(object sender, EventArgs e)
        {
            CheckGridView();
        }

        private void CheckGridView()
        {
            GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesDetail.DataSource = null;

            BindingList<Product> bindingList = new BindingList<Product>
            {
                AllowNew = true
            };

            GrcSalesDetail.DataSource = bindingList;
        }

        private void TxtSearchName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //06/07/2022
            switch (((int)e.KeyCode))
            {

                case 13:
                    BtnSearch_Click(null, null);
                    break;
                case 27:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void GrcSalesDetail_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (((byte)e.KeyChar))
            {
                case 13:
                    BtnAccept_Click(null, null);
                    Close();
                    break;
                case 27:
                    TxtSearchName.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}