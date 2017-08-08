using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;

namespace Jambo.Domain.Events
{
    public class PostCriadoDomainEvent: IEvent
    {
        public Post Post { get; private set; }

        public PostCriadoDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
