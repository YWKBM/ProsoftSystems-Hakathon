using System.Text;

namespace AuthLogic.Configs;

public class JWTConfig : BaseConfig
{
    public string PrivateKey { get; set; } = "secretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKey";
    
    public JWTConfig() 
    {
        Bind(this);
    }
}
