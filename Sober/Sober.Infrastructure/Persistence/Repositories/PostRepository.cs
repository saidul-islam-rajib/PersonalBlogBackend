using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePost(Post post)
        {
            _dbContext.Add(post);
            _dbContext.SaveChanges();
        }

        public bool DeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            var response = await _dbContext.Posts.ToListAsync();
            return response;
        }

        public Task<Post> GetPostById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPostByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPostByTopic(string topic)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
