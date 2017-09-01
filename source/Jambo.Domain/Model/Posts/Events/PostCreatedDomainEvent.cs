using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostCreatedDomainEvent : DomainEvent
    {
        public Guid BlogId { get; set; }
        public int BlogVersion { get; set; }

        public PostCreatedDomainEvent()
        {

        }

        public PostCreatedDomainEvent(AggregateRoot aggregateRoot, Guid blogId, int blogVersion)
            : base(aggregateRoot)
        {
            BlogId = blogId;
            BlogVersion = blogVersion;
        }
    }
}
