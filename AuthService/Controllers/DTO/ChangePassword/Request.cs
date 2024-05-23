using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Controllers.DTO.ChangePassword;

public class Request
{
    public required string Password { get; set; }
}
