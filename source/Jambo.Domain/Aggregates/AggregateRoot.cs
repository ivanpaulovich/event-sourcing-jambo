using Jambo.Domain.ServiceBus;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates
{
    public abstract class AggregateRoot : IEntity
    {
        public int Version { get; set; }

        public Guid Id { get; set; }

        public AggregateRoot()
        {
            Version = 0;
        }

        private List<DomainEvent> _events;

        public T AddEvent<T>(T _event) 
            where T : DomainEvent
        {
            _events = _events ?? new List<DomainEvent>();
            _events.Add(_event);

            return _event;
        }

        public IReadOnlyCollection<DomainEvent> GetEvents()
        {
            return _events;
        }
    }
}
