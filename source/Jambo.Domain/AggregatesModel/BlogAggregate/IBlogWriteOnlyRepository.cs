using Jambo.Domain.SeedWork;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogWriteOnlyRepository
    {
        Task Add(Blog blog);
        Task Update(Blog blog);
    }
}
