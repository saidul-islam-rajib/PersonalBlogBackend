using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Services;
using Sober.Application.Services.Interfaces;
using Sober.Contracts.Request;

namespace Sober.Api.Controllers.Authentication
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IUserAuthenticationService _authenticationService;

        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {

            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(
                request.Email,
                request.Password);

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
