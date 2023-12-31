﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.DLL.Repository
{
    public class SalesOriginRepository : BaseRepository
    {
        public SalesOriginRepository(string connectionString)
        {
            _dbContext = new POSEntities(connectionString);
        }

        public bool ConsultSalesOriginCredit(int salesOriginId)
        {
            try
            {
                return _dbContext
                    .SalesOrigin
                    .Where(so => so.SalesOriginId == salesOriginId)
                    .Select(so => so.AllowCredit)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SalesOrigin> GetSalesOrigins()
        {
            try
            {
                //return _dbContext.SP_SalesOrigin_Consult().ToList();
                return _dbContext
                    .SalesOrigin
                    .Where(s => s.SalesOriginId != 2 && s.IsECommerce == false)
                    //.Select(s => new { s.SalesOriginId, s.Name, s.SalesmanId })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
