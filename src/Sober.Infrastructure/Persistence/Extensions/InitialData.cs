using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Extensions;

internal class InitialData
{
    public static List<Education> CreateEducationAsync(UserId userId)
    {
        var educations = new List<Education>
        {
            Education.Create(
                userId,
                "Daffodil International University",
                "diu.png",
                "Computer Science & Engineering",
                new DateTime(2018, 01, 01),
                new DateTime(2022, 02, 22)
            )
        };

        return educations;
    }
    public static List<Experience> CreateExperienceAsync(UserId userId)
    {
        var experiences = new List<Experience>
        {
            Experience.Create(
                userId,
                "ASA International Management Services Limited",
                "AMSL",
                "amsl.png",
                "Intern Software Engineer",
                false,
                new DateTime(2022, 10, 10),
                new DateTime(2023, 01, 10),
                true),

            Experience.Create(
                userId,
                "ASA International Management Services Limited",
                "AMSL",
                "amsl.png",
                "Junior Software Engineer",
                true,
                new DateTime(2023, 01, 11),
                new DateTime(2025, 01, 02),
                true)
        };

        return experiences;
    }

    public static List<Skill> CreateSkillAsync()
    {
        var skills = new List<Skill>
        {
            Skill.Create("Data Structure & Algorithms"),
            Skill.Create("Computer Networks"),
            Skill.Create("Operating System"),
        };
        return skills;
    }

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

    public static List<Post> CreatePostAsync(UserId userId)
    {

        var posts =  new List<Post>
            {
                Post.Create(
                    userId,
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
