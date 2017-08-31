using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Aggregates.Posts.Events
{
    public class PostPublishedDomainEvent : DomainEvent
    {
        public PostPublishedDomainEvent()
        {

        }

        public PostPublishedDomainEvent(AggregateRoot aggregateRoot)
            : base(aggregateRoot)
        {
        }
    }
}
