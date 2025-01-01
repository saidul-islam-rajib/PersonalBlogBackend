﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        await SeedUserAsync(context);
        //await SeedTopicAsync(context);
        //await SeedSkillAsync(context);
        //await SeedSectionAsync(context);
        //await SeedPostItemAsync(context);
        //await SeedPostAsync(context);
        //await SeedExperienceAsync(context);
        //await SeedEducationAsync(context);
        //await SeedCommentAsync(context);
    }

    private static async Task SeedUserAsync(BlogDbContext context)
    {
        if(!await context.Users.AnyAsync())
        {
            await context.Users.AddRangeAsync(InitialData.CreateUserAsync());
            await context.SaveChangesAsync();
        }
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

    private static async Task SeedCommentAsync(BlogDbContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task SeedPostAsync(BlogDbContext context)
    {
        if(!await context.Posts.AnyAsync())
        {
            var response = InitialData.GetSeedData();
            await context.Posts.AddRangeAsync(response);
            await context.SaveChangesAsync();
        }
    }
}
