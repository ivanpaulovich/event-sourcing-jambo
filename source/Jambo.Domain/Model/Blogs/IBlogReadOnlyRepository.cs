using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.Model.Blogs
{
    public interface IBlogReadOnlyRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> GetBlog(Guid id);
    }
}
