using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostHiddenDomainEvent : DomainEvent
    {
        public PostHiddenDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {
        }
    }
}
