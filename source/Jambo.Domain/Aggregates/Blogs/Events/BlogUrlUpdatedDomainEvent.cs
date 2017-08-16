using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class BlogUrlUpdatedDomainEvent : DomainEvent
    {
        public string Url { get; set; }
        public BlogUrlUpdatedDomainEvent(Guid aggregateRootId, int version, string url)
            :base(aggregateRootId, version)
        {
            Url = url;
        }
    }
}
