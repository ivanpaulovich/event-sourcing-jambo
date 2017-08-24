using Jambo.Domain.Aggregates.Posts;
using Jambo.Domain.Aggregates.Posts.Events;
using MediatR;
using System;


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
            Post post = new Post();
            post.Apply(message);

            _postWriteOnlyRepository.AddPost(post).Wait();
        }
    }
}
