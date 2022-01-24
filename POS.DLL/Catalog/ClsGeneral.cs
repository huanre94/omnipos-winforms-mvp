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
                emissionPoint = (from em in new POSEntities().EmissionPoint
                                 where em.AddressIP == _addressIP
                                 && em.Status == "A"
                                 select em
                                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return emissionPoint;
        }

        public List<InventLocation> GetMainWarehouseByLocationId(int _locationId)
        {
            List<InventLocation> inventLocation;
            try
            {
                inventLocation = (from inl in new POSEntities().InventLocation
                                  where inl.LocationId == _locationId
                                  && inl.Status == "A"
                                  && inl.IsMain == true
                                  select inl).ToList();
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
