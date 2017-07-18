using Jambo.Domain.SeedWork;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository : IRepository<Blog>
    {
        Blog Add(Blog blog);
        Blog Update(Blog blog);
    }
}
