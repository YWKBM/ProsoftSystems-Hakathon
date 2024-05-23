using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuthService.Controllers.DTO.SignUp;

public record Response
{
    [JsonPropertyName("acess_token")]
    public required string AccessToken { get; set; }
}
