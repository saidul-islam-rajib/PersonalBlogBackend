namespace Sober.Contracts.Response.Comments
{
    public record CommentResponse(
        Guid CommentId,
        string PostId,
        string PostTitle,
        string CommentorName,
        string Comment,
        DateTime date);
}
