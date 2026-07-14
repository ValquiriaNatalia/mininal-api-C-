using mininal_api.Dto;

var builder = WebApplication.CreateBuilder(args);
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
