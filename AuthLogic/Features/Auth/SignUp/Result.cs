using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AuthLogic.Features.Auth.SignUp;

public record Result
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

}
