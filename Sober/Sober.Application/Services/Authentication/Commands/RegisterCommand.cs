using ErrorOr;
using MediatR;
using Sober.Application.Services.Authentication.Common;

namespace Sober.Application.Services.Authentication.Commands
{
    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
