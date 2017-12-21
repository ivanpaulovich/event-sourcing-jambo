namespace Jambo.Domain.Model.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogReadOnlyRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> GetBlog(Guid id);
    }
}
