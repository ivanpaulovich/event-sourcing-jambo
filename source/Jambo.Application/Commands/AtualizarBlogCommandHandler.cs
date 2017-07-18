using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.Commands
{
    public class AtualizarBlogCommandHandler
        : IAsyncRequestHandler<AtualizarBlogCommand, bool>
    {
        private readonly IBlogWriteOnlyRepository _blogRepository;
        private readonly IMediator _mediator;

        public AtualizarBlogCommandHandler(IMediator mediator, IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(AtualizarBlogCommand message)
        {
            Blog blog = new Blog(message.Id);

            _blogRepository.Update(blog);

            return await _blogRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
