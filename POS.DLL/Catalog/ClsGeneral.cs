using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsGeneral
    {
        private readonly string connectionString;

        public ClsGeneral(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<GlobalParameter> GetGlobalParameters()
        {
            try
            {
                return new POSEntities(connectionString).GlobalParameter.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GlobalParameter GetParameterByName(string _name)
        {
            try
            {
                return new POSEntities(connectionString).GlobalParameter.Where(gp => gp.Name == _name && gp.Status == "A").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmissionPoint GetEmissionPointByIP(string _addressIP)
        {
            try
            {
                return
                    new POSEntities(connectionString)
                    .EmissionPoint
                    .Where(em => em.AddressIP == _addressIP && em.Status.Equals("A"))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<InventLocation> GetMainWarehouseByLocationId(int _locationId)
        {
            try
            {
                return
                    new POSEntities(connectionString)
                    .InventLocation
                    .Where(inl => inl.LocationId == _locationId && inl.Status.Equals("A") && inl.IsMain == true)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SequenceTable GetSequenceByEmissionPointId(int _emissionPointId, int _locationId, int _sequenceType)
        {
            try
            {
                return new POSEntities(connectionString)
                    .SequenceTable
                    .Where(seq => seq.EmissionPointId == _emissionPointId
                                 && seq.LocationId == _locationId
                                 && seq.SequenceTypeId == _sequenceType
                                 && seq.Status == "A")
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string GetActiveTax()
        {
            try
            {
                return new POSEntities(connectionString)
                    .TaxTable
                    .Where(t => t.Status.Equals("A"))
                    .Select(t => t.TaxValue)
                    .FirstOrDefault()
                    .ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
