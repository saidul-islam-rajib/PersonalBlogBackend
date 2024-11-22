using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Services.Interfaces;
using Sober.Domain.Entities;

namespace Sober.Application.Services.Implementations
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public UserAuthenticationService(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // 1. User does exits
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exists.");
            }

            // 2. Validate user credentials (passwords)
            if(user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // 3. Create JWT token
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, "first name", "last name");
            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
            }

            // Create user (generate unique id) and persist into DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // Create JWT Token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
