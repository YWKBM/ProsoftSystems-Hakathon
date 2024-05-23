using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;


namespace AuthService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController
(
    IMediator mediator,
    HttpContextAccessor httpContextAccessor
) : Controller
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Registration([FromBody]DTO.SignUp.Request request)
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
    public async Task<ActionResult> Login([FromBody]DTO.SignIn.Request request)
    {
        //var result = await mediator.Send(mapper.Map<AuthLogic.Features.Auth.SignIn.Request>(request));

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
        var user = httpContextAccessor.HttpContext?.User;
        var value = user?.FindFirstValue("id");

        var query = new AuthLogic.Features.Auth.ChangePassword.Request
        {
            UserId = Convert.ToInt32(value),
            Password = request.Password,
        };


        await mediator.Send(query);

        return Ok();
    }
}
