using System;

namespace Jambo.Domain.Model.Blogs.Events
{
    public class BlogCreatedDomainEvent : DomainEvent
    {
        public BlogCreatedDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static BlogCreatedDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            BlogCreatedDomainEvent domainEvent = new BlogCreatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
