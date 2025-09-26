using API.Models;
using Microsoft.AspNetCore.Mvc;

//Console.Cear.();
var builder = WebApplication.CreateBuilder(args);

//Adicionar o serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();
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
// - Dados: rota (url) e corpo (opcional)


app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    //validar se existe alguma coisa dentro da lista
    if (ctx.Produtos.Count() == 0)
    {
        return Results.BadRequest("Nenhum produto cadastrado");
    }
    else
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    
});


//cADASTRAR pRODUTO
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto novoProduto,
[FromServices]AppDataContext ctx) =>
{

    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == novoProduto.Nome);
    if (resultado is not null)
    {
        return Results.Conflict("pRODUTO JÁ existente");
    }
    ctx.Produtos.Add(novoProduto);
    ctx.SaveChanges();
    return Results.Created("", novoProduto);
});

//remover produto pelo Id
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Produto? produtoRemover = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    if (produtoRemover == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    produtos.Remove(produtoRemover);
    return Results.Ok("Produto removido com sucesso");
});

//alterar produto pelo Id
app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado, [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    resultado.Nome = produtoAlterado.Nome;
    resultado.quantidade = produtoAlterado.quantidade;
    resultado.preco = produtoAlterado.preco;

    return Results.Ok(resultado);
});



//Buscar Produto pelo id
app.MapGet("/api/produto/buscar/{id}", ([FromRoute]string id, [FromServices] AppDataContext ctx) =>
{

    //Procura o produto na lista

    // foreach (Produto produtoCadastrado in produtos)
    // {
    //     if (produtoCadastrado.Nome == nome)
    //     {
    //         return Results.Ok(produtoCadastrado);
    //     }
    // }
    // return Results.NotFound("Produto não encontrado");


    //Expressão Lambda
    //Produto produtoEncontrado = produtos.FirstOrDefault(x => x.Nome.Contains(nome));
    Produto? produtoEncontrado = ctx.Produtos.Find(id);

    if (produtoEncontrado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    else
    {
        return Results.Ok(produtoEncontrado);
    }

});


app.Run();

AppDataContext ctx = new AppDataContext();

