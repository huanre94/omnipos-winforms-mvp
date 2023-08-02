using System;
using System.Linq;

namespace POS.DLL.Repository
{
    public class SalesOriginRepository : BaseRepository
    {
        readonly POSEntities _dbContext;

        public SalesOriginRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public bool ConsultSalesOriginCredit(int salesOriginId)
        {
            try
            {
                return _dbContext
                    .SalesOrigin
                    .Where(so => so.SalesOriginId == salesOriginId)
                    .Select(so => so.AllowCredit)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
