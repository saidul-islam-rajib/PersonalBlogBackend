using Sober.Contracts.Response.Skills;

namespace Sober.Contracts.Response
{
    public record PublicationResponse(
        Guid publicationId,
        string title,
        string journalName,
        string abstraction,
        List<SkillResponse> skills);
}
