using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;
        public string Email { get; } = null!;
        public string Password { get; } = null!;

        private User(
            UserId userId,
            string firstName,
            string lastName,
            string email,
            string password) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            User user = new User(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password);
            return user;
        }

        public User()
        {
        }
    }
}
