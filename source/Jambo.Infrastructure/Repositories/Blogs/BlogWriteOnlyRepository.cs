using Jambo.Domain.Model.Blogs;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.Infrastructure.Repositories.Blogs
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
            await _mongoContext.Blogs.ReplaceOneAsync(e => e.Id == blog.Id, blog);
        }
    }
}
