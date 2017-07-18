using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Application.Queries;

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

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogTask = _blogQueries.GetBlogsAsync();

            var blogs = await blogTask;

            return Ok(blogs);
        }

        // GET api/values/5
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

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CriarBlogCommand command)
        {
            bool commandResult = await _mediator.Send(command);
            return commandResult ? (IActionResult)Ok() : (IActionResult)BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]string value)
        {
            bool commandResult = await _mediator.Send(command);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
