using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ExperienceAggregate
{
    public sealed class Experience : AggregateRoot<ExperienceId>
    {
        private readonly List<Skill> _skills = new();
        public string CompanyName { get; private set; } = null!;
        public string? ShortName { get; private set; }
        public string? CompanyLogo { get; private set; }
        public string Designation { get; private set; } = null!;
        public bool IsCurrentEmployee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsFullTimeEmployee { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyCollection<Skill> Skills => _skills.AsReadOnly();

        private Experience(
            ExperienceId experienceId,
            UserId userId,
            string companyName,
            string shortName,
            string companyLogo,
            string designation,
            bool isCurrentEmployee,
            DateTime startDate,
            DateTime endDate,
            bool isFullTimeEmployee) : base(experienceId)
        {
            UserId = userId;
            CompanyName = companyName;
            ShortName = shortName ?? null;
            CompanyLogo = companyLogo ?? null;
            Designation = designation;
            IsCurrentEmployee = isCurrentEmployee;
            StartDate = startDate;
            EndDate = endDate;
            IsFullTimeEmployee = isFullTimeEmployee;
        }

        public static Experience Create(
            UserId userId,
            string companyName,
            string shortName,
            string companyLogo,
            string designation,
            bool isCurrentEmployee,
            DateTime startDate,
            DateTime endDate,
            bool isFullTimeEmployee)
        {
            Experience response = new Experience(
                ExperienceId.CreateUnique(),
                userId,
                companyName,
                shortName,
                companyLogo,
                designation,
                isCurrentEmployee,
                startDate,
                endDate,
                isFullTimeEmployee);

            return response;
        }

        public void AddSkill(Skill skill)
        {
            if (!_skills.Contains(skill))
                _skills.Add(skill);
        }

        public void RemoveSkill(Skill skill)
        {
            if (_skills.Contains(skill))
                _skills.Remove(skill);
        }

        private Experience()
        {
            
        }
    }
}
