using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Model.Posts.Events
{
    public class PostDisabledDomainEvent : DomainEvent
    {
        public PostDisabledDomainEvent()
        {

        }

        public PostDisabledDomainEvent(AggregateRoot aggregateRoot)
            : base(aggregateRoot)
        {

        }
    }
}
