using System;
using System.Collections.Generic;

namespace Jambo.Domain.Model
{
    public abstract class AggregateRoot : IEntity
    {
        private readonly Dictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
        private readonly List<DomainEvent> events = new List<DomainEvent>();

        public Guid Id { get; protected set; }
        public int Version { get; protected set; } = 0;

        protected void Register<T>(Action<T> when)
        {
            handlers.Add(typeof(T), e => when((T)e));
        }

        protected void Raise(DomainEvent domainEvent)
        {
            events.Add(domainEvent);
            handlers[domainEvent.GetType()](domainEvent);
            Version++;
        }

        public IReadOnlyCollection<DomainEvent> GetEvents()
        {
            return events;
        }

        public void Apply(DomainEvent domainEvent)
        {
            handlers[domainEvent.GetType()](domainEvent);
            Version++;
        }
    }
}
