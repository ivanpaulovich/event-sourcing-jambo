using Jambo.Core.Interfaces.Repository;

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
    }
}
