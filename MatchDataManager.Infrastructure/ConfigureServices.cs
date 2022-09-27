using MatchDataManager.Application.Common.Interfaces.Persistence;
using MatchDataManager.Application.Common.Interfaces.Persistence.Commands;
using MatchDataManager.Application.Common.Interfaces.Persistence.Queries;
using MatchDataManager.Infrastructure.Persistence;
using MatchDataManager.Infrastructure.Repositories.Commands;
using MatchDataManager.Infrastructure.Repositories.Queires;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchDataManager.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApplicationDbContext(configuration);

        #region Commands
        services.AddScoped<ILocationCommandsRepository, LocationCommandsRepository>();
        services.AddScoped<ITeamCommandsRepository, TeamCommandsRepository>();
        #endregion

        #region Queries
        services.AddScoped<ILocationQueriesRepository, LocationQueriesRepository>();
        services.AddScoped<ITeamQueriesRepository, TeamQueriesRepository>();
        #endregion

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        string connectionString = configuration
            .GetConnectionString("DefaultConnection")
            .Replace("{DirectoryDatabase}", configuration["DirectoryDatabase"]);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlite(connectionString,
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(
            provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        return services;
    }
}
