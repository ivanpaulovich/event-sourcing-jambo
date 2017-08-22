using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostDisabledEventHandler : IAsyncNotificationHandler<PostDisabledDomainEvent>
    {
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository _postWriteOnlyRepository;

        public PostDisabledEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }
        public async Task Handle(PostDisabledDomainEvent message)
        {
            Post post = await _postReadOnlyRepository.GetPost(message.AggregateRootId);

            if (post.Version == message.Version)
            {
                post.Disable();
                await _postWriteOnlyRepository.UpdatePost(post);
            }
        }
    }
}
