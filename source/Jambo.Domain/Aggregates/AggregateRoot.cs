using Jambo.Domain.ServiceBus;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates
{
    public abstract class AggregateRoot : Entity
    {
        public int Version { get; set; }

        public AggregateRoot()
        {
            Version = 0;
        }

        public AggregateRoot(Guid guid)
            :base(guid)
        {

        }

        private List<DomainEvent> _events;

        public void AddEvent(DomainEvent _event)
        {
            _events = _events ?? new List<DomainEvent>();
            _events.Add(_event);
        }

        public IReadOnlyCollection<DomainEvent> GetEvents()
        {
            return _events;
        }
    }
}
