namespace Sober.Contracts.Request
{
    public record UserRegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
