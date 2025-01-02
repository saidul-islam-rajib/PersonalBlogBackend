using MediatR;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Pages.Users.Queries;

public record GetDefaultUserQuery : IRequest<User>
{
}
