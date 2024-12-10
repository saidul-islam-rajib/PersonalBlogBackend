using Sober.Contracts.Request.Skills;

namespace Sober.Contracts.Request
{
    public record EducationRequest(
        string InstituteName,
        string InstituteLogo,
        string Department,
        DateTime StartDate,
        DateTime EndDate,
        List<SkillRequest> Skills);
}
