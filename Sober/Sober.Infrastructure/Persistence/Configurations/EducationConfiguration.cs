using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
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
                .HasConversion(id => id.Value, value => EducationId.Create(value))
                .ValueGeneratedNever().HasColumnName("EducationId");


            builder.Property(x => x.InstituteName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.InstituteLogo).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Department).HasMaxLength(200).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired(false);

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
                    j => j.HasOne<Education>().WithMany().HasForeignKey("EducationId"));
        }
    }
}
