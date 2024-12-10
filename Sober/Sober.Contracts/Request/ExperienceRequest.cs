using Sober.Contracts.Request.Skills;

namespace Sober.Contracts.Request
{
    public record ExperienceRequest(
        string companyName,
        string companyLogo,
        string designation,
        bool isCurrentEmployee,
        DateTime startDate,
        DateTime endDate,
        bool isFullTimeEmployee,
        List<SkillRequest> skill);
}
