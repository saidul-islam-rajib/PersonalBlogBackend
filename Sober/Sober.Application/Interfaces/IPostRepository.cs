using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Interfaces
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        void UpdatePost(Post post);
        bool DeletePost(Guid id);
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetPostById(Guid id);
        Task<IEnumerable<Post>> GetPostByTitle(string title);
        Task<IEnumerable<Post>> GetPostByTopic(string topic);
    }
}
