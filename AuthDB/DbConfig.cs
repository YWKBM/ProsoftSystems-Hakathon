using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDB;

public class DBConfig
{
    public string ConnectionString { get; set; } = string.Empty;

    public DBConfig(string ConnectString)
    {
        this.ConnectionString = ConnectString;
    }
}