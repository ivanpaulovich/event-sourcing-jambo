using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class PostPublishedDomainEvent : DomainEvent
    {
        public PostPublishedDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {
        }
    }
}
