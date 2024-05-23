using AuthDB;
using Mediator;
using Microsoft.EntityFrameworkCore;



namespace AuthLogic.Features.Auth.SignIn;

public class Handler
(
    AppDbContext db,
    Services.TokenService tokenService
) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = await db.Set<AuthDB.Entities.User>()
            .Where(m => m.Login == request.Login)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Ошибка авторизации");

        if (!verifyPassword(request.Password, user.Password))
        {
            throw new Exception("Ошибка авторизации: логин или пароль неверный");
        }

        var jti = Guid.NewGuid();

        var accessToken = tokenService.CreateUserAccessToken(user, jti);

        return new Result
        {
            AccessToken = accessToken,
        };
    }

    private static bool verifyPassword(string password, string hash)
    {
        return !string.IsNullOrWhiteSpace(hash)
            && !string.IsNullOrWhiteSpace(password)
            && BCrypt.Net.BCrypt.Verify(password, hash);
    }


}
