using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    internal class ExperienceRepository : IExperienceRepository
    {
        private readonly BlogDbContext _dbContext;

        public ExperienceRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddExperience(Experience experience)
        {
            _dbContext.Add(experience);
            _dbContext.SaveChanges();
        }

        public bool DeleteExperience(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Experience>> GetAllExperienceAsync()
        {
            var response = await _dbContext.Experiences.Include(x => x.Skills).ToListAsync();
            return response;
        }

        public async Task<Experience> GetExperienceByIdAsync(Guid experienceId)
        {
            var response = await _dbContext.Experiences
                .Include(experience => experience.Skills)
                .FirstOrDefaultAsync(ex => ex.Id.Equals(new ExperienceId(experienceId)));

            return response;
        }
    }
}
