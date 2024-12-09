using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public void CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
