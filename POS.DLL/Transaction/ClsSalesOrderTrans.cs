using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsSalesOrderTrans
    {
        public SP_Login_Consult_Result loginInformation;

        public SP_RemissionGuideInvoice_Insert_Result FinishRemissionGuide(long _remissionGuideId, int _emissionPointId, int _locationId, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
            SP_RemissionGuideInvoice_Insert_Result result;
            try
            {
                result = db.SP_RemissionGuideInvoice_Insert(_remissionGuideId, (short?)_emissionPointId, (short?)_locationId, loginInformation.UserId, loginInformation.Workstation).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_SalesOrderOmnipos_Insert_Result CreateOrUpdateSalesOrder(string _xml, long _salesOrderId = 0, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
            SP_SalesOrderOmnipos_Insert_Result result;
            try
            {
                if (_salesOrderId != 0)
                {
                    SalesOrder sales = (from so in db.SalesOrder
                                        where so.SalesOrderId == _salesOrderId
                                        select so).First();
                    sales.ModifiedBy = loginInformation.UserId;
                    sales.ModifiedDatetime = DateTime.Now;
                    db.SaveChanges();
                }
                result = db.SP_SalesOrderOmnipos_Insert(_xml, _salesOrderId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool CancelSalesOrder(long _id, bool cancelFromGuide = false, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
            SalesOrder order;
            try
            {
                if (!cancelFromGuide)
                {
                    var result = (from so in db.SalesOrder
                                  join sr in db.SalesRemissionLine on so.SalesOrderId equals sr.SalesOrderId
                                  where so.SalesOrderId == _id
                                  && so.Status == "S"
                                  && sr.Status == "A"
                                  select so).FirstOrDefault();

                    if (result != null)
                    {
                        if (result.SalesOrderId > 0)
                        {
                            return false;
                        }
                    }

                }

                order = (from so in db.SalesOrder
                         where so.SalesOrderId == _id
                         select so).First();

                order.Status = "I";
                order.ModifiedBy = loginInformation.UserId;
                order.ModifiedDatetime = DateTime.Now;
                order.Workstation = loginInformation.Workstation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return db.SaveChanges() > 0;
        }

        public bool FinishSalesOrder(long _id, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
            SalesOrder order;
            try
            {
                order = (from so in db.SalesOrder
                         where so.SalesOrderId == _id
                         select so).First();
                order.Status = "E";
                order.ModifiedBy = loginInformation.UserId;
                order.ModifiedDatetime = DateTime.Now;
                order.Workstation = loginInformation.Workstation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return db.SaveChanges() > 0;
        }

        public SP_SalesOrderRemission_Insert_Result CreateNewRemissionGuide(string _xml, string CadenaC = "")
        {
            var db = new POSEntities(CadenaC);
            SP_SalesOrderRemission_Insert_Result result;
            try
            {
                result = db.SP_SalesOrderRemission_Insert(_xml).First();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_RemissionGuide_Cancel_Result CancelRemissionGuide(long _remissionId, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
            SP_RemissionGuide_Cancel_Result result;
            try
            {
                result = db.SP_RemissionGuide_Cancel(_remissionId, loginInformation.UserId).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<SP_SalesOrderTicket_Consult_Result> GetSalesOrderTicket(long _salesOrderId, short _emissionPointId, bool _openCashier = false, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
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

        public List<string> GetRemissionGuideTicket(long _remissionGuideId, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);
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
