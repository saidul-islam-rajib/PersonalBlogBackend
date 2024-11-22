using Microsoft.Extensions.DependencyInjection;
using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Common.Interfaces.Services;
using Sober.Infrastructure.Authentication;
using Sober.Infrastructure.Services;

namespace Sober.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
