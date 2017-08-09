using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using System;

namespace Jambo.Infrastructure.Repositories
{
    public class BlogWriteOnlyRepository : IBlogWriteOnlyRepository
    {
        private readonly MessagingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BlogWriteOnlyRepository(MessagingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void PublishEvents(Blog blog)
        {
            foreach (var item in blog.Events)
            {
                _context.Add(item);
            }
        }
    }
}
