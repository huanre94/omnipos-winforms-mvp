using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Catalog
{
    public class ClsSalesOrder
    {
        public SP_Login_Consult_Result loginInformation;

        public List<SalesOrderStatus> GetSalesOrderStatus()
        {
            var db = new POSEntities();
            List<SalesOrderStatus> salesOrderStatus;

            try
            {

                salesOrderStatus = (
                                    from so in db.SalesOrderStatus
                                    where so.Status == "A"
                                    select so
                                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesOrderStatus;
        }

        public List<SalesOrigin> GetSalesOrderOrigin(bool canal = true)
        {
            var db = new POSEntities();
            List<SalesOrigin> salesOrderOrigin;

            try
            {
                if (canal)
                {
                    salesOrderOrigin = (from so in db.SalesOrigin
                                        where so.Status == "A"
                                        && so.SalesOriginId >= 6
                                        select so).ToList();
                }
                else
                {
                    salesOrderOrigin = (from so in db.SalesOrigin
                                        where so.Status == "A"
                                        && so.SalesmanId == 2
                                        select so).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesOrderOrigin;
        }

        public List<SP_SalesOrderStatus_Consult_Result> GetSalesOrderByStatus(string _date, string _status, int _channel, bool validateDate)
        {
            var db = new POSEntities();
            List<SP_SalesOrderStatus_Consult_Result> salesOrders;
            try
            {
                salesOrders = db.SP_SalesOrderStatus_Consult(!validateDate ? _date : null, _channel, _status).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return salesOrders;
        }

        public SP_SalesOrderOmnipos_Insert_Result CreateOrUpdateSalesOrder(string _xml, long _salesOrderId = 0)
        {
            var db = new POSEntities();
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

        public List<Transport> GetTransports()
        {
            var db = new POSEntities();
            List<Transport> transports;
            try
            {
                transports = (from tr in db.Transport
                              where tr.Status == "A"
                              select tr).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return transports;
        }

        public List<TransportDriver> GetTransportDrivers()
        {
            var db = new POSEntities();
            List<TransportDriver> transportDrivers;
            try
            {
                transportDrivers = (from tr in db.TransportDriver
                                    where tr.Status == "A"
                                    select tr).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return transportDrivers;
        }

        public List<TransportReason> GetTransportReasons()
        {
            var db = new POSEntities();
            List<TransportReason> transportReasons;
            try
            {
                transportReasons = (from tr in db.TransportReason
                                    where tr.Status == "A"
                                    select tr).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return transportReasons;
        }

        public SalesOrder GetSalesOrderById(long _id)
        {
            var db = new POSEntities();
            SalesOrder salesOrder;
            try
            {
                salesOrder = (from so in db.SalesOrder
                              where so.SalesOrderId == _id
                              select so).First();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return salesOrder;
        }

        public List<SP_SalesOrderProduct_Consult_Result> GetSalesOrderProductsById(long _id)
        {
            var db = new POSEntities();
            List<SP_SalesOrderProduct_Consult_Result> salesOrderProducts;
            try
            {
                salesOrderProducts = db.SP_SalesOrderProduct_Consult(_id).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return salesOrderProducts;
        }

        public bool CancelSalesOrder(long _id, bool cancelFromGuide = false)
        {
            var db = new POSEntities();
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return db.SaveChanges() > 0;
        }

        public bool FinishSalesOrder(long _id)
        {
            var db = new POSEntities();
            SalesOrder order;
            try
            {
                order = (from so in db.SalesOrder
                         where so.SalesOrderId == _id
                         select so).First();
                order.Status = "E";
                order.ModifiedBy = loginInformation.UserId;
                order.ModifiedDatetime = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return db.SaveChanges() > 0;
        }

        public SP_SalesOrderRemission_Insert_Result CreateNewRemissionGuide(string _xml)
        {
            var db = new POSEntities();
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

        public List<SP_RemissionPendingSalesOrder_Consult_Result> GetPendingSalesOrders()
        {
            var db = new POSEntities();
            List<SP_RemissionPendingSalesOrder_Consult_Result> list;
            try
            {
                list = db.SP_RemissionPendingSalesOrder_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<SP_RemissionGuide_Consult_Result> GetActiveRemissionGuides()
        {
            var db = new POSEntities();
            List<SP_RemissionGuide_Consult_Result> list;
            try
            {
                list = db.SP_RemissionGuide_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<SP_RemissionGuideSalesOrder_Consult_Result> GetSalesOrderByRemissionGuideNumber(long _guideId)
        {
            var db = new POSEntities();
            List<SP_RemissionGuideSalesOrder_Consult_Result> list;
            try
            {
                list = db.SP_RemissionGuideSalesOrder_Consult(_guideId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public SP_RemissionGuide_Cancel_Result CancelRemissionGuide(long _remissionId)
        {
            var db = new POSEntities();
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

        public List<SalesOrderText> ConsultCommand(long _salesOrderId)
        {
            var db = new POSEntities();
            List<SalesOrderText> text;
            try
            {
                text = (from st in db.SalesOrderText
                        where st.SalesOrderId == _salesOrderId
                        select st).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return text;
        }

        public SP_SalesOrderPayment_Insert_Result UpdateSalesOrderPayment(string _xml, long _salesOrderId)
        {
            var db = new POSEntities();
            SP_SalesOrderPayment_Insert_Result result;
            try
            {
                result = db.SP_SalesOrderPayment_Insert(_xml, _salesOrderId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_RemissionGuideInvoice_Insert_Result FinishRemissionGuide(long _remissionGuideId, int _emissionPointId, int _locationId)
        {
            var db = new POSEntities();
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
    }
}
