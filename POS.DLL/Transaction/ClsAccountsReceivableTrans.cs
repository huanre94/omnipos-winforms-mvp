using System;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Transaction
{
    public class ClsAccountsReceivableTrans
    {
        public SP_Advance_Insert_Result AddAdvance(XElement _advanceXml)
        {
            SP_Advance_Insert_Result result;
            try
            {
                result = new POSEntities().SP_Advance_Insert($"{_advanceXml}").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return result;
        }
    }
}
