using AuthLogic;
using AuthService.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogic();
builder.Services.AddControllers();
builder.Services.AddApiAuth();

var app = builder.Build();
app.Services.ConfigureLogic();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

