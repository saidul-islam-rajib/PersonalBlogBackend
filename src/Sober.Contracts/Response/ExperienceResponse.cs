using Sober.Contracts.Response.Skills;

namespace Sober.Contracts.Response
{
    public record ExperienceResponse(
        Guid ExperienceId,
        string UserId,
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        DateTime StartDate,
        DateTime EndDate,
        bool IsFullTimeEmployee,
        List<SkillResponse> Skills,
        DateTime CreatedDate,
        DateTime UpdatedDate);
}
