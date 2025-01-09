using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.SkillAggregate.ValueObjects
{
    public sealed class SkillId : ValueObject
    {
        public Guid Value { get; private set; }
        public SkillId(Guid value)
        {
            Value = value;
        }

        public static SkillId CreateUnique()
        {
            return new SkillId(Guid.NewGuid());
        }

        public static SkillId Create(Guid value)
        {
            return new SkillId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
