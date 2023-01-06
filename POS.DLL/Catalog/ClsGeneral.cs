using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsGeneral
    {
        
        public List<GlobalParameter> GetGlobalParameters(string CadenaC = "")
        {
            List<GlobalParameter> globalParameters;

            try
            {
                globalParameters = new POSEntities(CadenaC).GlobalParameter.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return globalParameters;
        }

        public GlobalParameter GetParameterByName(string _name, string CadenaC = "")
        {
            GlobalParameter parameter;

            try
            {
                parameter = new POSEntities(CadenaC).GlobalParameter.Where(gp => gp.Name == _name && gp.Status == "A").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return parameter;
        }

        public EmissionPoint GetEmissionPointByIP(string _addressIP, string CadenaC = "")
        {
            EmissionPoint emissionPoint;

            try
            {
                emissionPoint = (from em in new POSEntities(CadenaC).EmissionPoint
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

        public List<InventLocation> GetMainWarehouseByLocationId(int _locationId, string _CadenaC = "")
        {
            List<InventLocation> inventLocation;
            try
            {
                inventLocation = (from inl in new POSEntities(_CadenaC).InventLocation
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

        public SequenceTable GetSequenceByEmissionPointId(int _emissionPointId, int _locationId, int _sequenceType, string _CadenaC = "")
        {
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = new POSEntities(_CadenaC)
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
