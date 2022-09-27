using FluentValidation;
using MatchDataManager.Application.Common.Behaviors;
using MatchDataManager.Application.Common.Exceptions.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchDataManager.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
