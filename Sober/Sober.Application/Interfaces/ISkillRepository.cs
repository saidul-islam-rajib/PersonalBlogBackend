using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Interfaces
{
    public interface ISkillRepository
    {
        void CreateSkill(Skill skill);
        bool DeleteSkill(Guid skillId);
        Task<IEnumerable<Skill>> GetAllSkillAsync();
        Task<Skill> GetSkillByIdAsync(Guid skillId);
    }
}
