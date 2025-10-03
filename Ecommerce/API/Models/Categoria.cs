using System;

namespace API.Models;

public class Categoria
{

    public string Nome { get; set; } = string.Empty;

    public int CategoriaId { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.Now;

}

