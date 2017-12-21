using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Domain.Model.Posts.Events;
using MediatR;
using System;


namespace Jambo.Consumer.Application.DomainEventHandlers.Posts
{
    public class CommentCreatedEventHandler : IRequestHandler<CommentCreatedDomainEvent>
    {
        private readonly IPostReadOnlyRepository postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository blogWriteOnlyRepository;

        public CommentCreatedEventHandler(
            IPostReadOnlyRepository postReadOnlyRepository,
            IPostWriteOnlyRepository postWriteOnlyRepository,
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            this.postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            this.postWriteOnlyRepository = postWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(postWriteOnlyRepository));
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            this.blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(CommentCreatedDomainEvent domainEvent)
        {
            Post post = postReadOnlyRepository.GetPost(domainEvent.AggregateRootId).Result;

            if (post.Version != domainEvent.Version)
                throw new TransactionConflictException(post, domainEvent);

            post.Apply(domainEvent);
            postWriteOnlyRepository.UpdatePost(post).Wait();
        }
    }
}
