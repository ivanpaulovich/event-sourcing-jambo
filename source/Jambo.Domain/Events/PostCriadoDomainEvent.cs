using System;

namespace Jambo.Domain.Events
{
    public class PostCriadoDomainEvent: DomainEvent
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public PostCriadoDomainEvent(Guid aggregateRootId, int version, 
            string title, string content)
            : base(aggregateRootId, version)
        {
            AggregateRootId = aggregateRootId;
            Title = title;
            Content = content;
        }
    }
}
