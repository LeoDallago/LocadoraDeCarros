using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloCliente;

namespace LocadoraDeCarros.Dominio.ModuloCondutor;

public class Condutor : EntidadeBase
{

    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string CPF { get; set; }
    
    public string CNH { get; set; }
    
    public DateTime Validade { get; set; }
    
    public int ClienteId { get; set; }
    
    public Cliente Cliente { get; set; }

    public Condutor()
    {
        
    }

    public Condutor(string nome, string email, string telefone, string cpf, string cnh, DateTime validade, Cliente cliente)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        CPF = cpf;
        CNH = cnh;
        Validade = validade;
        Cliente = cliente;
    }
    
    public Condutor(string nome, string email, string telefone, string cpf, string cnh, DateTime validade, int clienteId, Cliente cliente)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        CPF = cpf;
        CNH = cnh;
        Validade = validade;
        ClienteId = clienteId;
        Cliente = cliente;
    }
}
