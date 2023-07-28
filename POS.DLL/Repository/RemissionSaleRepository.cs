using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Transaction
{
    public class RemissionSaleRepository
    {
        readonly POSEntities _dbContext;
        public SP_Login_Consult_Result LoginInformation { get; set; }

        public RemissionSaleRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public SP_SalesOrderRemission_Insert_Result CreateNewRemissionGuide(string _remissionGuideXml)
        {
            try
            {
                return _dbContext.SP_SalesOrderRemission_Insert(_remissionGuideXml).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SP_RemissionGuide_Cancel_Result CancelRemissionGuide(long _remissionId)
        {
            try
            {
                return _dbContext.SP_RemissionGuide_Cancel(_remissionId, LoginInformation.UserId).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<string> GetRemissionGuideTicket(long _remissionGuideId)
        {
            try
            {
                return _dbContext.SP_RemissionGuideTicket_Consult(_remissionGuideId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public SP_RemissionGuideInvoice_Insert_Result FinishRemissionGuide(long _remissionGuideId, int _emissionPointId, int _locationId)
        {
            try
            {
                return _dbContext.SP_RemissionGuideInvoice_Insert(_remissionGuideId, (short?)_emissionPointId, (short?)_locationId, LoginInformation.UserId, LoginInformation.Workstation).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
