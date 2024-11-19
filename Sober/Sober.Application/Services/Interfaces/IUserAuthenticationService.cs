namespace Sober.Application.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
