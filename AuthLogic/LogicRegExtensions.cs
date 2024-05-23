using AuthDB;
using Microsoft.Extensions.DependencyInjection;

namespace AuthLogic;

public static class LogicRegExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection services) 
    {
        services.AddDb(Configs.Config.Postgres.DATABASE);
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddScoped<Services.TokenService>();

        return services;
    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.InitDb();

        return serviceProvider;
    }

}
