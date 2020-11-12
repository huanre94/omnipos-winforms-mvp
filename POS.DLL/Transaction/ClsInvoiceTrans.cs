using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
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
                                                        , string _barcodeBefore = ""
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
                                                , _barcodeBefore
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
            List<SP_InvoiceTicket_Consult_Result> invoiceTicketResult;
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


        public bool InsertCancelledSales(SalesLog salesLog)
        {
            try
            {
                POSEntities context = new POSEntities();
                context.SalesLog.Add(salesLog);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool HasSuspendedSale(EmissionPoint emissionPoint)
        {
            POSEntities pos = new POSEntities();
            int consult = pos.SalesLog.Count(a => a.EmissionPointId == emissionPoint.EmissionPointId && a.Status == "A" && a.LogTypeId == 3);
            if (consult > 0)
            {
                return true;
            }
            return false;
        }

        public SP_SalesLog_Consult_Result ConsultSuspendedSale(EmissionPoint emissionPoint)
        {
            POSEntities pos = new POSEntities();
            try
            {
                SP_SalesLog_Consult_Result consult = pos.SP_SalesLog_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId).FirstOrDefault();
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
