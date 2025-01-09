namespace Sober.Contracts.Request
{
    public record ExperienceRequest(
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        bool IsFullTimeEmployee,
        List<ExperienceSectionRequest> ExperienceSection,
        DateTime StartDate,
        DateTime EndDate);

    public record ExperienceSectionRequest(string SectionDescription);
}
