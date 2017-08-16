using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class CreatedBlogDomainEvent : DomainEvent
    {
        public CreatedBlogDomainEvent(Guid aggregateRootId)
            :base(aggregateRootId, 0)
        {
        }
    }
}
