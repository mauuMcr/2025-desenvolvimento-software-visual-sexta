using API.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

    List<Produto> produtos = new List<Produto>
    {
        new Produto
        {
             Nome = "Notebook",
            quantidade = 10,
            preco = 4500.00
        },
        new Produto
        {
            Nome = "Mouse",
            quantidade = 50,
            preco = 79.90
        },
        new Produto
        {
            Nome = "Teclado Mecânico",
            quantidade = 30,
            preco = 250.00
        },
        new Produto
        {
            Nome = "Monitor 24\"",
            quantidade = 15,
            preco = 899.99
        },
        new Produto
        {
            Nome = "Cadeira Gamer",
            quantidade = 5,
            preco = 1200.00
        }
    };


//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP

app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{

    produtos.Add(produto);

});

app.Run();


Produto produto = new Produto();
produto.Nome = "Bolacha";

Console.WriteLine(produto.Nome);