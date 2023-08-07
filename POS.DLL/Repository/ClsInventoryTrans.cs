using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Repository
{
    public class ClsInventoryTrans : BaseRepository
    {


        public ClsInventoryTrans(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public SP_PhysicalStockLine_Insert_Result InsertPhysicalStockCounting(int sequence, string _xml)
        {
            try
            {
                return _dbContext.SP_PhysicalStockLine_Insert(sequence, _xml).FirstOrDefault();
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
                return _dbContext.SP_PhysicalStockTable_Insert(physicalStockXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool HasPendingCounting(EmissionPoint emissionPoint, int UserId) => _dbContext
                .PhysicalStockCountingTable
                .Where(a => a.EmissionPointId == emissionPoint.EmissionPointId
                    && a.Status == "O"
                    && a.CreatedBy == UserId)
                .Any();

        public int GetPendingCounting(EmissionPoint emissionPoint, long UserId) => _dbContext
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
                return _dbContext.SP_PhysicalStockLine_Consult(id).ToList();
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
                POSEntities db = _dbContext;

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
