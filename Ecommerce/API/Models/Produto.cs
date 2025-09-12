using System;

namespace API.Models;

//
public class Produto
{


    //Construtor
    public Produto()
    {
        id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    
    public string Nome { get; set; }
    public string id { get; set; }
    public int quantidade { get; set; }
    public double preco { get; set; }
    public DateTime CriadoEm { get; set; }

}


