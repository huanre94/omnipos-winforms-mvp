﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsSalesOrderTrans
    {
        private readonly string connectionString;

        public ClsSalesOrderTrans(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SP_Login_Consult_Result loginInformation;

        public SP_RemissionGuideInvoice_Insert_Result FinishRemissionGuide(long _remissionGuideId, int _emissionPointId, int _locationId)
        {
            SP_RemissionGuideInvoice_Insert_Result result;
            try
            {
                result = new POSEntities(connectionString).SP_RemissionGuideInvoice_Insert(_remissionGuideId, (short?)_emissionPointId, (short?)_locationId, loginInformation.UserId, loginInformation.Workstation).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_SalesOrderOmnipos_Insert_Result CreateOrUpdateSalesOrder(string _xml, long _salesOrderId = 0)
        {
            POSEntities db = new POSEntities(connectionString);
            SP_SalesOrderOmnipos_Insert_Result result;
            try
            {
                if (_salesOrderId != 0)
                {
                    SalesOrder sales = db.SalesOrder.Where(so => so.SalesOrderId == _salesOrderId).FirstOrDefault();

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

        public bool CancelSalesOrder(long _salesOrderId, bool cancelFromGuide = false)
        {
            POSEntities db = new POSEntities(connectionString);
            SalesOrder order;
            try
            {
                if (!cancelFromGuide)
                {
                    SalesOrder result =
                        db.SalesOrder
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

        public bool FinishSalesOrder(long _salesOrderId)
        {
            POSEntities db = new POSEntities(connectionString);
            SalesOrder order;
            try
            {
                order = db.SalesOrder.Where(so => so.SalesOrderId == _salesOrderId).FirstOrDefault();
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

        public SP_SalesOrderRemission_Insert_Result CreateNewRemissionGuide(string _remissionGuideXml)
        {
            try
            {
                return new POSEntities(connectionString).SP_SalesOrderRemission_Insert(_remissionGuideXml).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_RemissionGuide_Cancel_Result CancelRemissionGuide(long _remissionId)
        {
            try
            {
                return new POSEntities(connectionString).SP_RemissionGuide_Cancel(_remissionId, loginInformation.UserId).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SP_SalesOrderTicket_Consult_Result> GetSalesOrderTicket(long _salesOrderId, short _emissionPointId, bool _openCashier = false)
        {
            try
            {
                return new POSEntities(connectionString).SP_SalesOrderTicket_Consult(_salesOrderId, _openCashier, _emissionPointId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public IEnumerable<string> GetRemissionGuideTicket(long _remissionGuideId)
        {
            try
            {
                return new POSEntities(connectionString).SP_RemissionGuideTicket_Consult(_remissionGuideId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
