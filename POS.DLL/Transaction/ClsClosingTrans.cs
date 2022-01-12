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
            List<SP_ClosingCashierDenominations_Consult_Result> denominations;
            try
            {
                denominations = new POSEntities().SP_ClosingCashierDenominations_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return denominations;
        }

        public List<SP_ClosingCashierPartial_Consult_Result> GetPartialClosings(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            List<SP_ClosingCashierPartial_Consult_Result> partials;
            try
            {
                partials = new POSEntities().SP_ClosingCashierPartial_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return partials;
        }

        public List<SP_ClosingCashierPayment_Consult_Result> GetClosingPayments(EmissionPoint emissionPoint, SP_Login_Consult_Result loginInformation)
        {
            List<SP_ClosingCashierPayment_Consult_Result> payments;
            try
            {
                payments = new POSEntities().SP_ClosingCashierPayment_Consult(emissionPoint.LocationId, loginInformation.UserId, emissionPoint.EmissionPointId, "").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return payments;
        }

        public List<SP_ClosingCashier_Insert_Result> InsertFullClosing(XElement element)
        {
            List<SP_ClosingCashier_Insert_Result> closing;
            try
            {
                closing = new POSEntities().SP_ClosingCashier_Insert(element.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return closing;
        }

        public List<SP_ClosingCashierPartial_Insert_Result> InsertPartialClosing(XElement element)
        {
            List<SP_ClosingCashierPartial_Insert_Result> closing;
            try
            {
                closing = new POSEntities().SP_ClosingCashierPartial_Insert(element.ToString(), "P").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return closing;
        }

        public List<SP_ClosingCashierTicket_Consult_Result> GetClosingTicket(Int64 _invoiceId)
        {
            List<SP_ClosingCashierTicket_Consult_Result> invoiceTicketResult;

            try
            {
                invoiceTicketResult = new POSEntities().SP_ClosingCashierTicket_Consult(_invoiceId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceTicketResult;
        }

        public long ConsultLastClosing(EmissionPoint emissionPoint, string type)
        {
            long consult;

            try
            {
                consult = new POSEntities()
                    .ClosingCashierTable
                    .Where(it => it.EmissionPointId == emissionPoint.EmissionPointId
                    && it.LocationId == emissionPoint.LocationId
                    && it.ClosingCashierIdParent == 0
                    && it.Type == type
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

            return consult;
        }
    }
}
