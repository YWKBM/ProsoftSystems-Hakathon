namespace AuthService.Controllers.DTO.SignIn;

public record  Request
{
    public required string Login { get; set; }

    public required string Password { get; set; }
}
