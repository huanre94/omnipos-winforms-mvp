using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Catalog
{
    public class ClsAccountsReceivable
    {
        /// <summary>
        /// Show a list of pending active advances by customerid
        /// </summary>
        /// <param name="customer">Current customer filter</param>
        public List<SP_Advance_Consult_Result> GetPendingAdvances(long _customerId, int paymmodeId)
        {
            List<SP_Advance_Consult_Result> advances;
            try
            {
                advances = new POSEntities().SP_Advance_Consult(_customerId, paymmodeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return advances;
        }

        /// <summary>
        /// Show a list of pending active credit notes by customer
        /// </summary>
        public void GetPendingCreditNotes(long _customerId)
        {

        }
    }
}
