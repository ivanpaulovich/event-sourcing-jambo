using Jambo.Application.Commands;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class ExcluirBlogCommandHandler : IAsyncRequestHandler<ExcluirBlogCommand>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public ExcluirBlogCommandHandler(
            IServiceBus serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(ExcluirBlogCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.Id);

            blog.Disable();

            await _serviceBus.Publish(blog.GetEvents());
        }
    }
}
