using Jambo.Domain.Aggregates.Blogs.Events;
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

        public Post()
        {
        }

        public Post(Guid id)
            :base(id)
        {
        }

        public void Start()
        {
            AddEvent(new PostCreatedDomainEvent(Id));
        }

        public void Disable()
        {
            if (Enabled == true)
            {
                throw new BlogDomainException("The post is already disabled.");
            }

            Enabled = false;

            AddEvent(new PostDisabledDomainEvent(Id, Version));
        }

        public void Hide()
        {
            if (Published == true)
            {
                throw new BlogDomainException("The post is already hidden.");
            }

            Published = false;

            AddEvent(new PostHiddenDomainEvent(Id, Version));
        }

        public void Enable()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The post is already enabled.");
            }

            Enabled = true;

            AddEvent(new PostEnabledDomainEvent(Id, Version));
        }

        public void UpdateContent(string title, string content)
        {
            Title = title;
            Content = content;

            AddEvent(new PostContentUpdatedDomainEvent(Id, Version, Title, Content));
        }

        public void Publish()
        {
            if (Published == false)
            {
                throw new BlogDomainException("The post is already published.");
            }

            Published = true;

            AddEvent(new PostPublishedDomainEvent(Id, Version));
        }

        public void SetBlogId(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
