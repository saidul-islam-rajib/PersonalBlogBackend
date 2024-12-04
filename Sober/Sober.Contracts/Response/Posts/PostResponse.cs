namespace Sober.Contracts.Response.Posts
{
    public record PostResponse(
        Guid postId,
        string postTitle,
        string postAbstract,
        List<PostSectionResponse> Sections,
        List<TopicResponse> Topics,
        string userId,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record PostSectionResponse(
        string sectionId,
        string sectionTitle,
        string sectionDescription,
        List<PostSectionItemResponse> Items);

    public record PostSectionItemResponse(
        string itemId,
        string itemTitle,
        string itemDescription,
        string itemImageLink);

    public record TopicResponse(
        string topicId,
        string topicTitle,
        string userId);
}
