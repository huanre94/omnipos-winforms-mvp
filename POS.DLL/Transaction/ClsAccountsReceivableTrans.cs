using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                result = new POSEntities().SP_Advance_Insert(_advanceXml.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return result;
        }

        //public List<> GetInvoiceTicket(long _invoiceId, bool _openCashier = false)
        //{
        //    List<> advanceTicketResult;

        //    try
        //    {
        //        advanceTicketResult = new POSEntities().SP_InvoiceTicket_Consult(_invoiceId, _openCashier).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return advanceTicketResult;
        //}
    }
}
