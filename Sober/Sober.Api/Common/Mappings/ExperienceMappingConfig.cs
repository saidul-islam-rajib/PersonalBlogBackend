using Mapster;
using Sober.Application.Pages.Experiences.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Contracts.Response.Skills;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.SkillAggregate.Entities;

namespace Sober.Api.Common.Mappings
{
    public class ExperienceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(ExperienceRequest Request, Guid UserId), CreateExperienceCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Experience, ExperienceResponse>()
                .Map(dest => dest.ExperienceId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.Designation, src => src.Designation)
                .Map(dest => dest.CompanyName, src => src.CompanyName);

            config.NewConfig<SkillSection, SkillResponse>()
                .Map(dest => dest.skillId, src => src.Id.Value);
        }
    }
}
