using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public SP_Invoice_Insert_Result CreateInvoice(XElement _invoiceXml)
        {
            try
            {
                return _dbContext.SP_Invoice_Insert(_invoiceXml.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public IEnumerable<SP_InvoiceTicket_Consult_Result> GetInvoiceTicket(long _invoiceId, bool _openCashier = false)
        {
            try
            {
                return _dbContext.SP_InvoiceTicket_Consult(_invoiceId, _openCashier).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public bool InsertCancelledSales(SalesLog salesLog)
        {
            try
            {
                using (POSEntities context = _dbContext)
                {
                    context.SalesLog.Add(salesLog);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool HasSuspendedSale(EmissionPoint emissionPoint) =>
            _dbContext
                .SalesLog
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                && a.Status.Equals("A")
                && a.LogTypeId == (int)Enums.LogType.SUSPENDER_DOCUMENTO)
                .Any();


        public SP_SalesLog_Consult_Result ConsultSuspendedSale(EmissionPoint emissionPoint)
        {
            try
            {
                return _dbContext.SP_SalesLog_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetLastInvoice(EmissionPoint emissionPoint)
        {
            try
            {
                return _dbContext
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
        }

        public IEnumerable<SP_InvoicePayment_Consult_Result> GetInvoicePayments(int _locationId
                                                                            , string _emissionPoint
                                                                            , string _invoiceNumber)
        {
            try
            {
                return _dbContext.SP_InvoicePayment_Consult(
                                                        _locationId
                                                        , _emissionPoint
                                                        , _invoiceNumber
                                                        ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateInvoicePayments(long _invoiceId,
                                          int _paymModeId,
                                          int _sequence,
                                          InvoicePayment _invoicePayment,
                                          int _userId,
                                          string _workStation)
        {
            using (POSEntities db = _dbContext)
            {
                InvoiceTable invoiceTable = db
                    .InvoiceTable
                    .Where(y => y.InvoiceId == _invoiceId)
                    .FirstOrDefault();

                invoiceTable.TransferStatusId = (int)Enums.TransferStatus.PENDING_PAYMMODE_UPDATE;
                invoiceTable.ModifiedBy = _userId;
                invoiceTable.ModifiedDatetime = DateTime.Now;
                invoiceTable.Workstation = _workStation;

                InvoicePayment invoicePayment = db
                    .InvoicePayment
                    .Where(x => x.InvoiceId == _invoiceId && x.PaymModeId == _paymModeId && x.Sequence == _sequence).FirstOrDefault();

                invoicePayment.PaymModeId = _invoicePayment.PaymModeId;

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
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public InvoiceTable GetInvoiceById(long invoiceId)
        {
            try
            {
                return _dbContext.InvoiceTable.
                    Where(inv => inv.InvoiceId == invoiceId)
                    .Include(t => t.InvoiceLine)
                    .Include(t => t.InvoicePayment)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public InvoiceTable GetInvoiceByNumber(EmissionPoint emissionPoint, int invoiceNumber)
        {
            try
            {
                return _dbContext
                    .InvoiceTable
                    .Where(it => it.Location.LocationId == emissionPoint.LocationId
                  && it.EmissionPoint.EmissionPointId == emissionPoint.EmissionPointId
                  && it.InvoiceNumber == invoiceNumber)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CancelInvoice(SalesLog salesLog, InvoiceTable _invoiceTable)
        {
            try
            {
                using (POSEntities context = _dbContext)
                {
                    context.SalesLog.Add(salesLog);

                    InvoiceTable invoiceTable = context
                        .InvoiceTable
                        .Where(y => y.InvoiceId == _invoiceTable.InvoiceId)
                        .FirstOrDefault();

                    invoiceTable.TransferStatusId = _invoiceTable.TransferStatusId;
                    invoiceTable.Observation = _invoiceTable.Observation;
                    invoiceTable.ClosingCashierId = _invoiceTable.ClosingCashierId;
                    invoiceTable.Status = _invoiceTable.Status;
                    invoiceTable.ModifiedBy = _invoiceTable.ModifiedBy;
                    invoiceTable.ModifiedDatetime = _invoiceTable.ModifiedDatetime;

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ConsultSalesOriginCredit(int salesOriginId)
        {
            try
            {
                return _dbContext
                    .SalesOrigin
                    .Where(so => so.SalesOriginId == salesOriginId)
                    .Select(so => so.AllowCredit)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
