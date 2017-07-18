using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;

namespace Jambo.Domain.Events
{
    public class PostCriadoDomainEvent: INotification
    {
        public Post Post { get; private set; }

        public PostCriadoDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
