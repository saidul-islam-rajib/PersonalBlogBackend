using Microsoft.AspNetCore.Builder;
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
        await SeedPostDataAsync(context);
    }

    private static async Task SeedPostDataAsync(BlogDbContext context)
    {
        if(!await context.Posts.AnyAsync())
        {
            var response = InitialData.GetSeedData();
            await context.Posts.AddRangeAsync(response);
            var result = await context.SaveChangesAsync();
        }
    }
}
