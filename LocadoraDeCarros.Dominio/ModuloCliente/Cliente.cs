using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloCliente;

public class Cliente : EntidadeBase
{
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string Estado { get; set; }
    
    public string Cidade { get; set; }
    
    public string Bairro { get; set; }
    
    public string Rua { get; set; }
    
    public string Numero { get; set; }
    
    public string TipoCliente { get; set; }

    public Cliente()
    {
        
    }
    
    public Cliente(string nome, string email, string telefone, string estado, string cidade, string bairro, string rua, string numero, string tipoCliente)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Estado = estado;
        Cidade = cidade;
        Bairro = bairro;
        Rua = rua;
        Numero = numero;
        TipoCliente = tipoCliente;
    }
    
}