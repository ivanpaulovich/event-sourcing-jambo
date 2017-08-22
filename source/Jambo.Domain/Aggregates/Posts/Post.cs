using Jambo.Domain.Aggregates.Blogs.Events;
using System;

namespace Jambo.Domain.Aggregates.Posts
{
    public class Post : AggregateRoot
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int BlogId { get; private set; }

        public Post()
        {
            AddEvent(new PostCreatedDomainEvent(Id));
        }

        public Post(Guid id)
            :base(id)
        {
        }

        public void Disable()
        {
            AddEvent(new PostDisabledDomainEvent(Id, Version));
        }

        public void Hide()
        {
            AddEvent(new PostHiddenDomainEvent(Id, Version));
        }

        public void Enable()
        {
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
            AddEvent(new PostPublishedDomainEvent(Id, Version));
        }

        public void SetBlogId(Guid blogId)
        {
            throw new NotImplementedException();
        }
    }
}
