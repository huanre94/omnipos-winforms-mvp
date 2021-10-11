using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<SP_RemissionGuide_Consult_Result> GetActiveRemissionGuides(long userId = 0, long driverId = 0)
        {
            var db = new POSEntities();
            List<SP_RemissionGuide_Consult_Result> list;
            try
            {
                list = db.SP_RemissionGuide_Consult(userId, driverId).ToList();
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
    }
}
