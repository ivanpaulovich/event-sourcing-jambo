using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Blogs.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Consumer.Application.DomainEventHandlers.Blogs
{
    public class BlogEnabledEventHandler : IRequestHandler<BlogEnabledDomainEvent>
    {
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository blogWriteOnlyRepository;

        public BlogEnabledEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            this.blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(BlogEnabledDomainEvent domainEvent)
        {
            Blog blog = blogReadOnlyRepository.GetBlog(domainEvent.AggregateRootId).Result;

            if (blog.Version != domainEvent.Version)
                throw new TransactionConflictException(blog, domainEvent);

            blog.Apply(domainEvent);
            blogWriteOnlyRepository.UpdateBlog(blog).Wait();
        }
    }
}
