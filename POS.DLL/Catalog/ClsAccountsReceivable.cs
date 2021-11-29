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
        public List<SP_Advance_Consult_Result> GetPendingAccountReceivable(long _customerId, int paymmodeId)
        {
            List<SP_Advance_Consult_Result> advances;
            try
            {
                advances = new POSEntities().SP_Advance_Consult(_customerId, paymmodeId).ToList();
                if (advances.Count == 0)
                {
                    advances = new List<SP_Advance_Consult_Result>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            return advances;
        }
    }
}
