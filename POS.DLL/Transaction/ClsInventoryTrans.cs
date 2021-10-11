using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInventoryTrans
    {
        public SP_PhysicalStockLine_Insert_Result InsertPhysicalStockCounting(int sequence, string _xml)
        {
            var db = new POSEntities();
            SP_PhysicalStockLine_Insert_Result result;

            try
            {
                result = db.SP_PhysicalStockLine_Insert(sequence, _xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public SP_PhysicalStockTable_Insert_Result InsertNewSequence(string _xml)
        {
            var db = new POSEntities();
            SP_PhysicalStockTable_Insert_Result result;

            try
            {
                result = db.SP_PhysicalStockTable_Insert(_xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool HasPendingCounting(EmissionPoint emissionPoint, int UserId)
        {
            POSEntities pos = new POSEntities();
            bool response = false;
            int consult = 0;

            try
            {
                consult = pos.PhysicalStockCountingTable.Count(a => a.EmissionPointId == emissionPoint.EmissionPointId
                && a.Status == "O"
                && a.CreatedBy == UserId);

                if (consult > 0)
                {
                    response = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }

        public int GetPendingCounting(EmissionPoint emissionPoint, Int64 UserId)
        {
            var db = new POSEntities();
            int id;
            try
            {
                id = (from ta in db.PhysicalStockCountingTable
                      where ta.EmissionPointId == emissionPoint.EmissionPointId
                      && ta.Status == "O"
                      && ta.CreatedBy == UserId
                      select ta.PhysicalStockCountingId).FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public List<SP_PhysicalStockLine_Consult_Result> GetPendingCountingLine(int id)
        {
            var db = new POSEntities();
            List<SP_PhysicalStockLine_Consult_Result> list;
            try
            {
                list = db.SP_PhysicalStockLine_Consult(id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public bool UpdateStockTableStatus(int sequence)
        {
            var db = new POSEntities();
            bool response = false;
            PhysicalStockCountingTable table;
            try
            {
                table = (from ta in db.PhysicalStockCountingTable
                         where ta.PhysicalStockCountingId == sequence
                         select ta).First();

                table.ModifiedBy = table.CreatedBy;
                table.ModifiedDatetime = DateTime.Now;
                table.Status = "A";
                response = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
