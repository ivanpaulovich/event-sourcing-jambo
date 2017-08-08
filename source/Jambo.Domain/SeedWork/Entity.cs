using System;
using System.Collections.Generic;

namespace Jambo.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        private List<IEvent> _domainEvents;
        private List<IServiceBus> _observers = new List<IServiceBus>();

        public void AddDomainEvent(IEvent _event)
        {
            _domainEvents = _domainEvents ?? new List<IEvent>();
            _domainEvents.Add(_event);
        }

        public void RemoveDomainEvent(IEvent _event)
        {
            if (_domainEvents is null)
                return;

            _domainEvents.Remove(_event);
        }

        public void Attach(IServiceBus observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IServiceBus observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IServiceBus _serviceBus in _observers)
            {
                foreach(IEvent _event in _domainEvents)
                {
                    _serviceBus.Add(_event);
                }
            }
        }
    }
}
