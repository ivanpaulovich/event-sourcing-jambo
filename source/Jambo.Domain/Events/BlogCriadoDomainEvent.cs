using System;

namespace Jambo.Domain.Events
{
    public class BlogCriadoDomainEvent : DomainEvent
    {
        public BlogCriadoDomainEvent(Guid aggregateRootId)
            :base(aggregateRootId, 0)
        {
        }
    }
}
