using Sober.Contracts.Response.Comments;
using Sober.Contracts.Response.Posts;

namespace Sober.Contracts.Response
{
    public record ProjectRsponse(
        Guid projectId,
        string projectTitle,
        string projectAbstraction,
        List<PostSectionResponse> sections,
        string srcCodeLink,
        string userId,
        List<TopicResponse> topics,
        List<CommentResponse> comments,
        DateTime date,
        DateTime createdDate,
        DateTime updatedDate);
}
