using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BuyerAggregate
{
    public interface IBuyerWriteOnlyRepository : IRepository<Buyer>
    {
        Buyer Add(Buyer buyer);
        Buyer Update(Buyer buyer);
    }
}
