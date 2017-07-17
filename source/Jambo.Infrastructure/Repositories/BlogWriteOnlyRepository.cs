using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Infrastructure.Repositories
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
    }
}
