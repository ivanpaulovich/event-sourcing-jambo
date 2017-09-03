using Jambo.Domain.Model.Blogs.Events;
using Jambo.Domain.Model.Posts.Events;
using Jambo.Domain.Exceptions;

namespace Jambo.Domain.Model.Blogs
{
    public class Blog : AggregateRoot
    {
        public string Url { get; private set; }
        public int Rating { get; private set; }
        public bool Enabled { get; private set; }

        public Blog()
        {
            Register<BlogCreatedDomainEvent>(When);
            Register<BlogUrlUpdatedDomainEvent>(When);
            Register<BlogEnabledDomainEvent>(When);
            Register<BlogDisabledDomainEvent>(When);
            Register<PostCreatedDomainEvent>(When);
        }

        public void Start()
        {
            Raise(new BlogCreatedDomainEvent(this));
        }

        public void UpdateUrl(string url)
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            Raise(new BlogUrlUpdatedDomainEvent(this, url));
        }

        public void Enable()
        {
            if (Enabled == true)
            {
                throw new BlogDomainException("The blog is already enabled.");
            }

            Raise(new BlogEnabledDomainEvent(this));
        }

        public void Disable()
        {
            if (Enabled == false)
            {
                throw new BlogDomainException("The blog is already disabled.");
            }

            Raise(new BlogDisabledDomainEvent(this));
        }

        protected void When(BlogCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            Enabled = true;
        }

        protected void When(BlogUrlUpdatedDomainEvent @event)
        {
            Url = @event.Url;
        }

        protected void When(BlogDisabledDomainEvent @event)
        {
            Enabled = false;
        }

        protected void When(BlogEnabledDomainEvent @event)
        {
            Enabled = true;
        }

        protected void When(PostCreatedDomainEvent @event)
        {
            Rating += 1;
        }
    }
}
