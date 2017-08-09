using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.ProcessManager.Application.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.ProcessManager.Application.IntegrationEventHandlers
{
    public class BlogCriadoIntegrationEventHandler : IAsyncRequestHandler<BlogCriadoIntegrationEvent>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;

        public BlogCriadoIntegrationEventHandler(IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
        }

        public async Task Handle(BlogCriadoIntegrationEvent message)
        {
            var blog = new Blog(message.Url);

            _blogRepository.PublishEvents(blog);

            await _blogRepository.ServiceBus.SaveChangesAsync();
        }
    }
}
