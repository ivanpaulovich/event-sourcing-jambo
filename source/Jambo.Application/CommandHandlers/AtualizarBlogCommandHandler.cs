using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Application.Commands;
using Jambo.Domain.ServiceBus;
using Jambo.Domain.Aggregates.Blogs;

namespace Jambo.Application.CommandHandlers
{
    public class AtualizarBlogCommandHandler : IAsyncRequestHandler<AtualizarBlogCommand>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public AtualizarBlogCommandHandler(
            IServiceBus serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(AtualizarBlogCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.Id);
            blog.UpdateUrl(message.Url);

            await _serviceBus.Publish(blog.GetEvents());
        }
    }
}
