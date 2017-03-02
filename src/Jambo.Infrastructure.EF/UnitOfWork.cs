using Jambo.Core.Interfaces.Domain;

namespace Jambo.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VendasContext vendasContext;

        public UnitOfWork(VendasContext vendasContext)
        {
            this.vendasContext = vendasContext;
        }

        public int SaveChanges()
        {
            int rows = vendasContext.SaveChanges();
            return rows;
        }
    }
}
