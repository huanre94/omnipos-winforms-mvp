using System;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsAdministration
    {
        public SP_Login_Consult_Result GetLoginInformation(
                                                            string _user
                                                            , string _password
                                                            , string _workstation
                                                            , string _addressIP    
                                                            , string _CandenaC
                                                            )
        {
            SP_Login_Consult_Result result;

            try
            {
                result = new POSEntities(_CandenaC).SP_Login_Consult(
                                            _user
                                            , _password
                                            , _workstation
                                            , _addressIP                                            
                                            ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
