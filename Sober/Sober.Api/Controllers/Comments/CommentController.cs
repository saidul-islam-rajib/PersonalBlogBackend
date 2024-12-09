using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Comments.Commands;
using Sober.Contracts.Request.Comments;
using Sober.Contracts.Response.Comments;

namespace Sober.Api.Controllers.Comments
{
    [Route("[controller]")]
    public class CommentController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CommentController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("posts/{postId}/comment")]
        public async Task<IActionResult> CreateComment(CommentRequest request, Guid postId)
        {
            var command = _mapper.Map<CreateCommentCommand>((request, postId));
            var result = await _mediator.Send(command);

            var response = result.Match(
                comment => Ok(_mapper.Map<CommentResponse>(comment)),
                errors => Problem(errors));

            return response;
        }
    }
}
