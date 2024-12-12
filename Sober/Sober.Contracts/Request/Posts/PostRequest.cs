namespace Sober.Contracts.Request.Posts
{
    public record PostRequest(
        string PostTitle,
        string PostAbstract,
        string Conclusion,
        int ReadingMinute,
        List<PostSectionRequest> Sections,
        List<TopicRequest> Topics);

    public record PostSectionRequest(
        string SectionTitle,
        string SectionDescription,
        List<PostSectionItemRequest> Items);

    public record PostSectionItemRequest(
        string ItemTitle,
        string ItemDescription,
        string ItemImageLink);

    public record TopicRequest(
        string TopicTitle,
        string UserId);

}
