using System;
using System.Collections.Generic;

namespace Jambo.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        private List<IEvent> _events;
        public IReadOnlyCollection<IEvent> Events => _events;

        public void AddEvent(IEvent _event)
        {
            _events = _events ?? new List<IEvent>();
            _events.Add(_event);
        }

        public void RemoveEvent(IEvent _event)
        {
            if (_events is null)
                return;

            _events.Remove(_event);
        }
    }
}
