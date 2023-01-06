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
                                                        , string _barcodeBefore = ""
                                                        , string CadenaC = "")
        {
            SP_Product_Consult_Result result;

            try
            {
                result = new POSEntities(CadenaC).SP_Product_Consult(_locationId
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

        public SP_Invoice_Insert_Result CreateInvoice(XElement _invoiceXml, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
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

        public List<SP_InvoiceTicket_Consult_Result> GetInvoiceTicket(Int64 _invoiceId, bool _openCashier = false, string _CadenaC = "")
        {
            List<SP_InvoiceTicket_Consult_Result> invoiceTicketResult;

            try
            {
                invoiceTicketResult = new POSEntities(_CadenaC).SP_InvoiceTicket_Consult(_invoiceId, _openCashier).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return invoiceTicketResult;
        }

        public bool InsertCancelledSales(SalesLog salesLog, string CadenaC = "")
        {
            try
            {
                POSEntities context = new POSEntities(CadenaC);
                context.SalesLog.Add(salesLog);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool HasSuspendedSale(EmissionPoint emissionPoint, string CadenaC = "") =>
            new POSEntities(CadenaC)
                .SalesLog
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                && a.Status == "A"
                && a.LogTypeId == 3)
                .Any();


        public SP_SalesLog_Consult_Result ConsultSuspendedSale(EmissionPoint emissionPoint, string CadenaC = "")
        {
            POSEntities pos = new POSEntities(CadenaC);
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

        public long ConsultLastInvoice(EmissionPoint emissionPoint, string CadenaC = "")
        {
            POSEntities pos = new POSEntities(CadenaC);
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
                                                                            , string _CadenaC = ""
                                                                        )
        {
            var db = new POSEntities(_CadenaC);
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
                                            , string _CadenaC = ""
                                        )
        {
            var db = new POSEntities(_CadenaC);
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

        public InvoiceTable ConsultInvoice(long invoiceId, string Cadenac = "")
        {
            POSEntities pos = new POSEntities(Cadenac);
            InvoiceTable invoice;
            try
            {
                invoice = new POSEntities(Cadenac).InvoiceTable.Where(inv => inv.InvoiceId == invoiceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoice;
        }

        public SP_InvoiceCancel_Consult_Result ConsultInvoiceStatus(EmissionPoint emissionPoint, int invoiceNumber, string CadenaC = "")
        {
            SP_InvoiceCancel_Consult_Result response;

            try
            {
                response = new POSEntities(CadenaC).SP_InvoiceCancel_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId, invoiceNumber).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public bool CancelInvoice(SalesLog salesLog, InvoiceTable _invoiceTable, string _CadenaC = "")
        {
            POSEntities context = new POSEntities(_CadenaC);
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

        public bool ConsultSalesOriginCredit(int salesOriginId, string CadenaC = "")
        {
            bool allowCredit = false;
            try
            {
                allowCredit = new POSEntities(CadenaC)
                    .SalesOrigin
                    .Where(so => so.SalesOriginId == salesOriginId)
                    .Select(so => so.AllowCredit).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return allowCredit;
        }
    }
}
