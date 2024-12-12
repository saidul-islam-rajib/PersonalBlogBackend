using Sober.Domain.Entities;

namespace Sober.Application.Services.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token);
}
