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

        public SP_Invoice_Insert_Result CreateInvoice(XElement _invoiceXml)
        {
            var db = new POSEntities();
            SP_Invoice_Insert_Result invoiceResult = null;

            try
            {
                if (_invoiceXml.HasElements)
                {
                    invoiceResult = db.SP_Invoice_Insert(_invoiceXml.ToString()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceResult;
        }

        public List<SP_InvoiceTicket_Consult_Result> GetInvoiceTicket(Int64 _invoiceId)
        {
            var db = new POSEntities();
            List<SP_InvoiceTicket_Consult_Result> invoiceTicketResult = null;

            try
            {

                invoiceTicketResult = db.SP_InvoiceTicket_Consult(_invoiceId).ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceTicketResult;
        }
    }
}
