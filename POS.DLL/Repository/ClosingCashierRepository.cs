using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClosingCashierRepository : BaseRepository
    {
        readonly POSEntities _dbContext;

        public ClosingCashierRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<SP_ClosingCashierDenominations_Consult_Result> GetDenominations()
        {
            try
            {
                return _dbContext.SP_ClosingCashierDenominations_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_ClosingCashierPartial_Consult_Result> GetPartialClosings(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            try
            {
                //SP_ClosingCashierPartial_Consult_Result p = new SP_ClosingCashierPartial_Consult_Result();

                return _dbContext.SP_ClosingCashierPartial_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_ClosingCashierPayment_Consult_Result> GetClosingPayments(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            try
            {
                return _dbContext.SP_ClosingCashierPayment_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_ClosingCashier_Insert_Result> InsertFullClosing(XElement element, string TipoCierre = "")
        {
            try
            {
                return _dbContext.SP_ClosingCashier_Insert(element.ToString(), TipoCierre).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_ClosingCashierPartial_Insert_Result> InsertPartialClosing(XElement element)
        {
            try
            {
                return _dbContext.SP_ClosingCashierPartial_Insert(element.ToString(), "P").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_ClosingCashierTicket_Consult_Result> GetClosingTicket(long _invoiceId)
        {
            try
            {
                return _dbContext.SP_ClosingCashierTicket_Consult(_invoiceId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long ConsultLastClosing(EmissionPoint emissionPoint, string closingType)
        {
            try
            {
                return _dbContext
                    .ClosingCashierTable
                    .Where(it => it.EmissionPointId == emissionPoint.EmissionPointId
                    && it.LocationId == emissionPoint.LocationId
                    && it.ClosingCashierIdParent == 0
                    && it.Type == closingType
                    && it.Status == "A")
                    .OrderByDescending(it => it.ClosingCashierId)
                    .Take(1)
                    .Select(it => it.ClosingCashierId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PendingClosings(long emissionPointId, int userId)
        {
            return _dbContext
                .InvoiceTable
                .Where(inv => inv.ClosingCashierId == 0
                && DbFunctions.TruncateTime(inv.InvoiceDate) == DbFunctions.TruncateTime(DateTime.Today)
                && inv.EmissionPointId == emissionPointId
                && inv.CreatedBy != userId)
                .Any();
        }

        public ClosingCashierTable GetClosing(long closingId)
        {
            return _dbContext
                .ClosingCashierTable
                .Where(c => c.ClosingCashierId == closingId)
                .FirstOrDefault();
        }

        public bool ValidateDuplicateAccountingCode(int _locationId, string _accountingCode)
        {
            return _dbContext
                .ClosingCashierTable
                .Where(c => c.LocationId == _locationId && c.AccountingCode.Equals(_accountingCode))
                .Count() > 0;
        }

        //TODO: Logic for voiding cashier closings
        public ClosingCashierTable VoidClosingById(long closingId)
        {
            IQueryable<InvoiceTable> invoices = _dbContext.InvoiceTable.Where(i => i.ClosingCashierId == closingId);


            IQueryable<ClosingCashierTable> childClosings = _dbContext.ClosingCashierTable.Where(c => c.ClosingCashierIdParent == closingId);

            //whiplash, revenants

            return _dbContext
                    .ClosingCashierTable
                    .Where(c => c.ClosingCashierId == closingId)
                    .Include(p => p.ClosingCashierLine)

                    .FirstOrDefault();
        }
    }
}
