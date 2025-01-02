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

        //await SeedTopicAsync(context);
        //await SeedSkillAsync(context);
        //await SeedSectionAsync(context);
        //await SeedPostItemAsync(context);

        if(!await context.Posts.AnyAsync())
        {
            postId = await SeedPostAsync(context);
        }

        //await SeedExperienceAsync(context);
        //await SeedEducationAsync(context);

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

    private static async Task SeedTopicAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedSkillAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedSectionAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedPostItemAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedExperienceAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedEducationAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedCommentAsync(BlogDbContext context, PostId postId)
    {
        var comments = InitialData.CreateCommentAsync(postId);
        await context.Comments.AddRangeAsync(comments);
        await context.SaveChangesAsync();
    }

    private static async Task<PostId> SeedPostAsync(BlogDbContext context)
    {
        List<Post> posts = InitialData.CreatePostAsync();
        await context.Posts.AddRangeAsync(posts);
        await context.SaveChangesAsync();

        return posts[0].Id;
    }
}
