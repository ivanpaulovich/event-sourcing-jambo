using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.Blogs
{
    public class BlogDisabledEventHandler : IAsyncNotificationHandler<BlogDisabledDomainEvent>
    {
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public BlogDisabledEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public async Task Handle(BlogDisabledDomainEvent message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.AggregateRootId);

            if (blog.Version == message.Version)
            {
                blog.Disable();
                await _blogWriteOnlyRepository.UpdateBlog(blog);
            }
        }
    }
}
