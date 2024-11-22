using Microsoft.AspNetCore.Mvc;
using Sober.Application.Services.Interfaces;
using Sober.Contracts.Request;

namespace Sober.Api.Controllers.Authentication
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;

        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterRequest request)
        {
            var authRequest = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authRequest.Id,
                authRequest.FirstName,
                authRequest.LastName,
                authRequest.Email,
                authRequest.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {

            var authRequest = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authRequest.Id,
                authRequest.FirstName,
                authRequest.LastName,
                authRequest.Email,
                authRequest.Token);

            return Ok(response);
        }
    }
}
