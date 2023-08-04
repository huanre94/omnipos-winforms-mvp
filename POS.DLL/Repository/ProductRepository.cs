using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace POS.DLL
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public ICollection<Product> GetProductsByBarcode(string _barcode)
        {
            List<Product> products = _dbContext
                .Product
                .Where(p => p.ProductBarcode.Any(x => x.Barcode.Contains(_barcode)))
                //.Include(p => p.ProductModule)
                .Include(p => p.ProductBarcode)
                .ToList();

            return products;
        }

        public ICollection<Product> GetProductsByName(string _name)
        {
            return _dbContext
                .Product
                .Where(p => p.Name.Contains(_name))
                .Include(p => p.ProductBarcode)
                .Include(iu=>iu.InventUnit)
                .Take(50)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Product GetProductByProductId(long _productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductBySku(string _sku)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }


        public SP_Product_Consult_Result ProductConsult(ProductConsultDto product)
        {
            try
            {
                return _dbContext
                    .SP_Product_Consult(product.LocationId,
                                        product.Barcode,
                                        product.Quantity,
                                        product.CustomerId,
                                        product.InternalCreditCardId,
                                        product.Paymmode,
                                        product.BarcodeBefore)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public SP_Product_Consult_Result ProductConsult(short _locationId
                                                        , string _barcode
                                                        , decimal _qty
                                                        , long _customerId
                                                        , long _internalCreditCardId
                                                        , string _paymMode
                                                        , string _barcodeBefore = "")
        {
            try
            {
                return _dbContext
                    .SP_Product_Consult(_locationId,
                                        _barcode,
                                        _qty,
                                        _customerId,
                                        _internalCreditCardId,
                                        _paymMode,
                                        _barcodeBefore)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
