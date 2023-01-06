using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        public List<Bank> GetBanks(String CadenaC = "")
        {
            List<Bank> banks;

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

        public List<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true, string CadenaC = "")
        {
            List<CreditCard> creditCards;
            var DB = new POSEntities(CadenaC);
            try
            {

                creditCards = (from cre in DB.CreditCard
                               join ban in DB.BankCreditCard
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

        public List<PaymMode> GetPaymModes(string CadenaC = "")
        {
            List<PaymMode> paymModes;

            try
            {

                paymModes = (from pa in new POSEntities(CadenaC).PaymMode
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
