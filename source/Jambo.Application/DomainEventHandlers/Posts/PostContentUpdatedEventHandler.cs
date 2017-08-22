using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostContentUpdatedEventHandler : IAsyncNotificationHandler<PostContentUpdatedDomainEvent>
    {
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository _postWriteOnlyRepository;

        public PostContentUpdatedEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }
        public async Task Handle(PostContentUpdatedDomainEvent message)
        {
            Post post = await _postReadOnlyRepository.GetPost(message.AggregateRootId);

            if (post.Version == message.Version)
            {
                post.UpdateContent(message.Title, message.Content);
                await _postWriteOnlyRepository.UpdatePost(post);
            }
        }
    }
}
