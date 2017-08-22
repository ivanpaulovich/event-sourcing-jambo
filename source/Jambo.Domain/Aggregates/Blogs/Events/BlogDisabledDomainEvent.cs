using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class BlogDisabledDomainEvent : DomainEvent
    {
        public BlogDisabledDomainEvent(Guid aggregateRootId, int version)
            :base(aggregateRootId, version)
        {
        }
    }
}
