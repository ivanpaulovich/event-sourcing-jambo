using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostEnabledDomainEvent : DomainEvent
    {
        public PostEnabledDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static PostEnabledDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostEnabledDomainEvent domainEvent = new PostEnabledDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
