using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            ConfigureSkillTable(builder);
        }

        private void ConfigureSkillTable(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("SkillId")
                .HasConversion(id => id.Value, value => SkillId.Create(value));
            builder.Property(x => x.SkillName).HasMaxLength(50);

        }
    }
}
