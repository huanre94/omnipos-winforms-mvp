using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsProduct
    {
        public List<Product> GetProducts(string _productName)
        {
            var db = new POSEntities();
            List<Product> banks;

            try
            {

                banks =
                        (
                            from pr in db.Product
                            join bar in db.ProductBarcode on pr.ProductId equals bar.ProductId
                            where pr.Status == "A"
                            && pr.Name.Contains(_productName)
                            select pr
                        ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return banks;
        }

        public List<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int _location)
        {
            var db = new POSEntities();
            List<SP_ProductBarcode_Consult_Result> result;

            try
            {
                result = db.SP_ProductBarcode_Consult(_productName, _location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public SP_PhysicalStockProduct_Consult_Result GetProductPhysicalStock(EmissionPoint emissionPoint, string barcode, string internal_code)
        {
            var db = new POSEntities();
            SP_PhysicalStockProduct_Consult_Result result;

            try
            {
                result = db.SP_PhysicalStockProduct_Consult(
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
