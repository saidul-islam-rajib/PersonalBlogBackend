using MediatR;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Skills.Queries.Query
{
    public record GetAllSkillQuery : IRequest<IEnumerable<Skill>>
    {
    }
}
