using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _dbContext;

        public CommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateComment(Comment comment)
        {
            _dbContext.Add(comment);
            _dbContext.SaveChanges();
        }

        public bool DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            var response = await _dbContext.Comments.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<Comment> GetCommentByIdAsync(Guid commentId)
        {
            var response = await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id.Equals(new CommentId(commentId)));
            return response;
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostTitle(string postTitle)
        {
            var response = await _dbContext.Comments.Where(post => post.PostTitle.Contains(postTitle)).ToListAsync();
            return response;
        }
    }
}
