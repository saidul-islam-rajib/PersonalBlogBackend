using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.SkillAggregate
{
    public sealed class Skill : AggregateRoot<SkillId>
    {
        public string SkillName { get; private set; } = null!;
        private Skill(SkillId skillId, string skillName) : base(skillId)
        {
            SkillName = skillName;
        }

        public static Skill Create(string skillName)
        {
            Skill response = new Skill(SkillId.CreateUnique(), skillName);
            return response;
        }

        private Skill()
        {
            
        }
    }
}
