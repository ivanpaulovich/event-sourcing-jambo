using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System.Collections.Generic;
using System;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Blog : AggregateRoot
    {
        public string Url { get; private set; }
        public int Rating { get; private set; }
        public List<Post> Posts { get; private set; }

        public Blog()
        {
            AddEvent(new BlogCriadoDomainEvent(Id));
        }

        public Blog(Guid id)
            :base(id)
        {
        }
        public void DefinirUrl(string url)
        {
            Url = url;
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}
