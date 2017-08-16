using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class CreatedPostDomainEvent: DomainEvent
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public CreatedPostDomainEvent(Guid aggregateRootId, int version, 
            string title, string content)
            : base(aggregateRootId, version)
        {
            AggregateRootId = aggregateRootId;
            Title = title;
            Content = content;
        }
    }
}
