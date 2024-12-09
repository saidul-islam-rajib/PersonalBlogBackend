using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IPostRepository _repository;

        public GetPostByIdQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetPostByIdAsync(request.postId);
            return response;
        }
    }
}
