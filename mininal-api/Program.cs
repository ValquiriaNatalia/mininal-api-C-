var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/teste", () =>
{
    return "teste";
});


app.Run();
