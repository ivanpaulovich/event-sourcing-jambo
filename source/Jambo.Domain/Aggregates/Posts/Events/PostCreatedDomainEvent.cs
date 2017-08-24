using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostCreatedDomainEvent : DomainEvent
    {
        public Guid BlogId { get; set; }
        public PostCreatedDomainEvent(Guid aggregateRootId, Guid blogId)
            : base(aggregateRootId, 0)
        {
            BlogId = blogId;
        }
    }
}
