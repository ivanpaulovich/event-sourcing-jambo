using Jambo.Domain.Model.Posts.Events;
using Jambo.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Model.Posts
{
    public class Post : AggregateRoot
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid BlogId { get; private set; }
        public bool Enabled { get; private set; }
        public bool Published { get; private set; }
        public List<Comment> Comments { get; private set; }

        public Post()
        {
            Register<PostCreatedDomainEvent>(When);
            Register<PostDisabledDomainEvent>(When);
            Register<PostHiddenDomainEvent>(When);
            Register<PostEnabledDomainEvent>(When);
            Register<PostContentUpdatedDomainEvent>(When);
            Register<PostPublishedDomainEvent>(When);
            Register<CommentCreatedDomainEvent>(When);
        }

        public void Start(Guid blogId, int blogVersion)
        {
            Raise(new PostCreatedDomainEvent(this, blogId, blogVersion));
        }

        public void Disable()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The post is already disabled.");
            }

            Raise(new PostDisabledDomainEvent(this));
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

            Raise(new PostHiddenDomainEvent(this));
        }

        public void Enable()
        {
            if (Enabled == true)
            {
                throw new BlogDomainException("The post is already enabled.");
            }

            Raise(new PostEnabledDomainEvent(this));
        }

        public void UpdateContent(string title, string content)
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            Raise(new PostContentUpdatedDomainEvent(this, title, content));
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

            Raise(new PostPublishedDomainEvent(this));
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

            Raise(new CommentCreatedDomainEvent(this, comment.Id, comment.Message));
        }

        public void When(CommentCreatedDomainEvent commentCreatedDomainEvent)
        {
            Comments = Comments ?? new List<Comment>();
            Comment comment = new Comment(commentCreatedDomainEvent.Message);

            Comments.Add(comment);
        }

        public void When(PostCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            BlogId = @event.BlogId;
            Enabled = true;
        }

        public void When(PostContentUpdatedDomainEvent @event)
        {
            Title = @event.Title;
            Content = @event.Content;
        }

        public void When(PostDisabledDomainEvent @event)
        {
            Enabled = false;
        }

        public void When(PostEnabledDomainEvent @event)
        {
            Enabled = true;
        }

        public void When(PostHiddenDomainEvent @event)
        {
            Published = false;
        }

        public void When(PostPublishedDomainEvent @event)
        {
            Published = true;
        }
    }
}
