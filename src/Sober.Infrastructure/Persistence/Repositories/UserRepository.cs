using Sober.Application.Common.Interfaces.Persistence;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogDbContext _dbContext;

        public UserRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            //return _users.SingleOrDefault(x => x.Email == email);
            var response = _dbContext.Users.SingleOrDefault(x => x.Email == email);
            return response;
        }
    }
}
