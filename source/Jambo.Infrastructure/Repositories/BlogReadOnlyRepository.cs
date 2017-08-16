using Jambo.Domain.AggregatesModel.BlogAggregate;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Infrastructure.Repositories
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

        public async Task<Blog> FindAsync(Guid id)
        {
            return await _mongoContext.Blogs.Find(e => e.Id == id).SingleOrDefaultAsync();
        }
    }
}
