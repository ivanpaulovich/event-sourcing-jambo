using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers
{
    public class BlogCriadoEventHandler : IAsyncNotificationHandler<CreatedBlogDomainEvent>
    {
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public BlogCriadoEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public async Task Handle(CreatedBlogDomainEvent message)
        {
            Blog blog = new Blog(message.AggregateRootId);

            await _blogWriteOnlyRepository.AddBlog(blog);
        }
    }
}
