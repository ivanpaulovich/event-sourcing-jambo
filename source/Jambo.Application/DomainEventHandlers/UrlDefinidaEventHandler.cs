using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Blogs.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers
{
    public class UrlDefinidaEventHandler : IAsyncNotificationHandler<BlogUrlUpdatedDomainEvent>
    {
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public UrlDefinidaEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public async Task Handle(BlogUrlUpdatedDomainEvent message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.AggregateRootId);

            if (blog.Version == message.Version)
            {
                blog.UpdateUrl(message.Url);
                await _blogWriteOnlyRepository.UpdateBlog(blog);
            }
        }
    }
}
