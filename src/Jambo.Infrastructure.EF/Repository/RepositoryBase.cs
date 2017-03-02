namespace Jambo.Infrastructure.EF.Repository
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
