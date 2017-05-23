using Jambo.Domain.AggregatesModel.BuyerAggregate;
using System;
using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.InfrastructureDapper.Repositories
{
    public class BuyerReadOnlyRepository : IBuyerReadOnlyRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Buyer> FindAsync(string BuyerIdentityGuid)
        {
            throw new NotImplementedException();
        }
    }
}
