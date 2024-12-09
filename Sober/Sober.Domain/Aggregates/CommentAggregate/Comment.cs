using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.CommentAggregate
{
    public class Comment : AggregateRoot<CommentId>
    {
        public string PostTitle { get; private set; } = null!;
        public string CommentorName { get; private set; } = null!;
        public string CommentorComment { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public PostId PostId { get; private set; }



        private Comment(
            CommentId commentId,
            PostId postId,
            string commentorName,
            string commentorComment)
        {
            PostId = postId;
            CommentorName = commentorName;
            CommentorComment = commentorComment;
            Date = DateTime.Now;
        }

        public static Comment Create(PostId postId, string commentorName, string commentorComment)
        {
            Comment comment = new Comment(CommentId.CreateUnique(), postId, commentorName, commentorComment);
            return comment;
        }

        public Comment()
        {
            
        }
    }
}
