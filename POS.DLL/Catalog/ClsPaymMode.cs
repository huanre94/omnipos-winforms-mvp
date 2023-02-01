using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        public IEnumerable<Bank> GetBanks(String CadenaC = "")
        {
            IEnumerable<Bank> banks;

            try
            {
                banks = (from ba in new POSEntities(CadenaC).Bank
                         where ba.Status == "A"
                         select ba
                        ).OrderBy(ba => ba.Name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return banks;
        }

        public List<RetentionTable> GetRetentionTables(int _retentionType, string CadenaC = "")
        {
            var db = new POSEntities(CadenaC);
            List<RetentionTable> retentionTable;

            try
            {
                retentionTable = (from ret in new POSEntities(CadenaC).RetentionTable
                                  where ret.Status == "A"
                                  && ret.Type == $"{_retentionType}"
                                  select ret
                                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return retentionTable;
        }

        public IEnumerable<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true, string CadenaC = "")
        {
            IEnumerable<CreditCard> creditCards;
            var db = new POSEntities(CadenaC);
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

        public List<PaymMode> GetPaymModes(string CadenaC = "")
        {
            List<PaymMode> paymModes;

            try
            {
                paymModes =
                    new POSEntities(CadenaC)
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

        public long GetPromotionsCount(long _customerId, int _bankId, int _cardBrandId, string CadenaC = "")
        {
            long promotionPaymMode;

            try
            {
                promotionPaymMode = (long)new POSEntities(CadenaC).SP_PromotionPaymmode_Consult(_customerId, (short?)_bankId, (short?)_cardBrandId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return promotionPaymMode;
        }
    }
}
