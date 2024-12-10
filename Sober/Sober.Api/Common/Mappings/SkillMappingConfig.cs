using Mapster;
using Sober.Application.Pages.Skills.Commands;
using Sober.Contracts.Request.Skills;
using Sober.Contracts.Response.Skills;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Api.Common.Mappings
{
    public class SkillMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SkillRequest, CreateSkillCommand>();
            config.NewConfig<Skill, SkillResponse>()
                .Map(dest => dest.skillId, src => src.Id.Value)
                .Map(dest => dest.skillName, src => src.SkillName);
        }
    }
}
