namespace Jambo.Domain.Model.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostReadOnlyRepository
    {
        Task<IEnumerable<Post>> GetBlogPosts(Guid blogId);
        Task<Post> GetPost(Guid id);
    }
}
