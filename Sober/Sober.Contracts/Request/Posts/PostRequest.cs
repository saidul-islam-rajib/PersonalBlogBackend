namespace Sober.Contracts.Request.Posts
{
    public record PostRequest(
        string postTitle,
        string postAbstract,
        List<PostSectionRequest> Sections,
        List<TopicRequest> Topics);

    public record PostSectionRequest(
        string sectionTitle,
        string sectionDescription,
        List<PostSectionItemRequest> Items);

    public record PostSectionItemRequest(
        string itemTitle,
        string itemDescription,
        string itemImageLink);

    public record TopicRequest(
        string topicTitle,
        string userId);

}
