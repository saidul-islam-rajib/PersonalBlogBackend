using Sober.Contracts.Request.Skills;

namespace Sober.Contracts.Request
{
    public record ExperienceRequest(
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        DateTime StartDate,
        DateTime EndDate,
        bool IsFullTimeEmployee,
        List<SkillRequest> Skills);
}
