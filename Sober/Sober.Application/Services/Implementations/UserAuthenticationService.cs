using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Services.Interfaces;

namespace Sober.Application.Services.Implementations
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserAuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstname",
                "lastName",
                email,
                "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists

            // Create user (generate unique id)
            

            // Create JWT Token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                userId,
                firstName,
                lastName,
                email,
                token);
        }
    }
}
