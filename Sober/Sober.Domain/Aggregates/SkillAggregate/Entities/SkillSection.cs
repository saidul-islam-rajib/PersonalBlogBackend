using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.SkillAggregate.Entities
{
    public class SkillSection : Entity<ExperienceId>
    {
        public string SkillName { get; private set; } = null!;

        private SkillSection(SkillId skillId, string skillName)
        {
            SkillName = skillName;
        }

        public static SkillSection Create(string skillName)
        {
            SkillSection response = new SkillSection(SkillId.CreateUnique(), skillName);
            return response;
        }

        public SkillSection()
        {
            
        }
    }
}
