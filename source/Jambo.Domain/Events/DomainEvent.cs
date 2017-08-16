using Jambo.Domain.SeedWork;
using System;

namespace Jambo.Domain.Events
{
    public abstract class DomainEvent : IEvent
    {
        public Guid AggregateRootId { get; set; }
        public int Version { get; set; }

        public DomainEvent(Guid aggregateRootId)
        {
            AggregateRootId = aggregateRootId;
        }

        public DomainEvent(Guid aggregateRootId, int version)
            :this(aggregateRootId)
        {
            Version = version;
        }
    }
}
