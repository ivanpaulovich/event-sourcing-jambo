namespace Jambo.Domain.Model.Posts.Events
{
    using System;

    public class PostHiddenDomainEvent : DomainEvent
    {
        public PostHiddenDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static PostHiddenDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostHiddenDomainEvent domainEvent = new PostHiddenDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
