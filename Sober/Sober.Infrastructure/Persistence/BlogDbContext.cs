using Microsoft.EntityFrameworkCore;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Infrastructure.Persistence
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
