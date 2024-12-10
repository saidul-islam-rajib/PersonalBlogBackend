using FluentValidation;

namespace Sober.Application.Pages.Skills.Commands
{
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(x => x.skillName).NotEmpty();
        }
    }
}
