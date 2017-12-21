namespace Jambo.Domain.Model.Blogs.Events
{
    using System;

    public class BlogDisabledDomainEvent : DomainEvent
    {
        public BlogDisabledDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static BlogDisabledDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            BlogDisabledDomainEvent domainEvent = new BlogDisabledDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
