using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{

    public class ClsSalesOrder
    {
        private readonly string connectionString;

        public ClsSalesOrder(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //public SP_Login_Consult_Result loginInformation;

        public IEnumerable<SalesOrderStatus> GetSalesOrderStatus()
        {
            try
            {
                return new POSEntities(connectionString)
                      .SalesOrderStatus
                      .Where(so => so.Status.Equals("A"))
                      .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SalesOrigin> GetSalesOrderOrigin(bool canal = true)
        {
            try
            {
                return new POSEntities(connectionString)
                    .SalesOrigin
                    .Where(so => so.Status.Equals("A") && canal ? (so.SalesOriginId >= 6) : (so.SalesmanId == 2))
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
                return new POSEntities(connectionString).SP_SalesOrderStatus_Consult(!validateDate ? _date : null, _channel, _status).ToList();
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
                return new POSEntities(connectionString)
                        .SalesOrder
                        .Where(so => so.SalesOrderId == salesOrderId)
                        .FirstOrDefault();
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
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString).SP_SalesOrderProduct_Consult(salesOrderId).ToList();
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
                return new POSEntities(connectionString).SP_RemissionPendingSalesOrder_Consult().ToList();
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
                return new POSEntities(connectionString).SP_RemissionGuide_Consult(userId, driverId).ToList();
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
                return new POSEntities(connectionString).SP_RemissionGuideSalesOrder_Consult(_guideId).ToList();
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
                return new POSEntities(connectionString)
                    .SalesOrderText
                    .Where(st => st.SalesOrderId == _salesOrderId)
                    .ToList();
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
                return new POSEntities(connectionString).SP_SalesOrderPayment_Insert(_xml, _salesOrderId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_SalesOrigin_Consult_Result> GetSalesOrigins()
        {
            try
            {
                return new POSEntities(connectionString).SP_SalesOrigin_Consult().ToList();
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
                return new POSEntities(connectionString)
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
    }
}
