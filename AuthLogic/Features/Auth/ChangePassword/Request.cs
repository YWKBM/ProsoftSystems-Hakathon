using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator;

namespace AuthLogic.Features.Auth.ChangePassword;

public class Request : IRequest
{
    public required int UserId { get; set; }

    public required string Password { get; set; }
}
