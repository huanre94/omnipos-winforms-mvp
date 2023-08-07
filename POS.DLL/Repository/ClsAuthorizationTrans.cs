using POS.DLL.Repository;
using System;
using System.Linq;

namespace POS.DLL.Repository
{
    public class ClsAuthorizationTrans : BaseRepository
    {
        public ClsAuthorizationTrans(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public SP_Supervisor_Validate_Result GetSupervisorAuth(string _barcode, string _password)
        {
            try
            {
                return _dbContext.SP_Supervisor_Validate(_barcode, _password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_GaranCheck_Authorize_Result GetGaranCheckAuth(int _bankId
                                                                    , string _accountNumber
                                                                    , int _checkNumber
                                                                    , decimal _checkAmount
                                                                    , string _identificacion
                                                                    , string _ownerName
                                                                    , string _phone
                                                                    , string _reference)
        {
            try
            {
                return _dbContext
                    .SP_GaranCheck_Authorize(_bankId,
                    _accountNumber,
                    _checkNumber,
                    _checkAmount,
                    _identificacion,
                    _ownerName,
                    _phone,
                    _reference).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
