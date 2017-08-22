using Jambo.Application.Commands;
using Jambo.Application.Commands.Posts;
using Jambo.Application.Queries;
using Jambo.Domain.Aggregates.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jambo.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBlogQueries _blogQueries;

        public PostsController(IMediator mediator, IBlogQueries blogQueries)
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

        [HttpGet("{id}", Name = "GetPost")]
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
        public async Task<IActionResult> Post([FromBody]CreatePostCommand command)
        {
            Guid id = await _mediator.Send(command);

            return CreatedAtRoute("GetPost", new { id = id }, id);
        }

        [HttpPatch("Enable")]
        public async Task<IActionResult> Enable([FromBody]EnablePostCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Disable")]
        public async Task<IActionResult> Disable([FromBody]DisablePostCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Publish")]
        public async Task<IActionResult> Publish([FromBody]PublishPostCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Hide")]
        public async Task<IActionResult> Hide([FromBody]HidePostCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("UpdateContent")]
        public async Task<IActionResult> UpdateContent([FromBody]UpdatePostContentCommand command)
        {
            await _mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
