using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SequenceTable GetSequenceByEmissionPointId(int _emissionPointId)
        {
            var db = new POSEntities();
            SequenceTable sequenceTable;

            try
            {

                sequenceTable = (
                                    from seq in db.SequenceTable
                                    where seq.EmissionPointId == _emissionPointId
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
