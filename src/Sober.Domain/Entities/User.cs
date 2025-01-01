namespace Sober.Domain.Entities
{
    public record User
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;

        private User(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email, password);
            return user;                        
        }

        public User()
        {
        }
    }
}
