using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.DataAccess.Repositories.Posts
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
