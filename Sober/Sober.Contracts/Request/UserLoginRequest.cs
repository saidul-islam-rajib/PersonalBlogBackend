namespace Sober.Contracts.Request
{
    public record UserLoginRequest(
        string Email,
        string Password);
}
