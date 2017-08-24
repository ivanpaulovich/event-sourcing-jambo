using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostDisabledDomainEvent : DomainEvent
    {
        public PostDisabledDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {

        }
    }
}
