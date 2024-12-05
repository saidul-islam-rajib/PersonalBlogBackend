using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Posts.Commands;
using Sober.Contracts.Request.Posts;
using Sober.Contracts.Response.Posts;

namespace Sober.Api.Controllers.Posts
{
    [Route("[controller]")]
    public class PostsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public PostsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("users/{userId}/posts")]
        public async Task<IActionResult> CreatePostRequestAsync(PostRequest request, Guid userId)
        {
            var command = _mapper.Map<CreatePostCommand>((request, userId));
            var result = await _mediator.Send(command);

            var response = result.Match(
                menu => Ok(_mapper.Map<PostResponse>(menu)),
                errors => Problem(errors));

            return response;
        }
    }
}
