using Jambo.Core.Interfaces.Repositories;

namespace Jambo.Infrastructure.Dapper.Repositories
{
    public class RepositorySettings : IRepositorySettings
    {
        public string ConnectionString { get; private set; }

        public RepositorySettings(string connectionString)
        {
            this.ConnectionString = connectionString;
        }     
    }
}
