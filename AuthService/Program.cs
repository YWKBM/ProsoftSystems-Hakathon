using AuthLogic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using AuthLogic.Configs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<HttpContextAccessor>();
builder.Services.AddLogic();
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
        }; 
    });


var app = builder.Build();
app.UseRouting();

app.Services.ConfigureLogic();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

