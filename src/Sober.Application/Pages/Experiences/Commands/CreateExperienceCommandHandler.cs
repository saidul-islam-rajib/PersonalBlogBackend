using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Experiences.Commands
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, ErrorOr<Experience>>
    {
        private readonly IExperienceRepository _repository;

        public CreateExperienceCommandHandler(IExperienceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Experience>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            List<Skill> skills = request.Skills.Select(skillDto =>
                Skill.Create(skillDto.skillName)
            ).ToList();

            Experience experience = Experience.Create(
                UserId.Create(request.UserId),
                request.CompanyName,
                request.ShortName,
                request.CompanyLogo,
                request.Designation,
                request.IsCurrentEmployee,
                request.StartDate,
                request.EndDate,
                request.IsFullTimeEmployee);

            foreach (Skill skill in skills)
            {
                experience.AddSkill(skill);
            }

            _repository.AddExperience(experience);

            return experience;
        }
    }
}
