using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;

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
            var response = await _dbContext.Posts.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            var response = await _dbContext.Posts.Include(post => post.Sections)
                                  .ThenInclude(section => section.Items)
                                  .FirstOrDefaultAsync(post => post.Id.Equals(new PostId(postId)));
            return response;
        }

        public async Task<IEnumerable<Post>> GetPostByTitle(string title)
        {
            var response = await _dbContext.Posts.Include(post => post.Sections)
                                                 .ThenInclude(section => section.Items)
                                                 .Where(post => post.PostTitle.Contains(title))
                                                 .ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Post>> GetPostByTopicTitle(string topicTitle)
        {
            var response = await _dbContext.Posts.Include(post => post.Sections)
                                                 .ThenInclude(section => section.Items)
                                                 .Where(post => post.TopicIds.Any(topic => topic.TopicTitle.Contains(topicTitle)))
                                                 .ToListAsync();
            return response;
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
