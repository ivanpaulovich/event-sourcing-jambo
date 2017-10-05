using Jambo.Domain.Model.Blogs;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.DataAccess.Repositories.Blogs
{
    public class BlogWriteOnlyRepository : IBlogWriteOnlyRepository
    {
        private readonly MongoContext mongoContext;
        public BlogWriteOnlyRepository(MongoContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task AddBlog(Blog blog)
        {
            await mongoContext.Blogs.InsertOneAsync(blog);
        }

        public async Task UpdateBlog(Blog blog)
        {
            await mongoContext.Blogs.ReplaceOneAsync(e => e.Id == blog.Id, blog);
        }
    }
}
