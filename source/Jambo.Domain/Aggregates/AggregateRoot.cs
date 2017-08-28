using Jambo.Domain.ServiceBus;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates
{
    public abstract class AggregateRoot : IEntity
    {
        private readonly Dictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();
        private readonly List<DomainEvent> _events = new List<DomainEvent>();

        public Guid Id { get; protected set; }
        public int Version { get; protected set; } = 0;

        protected void Register<T>(Action<T> when)
        {
            _handlers.Add(typeof(T), e => when((T)e));
        }

        protected void Raise(DomainEvent _event)
        {
            _handlers[_event.GetType()](_event);
            _events.Add(_event);
        }

        public IReadOnlyCollection<DomainEvent> GetEvents()
        {
            return _events;
        }

        void ClearEvents()
        {
            _events.Clear();
        }

        public void Apply(DomainEvent e)
        {
            Raise(e);
            Version++;
        }
    }
}
