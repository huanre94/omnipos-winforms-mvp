using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class ClsAuthorizationTrans
    {
        public SP_Supervisor_Validate_Result GetSupervisorAuth(string _barcode, string _password)
        {
            SP_Supervisor_Validate_Result result;
            try
            {
                result = new POSEntities().SP_Supervisor_Validate(_barcode, _password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public SP_GaranCheck_Authorize_Result GetGaranCheckAuth(int _bankId
                                                                    , string _accountNumber
                                                                    , int _checkNumber
                                                                    , decimal _checkAmount
                                                                    , string _identificacion
                                                                    , string _ownerName
                                                                    , string _phone
                                                                    , string _reference
                                                                )
        {
            SP_GaranCheck_Authorize_Result result;

            try
            {
                result = new POSEntities().SP_GaranCheck_Authorize(
                                                    _bankId
                                                    , _accountNumber
                                                    , _checkNumber
                                                    , _checkAmount
                                                    , _identificacion
                                                    , _ownerName
                                                    , _phone
                                                    , _reference
                                                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public IEnumerable<CancelReason> ConsultReasons(int _reasonType)
        {
            try
            {
                return new POSEntities()
                    .CancelReason
                    .Where(re => re.Status.Equals("A") && re.ReasonType == _reasonType)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
