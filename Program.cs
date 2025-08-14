using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Infraestrutura.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))));

var app = builder.Build();

app.MapGet("/", () => "Minimal API em C#");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico AdministradorServico) => 
{
    if (AdministradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login successful");
    }else
    {
        return Results.Unauthorized();
    }
});

app.Run();