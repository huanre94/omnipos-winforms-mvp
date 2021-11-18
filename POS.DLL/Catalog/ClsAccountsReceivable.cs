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
        public List<SP_Advance_Consult_Result> GetPendingAdvances(long _customerId)
        {
            List<SP_Advance_Consult_Result> advances;
            try
            {
                advances = new POSEntities().SP_Advance_Consult(_customerId, "").ToList();
                //    new List<SP_Advance_Consult_Result>();
                //advances.Add(new SP_Advance_Consult_Result { IsSelected = false, AdvanceDate = DateTime.Today, AdvanceAmount = 10 });
                //advances.Add(new SP_Advance_Consult_Result { IsSelected = false, AdvanceDate = DateTime.Today, AdvanceAmount = 20 });
                //advances.Add(new SP_Advance_Consult_Result { IsSelected = false, AdvanceDate = DateTime.Today, AdvanceAmount = 5 });
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
