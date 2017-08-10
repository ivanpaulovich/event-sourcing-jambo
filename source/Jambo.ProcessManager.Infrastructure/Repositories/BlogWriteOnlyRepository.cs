using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Jambo.ProcessManager.Infrastructure.Repositories
{
    public class BlogWriteOnlyRepository : IBlogWriteOnlyRepository
    {
        private readonly BloggingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BlogWriteOnlyRepository(BloggingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Blog blog)
        {
            await _context.Blogs.InsertOneAsync(blog);
        }

        public async Task Update(Blog blog)
        {
            await _context.Blogs.ReplaceOneAsync(p => p.Id == blog.Id, blog);
        }

        public async Task Delete(Blog blog)
        {
            await _context.Blogs.DeleteOneAsync(p => p.Id == blog.Id);
        }
    }
}
