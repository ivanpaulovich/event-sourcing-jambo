using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Events
{
    public class BlogCriadoDomainEvent : INotification
    {
        public Blog Blog { get; private set; }

        public BlogCriadoDomainEvent(Blog blog)
        {
            Blog = blog;
        }
    }
}
