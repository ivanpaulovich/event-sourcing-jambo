using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface IPostQueries
    {
        Task<ExpandoObject> GetPostAsync(Guid id);

        Task<IEnumerable<ExpandoObject>> GetPostsAsync(Guid blogId);
    }
}
