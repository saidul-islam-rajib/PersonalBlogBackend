namespace Sober.Contracts.Request.Authentication
{
    public record UserRegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
