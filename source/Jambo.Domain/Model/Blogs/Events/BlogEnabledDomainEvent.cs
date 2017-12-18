namespace Jambo.Domain.Model.Blogs.Events
{
    using System;

    public class BlogEnabledDomainEvent : DomainEvent
    {
        public BlogEnabledDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        { 
        }

        public static BlogEnabledDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            BlogEnabledDomainEvent domainEvent = new BlogEnabledDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
