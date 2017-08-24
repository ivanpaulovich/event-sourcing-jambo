using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostContentUpdatedDomainEvent : DomainEvent
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public PostContentUpdatedDomainEvent(Guid aggregateRootId, int version, 
            string title, string content)
            : base(aggregateRootId, version)
        {
            Title = title;
            Content = content;
        }
    }
}
