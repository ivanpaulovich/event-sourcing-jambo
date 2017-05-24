using System.Data;
using System.Data.SqlClient;

namespace Jambo.InfrastructureDapper
{
    public class OrderingContext
    {
        private string connectionString;

        public OrderingContext(string conn)
        {
            connectionString = conn;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
