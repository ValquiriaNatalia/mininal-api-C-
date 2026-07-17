using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mininal_api.Dominio.Interfaces;
using mininal_api.Dominio.Servicos;
using mininal_api.Dto;
using mininal_api.Infraestutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

var app = builder.Build();


app.MapPost("/login", ([FromBody]LoginDto loginDto,IAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDto)!= null)
    {
        return Results.Ok("Login com sucesso ");
    }

    return Results.Unauthorized();
});

app.Run();