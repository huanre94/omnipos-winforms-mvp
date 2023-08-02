using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Repository
{
    public class BankRepository : BaseRepository
    {

        public BankRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<Bank> GetBanks()
        {
            try
            {
                return
                    _dbContext
                    .Bank
                    .Where(ba => ba.Status.Equals("A"))
                    .OrderBy(ba => ba.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
