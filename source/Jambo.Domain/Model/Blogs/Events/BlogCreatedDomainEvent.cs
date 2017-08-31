using Jambo.Domain.ServiceBus;
using System;

namespace Jambo.Domain.Model.Blogs.Events
{
    public class BlogCreatedDomainEvent : DomainEvent
    {
        public BlogCreatedDomainEvent()
        {

        }

        public BlogCreatedDomainEvent(AggregateRoot aggregateRoot) 
            : base(aggregateRoot)
        {
        }
    }
}
