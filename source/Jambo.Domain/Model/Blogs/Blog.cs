using Jambo.Domain.Model.Blogs.Events;
using Jambo.Domain.Model.Posts.Events;
using Jambo.Domain.Exceptions;

namespace Jambo.Domain.Model.Blogs
{
    public class Blog : AggregateRoot
    {
        private Url url;
        private int rating;
        private bool enabled;

        private Blog()
        {
            Register<BlogCreatedDomainEvent>(When);
            Register<BlogUrlUpdatedDomainEvent>(When);
            Register<BlogEnabledDomainEvent>(When);
            Register<BlogDisabledDomainEvent>(When);
            Register<PostCreatedDomainEvent>(When);
        }

        public static Blog Create()
        {
            return new Blog();
        }

        public void Start()
        {
            Raise(BlogCreatedDomainEvent.Create(this));
        }

        public void UpdateUrl(Url url)
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The blog is disabled. Enable this before making any changes.");
            }

            Raise(BlogUrlUpdatedDomainEvent.Create(this, url));
        }

        public void Enable()
        {
            if (enabled == true)
            {
                throw new BlogDomainException("The blog is already enabled.");
            }

            Raise(BlogEnabledDomainEvent.Create(this));
        }

        public void Disable()
        {
            if (enabled == false)
            {
                throw new BlogDomainException("The blog is already disabled.");
            }

            Raise(BlogDisabledDomainEvent.Create(this));
        }

        protected void When(BlogCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
            enabled = true;
        }

        protected void When(BlogUrlUpdatedDomainEvent @event)
        {
            url = @event.Url;
        }

        protected void When(BlogDisabledDomainEvent @event)
        {
            enabled = false;
        }

        protected void When(BlogEnabledDomainEvent @event)
        {
            enabled = true;
        }

        protected void When(PostCreatedDomainEvent @event)
        {
            rating += 1;
        }
    }
}
