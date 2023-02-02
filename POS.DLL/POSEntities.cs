using System.Data.Entity;

namespace POS.DLL.Context
{
    public partial class POSEntities : DbContext
    {
        public POSEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}