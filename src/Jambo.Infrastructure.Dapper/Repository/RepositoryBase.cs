using Jambo.Core.Interfaces.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Jambo.Infrastructure.Dapper.Repository
{
    public class RepositoryBase
    {
        protected readonly IRepositorySettings repositorySettings;

        public RepositoryBase(
            IRepositorySettings repositorySettings)
        {
            this.repositorySettings = repositorySettings;
        }

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(repositorySettings.ConnectionString);
            }
        }
    }
}
