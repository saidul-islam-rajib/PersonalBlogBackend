using Sober.Domain.Entities;

namespace Sober.Application.Services
{
    public record AuthenticationResult
    (
        User User,
        string Token);
}
