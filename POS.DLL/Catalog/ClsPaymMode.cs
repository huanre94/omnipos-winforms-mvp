using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsPaymMode
    {
        public List<Bank> GetBanks()
        {
            var db = new POSEntities();
            List<Bank> banks;

            try
            {

                banks = (
                            from ba in db.Bank
                            where ba.Status == "A"
                            select ba
                        ).ToList();
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
                retentionTable = (
                                from ret in db.RetentionTable
                                where ret.Status == "A"
                                && ret.Type == _retentionType.ToString()
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
            var db = new POSEntities();
            List<CreditCard> creditCards;

            try
            {

                creditCards = (
                                from cre in db.CreditCard
                                join ban in db.BankCreditCard
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
            var db = new POSEntities();
            List<PaymMode> paymModes;

            try
            {

                paymModes = (
                            from pa in db.PaymMode
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
    }
}
