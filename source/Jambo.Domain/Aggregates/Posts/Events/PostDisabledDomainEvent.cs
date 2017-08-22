using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class PostDisabledDomainEvent : DomainEvent
    {
        public PostDisabledDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {

        }
    }
}
