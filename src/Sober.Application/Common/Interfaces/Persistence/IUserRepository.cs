using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
