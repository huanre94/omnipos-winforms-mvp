using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsGeneral
    {
        readonly POSEntities _dbContext;

        public ClsGeneral(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public IEnumerable<GlobalParameter> GetGlobalParameters()
        {
            try
            {
                return _dbContext.GlobalParameter.ToList();
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
                return _dbContext
                    .GlobalParameter
                    .Where(gp => gp.Name == _name && gp.Status.Equals("A"))
                    .FirstOrDefault();
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
                    _dbContext
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
                    _dbContext
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
                return _dbContext
                    .SequenceTable
                    .Where(seq => seq.EmissionPointId == _emissionPointId
                                 && seq.LocationId == _locationId
                                 && seq.SequenceTypeId == _sequenceType
                                 && seq.Status.Equals("A"))
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
                return _dbContext
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
