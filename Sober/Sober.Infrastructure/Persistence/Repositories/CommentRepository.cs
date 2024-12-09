using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.CommentAggregate;

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
    }
}
