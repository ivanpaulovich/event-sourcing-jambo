using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogEventRepository : IRepository<Blog>
    {
        Task PublishEvents(Blog blog);
    }
}
