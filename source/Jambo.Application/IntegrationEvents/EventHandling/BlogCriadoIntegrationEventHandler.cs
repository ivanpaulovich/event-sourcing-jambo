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
    public class BlogCriadoIntegrationEventHandler : IRequestHandler<BlogCriadoIntegrationEvent>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;

        public BlogCriadoIntegrationEventHandler()
        {

        }

        public void Handle(BlogCriadoIntegrationEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
