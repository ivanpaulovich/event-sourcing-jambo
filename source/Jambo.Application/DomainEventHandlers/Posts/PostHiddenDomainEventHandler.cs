using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostHiddenDomainEventHandler : INotificationHandler<PostHiddenDomainEvent>
    {
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository _postWriteOnlyRepository;

        public PostHiddenDomainEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }
        public void Handle(PostHiddenDomainEvent message)
        {
            Post post = _postReadOnlyRepository.GetPost(message.AggregateRootId).Result;

            if (post.Version == message.Version)
            {
                post.Hide();
                _postWriteOnlyRepository.UpdatePost(post).Wait();
            }
        }
    }
}
