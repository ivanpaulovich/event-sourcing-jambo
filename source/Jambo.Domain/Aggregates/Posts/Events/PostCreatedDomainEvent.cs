using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostCreatedDomainEvent : DomainEvent
    {
        public Guid BlogId { get; set; }
        public int BlogVersion { get; set; }

        public PostCreatedDomainEvent(Guid aggregateRootId, Guid blogId, int blogVersion)
            : base(aggregateRootId, 0)
        {
            BlogId = blogId;
            BlogVersion = blogVersion;
        }
    }
}
