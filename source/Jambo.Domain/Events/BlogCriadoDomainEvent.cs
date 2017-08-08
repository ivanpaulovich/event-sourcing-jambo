using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;

namespace Jambo.Domain.Events
{
    public class BlogCriadoDomainEvent : IEvent
    {
        public Blog Blog { get; private set; }

        public BlogCriadoDomainEvent(Blog blog)
        {
            Blog = blog;
        }
    }
}
