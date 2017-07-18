using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.Commands
{
    public class ExcluirBlogCommandHandler
        : IAsyncRequestHandler<ExcluirBlogCommand, bool>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;
        private readonly IMediator _mediator;

        public ExcluirBlogCommandHandler(IMediator mediator, IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(ExcluirBlogCommand message)
        {
            Blog blog = new Blog(message.Id);

            _blogRepository.Add(blog);

            return await _blogRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
