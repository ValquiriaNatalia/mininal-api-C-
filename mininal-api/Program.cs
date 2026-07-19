using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mininal_api.Dominio.Entidades;
using mininal_api.Dominio.Interfaces;
using mininal_api.Dominio.ModelViews;
using mininal_api.Dominio.Servicos;
using mininal_api.Dto;
using mininal_api.Infraestutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")));
});

var app = builder.Build();
app.MapGet("/", () =>Results.Json(new Home()));


app.MapPost("/administradores/login", ([FromBody]LoginDto loginDto,IAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDto)!= null)
    {
        return Results.Ok("Login com sucesso ");
    }

    return Results.Unauthorized();
});
app.MapPost("/veiculos", ([ FromBody]VeiculoDto veiculoDto,IVeiculoServico veiculoServico) =>
{
    var veiculo = new Veiculo
    {
        Nome = veiculoDto.Nome,
        Marca = veiculoDto.Marca,
        Ano = veiculoDto.Ano, 
        
    };
    veiculoServico.Incluir(veiculo);
    return Results.Created($"/veiculo/{veiculo.Id}",veiculo);

});  



app.UseSwagger();
app.UseSwaggerUI();

app.Run();