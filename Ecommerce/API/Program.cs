var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP

app.MapGet("/", () => "Minha primeira API");

app.MapGet("/funcionalidade", () => "Minha segunda API");
app.MapPost("/funcionalidade", () => "Funcionalidade com POST");

app.Run();
