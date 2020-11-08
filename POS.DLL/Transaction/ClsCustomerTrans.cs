using System;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsCustomerTrans
    {
        public SP_InternalCreditCard_Consult_Result GetInternalCreditCard(string _creditCardCode)
        {
            var db = new POSEntities();
            SP_InternalCreditCard_Consult_Result result;

            try
            {
                result = db.SP_InternalCreditCard_Consult(0, _creditCardCode, "", "", "").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public SP_GiftCard_Consult_Result GetGiftCard(string _giftCard)
        {
            var db = new POSEntities();
            SP_GiftCard_Consult_Result result;
            try
            {
                result = db.SP_GiftCard_Consult(_giftCard).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
