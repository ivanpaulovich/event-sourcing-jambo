using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using System;

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

        public Blog Add(Blog blog)
        {
            if (blog.IsTransient())
            {
                //TODO: when migrating to ef core 1.1.1 change Add by AddAsync-. A bug in ef core 1.1.0 does not allow to do it https://github.com/aspnet/EntityFramework/issues/7298 
                return _context.Blogs
                    .Add(blog)
                    .Entity;
            }
            else
            {
                return blog;
            }
        }

        public Blog Update(Blog blog)
        {
            return _context.Blogs
                    .Update(blog)
                    .Entity;
        }

        public void Delete(Blog blog)
        {
            _context.Blogs.Attach(blog);
            _context.Blogs.Remove(blog);
        }
    }
}
