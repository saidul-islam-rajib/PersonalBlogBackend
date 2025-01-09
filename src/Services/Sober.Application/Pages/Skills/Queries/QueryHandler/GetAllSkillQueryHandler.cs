using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Skills.Queries.Query;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Skills.Queries.QueryHandler
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, IEnumerable<Skill>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Skill>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var response = await _skillRepository.GetAllSkillAsync();
            return response;
        }
    }
}
