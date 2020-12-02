using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Transaction
{
    public class ClsSalesOrderTrans
    {
        public List<SP_SalesOrigin_Consult_Result> GetSalesOrigins()
        {
            List<SP_SalesOrigin_Consult_Result> salesOrigins;
            var db = new POSEntities();
            try
            {
                salesOrigins = db.SP_SalesOrigin_Consult().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salesOrigins;
        }
    }
}
