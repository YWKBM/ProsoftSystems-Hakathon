using System.Text;

namespace AuthLogic.Configs;

public class JWTConfig : BaseConfig
{
    public string PrivateKey { get; set; } = "erqwerqwerqwerqwerqwerqwerasdfbrgbktgbmkmlkmmlkmqqweqwelkmasdlkmasdlkm";

    public byte[] PrivetKeyBytes => Encoding.ASCII.GetBytes(Config.JWT.PrivateKey);

    public JWTConfig() 
    {
        Bind(this);
    }
}
