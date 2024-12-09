using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.CommentAggregate.Entities
{
    public class CommentSection : Entity<CommentId>
    {
        public string CommentorName { get; private set; } = null!;
        public string CommentorComment { get; private set; } = null!;
        public PostId PostId { get; private set; } = null!;

        private CommentSection(
            CommentId commentId,
            string commentorName,
            string commentorComment,
            PostId postId) : base(commentId)
        {
            CommentorName = commentorName;
            CommentorComment = commentorComment;
            PostId = postId;
        }

        public static CommentSection Create(string commentorName, string commentorComment, PostId postId)
        {
            CommentSection commentSection = new CommentSection(
                CommentId.CreateUnique(),
                commentorName,
                commentorComment,
                postId);
            return commentSection;
        }

        public CommentSection()
        {
            
        }
    }
}
