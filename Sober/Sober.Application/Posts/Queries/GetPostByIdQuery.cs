using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries
{
    public record GetPostByIdQuery(Guid postId) : IRequest<Post>
    {
    }
}
