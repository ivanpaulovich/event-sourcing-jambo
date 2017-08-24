using Jambo.Domain.Aggregates.Posts.Events;
using Jambo.Domain.Exceptions;
using System;

namespace Jambo.Domain.Aggregates.Posts
{
    public class Post : AggregateRoot
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid BlogId { get; private set; }
        public bool Enabled { get; private set; }
        public bool Published { get; private set; }

        public void Start(Guid blogId)
        {
            Apply(AddEvent(new PostCreatedDomainEvent(Guid.NewGuid(), blogId)));
        }

        public void Disable()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The post is already disabled.");
            }

            Apply(AddEvent(new PostDisabledDomainEvent(Id, Version)));
        }

        public void Hide()
        {
            if (Published == false)
            {
                throw new BlogDomainException("The post is already hidden.");
            }

            Apply(AddEvent(new PostHiddenDomainEvent(Id, Version)));
        }

        public void Enable()
        {
            if (Enabled == true)
            {
                throw new BlogDomainException("The post is already enabled.");
            }

            Apply(AddEvent(new PostEnabledDomainEvent(Id, Version)));
        }

        public void UpdateContent(string title, string content)
        {
            Apply(AddEvent(new PostContentUpdatedDomainEvent(Id, Version, title, content)));
        }

        public void Publish()
        {
            if (Published == true)
            {
                throw new BlogDomainException("The post is already published.");
            }

            Apply(AddEvent(new PostPublishedDomainEvent(Id, Version)));
        }

        public void Apply(PostCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            BlogId = @event.BlogId;
        }

        public void Apply(PostContentUpdatedDomainEvent @event)
        {
            Title = @event.Title;
            Content = @event.Content;
        }

        public void Apply(PostDisabledDomainEvent @event)
        {
            Enabled = false;
        }

        public void Apply(PostEnabledDomainEvent @event)
        {
            Enabled = true;
        }

        public void Apply(PostHiddenDomainEvent @event)
        {
            Published = false;
        }

        public void Apply(PostPublishedDomainEvent @event)
        {
            Published = true;
        }
    }
}
