using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Model.Blogs.Events
{
    public class BlogUrlUpdatedDomainEvent : DomainEvent
    {
        public string Url { get; set; }

        public BlogUrlUpdatedDomainEvent()
        {

        }

        public BlogUrlUpdatedDomainEvent(AggregateRoot aggregateRoot, string url)
            : base(aggregateRoot)
        {
            Url = url;
        }
    }
}
