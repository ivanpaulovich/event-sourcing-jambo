using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface IBlogQueries
    {
        Task<ExpandoObject> GetBlogAsync(Guid id);

        Task<IEnumerable<ExpandoObject>> GetBlogsAsync();
    }
}
