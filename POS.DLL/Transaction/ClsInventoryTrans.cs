using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInventoryTrans
    {
        public SP_PhysicalStockLine_Insert_Result InsertPhysicalStockCounting(int sequence, string _xml)
        {
            POSEntities db = new POSEntities();
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
            POSEntities db = new POSEntities();
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

        public bool HasPendingCounting(EmissionPoint emissionPoint, int UserId) => new POSEntities()
                .PhysicalStockCountingTable
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                    && a.Status == "O"
                    && a.CreatedBy == UserId)
                .Any();

        public int GetPendingCounting(EmissionPoint emissionPoint, long UserId) => new POSEntities()
                 .PhysicalStockCountingTable
                 .Where(ta => ta.EmissionPointId == emissionPoint.EmissionPointId
                       && ta.Status == "O"
                       && ta.CreatedBy == UserId)
                 .Select(ta => ta.PhysicalStockCountingId)
                 .FirstOrDefault();

        public List<SP_PhysicalStockLine_Consult_Result> GetPendingCountingLine(int id)
        {
            POSEntities db = new POSEntities();
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
            bool response = false;
            try
            {
                using (POSEntities db = new POSEntities())
                {

                    PhysicalStockCountingTable table =
                            db
                            .PhysicalStockCountingTable
                            .Where(ta => ta.PhysicalStockCountingId == sequence)
                            .FirstOrDefault();

                    table.ModifiedBy = table.CreatedBy;
                    table.ModifiedDatetime = DateTime.Now;
                    table.Status = "A";
                    response = db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
