namespace AuthLogic.Configs;

public class PostgresConfig
{
    public string DATABASE_HOST { get; set; } = "localhost";

    public string DATABASE_USER { get; set; } = string.Empty;

    public string DATABASE_PASS { get; set; } = string.Empty;

    public string DATABASE_NAME { get; set; } = string.Empty;

    public string DATABASE => $"Host=localhost:5432;Database=Hakathon;Username=postgres;Password=0591;Timezone=0";


    public PostgresConfig()
    {
        BaseConfig.Bind(this);
    }

}
