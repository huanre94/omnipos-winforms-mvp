using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsProduct : BaseRepository
    {
        readonly POSEntities _dbContext;

        public ClsProduct(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public ICollection<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int _location)
        {
            try
            {
                return _dbContext
                    .SP_ProductBarcode_Consult(_productName, _location)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_PhysicalStockProduct_Consult_Result GetProductPhysicalStock(EmissionPoint emissionPoint, string barcode, string internal_code)
        {
            try
            {
                //Product product = _dbContext
                //    .Set<Product>()
                //    .Where(p => p.ProductBarcode.Any(b => b.Barcode.Contains(barcode)) || p.ProductOldCode.Equals(internal_code)).FirstOrDefault();

                return _dbContext
                    .SP_PhysicalStockProduct_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId, barcode, internal_code)
                  .First();

                //var itemOnCounting = _dbContext
                //.PhysicalStockCountingTable
                //.Where(p =>
                //p.Status.Equals("O") &&
                //p.PhysicalStockCountingLine.Any(x => x.ProductId == product.ProductId))
                //.Select(c => c);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
