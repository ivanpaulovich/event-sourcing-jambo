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
        public async Task<IActionResult> Get(Guid id)
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
        public async Task<IActionResult> Post([FromBody]CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateBlogUrlCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DisableBlogCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
