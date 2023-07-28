using System;
using System.Linq;

namespace POS.DLL.Repository
{
    public class PromotionRepository
    {
        readonly POSEntities _dbContext;

        public PromotionRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public long GetPromotionsCount(long _customerId, int _bankId, int _cardBrandId)
        {
            try
            {
                return (long)_dbContext
                    .SP_PromotionPaymmode_Consult(_customerId, (short?)_bankId, (short?)_cardBrandId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
