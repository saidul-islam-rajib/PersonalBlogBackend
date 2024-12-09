using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Commands
{
    public record CreatePostCommand(
        Guid UserId,
        string PostTitle,
        string PostAbstract,
        List<PostSectionCommand> Sections,
        List<TopicCommand> Topics
        ) : IRequest<ErrorOr<Post>>;

    public record PostSectionCommand(
        string SectionTitle,
        string SectionDescription,
        List<PostSectionItemCommand> Items);

    public record PostSectionItemCommand(
        string ItemTitle,
        string ItemDescription,
        string ItemImageLink);

    public record TopicCommand(
        Guid UserId,
        string TopicTitle);
}
