using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class PostCreatedDomainEvent : DomainEvent
    {
        public PostCreatedDomainEvent(Guid aggregateRootId)
            :base(aggregateRootId, 0)
        {
        }
    }
}
