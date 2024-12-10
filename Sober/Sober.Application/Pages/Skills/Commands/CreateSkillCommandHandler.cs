using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Skills.Commands
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, ErrorOr<Skill>>
    {
        private readonly ISkillRepository _skillRepository;

        public CreateSkillCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ErrorOr<Skill>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            Skill skill = Skill.Create(request.skillName);
            _skillRepository.CreateSkill(skill);

            return skill;
        }
    }
}
