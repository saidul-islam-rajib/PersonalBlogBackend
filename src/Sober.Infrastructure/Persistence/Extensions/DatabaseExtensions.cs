using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();
        await SeedDataAsync(context);
    }

    private static async Task SeedDataAsync(BlogDbContext context)
    {
        var userId = UserId.CreateUnique();
        var postId = PostId.CreateUnique();

        if (!await context.Users.AnyAsync())
        {
            userId = await SeedUserAsync(context);
        }

        if(!await context.Skills.AnyAsync())
        {
            await SeedSkillAsync(context);
        }

        if(!await context.Posts.AnyAsync())
        {
            postId = await SeedPostAsync(context, userId);
        }

        if(!await context.Experiences.AnyAsync())
        {
            await SeedExperienceAsync(context, userId);
        }

        if(!await context.Educations.AnyAsync())
        {
            await SeedEducationAsync(context, userId);
        }

        if (!await context.Comments.AnyAsync())
        {
            await SeedCommentAsync(context, postId);
        }

    }

    private static async Task<UserId> SeedUserAsync(BlogDbContext context)
    {
        var user = InitialData.CreateUserAsync();
        await context.Users.AddRangeAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    private static async Task SeedSkillAsync(BlogDbContext context)
    {
        var skills = InitialData.CreateSkillAsync();
        await context.Skills.AddRangeAsync(skills);
        await context.SaveChangesAsync();
    }


    private static async Task SeedExperienceAsync(BlogDbContext context, UserId userId)
    {
        var experiences = InitialData.CreateExperienceAsync(userId);
        await context.Experiences.AddRangeAsync(experiences);
        await context.SaveChangesAsync();
    }

    private static async Task SeedEducationAsync(BlogDbContext context, UserId userId)
    {
        var educations = InitialData.CreateEducationAsync(userId);
        await context.Educations.AddRangeAsync(educations);
        await context.SaveChangesAsync();
    }

    private static async Task SeedCommentAsync(BlogDbContext context, PostId postId)
    {
        var comments = InitialData.CreateCommentAsync(postId);
        await context.Comments.AddRangeAsync(comments);
        await context.SaveChangesAsync();
    }

    private static async Task<PostId> SeedPostAsync(BlogDbContext context, UserId userId)
    {
        List<Post> posts = InitialData.CreatePostAsync(userId);
        await context.Posts.AddRangeAsync(posts);
        await context.SaveChangesAsync();

        return posts[0].Id;
    }
}
