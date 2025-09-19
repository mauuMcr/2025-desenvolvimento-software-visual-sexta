using API.Models;
using Microsoft.AspNetCore.Mvc;

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
// - Dados: rota (url) e corpo (opcional)

app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    //validar se existe alguma coisa dentro da lista
    if (produtos.Count == 0)
    {
        return Results.BadRequest("Nenhum produto cadastrado");
    }
    else
    {
        return Results.Ok(produtos);
    }
    
});

app.MapPost("/api/produto/cadastrar", ([FromBody] Produto novoProduto) =>
{

    foreach (var produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == novoProduto.Nome)
        {
            return Results.Conflict("Produto já cadastrado");
        }
    }
    produtos.Add(novoProduto);
    return Results.Created("", novoProduto);
});

//remover produto pelo Id
app.MapDelete("/api/produto/remover/{id}", ([FromRoute] string id) =>
{
    Produto? produtoRemover = produtos.FirstOrDefault(x => x.Id == id);
    if (produtoRemover == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    produtos.Remove(produtoRemover);
    return Results.Ok("Produto removido com sucesso");
});

//alterar produto pelo Id
app.MapPatch("/api/produto/alterar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    Produto? resultado = produtos.FirstOrDefault(x => x.Id == id);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    resultado.Nome = produtoAlterado.Nome;
    resultado.quantidade = produtoAlterado.quantidade;
    resultado.preco = produtoAlterado.preco;

    return Results.Ok(resultado);
});


app.MapGet("/api/produto/buscar/{nome}", ([FromRoute]string nome) =>
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
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome.Contains(nome));

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