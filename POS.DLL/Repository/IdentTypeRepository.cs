using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class IdentTypeRepository
    {
        readonly POSEntities _dbContext;

        public IdentTypeRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<IdentType> GetIdentTypes()
        {
            try
            {
                return _dbContext
                     .IdentType
                     .Where(ide => ide.Status.Equals("A") && ide.IdentTypeId != 5)
                     .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}