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

        public Blog Add(Blog buyer)
        {
            if (buyer.IsTransient())
            {
                //TODO: when migrating to ef core 1.1.1 change Add by AddAsync-. A bug in ef core 1.1.0 does not allow to do it https://github.com/aspnet/EntityFramework/issues/7298 
                return _context.Blogs
                    .Add(buyer)
                    .Entity;
            }
            else
            {
                return buyer;
            }

        }

        public Blog Update(Blog buyer)
        {
            return _context.Blogs
                    .Update(buyer)
                    .Entity;
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
