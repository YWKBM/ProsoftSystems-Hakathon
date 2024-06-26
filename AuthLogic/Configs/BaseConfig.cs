using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;


namespace AuthLogic.Configs;

public class BaseConfig
{
    public static void Bind<T>(T instance) where T : class
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        config.Bind(instance);

        var context = new ValidationContext(instance);
        Validator.ValidateObject(instance, context, true);
    }
}
