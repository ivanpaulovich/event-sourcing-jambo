using MediatR;
using System;

namespace Jambo.Domain.ServiceBus
{
    public abstract class DomainEvent : INotification
    {
        public Guid AggregateRootId { get; set; }
        public int Version { get; set; }
        public DateTime Date { get; set; }
        public Guid CorrelationId { get; set; }

        public DomainEvent(Guid aggregateRootId)
        {
            AggregateRootId = aggregateRootId;
        }

        public DomainEvent(Guid aggregateRootId, int version)
            :this(aggregateRootId)
        {
            Version = version;
            Date = DateTime.Now;
        }
    }
}
