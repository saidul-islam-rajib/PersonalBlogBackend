using Sober.Contracts.Response.Skills;

namespace Sober.Contracts.Response
{
    public record ExperienceResponse(
        Guid experienceId,
        string companyName,
        string companyLogo,
        string designation,
        bool isCurrentEmployee,
        DateTime startDate,
        DateTime endDate,
        bool isFullTimeEmployee,
        List<SkillResponse> skill,
        DateTime createdDate,
        DateTime updatedDate);
}
