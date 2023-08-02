using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Repository
{
    public abstract class BaseRepository
    {
        protected POSEntities _dbContext;
    }
}
