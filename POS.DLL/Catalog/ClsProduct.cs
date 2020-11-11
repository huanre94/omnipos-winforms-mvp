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

        public List<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int emissionPoint)
        {
            var db = new POSEntities();
            List<SP_ProductBarcode_Consult_Result> result;

            try
            {
                result = db.SP_ProductBarcode_Consult(_productName, emissionPoint).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
