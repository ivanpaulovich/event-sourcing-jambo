using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Blogs.Events;
using MediatR;
using System;

namespace Jambo.Consumer.Application.DomainEventHandlers.Blogs
{
    public class BlogCreatedEventHandler : IRequestHandler<BlogCreatedDomainEvent>
    {
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository blogWriteOnlyRepository;

        public BlogCreatedEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            this.blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(BlogCreatedDomainEvent domainEvent)
        {
            Blog blog = Blog.Create();
            blog.Apply(domainEvent);
            blogWriteOnlyRepository.AddBlog(blog).Wait();
        }
    }
}
