using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class CommentCreatedDomainEvent : DomainEvent
    {
        public Guid CommentId { get; set; }
        public string Message { get; set; }

        public CommentCreatedDomainEvent()
        {

        }

        public CommentCreatedDomainEvent(AggregateRoot aggregateRoot,
            Guid commentId, string message)
            : base(aggregateRoot)
        {
            CommentId = commentId;
            Message = message;
        }
    }
}
