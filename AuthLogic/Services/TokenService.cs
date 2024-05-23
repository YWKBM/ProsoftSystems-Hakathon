using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AuthDB;
using Microsoft.IdentityModel.Tokens;

namespace AuthLogic.Services;

public class TokenService
{
    public const string ISSUER_USER = "user";
    public const string ISSUER_USER_REFRESH = "user-refresh";

    private readonly SigningCredentials credentials;
    private readonly AppDbContext db;

    public TokenService(AppDbContext db)
    {
        this.db = db;

        var ecda = ECDsa.Create();
        ecda.ImportECPrivateKey(Convert.FromBase64String(Configs.Config.JWT.PrivateKey), out _);
        var securityKey = new ECDsaSecurityKey(ecda);
        credentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256);
    }

    public string CreateUserAccessToken(AuthDB.Entities.User user, Guid jti)
    {
        var permissions = RoleHelper.GetPermissions(user.Role).Select(x => x.ToString()).ToArray();
        var expires = DateTimeOffset.UtcNow.AddMinutes(60);

        var header = new JwtHeader(credentials);
        var payload = new JwtPayload(ISSUER_USER, null, null, null, expires: expires.UtcDateTime)
        {
            { "id", user.Id },
            { "jti", jti },
            { "roles", permissions },
        };

        var token = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
