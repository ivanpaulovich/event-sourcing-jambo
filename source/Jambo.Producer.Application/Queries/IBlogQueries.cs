using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface IBlogQueries
    {
        Task<dynamic> GetBlogAsync(Guid id);

        Task<IEnumerable<dynamic>> GetBlogsAsync();
    }
}
