using POS.DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class CancelReasonRepository
    {
        readonly POSEntities _dbContext;

        public CancelReasonRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<CancelReason> ConsultReasons(CancelReasonType _reasonType)
        {
            try
            {
                return _dbContext
                    .CancelReason
                    .Where(re => re.Status.Equals("A")
                    && re.ReasonType == (int)_reasonType)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}