using Mediator;

namespace AuthLogic.Features.Auth.SignUp;

public record Request : IRequest<Result>
{
    public required string Login { get; set; }

    public required string Password { get; set; }
}