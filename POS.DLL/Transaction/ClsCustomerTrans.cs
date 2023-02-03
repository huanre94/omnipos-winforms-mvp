using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsCustomerTrans
    {
        private readonly string connectionString;

        public ClsCustomerTrans(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SP_InternalCreditCard_Consult_Result GetInternalCreditCard(string _creditCardCode)
        {
            try
            {
                return new POSEntities(connectionString).SP_InternalCreditCard_Consult(0, _creditCardCode, "", "", "").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_GiftCard_Consult_Result GetGiftCard(string _giftCard)
        {
            try
            {
                return new POSEntities(connectionString).SP_GiftCard_Consult(_giftCard).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SP_GiftCard_Consult_Result> GetGiftCardProducts(string _giftCard)
        {
            try
            {
                return new POSEntities(connectionString).SP_GiftCard_Consult(_giftCard).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_GiftCardRedeem_Insert_Result GiftCardRedeemInsert(string GiftCardNumber, string RedeemName, string RedeemIdentification, int RedeemLocation, string ProductGrid)
        {
            try
            {
                return new POSEntities(connectionString).SP_GiftCardRedeem_Insert(GiftCardNumber, RedeemName, RedeemIdentification, RedeemLocation, ProductGrid).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
