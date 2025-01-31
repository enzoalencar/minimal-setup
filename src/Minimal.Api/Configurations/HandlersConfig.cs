using Minimal.Features.Users.Commands;
using Minimal.Features.Users.Queries;

namespace Minimal.Api.Configurations;

public static class HandlersConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<CreateUser.Handler>()
            .AddScoped<ListUsers.Handler>();

        return services;
    }
}
