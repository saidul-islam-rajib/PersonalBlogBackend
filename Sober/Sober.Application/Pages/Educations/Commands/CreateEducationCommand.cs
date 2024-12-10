using ErrorOr;
using MediatR;
using Sober.Application.Pages.Skills.Commands;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Commands
{
    public record CreateEducationCommand(
        Guid UserId,
        string InstituteName,
        string InstituteLogo,
        string Department,
        DateTime StartDate,
        DateTime EndDate,
        List<CreateSkillCommand> Skills) : IRequest<ErrorOr<Education>>;
}
