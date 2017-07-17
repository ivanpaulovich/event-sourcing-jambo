using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.Commands
{
    public class CriarBlogCommandHandler
        : IAsyncRequestHandler<CriarBlogCommand, bool>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;
        private readonly IMediator _mediator;

        public CriarBlogCommandHandler(IMediator mediator, IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CriarBlogCommand message)
        {
            var blog = new Blog(message.Url, message.Rating);

            _blogRepository.Add(blog);

            return await _blogRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
