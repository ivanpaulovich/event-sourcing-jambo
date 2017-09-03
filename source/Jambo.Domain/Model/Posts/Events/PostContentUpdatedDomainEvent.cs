using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostContentUpdatedDomainEvent : DomainEvent
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public PostContentUpdatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, string title, string content)
            : base(aggregateRootId, version, createdDate, header)
        {
            Title = title;
            Content = content;
        }

        public static PostContentUpdatedDomainEvent Create(AggregateRoot aggregateRoot,
            string title, string content)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            PostContentUpdatedDomainEvent domainEvent = new PostContentUpdatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, title, content);

            return domainEvent;
        }
    }
}
