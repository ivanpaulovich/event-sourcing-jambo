using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostCreatedEventHandler : IAsyncNotificationHandler<BlogCreatedDomainEvent>
    {
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository _postWriteOnlyRepository;

        public PostCreatedEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }
        public async Task Handle(BlogCreatedDomainEvent message)
        {
            Post post = new Post(message.AggregateRootId);

            await _postWriteOnlyRepository.AddPost(post);
        }
    }
}
