using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloTaxa;

public class Taxa : EntidadeBase
{
    public Taxa(string nome, decimal preco, string planoCobranca)
    {
        Nome = nome;
        Preco = preco;
        PlanoCobranca = planoCobranca;
    }

    public string Nome { get; set; }
    
    public decimal Preco { get; set; }
    
    public string PlanoCobranca { get; set; }

    public Taxa()
    {
        
    }
    
    
}