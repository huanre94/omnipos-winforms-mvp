using DevExpress.XtraEditors;
using POS.DLL;
using POS.DLL.Enums;
using POS.Views;
using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmProductSearch : XtraForm, IProductView
    {
        public FrmProductSearch()
        {
            InitializeComponent();

            BtnCancel.Click += delegate { Close(); };
            BtnKeyPad.Click += delegate
            {
                FrmKeyBoard keyPad = new FrmKeyBoard(InputFromOption.PRODUCT_NAME);
                keyPad.ShowDialog();
                TxtSearchName.Text = keyPad.productName;
            };
            BtnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            BtnAccept.Click += delegate { SelectProduct?.Invoke(this, EventArgs.Empty); };

            GrcSalesDetail.KeyPress += (s, e) =>
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Enter:
                        SelectProduct?.Invoke(this, EventArgs.Empty);
                        Close();
                        break;
                    case (char)Keys.Escape:
                        if (GrcSalesDetail.Focused)
                        {
                            TxtSearchName.Focus();
                            return;
                        }
                        Close();
                        break;
                    case (char)Keys.F12:
                        TxtSearchName.Focus();
                        break;
                    default:
                        break;
                }
            };

            TxtSearchName.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        SearchEvent?.Invoke(this, EventArgs.Empty);
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.F12:
                        GrcSalesDetail.Focus();
                        break;
                    default:
                        break;
                }
            };
        }

        public string SearchValue
        {
            get => TxtSearchName.Text;
            set => TxtSearchName.Text = value;
        }

        public Product SelectedProduct
        {
            get => (Product)GrvSalesDetail.GetRow(GrvSalesDetail.FocusedRowHandle);
            set => GrvSalesDetail.GetRow(GrvSalesDetail.FocusedRowHandle);
        }

        public event EventHandler SearchEvent;
        public event EventHandler SelectProduct;

        public void SetProductListBindingSource(BindingSource productList)
        {
            GrcSalesDetail.DataSource = productList;
        }

        void IProductView.ShowDialog()
        {
            ShowDialog();
        }




        //private void TxtSearchName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    //06/07/2022
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Enter:
        //            BtnSearch_Click(null, null);
        //            break;
        //        case Keys.Escape:
        //            Close();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //readonly ClsFunctions functions = new ClsFunctions();
        //private EmissionPoint Emission { get; set; }
        //private Product Result { get; set; }

        //public Product GetProduct() => Result;

        //public FrmProductSearch()
        //{
        //    InitializeComponent();
        //}

        //public FrmProductSearch(EmissionPoint emission)
        //{
        //    InitializeComponent();
        //    Emission = emission;
        //}

        //private void BtnKeyPad_Click(object sender, System.EventArgs e)
        //{
        //    FrmKeyBoard keyPad = new FrmKeyBoard
        //    {
        //        inputFromOption = InputFromOption.PRODUCT_NAME
        //    };
        //    keyPad.ShowDialog();
        //    TxtSearchName.Text = keyPad.productName;
        //}

        //private void SearchProduct(string _searchProduct, int _locationId)
        //{
        //    try
        //    {
        //        //TODO: Replace this result with product
        //        //ICollection<SP_ProductBarcode_Consult_Result> products = new ClsProduct(Program.customConnectionString).GetProductsWithBarcode(_searchProduct, _locationId);
        //        ICollection<Product> products = new ProductRepository(Program.customConnectionString).GetProductsByName(_searchProduct);

        //        if (products?.Count() == 0)
        //        {
        //            functions.ShowMessage("Producto no encontrado", MessageType.WARNING);
        //            ClearSearchName();
        //            GrcSalesDetail.DataSource = null;
        //            return;
        //        }

        //        BindingList<Product> bindingList = new BindingList<Product>(products.ToList())
        //        { AllowNew = true };

        //        GrcSalesDetail.DataSource = bindingList;
        //    }
        //    catch (Exception ex)
        //    {
        //        functions.ShowMessage("Ocurrio un problema al cargar lista de Productos.",
        //                              MessageType.ERROR,
        //                              true,
        //                              ex.InnerException.Message);
        //    }
        //}

        //private void ClearSearchName()
        //{
        //    TxtSearchName.Text = "";
        //    TxtSearchName.Focus();
        //}

        //private void BtnCancel_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}

        //private void BtnAccept_Click(object sender, EventArgs e)
        //{
        //    int rowIndex = GrvSalesDetail.FocusedRowHandle;
        //    if (rowIndex < 0)
        //    {
        //        functions.ShowMessage("No se ha seleccionado item por agregar.", MessageType.ERROR);
        //        DialogResult = DialogResult.None;
        //        return;
        //    }

        //    Product selectedProduct = (Product)GrvSalesDetail.GetRow(rowIndex);
        //    //Product selectedProduct = (Product)GrvSalesDetail.GetRow(rowIndex);

        //    Result = selectedProduct;

        //    //Result.Barcode = selectedProduct.Barcode;
        //    //Result.ProductId = selectedProduct.ProductId;
        //    //Result.ProductName = selectedProduct.Name;
        //    //Result.UseCatchWeight = selectedProduct.UseCatchWeight;
        //}

        //private void BtnSearch_Click(object sender, EventArgs e)
        //{
        //    if (TxtSearchName.Text == string.Empty)
        //    {
        //        functions.ShowMessage("El filtro de busqueda no puede estar vacio.", MessageType.ERROR);
        //        ClearSearchName();
        //        return;
        //    }

        //    if (TxtSearchName.Text.Length <= 3)
        //    {
        //        functions.ShowMessage("La busqueda debe al menos contener 3 caracteres para proceder.", MessageType.ERROR);
        //        ClearSearchName();
        //        return;
        //    }

        //    SearchProduct(TxtSearchName.Text, Emission.LocationId);
        //    GrcSalesDetail.Focus();
        //}

        //private void FrmProductSearch_Load(object sender, EventArgs e)
        //{
        //    CheckGridView();
        //}

        //private void CheckGridView()
        //{
        //    GrvSalesDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        //    GrcSalesDetail.DataSource = null;

        //    BindingList<Product> bindingList = new BindingList<Product> { AllowNew = true };

        //    GrcSalesDetail.DataSource = bindingList;
        //}

        //private void TxtSearchName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    //06/07/2022
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Enter:
        //            BtnSearch_Click(null, null);
        //            break;
        //        case Keys.Escape:
        //            Close();
        //            break;
        //        default:
        //            break;
        //    }
        //}



        //private void GrcSalesDetail_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    switch (e.KeyChar)
        //    {
        //        case (char)Keys.Enter:
        //            BtnAccept_Click(null, null);
        //            Close();
        //            break;
        //        case (char)Keys.Escape:
        //            ClearSearchName();
        //            break;
        //        default:
        //            break;
        //    }
        //}

    }
}