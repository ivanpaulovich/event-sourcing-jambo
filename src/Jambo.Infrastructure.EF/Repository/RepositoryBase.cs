namespace Jambo.Infrastructure.EF.Repositories
{
    public class RepositoryBase
    {
        protected readonly VendasContext vendasContext;

        public RepositoryBase(VendasContext vendasContext)
        {
            this.vendasContext = vendasContext;
        }
    }
}
