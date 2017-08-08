using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;

namespace Jambo.Domain.Events
{
    public class PostCriadoDomainEvent: IEvent
    {
        public int BlogId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public PostCriadoDomainEvent(int blogId, string title, string content)
        {
            BlogId = blogId;
            Title = title;
            Content = content;
        }
    }
}
