using Mediator;

namespace AuthLogic.Features.Auth.SignIn;

public record Request : IRequest<Result>
{
    public required string Login { get; set; }

    public required string Password { get; set; }
}