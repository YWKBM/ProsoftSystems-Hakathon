namespace AuthLogic.Configs;

public static class Config
{
    public readonly static PostgresConfig Postgres = new();

    public readonly static JWTConfig JWT = new();
}
