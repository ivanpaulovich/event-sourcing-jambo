using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository : IRepository<Blog>
    {
        Task Add(Blog blog);
        Task Update(Blog blog);
        Task Delete(Blog blog);
    }
}
