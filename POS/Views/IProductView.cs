using POS.DLL;
using System;
using System.Windows.Forms;

namespace POS.Views
{
    public interface IProductView
    {
        string SearchValue { get; set; }
        Product SelectedProduct { get; set; }


        event EventHandler SearchEvent;
        event EventHandler SelectProduct;

        void SetProductListBindingSource(BindingSource productList);
        void ShowDialog();
    }
}
