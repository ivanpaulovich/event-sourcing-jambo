using Jambo.Domain.Aggregates.Posts.Events;
using Jambo.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Aggregates.Posts
{
    public class Post : AggregateRoot
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid BlogId { get; private set; }
        public int BlogVersion { get; private set; }
        public bool Enabled { get; private set; }
        public bool Published { get; private set; }
        public List<Comment> Comments { get; set; }

        public void Start(Guid blogId, int blogVersion)
        {
            Apply(AddEvent(new PostCreatedDomainEvent(Guid.NewGuid(), blogId, blogVersion)));
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
            if (Enabled == false)
            {
                throw new BlogDomainException("The post is disabled. Enable this before making any changes.");
            }

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
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            Apply(AddEvent(new PostContentUpdatedDomainEvent(Id, Version, title, content)));
        }

        public void Publish()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            if (Published == true)
            {
                throw new BlogDomainException("The post is already published.");
            }

            Apply(AddEvent(new PostPublishedDomainEvent(Id, Version)));
        }

        public void Comment(Comment comment)
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            if (Published == true)
            {
                throw new BlogDomainException("The post is already hidden.");
            }

            Apply(AddEvent(new CommentCreatedDomainEvent(Id, comment.Id, comment.Message)));
        }

        public void Apply(CommentCreatedDomainEvent commentCreatedDomainEvent)
        {
            Comments = Comments ?? new List<Comment>();
            Comment comment = new Comment(commentCreatedDomainEvent.Message);

            Comments.Add(comment);
        }

        public void Apply(PostCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            BlogId = @event.BlogId;
            Enabled = true;
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
