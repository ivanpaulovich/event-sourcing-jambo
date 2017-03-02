using Jambo.Core.Interfaces.Repository;

namespace Jambo.Infrastructure.Dapper.Repository
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
