using DevExpress.Utils.Filtering;
using POS.Classes;
using POS.DLL;
using POS.DLL.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS
{
    public partial class FrmProductSearch : DevExpress.XtraEditors.XtraForm
    {
        ClsFunctions functions = new ClsFunctions();
        public string barcode = "";
        public bool useCatchWeight;
        public long productId;
        public EmissionPoint emissionPoint;
        public bool returnProduct = false;
        public FrmProductSearch()
        {
            InitializeComponent();
        }

        private void BtnKeyPad_Click(object sender, System.EventArgs e)
        {
            FrmKeyBoard keyPad = new FrmKeyBoard();
            keyPad.inputFromOption = ClsEnums.InputFromOption.CUSTOMER_FIRSTNAME;
            keyPad.ShowDialog();
            TxtSearchName.Text = keyPad.customerFirstName;
        }

        private void SearchProduct(string _searchProduct, int _locationId)
        {
            ClsProduct paymMode = new ClsProduct();
            List<SP_ProductBarcode_Consult_Result> products;

            try
            {
                products = paymMode.GetProductsWithBarcode(_searchProduct, _locationId);

                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        BindingList<SP_ProductBarcode_Consult_Result> bindingList = new BindingList<SP_ProductBarcode_Consult_Result>(products);
                        bindingList.AllowNew = true;

                        GrcSalesDetail.DataSource = bindingList;
                    }
                    else
                    {
                        TxtSearchName.Text = "";
                        TxtSearchName.Focus();
                        GrcSalesDetail.DataSource = null;
                        functions.ShowMessage("Producto no encontrado", ClsEnums.MessageType.WARNING);
                    }
                }
            }
            catch (Exception ex)
            {
                functions.ShowMessage(
                                        "Ocurrio un problema al cargar lista de Productos."
                                        , ClsEnums.MessageType.ERROR
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
                functions.ShowMessage("No se ha seleccionado item por agregar.", ClsEnums.MessageType.ERROR);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else
            {
                SP_ProductBarcode_Consult_Result selectedProduct = (SP_ProductBarcode_Consult_Result)GrvSalesDetail.GetRow(rowIndex);
                barcode = selectedProduct.Barcode;
                productId = selectedProduct.ProductId;
                useCatchWeight = selectedProduct.UseCatchWeight;
                returnProduct = true;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearchName.Text != "")
            {
                SearchProduct(TxtSearchName.Text, emissionPoint.LocationId);
            }
            else
            {
                functions.ShowMessage("El filtro de busqueda no puede estar vacio.", ClsEnums.MessageType.ERROR);
            }
        }

        private void FrmProductSearch_Load(object sender, EventArgs e)
        {
            CheckGridView();
        }

        private void CheckGridView()
        {
            GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            GrcSalesDetail.DataSource = null;

            BindingList<Product> bindingList = new BindingList<Product>();
            bindingList.AllowNew = true;

            GrcSalesDetail.DataSource = bindingList;
        }
    }
}