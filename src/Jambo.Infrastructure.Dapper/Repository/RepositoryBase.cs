using Jambo.Core.Interfaces.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Jambo.Infrastructure.Dapper.Repositories
{
    public class RepositoryBase
    {
        protected readonly IRepositorySettings repositorySettings;

        public RepositoryBase(
            IRepositorySettings repositorySettings)
        {
            this.RepositoriesSettings = repositorySettings;
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
