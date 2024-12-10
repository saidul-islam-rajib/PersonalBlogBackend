using ErrorOr;
using MediatR;
using Sober.Application.Pages.Skills.Commands;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Commands
{
    public record CreateExperienceCommand(
        Guid UserId,
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        DateTime StartDate,
        DateTime EndDate,
        bool IsFullTimeEmployee,
        List<CreateSkillCommand> Skills) : IRequest<ErrorOr<Experience>>;
}
