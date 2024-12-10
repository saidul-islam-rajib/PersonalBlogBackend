using Microsoft.EntityFrameworkCore;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Entities;

namespace Sober.Infrastructure.Persistence
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
