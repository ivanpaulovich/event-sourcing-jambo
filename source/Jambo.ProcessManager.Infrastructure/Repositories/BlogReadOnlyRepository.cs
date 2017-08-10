using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.ProcessManager.Infrastructure.Repositories
{
    public class BlogReadOnlyRepository : IBlogReadOnlyRepository
    {
        private readonly BloggingContext _context;

        public BlogReadOnlyRepository(BloggingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _context.Blogs.Find(e => true).ToListAsync();
        }

        public async Task<Blog> FindAsync(Guid id)
        {
            return await _context.Blogs.Find(e => e.Id == id).SingleOrDefaultAsync();
        }
    }
}
