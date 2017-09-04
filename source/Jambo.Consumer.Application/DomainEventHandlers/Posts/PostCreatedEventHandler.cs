using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Domain.Model.Posts.Events;
using MediatR;
using System;


namespace Jambo.Consumer.Application.DomainEventHandlers.Posts
{
    public class PostCreatedEventHandler : IRequestHandler<PostCreatedDomainEvent>
    {
        private readonly IPostReadOnlyRepository postReadOnlyRepository;
        private readonly IPostWriteOnlyRepository postWriteOnlyRepository;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository blogWriteOnlyRepository;

        public PostCreatedEventHandler(
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
        public void Handle(PostCreatedDomainEvent domainEvent)
        {
            Blog blog = blogReadOnlyRepository.GetBlog(domainEvent.BlogId).Result;

            if (blog.Version != blog.Version)
                throw new TransactionConflictException(blog, domainEvent);

            Post post = Post.Create();
            post.Apply(domainEvent);

            postWriteOnlyRepository.AddPost(post).Wait();

            blog.Apply(domainEvent);
            blogWriteOnlyRepository.UpdateBlog(blog).Wait();
        }
    }
}
