using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System.Collections.Generic;
using System;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Blog : Entity, IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

        public Blog(IServiceBus serviceBus) : base(serviceBus)
        {
            AddDomainEvent(new BlogCriadoDomainEvent(this));
        }

        public void DefinirUrl(string url)
        {
            Url = url;
        }

        public void DefinirId(Guid id)
        {
            Id = id;
        }
    }
}
