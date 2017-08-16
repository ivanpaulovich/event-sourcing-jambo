using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class EnabledBlogDomainEvent : DomainEvent
    {
        public EnabledBlogDomainEvent(Guid aggregateRootId, int version)
            :base(aggregateRootId, version)
        {
        }
    }
}
