using Sober.Contracts.Request.Skills;

namespace Sober.Contracts.Request
{
    public record PublicationRequest(
        string title,
        string journalName,
        string abstraction,
        List<SkillRequest> skills);
}
