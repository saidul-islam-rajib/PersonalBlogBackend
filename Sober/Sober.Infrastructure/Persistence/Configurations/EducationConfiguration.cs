using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            ConfigureEducationTable(builder);
        }

        private void ConfigureEducationTable(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => EducationId.Create(value));

            builder.Property(x => x.InstituteName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.InstituteLogo)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(x => x.Department)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired(false);

            builder.Property(x => x.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value))
                .IsRequired();

            // Configure the many-to-many relationship
            builder
                .HasMany(x => x.Skills)
                .WithMany(x => x.Educations)
                .UsingEntity<Dictionary<string, object>>(
                    "EducationSkills",
                    j => j
                        .HasOne<Skill>()
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Education>()
                        .WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.ToTable("EducationSkills");
                        j.HasKey("EducationId", "SkillId");
                    });
        }
    }
}
