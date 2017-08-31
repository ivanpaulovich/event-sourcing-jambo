using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Blogs.Events
{
    public class BlogEnabledDomainEvent : DomainEvent
    {
        public BlogEnabledDomainEvent()
        {

        }

        public BlogEnabledDomainEvent(AggregateRoot aggregateRoot)
            : base(aggregateRoot)
        {
        }
    }
}
