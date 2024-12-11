using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Interfaces
{
    public interface ICommentRepository
    {
        void CreateComment(Comment comment);
        bool DeleteComment(Guid commentId);
        Task<IEnumerable<Comment>> GetAllCommentAsync();
        Task<Comment> GetCommentByIdAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetCommentByPostTitle(string postTitle);
        Task<Comment> GetCommentByPostId(Guid postId);
    }
}
