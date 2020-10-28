using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Transaction
{
    public class ClsAuthorization
    {
        public List<SP_Supervisor_Validate_Result> GetSupervisorAuth(string _barcode)
        {
            var db = new POSEntities();
            List<SP_Supervisor_Validate_Result> result;

            try
            {
                result = db.SP_Supervisor_Validate(_barcode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
