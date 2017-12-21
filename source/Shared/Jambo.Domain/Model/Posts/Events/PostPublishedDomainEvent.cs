namespace Jambo.Domain.Model.Posts.Events
{
    using System;

    public class PostPublishedDomainEvent : DomainEvent
    {
        public PostPublishedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static PostPublishedDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostPublishedDomainEvent domainEvent = new PostPublishedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
