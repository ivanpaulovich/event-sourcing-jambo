using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class ExcluirBlogCommandHandler : IAsyncRequestHandler<ExcluirBlogCommand>
    {
        private readonly IBlogEventRepository _blogEventRepository;

        public ExcluirBlogCommandHandler(IBlogEventRepository blogEventRepository)
        {
            _blogEventRepository = blogEventRepository ??
                throw new ArgumentNullException(nameof(blogEventRepository));
        }

        public async Task Handle(ExcluirBlogCommand message)
        {
            Blog blog = new Blog(message.Id);

            blog.Disable();

            await _blogEventRepository.PublishEvents(blog);

            await _blogEventRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
