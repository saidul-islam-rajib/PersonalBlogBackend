using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Extensions;

internal class InitialData
{
    public static List<Comment> CreateCommentAsync(PostId postId)
    {
        var comments = new List<Comment>
        {
            Comment.Create(
                postId,
                "Sajib Ahmed",
                "This is one of the best project...",
                "Post Title 1"),

            Comment.Create(
                postId,
                "Rakib Ahmed",
                "This is one of the best project...",
                "Post Title 2")
        };
        return comments;
    }

    public static User CreateUserAsync()
    {
        var user = User.Create(
            "Saidul Islam",
            "Rajib",
            "saidul.is.rajib@gmail.com",
            "Test@123"
        );
        return user;
    }

    public static List<Post> CreatePostAsync()
    {

        var posts =  new List<Post>
            {
                Post.Create(
                    UserId.Create(Guid.NewGuid()),
                    "POST TITLE 1",
                    "This is post abstraction",
                    "this is all about conclusions.",
                    10,
                    new List<PostSection>
                    {
                        PostSection.Create(
                            "Section title 1",
                            "Section description",
                            new List<PostItem>
                            {
                                PostItem.Create(
                                    "item title 1",
                                    "item description 1",
                                    "first.png"
                                ),
                                PostItem.Create(
                                    "item title 2",
                                    "item description 2",
                                    "second.png"
                                )
                            }
                        )
                    },
                    new List<PostTopic>
                    {
                        PostTopic.Create(
                            UserId.Create(Guid.NewGuid()),
                            "Topic title 1"
                        )
                    }
                )
            };

        return posts;
    }
}
