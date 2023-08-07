using POS.DLL;
using POS.DLL.Contracts;
using POS.DLL.Enums;
using POS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POS.Presenter
{
    public class ProductPresenter
    {
        private IProductView productView;
        private IProductRepository productRepository;
        private BindingSource productsBindingSource;
        private IEnumerable<Product> productList;

        public Product product;

        public ProductPresenter(IProductView productView, IProductRepository productRepository)
        {
            productsBindingSource = new BindingSource();
            this.productView = productView;
            this.productRepository = productRepository;

            this.productView.SearchEvent += SearchProducts;
            this.productView.SelectProduct += SelectProduct;

            this.productView.SetProductListBindingSource(productsBindingSource);

            this.productView.ShowDialog();
        }

        private void SelectProduct(object sender, EventArgs e)
        {
            productView.SelectedProduct = (Product)productsBindingSource.Current;
            product = productView.SelectedProduct;
        }

        private void SearchProducts(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(productView.SearchValue);
            if (emptyValue)
            {
                new ClsFunctions().ShowMessage("Campo busqueda no puede estar vacio.", MessageType.WARNING);
                return;
            }

            if (productView.SearchValue.Length < 3)
            {
                new ClsFunctions().ShowMessage("La busqueda debe contener al menos 3 caracteres.", MessageType.WARNING);
                return;
            }

            productList = productRepository.GetProductsByName(productView.SearchValue);

            if (!productList.Any())
            {
                new ClsFunctions().ShowMessage("No se encontro productos con la descripcion escrita.", MessageType.INFO);
                return;
            }

            productsBindingSource.DataSource = productList;
        }


    }
}
