using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInvoiceTrans
    {        
        public SP_Product_Consult_Result ProductConsult(
                                                        short _locationId
                                                        , string _barcode
                                                        , decimal _qty
                                                        , long _customerId
                                                        , int _internalCreditCardId
                                                        , string _paymMode
                                                        )
        {
            var db = new POSEntities();
            SP_Product_Consult_Result result;

            try
            {
                result = db.SP_Product_Consult(_locationId
                                                , _barcode
                                                , _qty
                                                , _customerId
                                                , _internalCreditCardId
                                                , _paymMode
                                                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool CreateInvoice(XElement _invoiceXml)
        {
            bool response = false;

            try
            {
                //Call to closing invoice process
                if (_invoiceXml.HasElements)
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }
    }
}
