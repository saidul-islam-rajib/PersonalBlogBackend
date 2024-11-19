using Sober.Application.Services.Interfaces;

namespace Sober.Application.Services.Implementations
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
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
            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                "token");
        }
    }
}
