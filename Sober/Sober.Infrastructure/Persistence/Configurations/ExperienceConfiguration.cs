using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            ConfigureExperienceTable(builder);
        }

        private void ConfigureExperienceTable(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(id => id.Value, value => ExperienceId.Create(value))
                .ValueGeneratedNever();

            builder.Property(x => x.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ShortName).HasMaxLength(10);
            builder.Property(x => x.CompanyLogo).HasMaxLength(500);
            builder.Property(x => x.Designation).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsCurrentEmployee);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate);
            builder.Property(x => x.IsFullTimeEmployee);

            builder.Property(x => x.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value))
                .IsRequired();

            builder
                .HasMany(x => x.Skills)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ExperienceSkills",
                    j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    j => j.HasOne<Experience>().WithMany().HasForeignKey("ExperienceId"));
        }
    }
}
