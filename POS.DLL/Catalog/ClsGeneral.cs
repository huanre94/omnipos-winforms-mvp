using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsGeneral
    {

        public List<GlobalParameter> GetGlobalParameters()
        {
            List<GlobalParameter> globalParameters;

            try
            {
                globalParameters = new POSEntities().GlobalParameter.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return globalParameters;
        }

        public GlobalParameter GetParameterByName(string _name)
        {
            GlobalParameter parameter;

            try
            {
                parameter = new POSEntities().GlobalParameter.Where(gp => gp.Name == _name && gp.Status == "A").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return parameter;
        }

        public EmissionPoint GetEmissionPointByIP(string _addressIP)
        {
            EmissionPoint emissionPoint;

            try
            {
                emissionPoint =
                    new POSEntities()
                    .EmissionPoint
                    .Where(em => em.AddressIP == _addressIP && em.Status.Equals("A"))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return emissionPoint;
        }

        public IEnumerable<InventLocation> GetMainWarehouseByLocationId(int _locationId)
        {
            List<InventLocation> inventLocation;
            try
            {
                inventLocation =
                    new POSEntities()
                    .InventLocation
                    .Where(inl => inl.LocationId == _locationId && inl.Status.Equals("A") && inl.IsMain == true)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return inventLocation;
        }

        public SequenceTable GetSequenceByEmissionPointId(int _emissionPointId, int _locationId, int _sequenceType)
        {
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = new POSEntities()
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
            return sequenceTable;
        }
    }
}
