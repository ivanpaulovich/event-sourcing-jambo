using Jambo.Domain.Model.Posts.Events;
using Jambo.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Model.Posts
{
    public class Post : AggregateRoot
    {
        private string title;
        private string content;
        private Guid blogId;
        private bool enabled;
        private bool published;
        private List<Comment> comments;

        public Guid BlogId
        {
            get
            {
                return blogId;
            }
        }

        private Post()
        {
            Register<PostCreatedDomainEvent>(When);
            Register<PostDisabledDomainEvent>(When);
            Register<PostHiddenDomainEvent>(When);
            Register<PostEnabledDomainEvent>(When);
            Register<PostContentUpdatedDomainEvent>(When);
            Register<PostPublishedDomainEvent>(When);
            Register<CommentCreatedDomainEvent>(When);
        }

        public static Post Create()
        {
            return new Post();
        }

        public void Start(Guid blogId, int blogVersion)
        {
            Raise(new PostCreatedDomainEvent(this, blogId, blogVersion));
        }

        public void Disable()
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The post is already disabled.");
            }

            Raise(new PostDisabledDomainEvent(this));
        }

        public void Hide()
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The post is disabled. Enable this before making any changes.");
            }

            if (published == false)
            {
                throw new BlogDomainException("The post is already hidden.");
            }

            Raise(new PostHiddenDomainEvent(this));
        }

        public void Enable()
        {
            if (enabled == true)
            {
                throw new BlogDomainException("The post is already enabled.");
            }

            Raise(new PostEnabledDomainEvent(this));
        }

        public void UpdateContent(string title, string content)
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            Raise(new PostContentUpdatedDomainEvent(this, title, content));
        }

        public void Publish()
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            if (published == true)
            {
                throw new BlogDomainException("The post is already published.");
            }

            Raise(new PostPublishedDomainEvent(this));
        }

        public void Comment(Comment comment)
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            if (published == true)
            {
                throw new BlogDomainException("The post is already hidden.");
            }

            Raise(new CommentCreatedDomainEvent(this, comment.Id, comment.Message));
        }

        protected void When(CommentCreatedDomainEvent commentCreatedDomainEvent)
        {
            comments = comments ?? new List<Comment>();
            Comment comment = new Comment(commentCreatedDomainEvent.Message);

            comments.Add(comment);
        }

        protected void When(PostCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            blogId = @event.BlogId;
            enabled = true;
        }

        protected void When(PostContentUpdatedDomainEvent @event)
        {
            title = @event.Title;
            content = @event.Content;
        }

        protected void When(PostDisabledDomainEvent @event)
        {
            enabled = false;
        }

        protected void When(PostEnabledDomainEvent @event)
        {
            enabled = true;
        }

        protected void When(PostHiddenDomainEvent @event)
        {
            published = false;
        }

        protected void When(PostPublishedDomainEvent @event)
        {
            published = true;
        }
    }
}
