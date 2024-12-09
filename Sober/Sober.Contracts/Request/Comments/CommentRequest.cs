namespace Sober.Contracts.Request.Comments
{
    public record CommentRequest(
        string PostId,
        string GuestName,
        string Comment);
}
