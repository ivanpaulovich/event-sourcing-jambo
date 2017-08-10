using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Infrastructure.Repositories
{
    public class BlogEventRepository : IBlogEventRepository
    {
        private readonly MessagingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BlogEventRepository(MessagingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task PublishEvents(Blog blog)
        {
            List<Task> Tasks = new List<Task>();
            foreach (var s in blog.Events)
                Tasks.Add(Task.Run(() => _context.Add(s)));

            await Task.WhenAll(Tasks);
        }
    }
}
