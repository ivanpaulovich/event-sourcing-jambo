using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers
{
    public class UrlDefinidaEventHandler : INotificationHandler<UrlDefinidaDomainEvent>
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
        public void Handle(UrlDefinidaDomainEvent message)
        {
            Blog blog = _blogReadOnlyRepository.FindAsync(message.AggregateRootId).Result;

            if (blog.Version == message.Version)
            {
                blog.DefinirUrl(message.Url);
                _blogWriteOnlyRepository.Update(blog).ConfigureAwait(true);
            }
        }
    }
}
