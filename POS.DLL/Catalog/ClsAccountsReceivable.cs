using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsAccountsReceivable
    {
        readonly string connectionString;

        public ClsAccountsReceivable(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Show a list of pending active advances by customerid
        /// </summary>
        /// <param name="customer">Current customer filter</param>
        public List<SP_Advance_Consult_Result> GetPendingAccountReceivable(long _customerId, PaymModeEnum paymmodeId)
        {
            try
            {
                List<SP_Advance_Consult_Result> advances = new POSEntities(connectionString).SP_Advance_Consult(_customerId, (int)paymmodeId, "").ToList();
                if (advances?.Count() == 0)
                {
                    advances = new List<SP_Advance_Consult_Result>();
                }

                return advances;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
