using Jambo.Domain.Aggregates.Posts;
using Jambo.Domain.Aggregates.Posts.Events;
using MediatR;
using System;


namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostEnabledEventHandler : INotificationHandler<PostEnabledDomainEvent>
    {
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository _postWriteOnlyRepository;

        public PostEnabledEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }

        public void Handle(PostEnabledDomainEvent message)
        {
            Post post = _postReadOnlyRepository.GetPost(message.AggregateRootId).Result;

            if (post.Version == message.Version)
            {
                post.Apply(message);
                _postWriteOnlyRepository.UpdatePost(post).Wait();
            }
        }
    }
}
