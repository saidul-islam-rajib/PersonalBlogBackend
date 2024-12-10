using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Skills.Commands
{
    public record CreateSkillCommand(string skillName) : IRequest<ErrorOr<Skill>>;
}
