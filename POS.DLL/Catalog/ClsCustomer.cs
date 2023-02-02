using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsCustomer
    {
        public IEnumerable<IdentType> GetIdentTypes()
        {
            try
            {
                return new POSEntities()
                     .IdentType
                     .Where(ide => ide.Status.Equals("A") && ide.IdentTypeId != 5)
                     .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Customer GetCustomerByIdentification(string _indentification)
        {
            try
            {
                return new POSEntities()
                    .Customer
                    .Where(cust => cust.Status == "A" && cust.Identification == _indentification)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Customer GetCustomerById(long _customerId)
        {
            try
            {
                return new POSEntities()
                    .Customer
                    .Where(cust => cust.Status.Equals("A") && cust.CustomerId == _customerId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_Customer_Insert_Result CreateOrUpdateCustomer(string _customerXml)
        {
            SP_Customer_Insert_Result result;

            try
            {
                result = new POSEntities().SP_Customer_Insert(_customerXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public FN_Identification_Validate_Result ValidateCustomerIdentification(string _identification, string _idenType)
        {
            FN_Identification_Validate_Result result;

            try
            {
                result = new POSEntities().FN_Identification_Validate(_identification, _idenType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<CustomerAddress> GetCustomerAddressesById(Customer _customer)
        {
            var db = new POSEntities();//07/07/2022  Se incremento linea de la variable
            List<CustomerAddress> result;
            try
            {
                result = (from ca in db.CustomerAddress
                          join cu in db.Customer on ca.CustomerId equals cu.CustomerId
                          where ca.CustomerId == _customer.CustomerId
                          && ca.Status == "A"
                          select ca).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public SP_CustomerAddress_Insert_Result CreateCustomerDeliveryAddress(string xml)
        {
            SP_CustomerAddress_Insert_Result result;
            try
            {
                result = new POSEntities().SP_CustomerAddress_Insert(xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateCustomerDeliveryAddress(CustomerAddress customerAddress)
        {
            var db = new POSEntities();
            CustomerAddress address;
            try
            {
                address = (from cu in db.CustomerAddress
                           where cu.CustomerAddressId == customerAddress.CustomerAddressId
                           && cu.CustomerId == customerAddress.CustomerId
                           select cu).First();

                address.Address = customerAddress.Address;
                address.AddressReference = customerAddress.AddressReference;
                address.Telephone = customerAddress.Telephone;
                address.ModifiedBy = customerAddress.ModifiedBy;
                address.ModifiedDatetime = customerAddress.ModifiedDatetime;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return db.SaveChanges() > 0;
        }
    }
}
