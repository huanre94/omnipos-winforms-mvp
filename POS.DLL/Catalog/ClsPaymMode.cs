using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        private readonly string connectionString;

        public ClsPaymMode(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Bank> GetBanks()
        {
            try
            {
                return
                    new POSEntities(connectionString)
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

        public IEnumerable<RetentionTable> GetRetentionTables(int _retentionType)
        {
            try
            {
                return
                     new POSEntities(connectionString)
                     .RetentionTable
                     .Where(ret => ret.Status.Equals("A") && ret.Type == $"{_retentionType}")
                     .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true)
        {
            POSEntities db = new POSEntities(connectionString);
            try
            {
                return
                    db.CreditCard
                    .Join(db.BankCreditCard,
                        cre => cre.CreditCardId,
                        ban => ban.CreditCardId,
                        (cre, ban) => new { CreditCard = cre, BankCreditCard = ban })
                    .Where(creban => creban.CreditCard.Status == "A"
                                   && creban.BankCreditCard.BankId == _bankId
                                   && creban.CreditCard.IsCredit == _isCredit)
                    .Select(creban => creban.CreditCard)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PaymMode> GetPaymModes()
        {
            try
            {
                return
                    new POSEntities(connectionString)
                    .PaymMode
                    .Where(pa => pa.Status.Equals("A"))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetPromotionsCount(long _customerId, int _bankId, int _cardBrandId)
        {
            try
            {
                return (long)new POSEntities(connectionString).SP_PromotionPaymmode_Consult(_customerId, (short?)_bankId, (short?)_cardBrandId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
