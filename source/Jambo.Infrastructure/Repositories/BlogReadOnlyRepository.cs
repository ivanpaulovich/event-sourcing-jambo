using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Jambo.Infrastructure.Repositories
{
    public class BlogReadOnlyRepository : IBlogReadOnlyRepository
    {
        private readonly BloggingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BlogReadOnlyRepository(BloggingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Blog FindAsync(int id)
        {
            var buyer = _context.Blogs
                .Where(b => b.Id == id)
                .SingleOrDefault();

            return buyer;
        }
    }
}
