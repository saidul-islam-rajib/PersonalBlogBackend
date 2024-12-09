using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries
{
    public record GetAllPostsQuery : IRequest<IEnumerable<Post>>
    {
    }
}
