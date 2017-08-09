using System.Data;
using System.Data.SqlClient;

namespace Jambo.SQLServerBus
{
    public class MessagingContext
    {
        private string connectionString;
        public MessagingContext(string conn)
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
