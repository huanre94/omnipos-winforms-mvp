using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Transaction
{
    public class ClsCustomer
    {
        public List<SP_InternalCreditCard_Consult_Result> GetInternalCreditCard(string _creditCardCode)
        {
            var db = new POSEntities();
            List<SP_InternalCreditCard_Consult_Result> result = null;

            try
            {
                result = db.SP_InternalCreditCard_Consult(0, _creditCardCode, "", "", "").ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<SP_GiftCard_Consult_Result> GetGiftCard(long _giftCard)
        {
            var db = new POSEntities();
            List<SP_GiftCard_Consult_Result> result = null;

            try
            {
                result = db.SP_GiftCard_Consult(_giftCard).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
