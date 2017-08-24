using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostEnabledDomainEvent : DomainEvent
    {
        public PostEnabledDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {

        }
    }
}
