using System.Data.Entity;

namespace POS.DLL
{
    public partial class POSEntities : DbContext
    {
        public POSEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}