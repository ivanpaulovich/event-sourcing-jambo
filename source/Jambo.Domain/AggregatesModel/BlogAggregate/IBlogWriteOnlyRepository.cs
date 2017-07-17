using Jambo.Domain.SeedWork;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository : IRepository<Blog>
    {
        Blog Add(Blog buyer);
        Blog Update(Blog buyer);
    }
}
