using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        private readonly List<PostId> _postIds = new();
        private readonly List<PostTopicId> _topicIds = new();
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;
        public string ProfileImage { get; } = null!;
        public IReadOnlyList<PostId> PostIds => _postIds.AsReadOnly();
        public IReadOnlyList<PostTopicId> PostTopicIds => _topicIds.AsReadOnly();
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; }

        public User(
            UserId userId,
            string firstName,
            string lastName,
            string profileImage,
            List<PostId>? postIds,
            List<PostTopicId>? topicIds,
            DateTime createdDate,
            DateTime updatedDate)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            _postIds = postIds;
            _topicIds = topicIds;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }

        public static User Create(
            Guid userId,
            string firstName,
            string lastName,
            string profileImage,
            List<PostId>? postIds,
            List<PostTopicId>? topicIds,
            DateTime createdDate,
            DateTime updatedDate)
        {
            User user = new User(UserId.CreateUnique(), firstName, lastName, profileImage, postIds, topicIds, createdDate, updatedDate);
            return user;
        }
    }
}
