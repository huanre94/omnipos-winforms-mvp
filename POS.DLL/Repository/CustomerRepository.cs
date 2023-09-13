using POS.DLL.Contracts;
using POS.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        public CustomerRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public Customer GetCustomerByIdentification(string _indentification)
        {
            try
            {
                var customer =
                    _dbContext
                    .Customer
                    .Where(cust => cust.Status.Equals("A") && cust.Identification == _indentification)
                    .FirstOrDefault();

                return customer;
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
                return _dbContext
                    .Customer
                    .Where(cust => cust.Status.Equals("A") && cust.CustomerId == _customerId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO: Cambiar la logica para no usar sql
        public SP_Customer_Insert_Result CreateOrUpdateCustomer(string _customerXml)
        {
            try
            {
                return _dbContext.SP_Customer_Insert(_customerXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FN_Identification_Validate_Result ValidateCustomerIdentification(string _identification, string _idenType)
        {

            try
            {
                return _dbContext.FN_Identification_Validate(_identification, _idenType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CustomerAddress> GetCustomerAddressesById(Customer _customer)
        {
            POSEntities db = _dbContext;//07/07/2022  Se incremento linea de la variable
            try
            {
                var addresses = db
                    .CustomerAddress
                    .Join(db.Customer,
                    cu => cu.CustomerId,
                    ca => ca.CustomerId,
                    (cu, ca) => new { CustomerAddress = cu, Customer = ca })
                    .Where(cuca => cuca.Customer.CustomerId == _customer.CustomerId
                          && cuca.CustomerAddress.Status == "A")
                    .Select(cuca => cuca.CustomerAddress)
                    .ToList();

                return addresses;
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
                return _dbContext.SP_CustomerAddress_Insert(xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO: Nueva logica para insertar nuevas direcciones
        public bool CreateCustomerDeliveryAddress(CustomerAddress newAddress)
        {
            try
            {
                POSEntities db = _dbContext;
                db.CustomerAddress.Add(newAddress);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateCustomerDeliveryAddress(CustomerAddress customerAddress)
        {
            POSEntities db = _dbContext;
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
