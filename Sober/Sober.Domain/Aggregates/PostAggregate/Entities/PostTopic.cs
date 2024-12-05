using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostTopic : Entity<PostTopicId>
    {
        public string TopicTitle { get; private set; } = null!;
        private PostTopic(
            PostTopicId postTopicId,
            string topicTitle) : base(postTopicId)
        {
            TopicTitle = topicTitle;
        }

        public static PostTopic Create(
            string topicTitle)
        {
            PostTopic topic = new PostTopic(
                PostTopicId.CreateUqique(),
                topicTitle);

            return topic;
        }
    }
}
