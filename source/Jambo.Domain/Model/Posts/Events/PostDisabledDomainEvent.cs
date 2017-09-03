using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostDisabledDomainEvent : DomainEvent
    {
        public PostDisabledDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static PostDisabledDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostDisabledDomainEvent domainEvent = new PostDisabledDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
