using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Application.Commands;

namespace Jambo.Application.CommandHandlers
{
    public class AtualizarBlogCommandHandler : IAsyncRequestHandler<AtualizarBlogCommand>
    {
        private readonly IBlogEventRepository _blogWriteOnlyRepository;

        public AtualizarBlogCommandHandler(IBlogEventRepository blogWriteOnlyRepository)
        {
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }

        public async Task Handle(AtualizarBlogCommand message)
        {
            Blog blog = new Blog(message.Id);

            blog.DefinirUrl(message.Url);

            await _blogWriteOnlyRepository.PublishEvents(blog);

            await _blogWriteOnlyRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
