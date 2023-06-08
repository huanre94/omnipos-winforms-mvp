using POS.DLL;
using POS.DLL.Catalog;
using POS.DLL.Enums;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace POS
{
    public partial class FrmProductSearch : DevExpress.XtraEditors.XtraForm
    {
        readonly ClsFunctions functions = new ClsFunctions();
        private EmissionPoint Emission { get; set; }
        private SP_Product_Consult_Result result { get; set; } = new SP_Product_Consult_Result();

        public SP_Product_Consult_Result GetProduct() => result;

        public FrmProductSearch()
        {
            InitializeComponent();
        }

        public FrmProductSearch(EmissionPoint emission)
        {
            InitializeComponent();
            Emission = emission;
        }

        private void BtnKeyPad_Click(object sender, System.EventArgs e)
        {
            FrmKeyBoard keyPad = new FrmKeyBoard
            {
                inputFromOption = InputFromOption.PRODUCT_NAME
            };
            keyPad.ShowDialog();
            TxtSearchName.Text = keyPad.productName;
        }

        private void SearchProduct(string _searchProduct, int _locationId)
        {
            try
            {
                IEnumerable<SP_ProductBarcode_Consult_Result> products = new ClsProduct(Program.customConnectionString).GetProductsWithBarcode(_searchProduct, _locationId);

                if (products?.Count() == 0)
                {
                    functions.ShowMessage("Producto no encontrado", MessageType.WARNING);
                    ClearSearchName();
                    GrcSalesDetail.DataSource = null;
                    return;
                }

                BindingList<SP_ProductBarcode_Consult_Result> bindingList = new BindingList<SP_ProductBarcode_Consult_Result>(products.ToList()) { AllowNew = true };
                GrcSalesDetail.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                functions.ShowMessage("Ocurrio un problema al cargar lista de Productos.",
                                      MessageType.ERROR,
                                      true,
                                      ex.InnerException.Message);
            }
        }

        private void ClearSearchName()
        {
            TxtSearchName.Text = "";
            TxtSearchName.Focus();
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
                DialogResult = DialogResult.None;
                return;
            }

            SP_ProductBarcode_Consult_Result selectedProduct = (SP_ProductBarcode_Consult_Result)GrvSalesDetail.GetRow(rowIndex);

            result.Barcode = selectedProduct.Barcode;
            result.ProductId = selectedProduct.ProductId;
            result.UseCatchWeight = selectedProduct.UseCatchWeight;
            result.ProductName = selectedProduct.Name;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearchName.Text == string.Empty)
            {
                functions.ShowMessage("El filtro de busqueda no puede estar vacio.", MessageType.ERROR);
                ClearSearchName();
                return;
            }

            if (TxtSearchName.Text.Length <= 3)
            {
                functions.ShowMessage("La busqueda debe al menos contener 3 caracteres para proceder.", MessageType.ERROR);
                ClearSearchName();
                return;
            }

            SearchProduct(TxtSearchName.Text, Emission.LocationId);
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

            BindingList<Product> bindingList = new BindingList<Product> { AllowNew = true };

            GrcSalesDetail.DataSource = bindingList;
        }

        private void TxtSearchName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //06/07/2022
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnSearch_Click(null, null);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void GrcSalesDetail_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    BtnAccept_Click(null, null);
                    Close();
                    break;
                case (char)Keys.Escape:
                    ClearSearchName();
                    break;
                default:
                    break;
            }
        }
    }
}