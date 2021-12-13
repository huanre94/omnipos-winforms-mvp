using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        public List<Bank> GetBanks()
        {
            List<Bank> banks;

            try
            {
                banks = (from ba in new POSEntities().Bank
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

        public List<RetentionTable> GetRetentionTables(int _retentionType)
        {
            var db = new POSEntities();
            List<RetentionTable> retentionTable;

            try
            {
                retentionTable = (from ret in new POSEntities().RetentionTable
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

        public List<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true)
        {
            List<CreditCard> creditCards;

            try
            {

                creditCards = (from cre in new POSEntities().CreditCard
                               join ban in new POSEntities().BankCreditCard
                               on cre.CreditCardId equals ban.CreditCardId
                               where cre.Status == "A"
                               && ban.BankId == _bankId
                               && cre.IsCredit == _isCredit
                               select cre
                                ).ToList();
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

                paymModes = (from pa in new POSEntities().PaymMode
                             where pa.Status == "A"
                             select pa
                            ).ToList();
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
