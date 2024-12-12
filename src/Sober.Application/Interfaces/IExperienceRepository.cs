using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Interfaces
{
    public interface IExperienceRepository
    {
        void AddExperience(Experience experience);
        bool DeleteExperience(Guid commentId);
        Task<IEnumerable<Experience>> GetAllExperienceAsync();
        Task<Experience> GetExperienceByIdAsync(Guid experienceId);
    }
}
