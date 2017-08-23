using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using Jambo.Domain.Aggregates.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Posts
{
    public class PostCreatedEventHandler : INotificationHandler<PostCreatedDomainEvent>
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
        public void Handle(PostCreatedDomainEvent message)
        {
            Post post = new Post(message.AggregateRootId);
            post.Start(message.BlogId);

            _postWriteOnlyRepository.AddPost(post).Wait();
        }
    }
}
