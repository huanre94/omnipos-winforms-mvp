﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsProduct
    {
        public List<SP_ProductBarcode_Consult_Result> GetProductsWithBarcode(string _productName, int _location, string CadenaC = "")
        {
            List<SP_ProductBarcode_Consult_Result> result;

            try
            {
                result = new POSEntities(CadenaC).SP_ProductBarcode_Consult(_productName, _location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_PhysicalStockProduct_Consult_Result GetProductPhysicalStock(EmissionPoint emissionPoint, string barcode, string internal_code, string _CadenaC = "")
        {
            SP_PhysicalStockProduct_Consult_Result result;

            try
            {
                result = new POSEntities(_CadenaC).SP_PhysicalStockProduct_Consult(
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
