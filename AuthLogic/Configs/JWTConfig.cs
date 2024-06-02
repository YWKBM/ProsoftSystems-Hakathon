using System.Text;

namespace AuthLogic.Configs;

public class JWTConfig : BaseConfig
{
    public string PrivateKey { get; set; } = string.Empty;
    
    public JWTConfig() 
    {
        Bind(this);
    }
}
