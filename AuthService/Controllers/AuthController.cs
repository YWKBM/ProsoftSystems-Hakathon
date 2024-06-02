using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mediator;

namespace AuthService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController
(
    IMediator mediator
) : Controller
{
    [HttpPost]
    public async Task<ActionResult> SignUp([FromBody]DTO.SignUp.Request request)
    {
        var query = new AuthLogic.Features.Auth.SignUp.Request
        {
            Login = request.Login,
            Password = request.Password
        };
        var result = await mediator.Send(query);

        var resp = new DTO.SignUp.Response
        {
            AccessToken = result.AccessToken
        };

        return Ok(resp);
    }

    [HttpPost]
    public async Task<ActionResult> SignIn([FromBody]DTO.SignIn.Request request)
    {
        var query = new AuthLogic.Features.Auth.SignIn.Request
        {
            Login = request.Login,
            Password = request.Password
        };
        var result = await mediator.Send(query);

        var resp =  new DTO.SignIn.Response
        {
            AcessToken = result.AccessToken
        };

        return Ok(resp);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Change([FromBody]DTO.SignIn.Request request)
    {
        var user = HttpContext.User.Claims;

        string userId = string.Empty;

        if (user != null) 
        {
            var userIdClaim = user
                .Where(m => m.Type == "id")
                .FirstOrDefault()
                ?? throw new Exception("Unauthorized");

            userId = userIdClaim.Value;
        }

        var query = new AuthLogic.Features.Auth.ChangePassword.Request
        {
            UserId = Convert.ToInt32(userId),
            Password = request.Password,
        };

        await mediator.Send(query);

        return Ok();
    }
}
