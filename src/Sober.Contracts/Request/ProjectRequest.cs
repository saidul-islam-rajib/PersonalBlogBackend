namespace Sober.Contracts.Request
{
    public record ProjectRequest(
        string srcCodeLink,
        Guid postId,
        DateTime date);
}
