using Mapster;
using Sober.Application.Pages.Educations.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response.Skills;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Api.Common.Mappings
{
    public class EducationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(EducationRequest Request, Guid UserId), CreateEducationCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Education, EducationResponse>()
                .Map(dest => dest.EducationId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.InstituteName, src => src.InstituteName)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.Skills, src => src.Skills.Select(s => new SkillResponse(
                    s.Id.Value.ToString(),
                    s.SkillName)
                {
                    SkillId = s.Id.Value.ToString(),
                    SkillName = s.SkillName
                }).ToList());

            config.NewConfig<Skill, SkillResponse>()
                .Map(dest => dest.SkillId, src => src.Id.Value)
                .Map(dest => dest.SkillName, src => src.SkillName);
        }
    }
}
