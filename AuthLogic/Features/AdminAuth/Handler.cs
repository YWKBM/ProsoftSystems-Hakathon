using AuthDB;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.;



namespace AuthLogic.Features.AdminAuth;

public class Handler
(
    AppDbContext db
) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        var admin = await db.Set<AuthDB.Entities.Admin>()
            .Where(m => m.Login == request.Login)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Ошибка авторизации");

        if (!verifyPassword(request.Password, admin.Password))
        {
            throw new Exception("Ошибка авторизации: логин или пароль неверный");
        }

        var jti = Guid.NewGuid();

        var accessToken = tokenService.CreateManagerAccessToken(manager, jti);
        var refreshToken = await tokenService.CreateManagerRefreshToken(manager.Id, jti);
        await addHistory(manager.Id, request.Ip, true);

        return new Result
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RequireCode = false,
            RequireCodeText = string.Empty,
        };
    }

    private static bool verifyPassword(string password, string hash)
    {
        return !string.IsNullOrWhiteSpace(hash)
            && !string.IsNullOrWhiteSpace(password)
            && BCrypt.Net.BCrypt.Verify(password, hash);
    }


}
