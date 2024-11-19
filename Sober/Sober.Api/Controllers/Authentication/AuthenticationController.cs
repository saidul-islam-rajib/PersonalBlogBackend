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
            return Ok(request);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {
            return Ok(request);
        }
    }
}
