using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers
{
    public class BlogCriadoEventHandler : IAsyncNotificationHandler<BlogCriadoDomainEvent>
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
        public async Task Handle(BlogCriadoDomainEvent message)
        {
            Blog blog = new Blog(message.AggregateRootId);
            blog.Version = message.Version;

            await _blogWriteOnlyRepository.Add(blog);

            await _blogWriteOnlyRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
