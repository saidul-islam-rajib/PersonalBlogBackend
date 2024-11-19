namespace Sober.Contracts.Request
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
