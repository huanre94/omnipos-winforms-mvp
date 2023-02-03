using System;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsAccountsReceivableTrans
    {
        private readonly string connectionString;

        public ClsAccountsReceivableTrans(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SP_Advance_Insert_Result AddAdvance(XElement _advanceXml)
        {
            try
            {
                return new POSEntities(connectionString).SP_Advance_Insert($"{_advanceXml}").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
