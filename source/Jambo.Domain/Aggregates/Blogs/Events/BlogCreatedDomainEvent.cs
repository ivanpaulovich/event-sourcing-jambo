using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class BlogCreatedDomainEvent : DomainEvent
    {
        public BlogCreatedDomainEvent(Guid aggregateRootId)
            :base(aggregateRootId, 0)
        {
        }
    }
}
