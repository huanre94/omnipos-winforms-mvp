using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsProduct
    {
        private readonly string connectionString;

        public ClsProduct(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int _location)
        {
            try
            {
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString)
                    .SP_PhysicalStockProduct_Consult(emissionPoint.LocationId,
                                                     emissionPoint.EmissionPointId,
                                                     barcode,
                                                     internal_code)
                    .First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
