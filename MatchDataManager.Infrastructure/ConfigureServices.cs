using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Infrastructure.Repositories.Commands;
using MatchDataManager.Infrastructure.Repositories.Queires;
using Microsoft.Extensions.DependencyInjection;

namespace MatchDataManager.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ILocationCommandsRepository, LocationCommandsRepository>();
        services.AddScoped<ILocationQueriesRepository, LocationQueriesRepository>();

        return services;
    }
}
