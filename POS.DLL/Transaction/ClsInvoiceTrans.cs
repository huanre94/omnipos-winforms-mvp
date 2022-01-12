using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInvoiceTrans
    {
        public SP_Product_Consult_Result ProductConsult(short _locationId
                                                        , string _barcode
                                                        , decimal _qty
                                                        , long _customerId
                                                        , long _internalCreditCardId
                                                        , string _paymMode
                                                        , string _barcodeBefore = "")
        {
            SP_Product_Consult_Result result;

            try
            {
                result = new POSEntities().SP_Product_Consult(_locationId
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
                throw new Exception(ex.InnerException.Message);
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
                throw new Exception(ex.InnerException.Message);
            }

            return invoiceResult;
        }

        public List<SP_InvoiceTicket_Consult_Result> GetInvoiceTicket(Int64 _invoiceId, bool _openCashier = false)
        {
            var db = new POSEntities();
            List<SP_InvoiceTicket_Consult_Result> invoiceTicketResult;

            try
            {
                invoiceTicketResult = db.SP_InvoiceTicket_Consult(_invoiceId, _openCashier).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
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
            SP_SalesLog_Consult_Result consult;

            try
            {
                consult = pos.SP_SalesLog_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return consult;
        }

        public long ConsultLastInvoice(EmissionPoint emissionPoint)
        {
            POSEntities pos = new POSEntities();
            long consult;

            try
            {
                consult = pos
                    .InvoiceTable
                    .Where(it => it.EmissionPointId == emissionPoint.EmissionPointId
                    && it.LocationId == emissionPoint.LocationId
                    && it.ClosingCashierId == 0)
                    .OrderByDescending(it => it.InvoiceId)
                    .Take(1)
                    .Select(it => it.InvoiceId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return consult;
        }

        public List<SP_InvoicePayment_Consult_Result> GetInvoicePayments(int _locationId
                                                                            , string _emissionPoint
                                                                            , string _invoiceNumber
                                                                        )
        {
            var db = new POSEntities();
            List<SP_InvoicePayment_Consult_Result> payments;

            try
            {
                payments = db.SP_InvoicePayment_Consult(
                                                        _locationId
                                                        , _emissionPoint
                                                        , _invoiceNumber
                                                        ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return payments;
        }

        public bool UpdateInvoicePayments(
                                            long _invoiceId
                                            , int _paymModeId
                                            , int _sequence
                                            , InvoicePayment _invoicePayment
                                            , int _userId
                                            , string _workStation
                                        )
        {
            var db = new POSEntities();
            bool response;

            InvoicePayment invoicePayment = (from x in db.InvoicePayment
                                             where x.InvoiceId == _invoiceId
                                             && x.PaymModeId == _paymModeId
                                             && x.Sequence == _sequence
                                             select x).First();

            InvoiceTable invoiceTable = (from y in db.InvoiceTable
                                         where y.InvoiceId == _invoiceId
                                         select y).First();

            invoicePayment.PaymModeId = _invoicePayment.PaymModeId;

            invoiceTable.TransferStatusId = 4;
            invoiceTable.ModifiedBy = _userId;
            invoiceTable.ModifiedDatetime = DateTime.Now;
            invoiceTable.Workstation = _workStation;

            switch (_invoicePayment.PaymModeId)
            {
                case 1:
                    invoicePayment.GiftCardNumber = _invoicePayment.GiftCardNumber;
                    break;
                case 5:
                case 13:
                    invoicePayment.BankId = _invoicePayment.BankId;
                    invoicePayment.CreditCardId = _invoicePayment.CreditCardId;
                    invoicePayment.Authorization = _invoicePayment.Authorization;
                    break;
                case 2:
                case 3:
                    invoicePayment.BankId = _invoicePayment.BankId;
                    invoicePayment.AccountNumber = _invoicePayment.AccountNumber;
                    invoicePayment.CkeckNumber = _invoicePayment.CkeckNumber;
                    invoicePayment.CkeckType = _invoicePayment.CkeckType;
                    invoicePayment.CkeckDate = _invoicePayment.CkeckDate;
                    invoicePayment.CheckOwner = _invoicePayment.CheckOwner;
                    invoicePayment.Authorization = _invoicePayment.Authorization;
                    break;
                default:
                    break;
            }

            try
            {
                db.SaveChanges();
                response = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }

        public InvoiceTable ConsultInvoice(long invoiceId)
        {
            POSEntities pos = new POSEntities();
            InvoiceTable invoiceTable;
            try
            {
                invoiceTable = (from y in pos.InvoiceTable
                                where y.InvoiceId == invoiceId
                                select y).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoiceTable;
        }

        public SP_InvoiceCancel_Consult_Result ConsultInvoiceStatus(EmissionPoint emissionPoint, string emission, int invoiceNumber)
        {
            POSEntities pos = new POSEntities();
            SP_InvoiceCancel_Consult_Result response;
            EmissionPoint _emissionPoint;

            try
            {
                _emissionPoint = (from y in pos.EmissionPoint
                                  where y.Emission == emission
                                  && y.LocationId == emissionPoint.LocationId
                                  select y).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                response = pos.SP_InvoiceCancel_Consult(emissionPoint.LocationId, _emissionPoint.EmissionPointId, invoiceNumber).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public bool CancelInvoice(SalesLog salesLog, InvoiceTable _invoiceTable)
        {
            POSEntities context = new POSEntities();
            try
            {

                context.SalesLog.Add(salesLog);

                InvoiceTable invoiceTable = (from y in context.InvoiceTable
                                             where y.InvoiceId == _invoiceTable.InvoiceId
                                             select y).First();

                invoiceTable.TransferStatusId = _invoiceTable.TransferStatusId;
                invoiceTable.Observation = _invoiceTable.Observation;
                invoiceTable.ClosingCashierId = _invoiceTable.ClosingCashierId;
                invoiceTable.Status = _invoiceTable.Status;
                invoiceTable.ModifiedBy = _invoiceTable.ModifiedBy;
                invoiceTable.ModifiedDatetime = _invoiceTable.ModifiedDatetime;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ConsultSalesOriginCredit(int salesOriginId)
        {
            bool allowCredit = false;
            var db = new POSEntities();
            try
            {
                allowCredit = (bool)(from so in db.SalesOrigin
                                     where so.SalesOriginId == salesOriginId
                                     select so.AllowCredit).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return allowCredit;
        }
    }
}
