using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;

namespace Jambo.Domain.Events
{
    public class BlogCriadoDomainEvent : INotification
    {
        public Blog Blog { get; private set; }

        public BlogCriadoDomainEvent(Blog blog)
        {
            Blog = blog;
        }
    }
}
