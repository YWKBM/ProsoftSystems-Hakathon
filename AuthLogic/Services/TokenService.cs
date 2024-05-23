using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthDB;
using AuthLogic.Configs;
using Microsoft.IdentityModel.Tokens;

namespace AuthLogic.Services;

public class TokenService
{
    public const string ISSUER_USER = "user";
    private readonly SigningCredentials credentials;

    public TokenService()
    {
        byte[] bytes = Encoding.ASCII.GetBytes(Config.JWT.PrivateKey);
        credentials = new SigningCredentials(
            new SymmetricSecurityKey(bytes),
            SecurityAlgorithms.HmacSha256Signature);
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
