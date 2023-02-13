using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsCustomer
    {
        private readonly string connectionString;

        public ClsCustomer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IdentType> GetIdentTypes()
        {
            try
            {
                return new POSEntities(connectionString)
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
                return new POSEntities(connectionString)
                    .Customer
                    .Where(cust => cust.Status.Equals("A") && cust.Identification == _indentification)
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
                return new POSEntities(connectionString)
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
            try
            {
                return new POSEntities(connectionString).SP_Customer_Insert(_customerXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FN_Identification_Validate_Result ValidateCustomerIdentification(string _identification, string _idenType)
        {
            FN_Identification_Validate_Result result;

            try
            {
                result = new POSEntities(connectionString).FN_Identification_Validate(_identification, _idenType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public IEnumerable<CustomerAddress> GetCustomerAddressesById(Customer _customer)
        {
            POSEntities db = new POSEntities(connectionString);//07/07/2022  Se incremento linea de la variable
            try
            {
                return new POSEntities(connectionString)
                    .CustomerAddress
                    .Join(db.Customer,
                    cu => cu.CustomerId,
                    ca => ca.CustomerId,
                    (cu, ca) => new { CustomerAddress = cu, Customer = ca })
                    .Where(cuca => cuca.Customer.CustomerId == _customer.CustomerId
                          && cuca.CustomerAddress.Status == "A")
                    .Select(cuca => cuca.CustomerAddress)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_CustomerAddress_Insert_Result CreateCustomerDeliveryAddress(string xml)
        {
            try
            {
                return new POSEntities(connectionString).SP_CustomerAddress_Insert(xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateCustomerDeliveryAddress(CustomerAddress customerAddress)
        {
            POSEntities db = new POSEntities(connectionString);
            try
            {
                CustomerAddress address =
                    db
                    .CustomerAddress
                    .Where(cu => cu.CustomerAddressId == customerAddress.CustomerAddressId && cu.CustomerId == customerAddress.CustomerId)
                    .FirstOrDefault();

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
