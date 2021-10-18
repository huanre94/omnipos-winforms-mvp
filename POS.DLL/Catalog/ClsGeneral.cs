using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Catalog
{
    public class ClsGeneral
    {
        public List<GlobalParameter> GetGlobalParameters()
        {
            var db = new POSEntities();
            List<GlobalParameter> globalParameters;

            try
            {

                globalParameters = (
                                    from par in db.GlobalParameter
                                    select par
                                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return globalParameters;
        }

        public GlobalParameter GetParameterByName(string _name)
        {
            var db = new POSEntities();
            GlobalParameter parameter;

            try
            {

                parameter = (
                                from par in db.GlobalParameter
                                where par.Name == _name
                                && par.Status == "A"
                                select par
                            ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return parameter;
        }

        public EmissionPoint GetEmissionPointByIP(string _addressIP)
        {
            var db = new POSEntities();
            EmissionPoint emissionPoint;

            try
            {

                emissionPoint = (
                                    from em in db.EmissionPoint
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

        //public SequenceTable GetSequenceByEmissionPointId(int _emissionPointId)
        //{
        //    var db = new POSEntities();
        //    SequenceTable sequenceTable;

        //    try
        //    {

        //        sequenceTable = (
        //                            from seq in db.SequenceTable
        //                            where seq.EmissionPointId == _emissionPointId
        //                            && seq.Status == "A"
        //                            select seq
        //                            ).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return sequenceTable;
        //}

        public List<InventLocation> GetMainWarehouseByLocationId(int _locationId)
        {
            var pos = new POSEntities();
            List<InventLocation> inventLocation;
            try
            {
                inventLocation = (from inl in pos.InventLocation
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
            var db = new POSEntities();
            SequenceTable sequenceTable;

            try
            {
                sequenceTable = (
                                                 from seq in db.SequenceTable
                                                 where seq.EmissionPointId == _emissionPointId
                                                 && seq.LocationId == _locationId
                                                 && seq.SequenceTypeId == _sequenceType
                                                 && seq.Status == "A"
                                                 select seq
                                                 ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sequenceTable;
        }
    }
}
