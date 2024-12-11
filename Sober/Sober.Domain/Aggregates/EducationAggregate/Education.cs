using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.EducationAggregate
{
    public sealed class Education : AggregateRoot<EducationId>
    {
        private readonly List<Skill> _skills = new();
        public string InstituteName { get; private set; } = null!;
        public string? InstituteLogo { get; private set; }
        public string Department { get; private set; } = null!;
        public DateTime StartDate { get ; private set; }
        public DateTime? EndDate { get; private set; }
        public UserId UserId { get; private set; }
        public ICollection<Skill> Skills => _skills;

        private Education(
            EducationId id,
            UserId userId,
            string instituteName,
            string? instituteLogo,
            string department,
            DateTime startDate,
            DateTime? endDate) : base(id)
        {
            UserId = userId;
            InstituteName = instituteName;
            InstituteLogo = instituteLogo ?? null;
            Department = department;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static Education Create(
            UserId userId,
            string instituteName,
            string? instituteLogo,
            string department,
            DateTime startDate,
            DateTime? endDate)
        {
            Education response = new Education(
                EducationId.CreateUnique(),
                userId,
                instituteName,
                instituteLogo,
                department,
                startDate,
                endDate);

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

        private Education() { }
    }
}
