using System;

namespace API.Models;

//
public class Produto
{


    //Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    
    public string Nome { get; set; }
    public string Id { get; internal set; }
    public int quantidade { get; set; }
    public double preco { get; set; }
    public DateTime CriadoEm { get; set; }

}


