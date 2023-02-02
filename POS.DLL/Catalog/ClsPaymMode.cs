using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        public IEnumerable<Bank> GetBanks()
        {
            IEnumerable<Bank> banks;

            try
            {
                banks =
                    new POSEntities()
                    .Bank
                    .Where(ba => ba.Status.Equals("A"))
                    .OrderBy(ba => ba.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return banks;
        }

        public IEnumerable<RetentionTable> GetRetentionTables(int _retentionType)
        {
            IEnumerable<RetentionTable> retentionTable;

            try
            {
                retentionTable =
                    new POSEntities()
                    .RetentionTable
                    .Where(ret => ret.Status.Equals("A") && ret.Type == $"{_retentionType}")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return retentionTable;
        }

        public IEnumerable<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true)
        {
            IEnumerable<CreditCard> creditCards;

            var db = new POSEntities();
            try
            {
                creditCards =
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

            return creditCards;
        }

        public List<PaymMode> GetPaymModes()
        {
            List<PaymMode> paymModes;

            try
            {
                paymModes =
                    new POSEntities()
                    .PaymMode
                    .Where(pa => pa.Status == "A")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymModes;
        }

        public long GetPromotionsCount(long _customerId, int _bankId, int _cardBrandId)
        {
            long promotionPaymMode;

            try
            {
                promotionPaymMode = (long)new POSEntities().SP_PromotionPaymmode_Consult(_customerId, (short?)_bankId, (short?)_cardBrandId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return promotionPaymMode;
        }
    }
}
