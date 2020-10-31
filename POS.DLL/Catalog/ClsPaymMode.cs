using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
