using POS.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
