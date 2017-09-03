using System;

namespace Jambo.Domain.Model.Blogs.Events
{
    public class BlogUrlUpdatedDomainEvent : DomainEvent
    {
        public Url Url { get; private set; }

        public BlogUrlUpdatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Url url, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
            Url = url;
        }

        public static BlogUrlUpdatedDomainEvent Create(AggregateRoot aggregateRoot, Url url)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            return new BlogUrlUpdatedDomainEvent(aggregateRoot.Id, aggregateRoot.Version,
                DateTime.UtcNow, url, null);
        }
    }
}
