using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Transaction
{
    public class ClsAuthorizationTrans
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

        public List<SP_GaranCheck_Authorize_Result> GetGaranCheckAuth(
                                                                        int _bankId
                                                                        , string _accountNumber
                                                                        , int _checkNumber                                                                    
                                                                        , decimal _checkAmount
                                                                        , string _identificacion
                                                                        , string _ownerName
                                                                        , string _phone
                                                                        , string _reference
                                                                    )
        {
            var db = new POSEntities();
            List<SP_GaranCheck_Authorize_Result> result;

            try
            {
                result = db.SP_GaranCheck_Authorize(
                                                    _bankId
                                                    , _accountNumber
                                                    , _checkNumber
                                                    , _checkAmount
                                                    , _identificacion
                                                    , _ownerName
                                                    , _phone
                                                    , _reference
                                                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
