using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostItem : Entity<PostItemId>
    {
        public string PostItemTitle { get; private set; } = null!;
        public string PostItemDescription { get; private set; } = null!;
        public string PostItemImageLink { get; private set; } = null!;

        private PostItem(
            PostItemId postItemId,
            string postItemTitle,
            string postItemDescription,
            string postItemImageLink) : base(postItemId)
        {
            PostItemTitle = postItemTitle;
            PostItemDescription = postItemDescription;
            PostItemImageLink = postItemImageLink;
        }

        public static PostItem Create(
            string postItemTitle,
            string postItemDescription,
            string postItemImageLink)
        {
            PostItem items = new PostItem(PostItemId.CreateUqique(), postItemTitle, postItemDescription, postItemImageLink);
            return items;
        }


        private PostItem()
        {
        }
    }
}
