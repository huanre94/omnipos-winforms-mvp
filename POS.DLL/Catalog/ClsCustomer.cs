using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsCustomer
    {
        public List<IdentType> GetIdentTypes(string CadenaC = "")
        {
            List<IdentType> custIdentTypes;

            try
            {
                custIdentTypes = (from ide in new POSEntities(CadenaC).IdentType
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

        public Customer GetCustomerByIdentification(string _indentification, string CadenaC = "")
        {
            Customer customer;

            try
            {
                customer = (from cust in new POSEntities(CadenaC).Customer
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

        public Customer GetCustomerById(long _customerId, string CadenaC = "")
        {
            Customer customer;

            try
            {
                customer = (from cust in new POSEntities(CadenaC).Customer
                            where cust.Status == "A"
                            && cust.CustomerId == _customerId
                            select cust
                            ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return customer;
        }

        public SP_Customer_Insert_Result CreateOrUpdateCustomer(string _customerXml, string CadenaC = "")
        {
            SP_Customer_Insert_Result result;

            try
            {
                result = new POSEntities(CadenaC).SP_Customer_Insert(_customerXml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public FN_Identification_Validate_Result ValidateCustomerIdentification(string _identification, string _idenType, string _CadenaC = "")
        {
            FN_Identification_Validate_Result result;

            try
            {
                result = new POSEntities(_CadenaC).FN_Identification_Validate(_identification, _idenType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<CustomerAddress> GetCustomerAddressesById(Customer _customer, string _CadenaC = "")
        {
            var db = new POSEntities(_CadenaC);//07/07/2022  Se incremento linea de la variable
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

        public SP_CustomerAddress_Insert_Result CreateCustomerDeliveryAddress(string xml, string CadenaC = "")
        {
            SP_CustomerAddress_Insert_Result result;
            try
            {
                result = new POSEntities(CadenaC).SP_CustomerAddress_Insert(xml).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateCustomerDeliveryAddress(CustomerAddress customerAddress, string CadenaC = "")
        {
            var db = new POSEntities(CadenaC);
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
