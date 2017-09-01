using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public interface IPostQueries
    {
        Task<dynamic> GetPostAsync(Guid id);

        Task<IEnumerable<dynamic>> GetPostsAsync(Guid blogId);
    }
}
