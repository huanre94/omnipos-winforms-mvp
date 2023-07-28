using System.Collections.Generic;

namespace POS.DLL.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        ICollection<Product> GetProductsByBarcode(string _barcode);
        ICollection<Product> GetProductsByName(string _name);
        Product GetProductBySku(string _sku);
        Product GetProductByProductId(long _productId);
    }
}
