using AuthDB;
using Microsoft.Extensions.DependencyInjection;

namespace AuthLogic;

public static class LogicRegExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection services) 
    {
        services.AddDb(Configs.Config.Postgres.DATABASE);

        return services;
    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.InitDb();

        return serviceProvider;
    }

}
