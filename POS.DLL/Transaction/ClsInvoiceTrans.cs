using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInvoiceTrans
    {
        readonly string connectionString;

        public ClsInvoiceTrans(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SP_Product_Consult_Result ProductConsult(ProductConsultDto product)
        {
            try
            {
                return new POSEntities(connectionString)
                    .SP_Product_Consult(product.LocationId,
                                        product.Barcode,
                                        product.Quantity,
                                        product.CustomerId,
                                        product.InternalCreditCardId,
                                        product.Paymmode,
                                        product.BarcodeBefore)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public SP_Product_Consult_Result ProductConsult(short _locationId
                                                        , string _barcode
                                                        , decimal _qty
                                                        , long _customerId
                                                        , long _internalCreditCardId
                                                        , string _paymMode
                                                        , string _barcodeBefore = "")
        {
            try
            {
                return new POSEntities(connectionString)
                    .SP_Product_Consult(_locationId,
                                        _barcode,
                                        _qty,
                                        _customerId,
                                        _internalCreditCardId,
                                        _paymMode,
                                        _barcodeBefore)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public SP_Invoice_Insert_Result CreateInvoice(XElement _invoiceXml)
        {
            SP_Invoice_Insert_Result invoiceResult = null;

            try
            {
                if (_invoiceXml.HasElements)
                {
                    return new POSEntities(connectionString).SP_Invoice_Insert(_invoiceXml.ToString()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return invoiceResult;
        }

        public IEnumerable<SP_InvoiceTicket_Consult_Result> GetInvoiceTicket(long _invoiceId, bool _openCashier = false)
        {
            try
            {
                return new POSEntities(connectionString).SP_InvoiceTicket_Consult(_invoiceId, _openCashier).ToList();
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
                using (POSEntities context = new POSEntities(connectionString))
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
            new POSEntities(connectionString)
                .SalesLog
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                && a.Status.Equals("A")
                && a.LogTypeId == 3)
                .Any();


        public SP_SalesLog_Consult_Result ConsultSuspendedSale(EmissionPoint emissionPoint)
        {
            try
            {
                return new POSEntities(connectionString).SP_SalesLog_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long ConsultLastInvoice(EmissionPoint emissionPoint)
        {
            try
            {
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString).SP_InvoicePayment_Consult(
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
            using (POSEntities db = new POSEntities(connectionString))
            {
                InvoicePayment invoicePayment = db
                    .InvoicePayment
                    .Where(x => x.InvoiceId == _invoiceId && x.PaymModeId == _paymModeId && x.Sequence == _sequence).FirstOrDefault();

                InvoiceTable invoiceTable = db
                    .InvoiceTable
                    .Where(y => y.InvoiceId == _invoiceId)
                    .FirstOrDefault();

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
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public InvoiceTable ConsultInvoice(long invoiceId)
        {
            try
            {
                return new POSEntities(connectionString).InvoiceTable.Where(inv => inv.InvoiceId == invoiceId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_InvoiceCancel_Consult_Result ConsultInvoiceStatus(EmissionPoint emissionPoint, int invoiceNumber)
        {
            try
            {
                return new POSEntities(connectionString).SP_InvoiceCancel_Consult(emissionPoint.LocationId, emissionPoint.EmissionPointId, invoiceNumber).FirstOrDefault();
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
                using (POSEntities context = new POSEntities(connectionString))
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
                return new POSEntities(connectionString)
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
