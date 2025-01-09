using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Users.Queries;
using Sober.Contracts.Response;

namespace Sober.Api.Controllers.UserInformation;

public class UserController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public UserController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-default-user")]
    public async Task<IActionResult> GetDefaultUser()
    {
        var query = new GetDefaultUserQuery();
        var user = await _mediator.Send(query);
        if(user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserResponse>(user);
        return Ok(response);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);

        if(user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserResponse>(user);
        return Ok(response);
    }
}
