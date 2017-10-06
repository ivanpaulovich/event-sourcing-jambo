using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.DataAccess.Repositories.Blogs
{
    public class BlogReadOnlyRepository : IBlogReadOnlyRepository
    {
        private readonly MongoContext _mongoContext;

        public BlogReadOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _mongoContext.Blogs.Find(e => true).ToListAsync();
        }

        public async Task<Blog> GetBlog(Guid id)
        {
            return await _mongoContext.Blogs.Find(e => e.Id == id).SingleAsync();
        }
    }
}
