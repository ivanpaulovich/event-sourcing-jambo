using Jambo.Application.Commands;
using Jambo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.API.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBlogQueries _blogQueries;

        public BlogsController(IMediator mediator, IBlogQueries blogQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _blogQueries = blogQueries ?? throw new ArgumentNullException(nameof(blogQueries));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _blogQueries.GetBlogsAsync();

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var blog = await _blogQueries.GetBlogAsync(id);

                return Ok(blog);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CriarBlogCommand command)
        {
            bool commandResult = await _mediator.Send(command);
            return commandResult ? (IActionResult)Ok() : (IActionResult)BadRequest();
        }

        [HttpPut]
        public async void Put([FromBody]AtualizarBlogCommand command)
        {
            bool commandResult = await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async void Delete([FromBody]ExcluirBlogCommand command)
        {
            bool commandResult = await _mediator.Send(command);
        }
    }
}
