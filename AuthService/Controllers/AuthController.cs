using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;


namespace AuthService.Controllers;

[ApiController]
[Route("api/auth/[controller]")]
public class AuthController
(
    IMediator mediator,
    IMapper mapper,
    HttpContextAccessor httpContextAccessor
) : Controller
{
    [HttpPost]
    public async Task<DTO.SignUp.Response> Registration([FromBody]DTO.SignUp.Request request)
    {
        var result = await mediator.Send(mapper.Map<AuthLogic.Features.Auth.SignUp.Request>(request));
        return mapper.Map<DTO.SignUp.Response>(result);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<DTO.SignIn.Response> Login([FromBody]DTO.SignIn.Request request)
    {
        var result = await mediator.Send(mapper.Map<AuthLogic.Features.Auth.SignIn.Request>(request));
        return mapper.Map<DTO.SignIn.Response>(result);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
