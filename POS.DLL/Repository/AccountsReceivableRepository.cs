using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace POS.DLL.Catalog
{
    public class AccountsReceivableRepository
    {
        readonly POSEntities _dbContext;

        public AccountsReceivableRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        /// <summary>
        /// Show a list of pending active advances by customerid
        /// </summary>
        /// <param name="customer">Current customer filter</param>
        public List<SP_Advance_Consult_Result> GetPendingAccountReceivable(long _customerId, PaymModeEnum paymmodeId)
        {
            try
            {
                List<SP_Advance_Consult_Result> advances = _dbContext.SP_Advance_Consult(_customerId, (int)paymmodeId, "").ToList();
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

        public SP_Advance_Insert_Result AddAdvance(XElement _advanceXml)
        {
            try
            {
                return _dbContext.SP_Advance_Insert($"{_advanceXml}").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
