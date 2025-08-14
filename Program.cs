using minimal_api.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Minimal API em C#");

app.MapPost("/login", (LoginDTO loginDTO) => 
{
    if (loginDTO.Username == "admin@teste.com" &&
        loginDTO.Password == "12345678")
    {
        return Results.Ok("Login successful");
    }else
    {
        return Results.Unauthorized();
    }
});

app.Run();