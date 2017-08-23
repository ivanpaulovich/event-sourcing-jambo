using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using Jambo.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates.Blogs
{
    public class Blog : AggregateRoot
    {
        public string Url { get; private set; }
        public int Rating { get; private set; }
        public bool Enabled { get; private set; }

        public Blog()
        {
        }

        public Blog(Guid id)
            :base(id)
        {
        }

        public void Start()
        {
            AddEvent(new BlogCreatedDomainEvent(Id));
        }

        public void UpdateUrl(string url)
        {
            Url = url;

            AddEvent(new BlogUrlUpdatedDomainEvent(Id, Version, Url));
        }

        public void Disable()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is already disabled.");
            }

            Enabled = false;

            AddEvent(new BlogDisabledDomainEvent(Id, Version));
        }

        public void Enable()
        {
            if (Enabled == true)
            {
                throw new BlogDomainException("The blog is already enabled.");
            }

            Enabled = true;

            AddEvent(new BlogEnabledDomainEvent(Id, Version));
        }
    }
}
