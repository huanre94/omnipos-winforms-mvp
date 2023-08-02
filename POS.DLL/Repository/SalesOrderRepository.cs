using POS.DLL.Enums;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace POS.DLL.Catalog
{

    public class SalesOrderRepository : BaseRepository
    {
        public SP_Login_Consult_Result LoginInformation { get; set; }

        public SalesOrderRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        //public SP_Login_Consult_Result loginInformation;
        public SalesOrder GetSalesOrder(long _salesOrderId)
        {
            return _dbContext.SalesOrder.Where(x => x.SalesOrderId == _salesOrderId)
                .Include(x => x.SalesOrderLine)
                .Include(x => x.SalesOrderPayment)
                .Include(x => x.SalesOrderText)
                .FirstOrDefault();
        }

        public SP_SalesOrderOmnipos_Insert_Result CreateOrUpdateSalesOrder(string _xml, long _salesOrderId = 0)
        {
            try
            {
                using (POSEntities db = _dbContext)
                {
                    if (_salesOrderId != 0)
                    {
                        SalesOrder sales = db.SalesOrder.Where(so => so.SalesOrderId == _salesOrderId).FirstOrDefault();

                        sales.ModifiedBy = LoginInformation.UserId;
                        sales.ModifiedDatetime = DateTime.Now;
                        db.SaveChanges();
                    }
                    return db.SP_SalesOrderOmnipos_Insert(_xml, _salesOrderId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SalesOrder CopySalesOrder(long _salesOrderId)
        {
            SalesOrder order = _dbContext.SalesOrder.Where(x => x.SalesOrderId == _salesOrderId)
                .Include(x => x.SalesOrderLine)
                .Include(x => x.SalesOrderPayment)
                .Include(x => x.SalesOrderText)
                .FirstOrDefault();

            SalesOrder newOrder = order.Clone();

            newOrder.SalesOrderId = 0;
            _dbContext.SalesOrder.Add(newOrder);
            _dbContext.SaveChanges();

            int serverId = _dbContext.Server.Where(s => s.IsLocal).Select(s => s.ServerId).FirstOrDefault();

            newOrder.SalesOrderId = long.Parse($"{serverId}{newOrder.SalesOrderIdLocal}");

            _dbContext.SaveChanges();

            return newOrder;
        }

        public IEnumerable<SalesOrderStatus> GetSalesOrderStatus()
        {
            try
            {
                return _dbContext
                      .SalesOrderStatus
                      .Where(so => so.Status.Equals("A"))
                      .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SalesOrigin> GetSalesOrderOrigin(bool customerServiceOrigins = true)
        {
            try
            {
                return _dbContext
                    .SalesOrigin
                    .Where(so => customerServiceOrigins ? (so.SalesOriginId >= 6) : (so.SalesmanId == 2) && so.Status.Equals("A"))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_SalesOrderStatus_Consult_Result> GetSalesOrderByStatus(string _date, string _status, int _channel, bool validateDate)
        {
            try
            {
                return _dbContext.SP_SalesOrderStatus_Consult(!validateDate ? _date : null, _channel, _status).ToList();

                //TODO: consulta de ordenes con linq

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CancelSalesOrder(long _salesOrderId, bool cancelFromGuide = false)
        {
            POSEntities db = _dbContext;
            SalesOrder order;
            try
            {
                if (!cancelFromGuide)
                {
                    SalesOrder result =
                        db
                        .SalesOrder
                        .Join(db.SalesRemissionLine,
                        so => so.SalesOrderId,
                        sr => sr.SalesOrderId,
                        (so, sr) => new { SalesOrder = so, SalesRemissionLine = sr })
                        .Where(sosr => sosr.SalesOrder.Status == "S"
                        && sosr.SalesRemissionLine.Status == "A"
                        && sosr.SalesOrder.SalesOrderId == _salesOrderId)
                        .Select(sosr => sosr.SalesOrder)
                        .FirstOrDefault();

                    if (result != null)
                    {
                        if (result.SalesOrderId > 0)
                        {
                            return false;
                        }
                    }

                }

                order = db.SalesOrder.Where(so => so.SalesOrderId == _salesOrderId).FirstOrDefault();
                order.Status = "I";
                order.ModifiedBy = LoginInformation.UserId;
                order.ModifiedDatetime = DateTime.Now;
                order.Workstation = LoginInformation.Workstation;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Transport> GetTransports()
        {
            try
            {
                return _dbContext
                    .Transport
                    .Where(tr => tr.Status.Equals("A"))
                    .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TransportDriver> GetTransportDrivers()
        {
            try
            {
                return _dbContext
                    .TransportDriver
                    .Where(tr => tr.Status.Equals("A"))
                    .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TransportReason> GetTransportReasons()
        {
            try
            {
                return _dbContext
                    .TransportReason
                    .Where(tr => tr.Status == "A")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public IEnumerable<SP_SalesOrderProduct_Consult_Result> GetSalesOrderProductsById(long salesOrderId)
        {
            try
            {
                return _dbContext.SP_SalesOrderProduct_Consult(salesOrderId).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_RemissionPendingSalesOrder_Consult_Result> GetPendingSalesOrders()
        {
            try
            {
                return _dbContext.SP_RemissionPendingSalesOrder_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_RemissionGuide_Consult_Result> GetActiveRemissionGuides(long userId = 0, long driverId = 0)
        {
            try
            {
                return _dbContext.SP_RemissionGuide_Consult(userId, driverId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_RemissionGuideSalesOrder_Consult_Result> GetSalesOrderByRemissionGuideNumber(long _guideId)
        {
            try
            {
                return _dbContext.SP_RemissionGuideSalesOrder_Consult(_guideId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SalesOrder GetSalesOrderById(long salesOrderId)
        {
            try
            {
                return _dbContext
                        .SalesOrder
                        .Where(so => so.SalesOrderId == salesOrderId)
                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<SalesOrderText> ConsultCommand(long _salesOrderId)
        {
            try
            {
                return (IEnumerable<SalesOrderText>)_dbContext
                    .SalesOrder
                    .Where(st => st.SalesOrderId == _salesOrderId)
                    .Select(x => x.SalesOrderText)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool FinishSalesOrder(long _salesOrderId)
        {
            try
            {
                using (POSEntities db = _dbContext)
                {
                    SalesOrder order = db.SalesOrder.Where(so => so.SalesOrderId == _salesOrderId).FirstOrDefault();

                    order.Status = "E";
                    order.ModifiedBy = LoginInformation.UserId;
                    order.ModifiedDatetime = DateTime.Now;
                    order.Workstation = LoginInformation.Workstation;
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public SP_SalesOrderPayment_Insert_Result UpdateSalesOrderPayment(string _xml, long _salesOrderId)
        {
            try
            {
                return _dbContext.SP_SalesOrderPayment_Insert(_xml, _salesOrderId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SalesOrigin> GetSalesOrigins()
        {
            try
            {
                //return _dbContext.SP_SalesOrigin_Consult().ToList();
                return _dbContext
                    .SalesOrigin
                    .Where(s => s.SalesOriginId != 2 && s.IsECommerce == false)
                    //.Select(s => new { s.SalesOriginId, s.Name, s.SalesmanId })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public bool SalesOrderHaveWebPayments(long salesOrderId)
        {
            try
            {
                return _dbContext
                    .SalesOrderPayment
                    .Where(sp => sp.SalesOrderId == salesOrderId && sp.PaymModeId == (int)PaymModeEnum.PAGOS_WEB)
                    .ToList()
                    .Count() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public IEnumerable<SP_SalesOrderTicket_Consult_Result> GetSalesOrderTicket(long _salesOrderId, short _emissionPointId, bool _openCashier = false)
        {
            try
            {
                return _dbContext.SP_SalesOrderTicket_Consult(_salesOrderId, _openCashier, _emissionPointId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
