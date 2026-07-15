using Microsoft.EntityFrameworkCore;
using mininal_api.Dto;
using mininal_api.Infraestutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

var app = builder.Build();


app.MapPost("/login", (LoginDto loginDto) =>
{
    if (loginDto.Email == "Valquirianatalia@gmail.com" && loginDto.Senha == "123456")
    {
        return Results.Ok("Login com sucesso ");
    }

    return Results.Unauthorized();
});

app.Run();