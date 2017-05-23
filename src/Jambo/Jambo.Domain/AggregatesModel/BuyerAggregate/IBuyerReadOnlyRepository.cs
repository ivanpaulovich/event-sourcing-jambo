using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BuyerAggregate
{
    public interface IBuyerReadOnlyRepository : IRepository<Buyer>
    {
        Task<Buyer> FindAsync(string BuyerIdentityGuid);
    }
}
