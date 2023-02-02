using System;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsAdministration
    {
        private string ConnectionString;

        public ClsAdministration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SP_Login_Consult_Result GetLoginInformation(string _user, string _password, string _workstation, string _addressIP)
        {
            try
            {
                return new POSEntities(ConnectionString)
                       .SP_Login_Consult(_user, _password, _workstation, _addressIP)
                       .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
