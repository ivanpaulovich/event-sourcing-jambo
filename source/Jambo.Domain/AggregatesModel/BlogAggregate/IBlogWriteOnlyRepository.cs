using Jambo.Domain.SeedWork;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository : IRepository<Blog>
    {
        void PublishEvents(Blog blog);
    }
}
