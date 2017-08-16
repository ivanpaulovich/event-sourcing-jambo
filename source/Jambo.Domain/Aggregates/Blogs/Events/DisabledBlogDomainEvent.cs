using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class DisabledBlogDomainEvent : DomainEvent
    {
        public DisabledBlogDomainEvent(Guid aggregateRootId, int version)
            :base(aggregateRootId, version)
        {
        }
    }
}
