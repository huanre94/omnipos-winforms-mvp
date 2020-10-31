using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Catalog
{
    public class ClsCustomer
    {
        public List<IdentType> GetIdentTypes()
        {
            var db = new POSEntities();
            List<IdentType> custIdentTypes;

            try
            {

                custIdentTypes = (
                                    from ide in db.IdentType
                                    where ide.Status == "A"
                                    && ide.IdentTypeId != 5
                                    select ide
                                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return custIdentTypes;
        }

        public Customer GetCustomerByIdentification(string _indentification)
        {
            var db = new POSEntities();
            Customer customer;

            try
            {

                customer = (
                            from cust in db.Customer
                            where cust.Status == "A"
                            && cust.Identification == _indentification
                            select cust
                            ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return customer;
        }

        public bool CreateCustomer(Customer _customer)
        {
            var db = new POSEntities();
            bool response;

            try
            {                
                db.Customer.Add(_customer);

                response = true;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }

            return response;
        }
    }
}
