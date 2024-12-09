using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate
{
    public sealed class Post : AggregateRoot<PostId>
    {
        private readonly List<PostSection> _sections = new();
        private readonly List<PostTopic> _topics = new();
        public string PostTitle { get; private set; } = null!;
        public string PostAbstract { get; private set; } = null!;
        public ICollection<PostSection> Sections => _sections;
        public ICollection<PostTopic> TopicIds => _topics;
        public UserId UserId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }


        private Post(
            PostId postId,
            UserId userId,
            string postTitle,
            string postAbstract,
            List<PostSection> sections,
            List<PostTopic> topics) : base(postId)
        {
            UserId = userId;
            PostTitle = postTitle;
            PostAbstract = postAbstract;
            _sections = sections;
            _topics = topics;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public static Post Create(
            UserId userId,
            string postTitle,
            string postAbstract,
            List<PostSection> sections,
            List<PostTopic> topics)
        {
            Post postResponse = new Post(PostId.CreateUnique(), userId, postTitle, postAbstract, sections, topics);
            return postResponse;
        }

        public Post()
        {
            
        }
    }
}
