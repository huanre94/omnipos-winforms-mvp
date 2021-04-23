using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Transaction
{
    public class ClsSalesOrderTrans
    {
        public List<SP_SalesOrigin_Consult_Result> GetSalesOrigins()
        {
            List<SP_SalesOrigin_Consult_Result> salesOrigins;
            var db = new POSEntities();
            try
            {
                salesOrigins = db.SP_SalesOrigin_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salesOrigins;
        }

        public List<SP_SalesOrderTicket_Consult_Result> GetSalesOrderTicket(Int64 _salesOrderId, short _emissionPointId, bool _openCashier = false)
        {
            var db = new POSEntities();
            List<SP_SalesOrderTicket_Consult_Result> salesOrderTicketResult;

            try
            {
                salesOrderTicketResult = db.SP_SalesOrderTicket_Consult(_salesOrderId, _openCashier, _emissionPointId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return salesOrderTicketResult;
        }

        public List<string> GetRemissionGuideTicket(long _remissionGuideId)
        {
            var db = new POSEntities();
            List<string> salesOrderTicketResult;

            try
            {
                salesOrderTicketResult = db.SP_RemissionGuideTicket_Consult(_remissionGuideId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return salesOrderTicketResult;
        }
    }
}
