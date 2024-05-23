namespace AuthLogic.Features.AdminAuth;

public record Result
{
    public required string AccessToken { get; set; }

    public required string RefreshToker { get; set; }
}