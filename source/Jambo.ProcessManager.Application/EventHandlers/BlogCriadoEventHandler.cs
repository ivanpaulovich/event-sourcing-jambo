using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using Jambo.ProcessManager.Application.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.ProcessManager.Application.IntegrationEventHandlers
{
    public class BlogCriadoEventHandler : IAsyncRequestHandler<BlogCriadoDomainEvent>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;

        public BlogCriadoEventHandler(IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
        }

        public async Task Handle(BlogCriadoDomainEvent message)
        {
            var blog = new Blog(message.Url);

            _blogRepository.PublishEvents(blog);

            await _blogRepository.ServiceBus.SaveChangesAsync();
        }
    }
}
