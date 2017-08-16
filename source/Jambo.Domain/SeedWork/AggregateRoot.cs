using System;
using System.Collections.Generic;

namespace Jambo.Domain.SeedWork
{
    public class AggregateRoot : Entity, IAggregateRoot
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

        private List<IEvent> _events;

        public void AddEvent(IEvent _event)
        {
            _events = _events ?? new List<IEvent>();
            _events.Add(_event);
        }

        public IReadOnlyCollection<IEvent> GetEvents()
        {
            return _events;
        }
    }
}
