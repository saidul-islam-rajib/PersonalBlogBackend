using MediatR;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Pages.Users.Queries;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Pages.Users.QueryHandler
{
    public class GetDefaultUserQueryHandler : IRequestHandler<GetDefaultUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetDefaultUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetDefaultUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetDefaultUser();

            return response;
        }
    }
}
