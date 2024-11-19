using Microsoft.Extensions.DependencyInjection;
using Sober.Application.Services.Implementations;
using Sober.Application.Services.Interfaces;

namespace Sober.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            return services;
        }
    }
}
