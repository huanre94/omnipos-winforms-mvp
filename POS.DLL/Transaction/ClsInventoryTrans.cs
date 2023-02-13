using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsInventoryTrans
    {
        private readonly string connectionString;

        public ClsInventoryTrans(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SP_PhysicalStockLine_Insert_Result InsertPhysicalStockCounting(int sequence, string _xml)
        {
            try
            {
                return new POSEntities(connectionString).SP_PhysicalStockLine_Insert(sequence, _xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_PhysicalStockTable_Insert_Result InsertNewSequence(string physicalStockXml)
        {
            try
            {
                return new POSEntities(connectionString).SP_PhysicalStockTable_Insert(physicalStockXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool HasPendingCounting(EmissionPoint emissionPoint, int UserId) => new POSEntities(connectionString)
                .PhysicalStockCountingTable
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                    && a.Status == "O"
                    && a.CreatedBy == UserId)
                .Any();

        public int GetPendingCounting(EmissionPoint emissionPoint, long UserId) => new POSEntities(connectionString)
                 .PhysicalStockCountingTable
                 .Where(ta => ta.EmissionPointId == emissionPoint.EmissionPointId
                       && ta.Status == "O"
                       && ta.CreatedBy == UserId)
                 .Select(ta => ta.PhysicalStockCountingId)
                 .FirstOrDefault();

        public IEnumerable<SP_PhysicalStockLine_Consult_Result> GetPendingCountingLine(int id)
        {
            try
            {
                return new POSEntities(connectionString).SP_PhysicalStockLine_Consult(id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateStockTableStatus(int sequence)
        {
            try
            {
                using (POSEntities db = new POSEntities(connectionString))
                {

                    PhysicalStockCountingTable table =
                            db
                            .PhysicalStockCountingTable
                            .Where(ta => ta.PhysicalStockCountingId == sequence)
                            .FirstOrDefault();

                    table.ModifiedBy = table.CreatedBy;
                    table.ModifiedDatetime = DateTime.Now;
                    table.Status = "A";
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
