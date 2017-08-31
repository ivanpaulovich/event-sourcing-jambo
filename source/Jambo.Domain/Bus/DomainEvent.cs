using Jambo.Domain.Aggregates;
using MediatR;
using System;

namespace Jambo.Domain.ServiceBus
{
    public abstract class DomainEvent : INotification
    {
        public Guid AggregateRootId { get; set; }
        public int Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CorrelationId { get; set; }
        public string UserName { get; set; }

        public DomainEvent()
        {

        }

        public DomainEvent(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot.Id == Guid.Empty)
                AggregateRootId = Guid.NewGuid();
            else
                AggregateRootId = aggregateRoot.Id;

            Version = aggregateRoot.Version;
            CreatedDate = DateTime.Now;
        }
    }
}
