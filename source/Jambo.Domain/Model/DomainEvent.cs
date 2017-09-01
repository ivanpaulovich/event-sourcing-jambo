using Jambo.Domain.Model;
using MediatR;
using System;

namespace Jambo.Domain.Model
{
    public abstract class DomainEvent : IRequest
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
