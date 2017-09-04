using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostContentUpdatedDomainEvent : DomainEvent
    {
        public Title Title { get; private set; }
        public Content Content { get; private set; }

        public PostContentUpdatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Title title, Content content)
            : base(aggregateRootId, version, createdDate, header)
        {
            Title = title;
            Content = content;
        }

        public static PostContentUpdatedDomainEvent Create(AggregateRoot aggregateRoot,
            Title title, Content content)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostContentUpdatedDomainEvent domainEvent = new PostContentUpdatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, title, content);

            return domainEvent;
        }
    }
}
