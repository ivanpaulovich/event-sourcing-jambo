using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.DataAccess.Repositories.Posts
{
    public class PostReadOnlyRepository : IPostReadOnlyRepository
    {
        private readonly MongoContext _mongoContext;

        public PostReadOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<IEnumerable<Post>> GetBlogPosts(Guid blogId)
        {
            return await _mongoContext.Posts.Find(e => e.BlogId == blogId).ToListAsync();
        }

        public async Task<Post> GetPost(Guid id)
        {
            return await _mongoContext.Posts.Find(e => e.Id == id).SingleAsync();
        }
    }
}
