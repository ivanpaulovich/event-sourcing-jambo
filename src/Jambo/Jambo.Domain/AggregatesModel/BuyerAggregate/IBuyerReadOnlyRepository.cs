using Jambo.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BuyerAggregate
{
    public interface IBuyerReadOnlyRepository
    {
        IEnumerable<Buyer> Find(string BuyerIdentityGuid);
    }
}
