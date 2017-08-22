using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates.Blogs
{
    public class Blog : AggregateRoot
    {
        public string Url { get; private set; }
        public int Rating { get; private set; }

        public Blog()
        {
            AddEvent(new BlogCreatedDomainEvent(Id));
        }

        public Blog(Guid id)
            :base(id)
        {
        }

        public void UpdateUrl(string url)
        {
            Url = url;
            AddEvent(new BlogUrlUpdatedDomainEvent(Id, Version, Url));
        }

        public void Disable()
        {
            AddEvent(new BlogDisabledDomainEvent(Id, Version));
        }

        public void Enable()
        {
            AddEvent(new BlogEnabledDomainEvent(Id, Version));
        }
    }
}
