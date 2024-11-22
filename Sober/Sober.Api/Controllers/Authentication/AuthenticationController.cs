using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Services.Authentication.Commands;
using Sober.Application.Services.Authentication.Common;
using Sober.Application.Services.Authentication.Queries;
using Sober.Application.Services.Interfaces;
using Sober.Contracts.Request;

namespace Sober.Api.Controllers.Authentication
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errorList => Problem(errorList));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }


        private static AuthenticationResponse MapAuthResult(AuthenticationResult authRequest)
        {
            return new AuthenticationResponse(
                            authRequest.User.Id,
                            authRequest.User.FirstName,
                            authRequest.User.LastName,
                            authRequest.User.Email,
                            authRequest.Token);
        }
    }
}
