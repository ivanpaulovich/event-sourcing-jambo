using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class CommentCreatedDomainEvent : DomainEvent
    {
        public Guid CommentId { get; private set; }
        public string Message { get; private set; }

        public CommentCreatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid commentId, string message)
            : base(aggregateRootId, version, createdDate, header)
        {
            CommentId = commentId;
            Message = message;
        }

        public static CommentCreatedDomainEvent Create(AggregateRoot aggregateRoot,
            Guid commentId, string message)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            CommentCreatedDomainEvent domainEvent = new CommentCreatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version,  DateTime.UtcNow, null, commentId, message);

            return domainEvent;
        }
    }
}
