using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System.Collections.Generic;
using System;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Blog : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public int Rating { get; private set; }
        public List<Post> Posts { get; private set; }

        public Blog(Guid id)
        {
            Id = id;
        }

        public Blog(string url)
        {
            this.Url = url;

            AddEvent(new BlogCriadoDomainEvent(Url));
        }

        public void DefinirUrl(string url)
        {
            Url = url;
        }

        public void DefinirId(Guid id)
        {
            Id = id;
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}
