using Sober.Contracts.Response.Skills;

namespace Sober.Contracts.Response
{
    public record EducationResponse(
        Guid EducationId,
        string UserId,
        string InstituteName,
        string InstituteLogo,
        string Department,
        DateTime StartDate,
        DateTime EndDate,
        List<SkillResponse> Skills);
}
