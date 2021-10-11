using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsClosingTrans
    {
        public List<SP_ClosingCashierDenominations_Consult_Result> GetDenominations()
        {
            POSEntities entities = new POSEntities();
            List<SP_ClosingCashierDenominations_Consult_Result> denominations;
            try
            {
                denominations = entities.SP_ClosingCashierDenominations_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return denominations;
        }

        public List<SP_ClosingCashierPartial_Consult_Result> GetPartialClosings(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            POSEntities entities = new POSEntities();
            List<SP_ClosingCashierPartial_Consult_Result> partials;
            try
            {
                partials = entities.SP_ClosingCashierPartial_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return partials;
        }

        public List<SP_ClosingCashierPayment_Consult_Result> GetClosingPayments(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            POSEntities entities = new POSEntities();
            List<SP_ClosingCashierPayment_Consult_Result> payments;
            try
            {
                payments = entities.SP_ClosingCashierPayment_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return payments;
        }

        public List<SP_ClosingCashier_Insert_Result> InsertFullClosing(XElement element)
        {
            POSEntities entities = new POSEntities();
            List<SP_ClosingCashier_Insert_Result> closing;
            try
            {
                closing = entities.SP_ClosingCashier_Insert(element.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return closing;
        }

        public List<SP_ClosingCashierPartial_Insert_Result> InsertPartialClosing(XElement element)
        {
            POSEntities entities = new POSEntities();
            List<SP_ClosingCashierPartial_Insert_Result> closing;
            try
            {
                closing = entities.SP_ClosingCashierPartial_Insert(element.ToString(), "P").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return closing;
        }

        public List<SP_ClosingCashierTicket_Consult_Result> GetClosingTicket(Int64 _invoiceId)
        {
            var db = new POSEntities();
            List<SP_ClosingCashierTicket_Consult_Result> invoiceTicketResult;

            try
            {
                invoiceTicketResult = db.SP_ClosingCashierTicket_Consult(_invoiceId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceTicketResult;
        }

        public Int64 ConsultLastClosing(EmissionPoint emissionPoint, string type)
        {
            POSEntities pos = new POSEntities();
            long consult;

            try
            {
                consult = pos
                    .ClosingCashierTable
                    .Where(it => it.EmissionPointId == emissionPoint.EmissionPointId
                    && it.LocationId == emissionPoint.LocationId
                    && it.ClosingCashierIdParent == 0
                    && it.Type == type)
                    .OrderByDescending(it => it.ClosingCashierId)
                    .Take(1)
                    .Select(it => it.ClosingCashierId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return consult;
        }
    }
}
