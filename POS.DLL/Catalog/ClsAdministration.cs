using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Catalog
{
    public class ClsAdministration
    {
        public SP_Login_Consult_Result GetLoginInformation(
                                                            string _user
                                                            , string _password
                                                            , string _workstation
                                                            , string _addressIP
                                                            )
        {
            var db = new POSEntities();
            SP_Login_Consult_Result result;

            try
            {
                result = db.SP_Login_Consult(
                                            _user
                                            , _password
                                            , _workstation
                                            , _addressIP
                                            ).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
