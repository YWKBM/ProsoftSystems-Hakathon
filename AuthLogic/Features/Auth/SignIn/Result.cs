namespace AuthLogic.Features.Auth.SignIn;

public record Result
{
    public required string AccessToken { get; set; }

}