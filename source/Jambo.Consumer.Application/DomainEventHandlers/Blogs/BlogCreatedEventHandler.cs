using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Blogs.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Consumer.Application.DomainEventHandlers.Blogs
{
    public class BlogCreatedEventHandler : IRequestHandler<BlogCreatedDomainEvent>
    {
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public BlogCreatedEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(BlogCreatedDomainEvent message)
        {
            Blog blog = new Blog();
            blog.Apply(message);
            _blogWriteOnlyRepository.AddBlog(blog).Wait();
        }
    }
}
