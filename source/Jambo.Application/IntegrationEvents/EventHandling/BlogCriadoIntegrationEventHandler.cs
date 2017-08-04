using Jambo.Application.IntegrationEvents.Events;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.IntegrationEvents.EventHandling
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

            _blogRepository.Add(blog);

            await _blogRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
