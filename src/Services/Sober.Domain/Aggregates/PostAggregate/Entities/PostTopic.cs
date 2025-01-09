using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostTopic : Entity<PostTopicId>
    {
        public string TopicTitle { get; private set; } = null!;
        public UserId UserId { get; private set; }

        private PostTopic(
            PostTopicId postTopicId,
            UserId userId,
            string topicTitle) : base(postTopicId)
        {
            TopicTitle = topicTitle;
            UserId = userId;
        }

        public static PostTopic Create(
            UserId userId,
            string topicTitle)
        {
            PostTopic topic = new PostTopic(
                PostTopicId.CreateUqique(),
                userId,
                topicTitle);

            return topic;
        }

        public PostTopic()
        {
            
        }
    }
}
