using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class CommentCreatedDomainEvent : DomainEvent
    {
        public Guid CommentId { get; set; }
        public string Message { get; set; }

        public CommentCreatedDomainEvent(Guid postId, Guid commentId, string message)
            : base(postId, 0)
        {
            CommentId = commentId;
            Message = message;
        }
    }
}
