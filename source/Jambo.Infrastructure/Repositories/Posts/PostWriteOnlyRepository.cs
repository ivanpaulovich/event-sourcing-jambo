using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Posts;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.Infrastructure.Repositories.Posts
{
    public class PostWriteOnlyRepository : IPostWriteOnlyRepository
    {
        private readonly MongoContext _mongoContext;
        public PostWriteOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task AddPost(Post post)
        {
            await _mongoContext.Posts.InsertOneAsync(post);
        }

        public async Task UpdatePost(Post post)
        {
            await _mongoContext.Posts.ReplaceOneAsync(e => e.Id == post.Id, post);
        }
    }
}
