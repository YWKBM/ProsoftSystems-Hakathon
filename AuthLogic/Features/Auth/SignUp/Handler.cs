using AuthDB;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace AuthLogic.Features.Auth.SignUp;

public class Handler
(
    AppDbContext db,
    Services.TokenService tokenService
) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        if (await db.Set<AuthDB.Entities.User>().Where(m => m.Login == request.Login)
        .FirstOrDefaultAsync(cancellationToken) is not null) 
        {
            throw new Exception("Пользователь уже зарегистрирован");
        }

        var user = new AuthDB.Entities.User
        {
            Login = request.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = AuthDB.Entities.Enums.RoleEnum.User,
        };

        db.Set<AuthDB.Entities.User>().Add(user);

        await db.SaveChangesAsync();

        var jti = Guid.NewGuid();

        var accessToken = tokenService.CreateUserAccessToken(user, jti);


        return new Result
        {
            AccessToken = accessToken
        };
    }
}
