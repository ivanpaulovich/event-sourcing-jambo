using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Posts;
using Jambo.Domain.Model.Posts.Events;
using MediatR;
using System;


namespace Jambo.Consumer.Application.DomainEventHandlers.Posts
{
    public class PostEnabledEventHandler : IRequestHandler<PostEnabledDomainEvent>
    {
        private readonly IPostReadOnlyRepository postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;

        public PostEnabledEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository)
        {
            this.postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            this.postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
        }

        public void Handle(PostEnabledDomainEvent domainEvent)
        {
            Post post = postReadOnlyRepository.GetPost(domainEvent.AggregateRootId).Result;

            if (post.Version != domainEvent.Version)
                throw new TransactionConflictException(post, domainEvent);

            post.Apply(domainEvent);
            postWriteOnlyRepository.UpdatePost(post).Wait();
        }
    }
}
