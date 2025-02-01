using Minimal.Domain.Users.Repository;
using Minimal.Features.Users.Queries.Repository;
using Minimal.Infra.Data.Repositories;
using Minimal.Infra.Data.Repositories.Queries;

namespace Minimal.Api.Configurations;

public static class RepositoriesConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserQueryRepository, UserQueryRepository>();

        return services;
    }
}
