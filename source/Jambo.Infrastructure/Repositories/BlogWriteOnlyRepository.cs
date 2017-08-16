using Jambo.Domain.AggregatesModel.BlogAggregate;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Jambo.Domain.SeedWork;

namespace Jambo.Infrastructure.Repositories
{
    public class BlogWriteOnlyRepository : IBlogWriteOnlyRepository
    {
        private readonly MongoContext _mongoContext;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public BlogWriteOnlyRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task Add(Blog blog)
        {
            await _mongoContext.Blogs.InsertOneAsync(blog);
        }

        public async Task Update(Blog blog)
        {
            await _mongoContext.Blogs.ReplaceOneAsync(e => e.Id == blog.Id, blog);
        }
    }
}
