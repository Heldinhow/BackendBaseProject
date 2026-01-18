using FluentResults;
using Microsoft.Extensions.DependencyInjection;

namespace BackendBaseProject.Infrastructure.Configuration;

public static class SetupCommand
{
    public static IServiceCollection AddCommandHandler<TInterface, TImplementation>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        services.AddScoped<TInterface, TImplementation>();
        return services;
    }

    public static IServiceCollection AddCommandHandler<TImplementation>(this IServiceCollection services)
        where TImplementation : class
    {
        services.AddScoped<TImplementation>();
        return services;
    }
}
