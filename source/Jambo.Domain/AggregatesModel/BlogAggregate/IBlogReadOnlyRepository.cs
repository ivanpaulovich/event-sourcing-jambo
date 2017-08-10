using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogReadOnlyRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> FindAsync(Guid id);
    }
}
