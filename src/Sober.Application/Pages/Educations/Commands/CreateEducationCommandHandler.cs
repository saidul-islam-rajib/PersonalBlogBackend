using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Educations.Commands
{
    public class CreateEducationCommandHandler
        : IRequestHandler<CreateEducationCommand, ErrorOr<Education>>
    {
        private readonly IEducationRepository _educationRepository;

        public CreateEducationCommandHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<ErrorOr<Education>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            List<Skill> skills = request.Skills.Select(skillDto =>
                Skill.Create(skillDto.skillName)
            ).ToList();

            Education education = Education.Create(
                UserId.Create(request.UserId),
                request.InstituteName,
                request.InstituteLogo,
                request.Department,
                request.StartDate,
                request.EndDate);

            foreach (Skill skill in skills)
            {
                education.AddSkill(skill);
            }

            _educationRepository.AddEducation(education);
            return education;
        }
    }
}
