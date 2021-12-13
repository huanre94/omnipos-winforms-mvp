using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsProduct
    {
        public List<Product> GetProducts(string _productName)
        {
            List<Product> products;

            try
            {
                products =
                        (
                            from pr in new POSEntities().Product
                            join bar in new POSEntities().ProductBarcode on pr.ProductId equals bar.ProductId
                            where pr.Status == "A"
                            && pr.Name.Contains(_productName)
                            select pr
                        ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public List<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int _location)
        {
            List<SP_ProductBarcode_Consult_Result> result;

            try
            {
                result = new POSEntities().SP_ProductBarcode_Consult(_productName, _location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_PhysicalStockProduct_Consult_Result GetProductPhysicalStock(EmissionPoint emissionPoint, string barcode, string internal_code)
        {
            SP_PhysicalStockProduct_Consult_Result result;

            try
            {
                result = new POSEntities().SP_PhysicalStockProduct_Consult(
                                                            emissionPoint.LocationId
                                                            , emissionPoint.EmissionPointId
                                                            , barcode, internal_code
                                                            ).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
