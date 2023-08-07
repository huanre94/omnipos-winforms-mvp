using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Repository
{
    public class ClsPaymMode : BaseRepository
    {
        public ClsPaymMode(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<RetentionTable> GetRetentionTables(int _retentionType)
        {
            try
            {
                return
                     _dbContext
                     .RetentionTable
                     .Where(ret => ret.Status.Equals("A") && ret.Type.Equals($"{_retentionType}"))
                     .AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<CreditCard> GetCreditCardsByBank(int _bankId, bool _isCredit = true)
        {
            POSEntities db = _dbContext;
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
                    _dbContext
                    .PaymMode
                    .Where(pa => pa.Status.Equals("A"))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
