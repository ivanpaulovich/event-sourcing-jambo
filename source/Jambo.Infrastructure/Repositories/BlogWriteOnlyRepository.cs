using Jambo.Domain.Aggregates.Blogs;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.Infrastructure.Repositories
{
    public class BlogWriteOnlyRepository : IBlogWriteOnlyRepository
    {
        private readonly MongoContext _mongoContext;
        public BlogWriteOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task AddBlog(Blog blog)
        {
            await _mongoContext.Blogs.InsertOneAsync(blog);
        }

        public async Task UpdateBlog(Blog blog)
        {
            blog.Version += 1;
            await _mongoContext.Blogs.ReplaceOneAsync(e => e.Id == blog.Id, blog);
        }
    }
}
