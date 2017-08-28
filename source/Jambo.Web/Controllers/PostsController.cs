using Jambo.Application.Commands;
using Jambo.Application.Commands.Blogs;
using Jambo.Application.Commands.Posts;
using Jambo.Application.Queries;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Jambo.Web.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IPostQueries _postQueries;

        public PostsController(IMediator mediator, IPostQueries postQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _postQueries = postQueries ?? throw new ArgumentNullException(nameof(postQueries));
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(Guid blogId)
        {
            var posts = await _postQueries.GetPostsAsync(blogId);

            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post = await _postQueries.GetPostAsync(id);

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePostCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Guid id = await _mediator.Send(command);

                return CreatedAtRoute("GetPost", new { id = id }, id);
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("Comment")]
        public async Task<IActionResult> Comment([FromBody]CreateCommentCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("Enable")]
        public async Task<IActionResult> Enable([FromBody]EnablePostCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("Disable")]
        public async Task<IActionResult> Disable([FromBody]DisablePostCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("Publish")]
        public async Task<IActionResult> Publish([FromBody]PublishPostCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("Hide")]
        public async Task<IActionResult> Hide([FromBody]HidePostCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("UpdateContent")]
        public async Task<IActionResult> UpdateContent([FromBody]UpdatePostContentCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _mediator.Send(command);
                return (IActionResult)Ok();
            }
            catch (BlogDomainException ex)
            {
                ModelState.AddModelError("DomainException", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
