using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLogic.Configs;

public static class Config
{
    public readonly static PostgresConfig Postgres = new();

    public readonly static JWTConfig JWT = new();
}
